// ------------------------------------------------------------------------------------------
//  <copyright file = "ReusableBiValidationAssertion.cs" company = "ANEXIA® Internetdienstleistungs GmbH">
//  Copyright (c) ANEXIA® Internetdienstleistungs GmbH. All rights reserved.
//  </copyright>
// ------------------------------------------------------------------------------------------

#region
using Anexia.Validation.Api.CustomInterface;
using Anexia.Validation.Api.Validate;
#endregion

namespace Anexia.Validation.Api.Assert;

public sealed class ReusableBiValidationAssertion<TFirst, TSecond> : IReusableBiAssertion<TFirst, TSecond>
{
    public ReusableBiValidationAssertion(
        IReusableBiValidation<TFirst, TSecond> validation,
        Func<TFirst, TSecond, Exception> exceptionSupplier)
    {
        Validation = validation;
        ExceptionSupplier = exceptionSupplier;
    }

    private readonly IReusableBiValidation<TFirst, TSecond> Validation;
    private readonly Func<TFirst, TSecond, Exception> ExceptionSupplier;

    public void Assert(TFirst first, TSecond second)
    {
        if(!Validation.IsValid(first, second)) throw ExceptionSupplier.Invoke(first, second);
    }
}