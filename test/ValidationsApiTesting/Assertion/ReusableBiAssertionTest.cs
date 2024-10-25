// ------------------------------------------------------------------------------------------
//  <copyright file = "ReusableBiAssertionTest.cs" company = "ANEXIA® Internetdienstleistungs GmbH">
//  Copyright (c) ANEXIA® Internetdienstleistungs GmbH. All rights reserved.
//  </copyright>
// ------------------------------------------------------------------------------------------

#region
using System;
#endregion

namespace Anexia.Validation.ApiTesting.Assertion;

public sealed class ReusableBiAssertionTest
{
    private static readonly IReusableBiAssertion<int, int> _assertion = new ReusableBiAssertion<int, int>(
        (first, second) => first > 0 && second > 0,
        (first, second) =>
            throw new ArgumentException($"Both values must be greater than 0, but were {first} and {second}"));

    [Fact]
    public void AssertDoesNotThrowExceptionForBooleanSupplierReturningTrue() => _assertion.Assert(3, 2);

    [Fact]
    public void AssertThrowsExceptionForBooleanSupplierReturningFalseBecauseOfFirstValue()
    {
        Assert.Throws<ArgumentException>(() => _assertion.Assert(0, 1));
    }

    [Fact]
    public void AssertThrowsExceptionForBooleanSupplierReturningFalseBecauseOfSecondValue()
    {
        Assert.Throws<ArgumentException>(() => _assertion.Assert(2, 0));
    }
}