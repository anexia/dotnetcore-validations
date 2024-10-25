// ------------------------------------------------------------------------------------------
//  <copyright file = "ReusableValidationAssertion.cs" company = "ANEXIA® Internetdienstleistungs GmbH">
//  Copyright (c) ANEXIA® Internetdienstleistungs GmbH. All rights reserved.
//  </copyright>
// ------------------------------------------------------------------------------------------

#region
using ANX.Common.Validation.Api.CustomInterface;
using ANX.Common.Validation.Api.Validate;
#endregion

namespace ANX.Common.Validation.Api.Assert;

public sealed class ReusableValidationAssertion<T> : IReusableAssertion<T>
{
    private readonly Func<T, Exception> _exceptionSupplier;
    private readonly IReusableValidation<T> _validation;

    public ReusableValidationAssertion(IReusableValidation<T> validation, Func<T, Exception> exceptionSupplier)
    {
        _validation = validation;
        _exceptionSupplier = exceptionSupplier;
    }

    public void Assert(T value)
    {
        if(!_validation.IsValid(value)) throw _exceptionSupplier.Invoke(value);
    }
}