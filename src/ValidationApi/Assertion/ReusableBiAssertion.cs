// ------------------------------------------------------------------------------------------
//  <copyright file = "ReusableBiAssertion.cs" company = "ANEXIA® Internetdienstleistungs GmbH">
//  Copyright (c) ANEXIA® Internetdienstleistungs GmbH. All rights reserved.
//  </copyright>
// ------------------------------------------------------------------------------------------

#region
using Anexia.Validation.Api.CustomInterface;
#endregion

namespace Anexia.Validation.Api.Assert;

public sealed class ReusableBiAssertion<TFirst, TSecond> : IReusableBiAssertion<TFirst, TSecond>
{
    public ReusableBiAssertion(
        Func<TFirst, TSecond, bool> predicate,
        Func<TFirst, TSecond, Exception> exceptionSupplier)
    {
        Predicate = predicate;
        ExceptionSupplier = exceptionSupplier;
    }

    private readonly Func<TFirst, TSecond, bool> Predicate;
    private readonly Func<TFirst, TSecond, Exception> ExceptionSupplier;

    public void Assert(TFirst first, TSecond second)
    {
        if(!Predicate.Invoke(first, second)) throw ExceptionSupplier.Invoke(first, second);
    }
}