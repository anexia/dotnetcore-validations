// --------------------------------------------------------------------------------------------
//  <copyright file = "ReusableTriAssertionTest.cs" company = "ANEXIA® Internetdienstleistungs GmbH">
//  Copyright (c) ANEXIA® Internetdienstleistungs GmbH.All rights reserved.
//  </copyright>
// --------------------------------------------------------------------------------------------

#region

using System;
using ANX.Common.Validation.Api.Assert;
using Xunit;

#endregion

namespace ANX.Common.Validation.ApiTesting.Assert;

public sealed class ReusableTriAssertionTest {
    private static readonly IReusableTriAssertion<int, int, int> _assertion = new ReusableTriAssertion<int, int, int>(
        (first, second, third) => first + second > third,
        (_, _, third) => throw new ArgumentException($"Sum of first and second value must be greater than {third}."));

    [Fact]
    public void AssertDoesNotThrowExceptionForBooleanSupplierReturningTrue() => _assertion.Assert(4, 3, 5);

    [Fact]
    public void AssertThrowsExceptionForBooleanSupplierReturningFalse()
    {
        var exception = Xunit.Assert.Throws<ArgumentException>(() => _assertion.Assert(2, 3, 6));

        Xunit.Assert.Equal("Sum of first and second value must be greater than 6.", exception.Message);
    }
}