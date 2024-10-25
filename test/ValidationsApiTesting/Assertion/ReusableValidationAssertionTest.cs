// ------------------------------------------------------------------------------------------
//  <copyright file = "ReusableValidationAssertionTest.cs" company = "ANEXIA® Internetdienstleistungs GmbH">
//  Copyright (c) ANEXIA® Internetdienstleistungs GmbH. All rights reserved.
//  </copyright>
// ------------------------------------------------------------------------------------------

#region
using System;
#endregion

namespace Anexia.Validation.ApiTesting.Assertion;

public sealed class ReusableValidationAssertionTest
{
    private static readonly ReusableValidationAssertion<uint> _assertion = new(
        new PositiveReusableUintValidation(),
        value => throw new ArgumentException($"Value {value} is not positive"));

    [Fact]
    public void AssertDoesNotThrowExceptionForBooleanSupplierReturningTrue() => _assertion.Assert(1);

    [Fact]
    public void AssertThrowsExceptionForBooleanSupplierReturningFalse()
    {
        Assert.Throws<ArgumentException>(() => _assertion.Assert(0));
    }
}
internal sealed class PositiveReusableUintValidation : IReusableValidation<uint>
{
    public bool IsValid(uint value) => value > 0;
}