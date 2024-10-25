// ------------------------------------------------------------------------------------------
//  <copyright file = "Assertion.cs" company = "ANEXIA® Internetdienstleistungs GmbH">
//  Copyright (c) ANEXIA® Internetdienstleistungs GmbH. All rights reserved.
//  </copyright>
// ------------------------------------------------------------------------------------------

#region
using Anexia.Validation.Api.CustomInterface;
#endregion

namespace Anexia.Validation.Api.Assert;

public sealed class Assertion : IAssertion
{
    private readonly Func<bool> _booleanSupplier;
    private readonly Func<Exception> _exceptionSupplier;

    public Assertion(Func<bool> booleanSupplier, Func<Exception> exceptionSupplier)
    {
        _booleanSupplier = booleanSupplier;
        _exceptionSupplier = exceptionSupplier;
    }

    public void Assert()
    {
        if(!_booleanSupplier.Invoke()) throw _exceptionSupplier.Invoke();
    }

    public static void Assert(Func<bool> booleanSupplier, Func<Exception> exceptionSupplier) =>
        new Assertion(booleanSupplier, exceptionSupplier).Assert();
}