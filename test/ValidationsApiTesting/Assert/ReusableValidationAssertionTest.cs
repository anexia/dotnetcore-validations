// ------------------------------------------------------------------------------------------
//  <copyright file = "ReusableValidationAssertionTest.cs" company = "ANEXIA® Internetdienstleistungs GmbH">
//  Copyright (c) ANEXIA® Internetdienstleistungs GmbH. All rights reserved.
//  </copyright>
// ------------------------------------------------------------------------------------------

#region
using System;
using ANX.Common.Validation.Api.Assert;
using ANX.Common.Validation.Api.Validate;
using Xunit;
#endregion

namespace ANX.Common.Validation.ApiTesting.Assert;

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
        var exception = Xunit.Assert.Throws<ArgumentException>(() => _assertion.Assert(0));

        Xunit.Assert.Equal("Value 0 is not positive", exception.Message);
    }
}
internal sealed class PositiveReusableUintValidation : IReusableValidation<uint>
{
    public bool IsValid(uint value) => value > 0;
}