// --------------------------------------------------------------------------------------------
//  <copyright file = "ReusableAssertion.cs" company = "ANEXIA® Internetdienstleistungs GmbH">
//  Copyright (c) ANEXIA® Internetdienstleistungs GmbH.All rights reserved.
//  </copyright>
// --------------------------------------------------------------------------------------------

namespace ANX.Common.Validation.Api.Assert;

public sealed class ReusableAssertion<T> : IReusableAssertion<T> {
    private readonly Func<T, Exception> _exceptionSupplier;
    private readonly Func<T, bool> _predicate;

    public ReusableAssertion(Func<T, bool> predicate, Func<T, Exception> exceptionSupplier)
    {
        _predicate = predicate;
        _exceptionSupplier = exceptionSupplier;
    }

    public void Assert(T value)
    {
        if(!_predicate.Invoke(value)) throw _exceptionSupplier.Invoke(value);
    }
}