// ------------------------------------------------------------------------------------------
//  <copyright file = "ReusableBiValidationAssertionTest.cs" company = "ANEXIA® Internetdienstleistungs GmbH">
//  Copyright (c) ANEXIA® Internetdienstleistungs GmbH. All rights reserved.
//  </copyright>
// ------------------------------------------------------------------------------------------

#region
using System;
using static Xunit.Assert;
#endregion

namespace Anexia.Validation.ApiTesting.Assertion;

public sealed class ReusableBiValidationAssertionTest
{
    private static readonly FirstValueGreaterThanSecondReusableValidation _validation = new();

    private static readonly ReusableBiValidationAssertion<uint, uint> _assertion = new(
        _validation,
        (first, second) =>
            throw new ArgumentException($"First value {first} must be greater than second value {second}."));

    [Fact]
    public void AssertDoesNotThrowExceptionForBooleanSupplierReturningTrue() => _assertion.Assert(4, 2);

    [Fact]
    public void AssertThrowsExceptionForBooleanSupplierReturningFalse()
    {
        var exception = Throws<ArgumentException>(() => _assertion.Assert(1, 3));

        Equal("First value 1 must be greater than second value 3.", exception.Message);
    }
}
internal sealed class FirstValueGreaterThanSecondReusableValidation : IReusableBiValidation<uint, uint>
{
    public bool IsValid(uint first, uint second) => first > second;
}