// ------------------------------------------------------------------------------------------
//  <copyright file = "ValidationAssertion.cs" company = "ANEXIA® Internetdienstleistungs GmbH">
//  Copyright (c) ANEXIA® Internetdienstleistungs GmbH. All rights reserved.
//  </copyright>
// ------------------------------------------------------------------------------------------

#region
using Anexia.Validation.Api.CustomInterface;
using Anexia.Validation.Api.Validate;
#endregion

namespace Anexia.Validation.Api.Assert;

public sealed class ValidationAssertion : IAssertion
{
    private readonly Func<Exception> _exceptionSupplier;
    private readonly IValidation _validation;

    public ValidationAssertion(IValidation validation, Func<Exception> exceptionSupplier)
    {
        _validation = validation;
        _exceptionSupplier = exceptionSupplier;
    }

    public void Assert()
    {
        if(!_validation.IsValid()) throw _exceptionSupplier.Invoke();
    }

    public static void Assert(IValidation validation, Func<Exception> exceptionSupplier) =>
        new ValidationAssertion(validation, exceptionSupplier).Assert();
}