// ------------------------------------------------------------------------------------------
//  <copyright file = "ParallelContinuousBiAssertion.cs" company = "ANEXIA® Internetdienstleistungs GmbH">
//  Copyright (c) ANEXIA® Internetdienstleistungs GmbH. All rights reserved.
//  </copyright>
// ------------------------------------------------------------------------------------------

#region
using System.Threading.Tasks.Dataflow;
using ANX.Common.Validation.Api.CustomInterface;
using ANX.Common.Validation.Api.Extension;
#endregion

namespace ANX.Common.Validation.Api.Assert.Parallel;

public sealed class ParallelContinuousBiAssertion<T> : IAsyncReusableAssertion<T>
{
    private readonly Func<T, T, Exception> _exceptionSupplier;
    private readonly Func<T, T, bool> _predicate;
    private readonly ExecutionDataflowBlockOptions? _executionDataflowBlockOptions;

    public ParallelContinuousBiAssertion(
        Func<T, T, bool> predicate,
        Func<T, T, Exception> exceptionSupplier,
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

        foreach(var (valueOne, valueTwo) in values.ToArray().PairAssert())
        {
            _ = validationTransformBlock.Post((valueOne, valueTwo));
            counter++;
        }

        validationTransformBlock.Complete();

        for(var i = 0; i < counter; i++)
        {
            var (valueOne, valueTwo, valid) = await validationTransformBlock.ReceiveAsync();

            if(!valid) throw _exceptionSupplier.Invoke(valueOne, valueTwo);
        }
    }

    private TransformBlock<(T, T), (T, T, bool)> CreateTransformBlock()
    {
        var executionDataflowBlockOptions = _executionDataflowBlockOptions ?? new ExecutionDataflowBlockOptions
            { MaxDegreeOfParallelism = Environment.ProcessorCount };

        return new TransformBlock<(T, T), (T, T, bool)>(
            arg => (arg.Item1, arg.Item2, _predicate(arg.Item1, arg.Item2)),
            executionDataflowBlockOptions);
    }
}