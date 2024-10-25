// --------------------------------------------------------------------------------------------
//  <copyright file = "ReusableTriAssertion.cs" company = "ANEXIA® Internetdienstleistungs GmbH">
//  Copyright (c) ANEXIA® Internetdienstleistungs GmbH.All rights reserved.
//  </copyright>
// --------------------------------------------------------------------------------------------

namespace ANX.Common.Validation.Api.Assert;

public sealed class ReusableTriAssertion<TFirst, TSecond, TThird> : IReusableTriAssertion<TFirst, TSecond, TThird> {
    public ReusableTriAssertion(
        Func<TFirst, TSecond, TThird, bool> predicate,
        Func<TFirst, TSecond, TThird, Exception> exceptionSupplier)
    {
        Predicate = predicate;
        ExceptionSupplier = exceptionSupplier;
    }

    private Func<TFirst, TSecond, TThird, bool> Predicate { get; }
    private Func<TFirst, TSecond, TThird, Exception> ExceptionSupplier { get; }

    public void Assert(TFirst first, TSecond second, TThird third)
    {
        if(!Predicate.Invoke(first, second, third)) throw ExceptionSupplier.Invoke(first, second, third);
    }
}