// ------------------------------------------------------------------------------------------
//  <copyright file = "ReusableBiValidationAssertion.cs" company = "ANEXIA® Internetdienstleistungs GmbH">
//  Copyright (c) ANEXIA® Internetdienstleistungs GmbH. All rights reserved.
//  </copyright>
// ------------------------------------------------------------------------------------------

#region
using ANX.Common.Validation.Api.CustomInterface;
using ANX.Common.Validation.Api.Validate;
#endregion

namespace ANX.Common.Validation.Api.Assert;

public sealed class ReusableBiValidationAssertion<TFirst, TSecond> : IReusableBiAssertion<TFirst, TSecond>
{
    public ReusableBiValidationAssertion(
        IReusableBiValidation<TFirst, TSecond> validation,
        Func<TFirst, TSecond, Exception> exceptionSupplier)
    {
        Validation = validation;
        ExceptionSupplier = exceptionSupplier;
    }

    private IReusableBiValidation<TFirst, TSecond> Validation { get; }
    private Func<TFirst, TSecond, Exception> ExceptionSupplier { get; }

    public void Assert(TFirst first, TSecond second)
    {
        if(!Validation.IsValid(first, second)) throw ExceptionSupplier.Invoke(first, second);
    }
}