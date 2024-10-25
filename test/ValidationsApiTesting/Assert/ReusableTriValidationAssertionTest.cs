// --------------------------------------------------------------------------------------------
//  <copyright file = "ReusableTriValidationAssertionTest.cs" company = "ANEXIA® Internetdienstleistungs GmbH">
//  Copyright (c) ANEXIA® Internetdienstleistungs GmbH.All rights reserved.
//  </copyright>
// --------------------------------------------------------------------------------------------

#region

using System;
using ANX.Common.Validation.Api.Assert;
using ANX.Common.Validation.Api.Validate;
using Xunit;
using static Xunit.Assert;

#endregion

namespace ANX.Common.Validation.ApiTesting.Assert;

public sealed class ReusableTriValidationAssertionTest {
    private static readonly FirstAndSecondGreaterThanThirdReusableValidation _validation = new();

    private static readonly ReusableTriValidationAssertion<uint, uint, uint> _assertion = new(
        _validation,
        (first, second, third) => throw new ArgumentException(
            $"First value {first} + second value {second} must be greater than third value {third}."));

    [Fact]
    public void AssertDoesNotThrowExceptionForBooleanSupplierReturningTrue() => _assertion.Assert(4, 2, 3);

    [Fact]
    public void AssertThrowsExceptionForBooleanSupplierReturningFalse()
    {
        var exception = Throws<ArgumentException>(() => _assertion.Assert(1, 3, 5));

        Equal("First value 1 + second value 3 must be greater than third value 5.", exception.Message);
    }
}

internal sealed class FirstAndSecondGreaterThanThirdReusableValidation : IReusableTriValidation<uint, uint, uint> {
    public bool IsValid(uint first, uint second, uint third) => first + second > third;
}