// --------------------------------------------------------------------------------------------
//  <copyright file = "ReusableBiAssertion.cs" company = "ANEXIA® Internetdienstleistungs GmbH">
//  Copyright (c) ANEXIA® Internetdienstleistungs GmbH.All rights reserved.
//  </copyright>
// --------------------------------------------------------------------------------------------

using ANX.Common.Validation.Api.CustomInterface;

namespace ANX.Common.Validation.Api.Assert;

public sealed class ReusableBiAssertion<TFirst, TSecond> : IReusableBiAssertion<TFirst, TSecond> {
    public ReusableBiAssertion(
        Func<TFirst, TSecond, bool> predicate,
        Func<TFirst, TSecond, Exception> exceptionSupplier)
    {
        Predicate = predicate;
        ExceptionSupplier = exceptionSupplier;
    }

    private Func<TFirst, TSecond, bool> Predicate { get; }
    private Func<TFirst, TSecond, Exception> ExceptionSupplier { get; }

    public void Assert(TFirst first, TSecond second)
    {
        if(!Predicate.Invoke(first, second)) throw ExceptionSupplier.Invoke(first, second);
    }
}