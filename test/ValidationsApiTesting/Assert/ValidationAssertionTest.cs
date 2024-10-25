// --------------------------------------------------------------------------------------------
//  <copyright file = "ValidationAssertionTest.cs" company = "ANEXIA® Internetdienstleistungs GmbH">
//  Copyright (c) ANEXIA® Internetdienstleistungs GmbH.All rights reserved.
//  </copyright>
// --------------------------------------------------------------------------------------------

#region

using System;
using ANX.Common.Validation.Api.Assert;
using ANX.Common.Validation.Api.Validate;
using Xunit;

#endregion

namespace ANX.Common.Validation.ApiTesting.Assert;

public sealed class ValidationAssertionTest {
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

        _ = Xunit.Assert.Throws<ArgumentException>(() => assertion.Assert());
    }

    [Fact]
    public void StaticAssertDoesNotThrowExceptionForBooleanSupplierReturningTrue() =>
        ValidationAssertion.Assert(
            new PositiveUintValidation(1),
            () => throw new ArgumentException("Value is not positive"));

    [Fact]
    public void StaticAssertThrowsExceptionForBooleanSupplierReturningFalse() =>
        Xunit.Assert.Throws<ArgumentException>(
            () => ValidationAssertion.Assert(
                new PositiveUintValidation(0),
                () => throw new ArgumentException("Value is not positive")));
}

internal sealed class PositiveUintValidation : IValidation {
    public PositiveUintValidation(uint value)
    {
        Value = value;
    }

    private uint Value { get; }

    public bool IsValid() => Value > 0;
}