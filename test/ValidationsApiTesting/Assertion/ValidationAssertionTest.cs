// ------------------------------------------------------------------------------------------
//  <copyright file = "ValidationAssertionTest.cs" company = "ANEXIA® Internetdienstleistungs GmbH">
//  Copyright (c) ANEXIA® Internetdienstleistungs GmbH. All rights reserved.
//  </copyright>
// ------------------------------------------------------------------------------------------

#region
using System;
#endregion

namespace Anexia.Validation.ApiTesting.Assertion;

public sealed class ValidationAssertionTest
{
    [Fact]
    public void AssertDoesNotThrowExceptionForBooleanSupplierReturningTrue() =>
        new ValidationAssertion(
            new PositiveUintValidation(1),
            () => throw new ArgumentException("Value is not positive")).Assert();

    [Fact]
    public void AssertThrowsExceptionForBooleanSupplierReturningFalse()
    {
        var assertion = new ValidationAssertion(
            new PositiveUintValidation(0),
            () => throw new ArgumentException("Value is not positive"));

        _ = Assert.Throws<ArgumentException>(() => assertion.Assert());
    }

    [Fact]
    public void StaticAssertDoesNotThrowExceptionForBooleanSupplierReturningTrue() =>
        ValidationAssertion.Assert(
            new PositiveUintValidation(1),
            () => throw new ArgumentException("Value is not positive"));

    [Fact]
    public void StaticAssertThrowsExceptionForBooleanSupplierReturningFalse() =>
        Assert.Throws<ArgumentException>(
            () => ValidationAssertion.Assert(
                new PositiveUintValidation(0),
                () => throw new ArgumentException("Value is not positive")));
}
internal sealed class PositiveUintValidation : IValidation
{
    public PositiveUintValidation(uint value)
    {
        Value = value;
    }

    private readonly uint Value;

    public bool IsValid() => Value > 0;
}