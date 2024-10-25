// --------------------------------------------------------------------------------------------
//  <copyright file = "ReusableBiAssertionTest.cs" company = "ANEXIA® Internetdienstleistungs GmbH">
//  Copyright (c) ANEXIA® Internetdienstleistungs GmbH.All rights reserved.
//  </copyright>
// --------------------------------------------------------------------------------------------

#region

using System;
using ANX.Common.Validation.Api.Assert;
using ANX.Common.Validation.Api.CustomInterface;
using Xunit;

#endregion

namespace ANX.Common.Validation.ApiTesting.Assert;

public sealed class ReusableBiAssertionTest {
    private static readonly IReusableBiAssertion<int, int> _assertion = new ReusableBiAssertion<int, int>(
        (first, second) => first > 0 && second > 0,
        (first, second) =>
            throw new ArgumentException($"Both values must be greater than 0, but were {first} and {second}"));

    [Fact]
    public void AssertDoesNotThrowExceptionForBooleanSupplierReturningTrue() => _assertion.Assert(3, 2);

    [Fact]
    public void AssertThrowsExceptionForBooleanSupplierReturningFalseBecauseOfFirstValue()
    {
        var exception = Xunit.Assert.Throws<ArgumentException>(() => _assertion.Assert(0, 1));

        Xunit.Assert.Equal("Both values must be greater than 0, but were 0 and 1", exception.Message);
    }

    [Fact]
    public void AssertThrowsExceptionForBooleanSupplierReturningFalseBecauseOfSecondValue()
    {
        var exception = Xunit.Assert.Throws<ArgumentException>(() => _assertion.Assert(2, 0));

        Xunit.Assert.Equal("Both values must be greater than 0, but were 2 and 0", exception.Message);
    }
}