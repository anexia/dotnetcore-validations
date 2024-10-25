// ------------------------------------------------------------------------------------------
//  <copyright file = "LeftClosedRightOpenIntervalVerificationTest.cs" company = "ANEXIA® Internetdienstleistungs GmbH">
//  Copyright (c) ANEXIA® Internetdienstleistungs GmbH. All rights reserved.
//  </copyright>
// ------------------------------------------------------------------------------------------

#region
using ANX.Common.Validation.Interval.Closed;
using ANX.Common.Validation.Interval.Common;
using ANX.Common.Validation.Interval.Exception;
using ANX.Common.Validation.Interval.Verify;
using Xunit;
#endregion

namespace ANX.Common.Validation.IntervalTesting.Verify;

public sealed class LeftClosedRightOpenIntervalVerificationTest
{
    private static readonly IInterval<int> _interval = new LeftClosedRightOpenInterval<int>(-5, 5);
    private static readonly IntervalVerification<int> _verification = new(_interval);

    [Theory]
    [InlineData(-5)]
    [InlineData(0)]
    [InlineData(2)]
    [InlineData(4)]
    public void VerifyReturnsValueForValidValues(int value) => Assert.Equal(value, _verification.Verify(value));

    [Theory]
    [InlineData(-6)]
    [InlineData(5)]
    [InlineData(6)]
    public void VerifyThrowsExceptionForInValidValues(int value)
    {
        var exception = Assert.Throws<ValueOutOfIntervalException<int>>(() => _verification.Verify(value));

        Assert.Equal($"Value {value} is not in interval [-5,5).", exception.Message);
    }
}