// ------------------------------------------------------------------------------------------
//  <copyright file = "ReusableTriAssertion.cs" company = "ANEXIA® Internetdienstleistungs GmbH">
//  Copyright (c) ANEXIA® Internetdienstleistungs GmbH. All rights reserved.
//  </copyright>
// ------------------------------------------------------------------------------------------

#region
using Anexia.Validation.Api.CustomInterface;
#endregion

namespace Anexia.Validation.Api.Assert;

public sealed class ReusableTriAssertion<TFirst, TSecond, TThird> : IReusableTriAssertion<TFirst, TSecond, TThird>
{
    public ReusableTriAssertion(
        Func<TFirst, TSecond, TThird, bool> predicate,
        Func<TFirst, TSecond, TThird, Exception> exceptionSupplier)
    {
        Predicate = predicate;
        ExceptionSupplier = exceptionSupplier;
    }

    private readonly Func<TFirst, TSecond, TThird, bool> Predicate;
    private readonly Func<TFirst, TSecond, TThird, Exception> ExceptionSupplier;

    public void Assert(TFirst first, TSecond second, TThird third)
    {
        if(!Predicate.Invoke(first, second, third)) throw ExceptionSupplier.Invoke(first, second, third);
    }
}