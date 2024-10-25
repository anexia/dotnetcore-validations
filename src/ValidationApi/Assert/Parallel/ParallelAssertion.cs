// --------------------------------------------------------------------------------------------
//  <copyright file = "ParallelAssertion.cs" company = "ANEXIA® Internetdienstleistungs GmbH">
//  Copyright (c) ANEXIA® Internetdienstleistungs GmbH.All rights reserved.
//  </copyright>
// --------------------------------------------------------------------------------------------

using System.Threading.Tasks.Dataflow;
using ANX.Common.Validation.Api.CustomInterface;

namespace ANX.Common.Validation.Api.Assert.Parallel;

public sealed class ParallelAssertion<T> : IAsyncReusableAssertion<T>
{
    private readonly Func<T, Exception> _exceptionSupplier;
    private readonly Func<T, bool> _predicate;
    private readonly ExecutionDataflowBlockOptions? _executionDataflowBlockOptions;

    public ParallelAssertion(
        Func<T, bool> predicate,
        Func<T, Exception> exceptionSupplier,
        ExecutionDataflowBlockOptions? executionDataflowBlockOptions = null)
    {
        _predicate = predicate;
        _exceptionSupplier = exceptionSupplier;
        _executionDataflowBlockOptions = executionDataflowBlockOptions;
    }

    public async Task AssertAsync(IEnumerable<T> values)
    {
        var counter = 0;
        var validationTransformBlock = CreateTransformBlock();

        foreach(var value in values)
        {
            _ = validationTransformBlock.Post(value);
            counter++;
        }

        validationTransformBlock.Complete();

        for(var i = 0; i < counter; i++)
        {
            var (value, valid) = await validationTransformBlock.ReceiveAsync();
            if(!valid) throw _exceptionSupplier.Invoke(value);
        }
    }

    private TransformBlock<T, (T, bool)> CreateTransformBlock()
    {
        var executionDataflowBlockOptions = _executionDataflowBlockOptions ?? new ExecutionDataflowBlockOptions
            { MaxDegreeOfParallelism = Environment.ProcessorCount };

        return new TransformBlock<T, (T, bool)>(arg => (arg, _predicate(arg)), executionDataflowBlockOptions);
    }
}