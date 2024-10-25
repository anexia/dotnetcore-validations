// ------------------------------------------------------------------------------------------
//  <copyright file = "ReusableAssertionTest.cs" company = "ANEXIA® Internetdienstleistungs GmbH">
//  Copyright (c) ANEXIA® Internetdienstleistungs GmbH. All rights reserved.
//  </copyright>
// ------------------------------------------------------------------------------------------

#region
using System;
using ANX.Common.Validation.Api.Assert;
using Xunit;
#endregion

namespace ANX.Common.Validation.ApiTesting.Assert;

public sealed class ReusableAssertionTest
{
    private static readonly ReusableAssertion<int> _assertion = new(
        value => value > 0,
        value => throw new ArgumentException($"Value {value} must be greater than 0."));

    [Fact]
    public void AssertDoesNotThrowExceptionForBooleanSupplierReturningTrue() => _assertion.Assert(1);

    [Fact]
    public void AssertThrowsExceptionForBooleanSupplierReturningFalse()
    {
        var exception = Xunit.Assert.Throws<ArgumentException>(() => _assertion.Assert(0));

        Xunit.Assert.Equal("Value 0 must be greater than 0.", exception.Message);
    }
}