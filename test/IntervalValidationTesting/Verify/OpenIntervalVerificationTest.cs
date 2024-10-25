// ------------------------------------------------------------------------------------------
//  <copyright file = "OpenIntervalVerificationTest.cs" company = "ANEXIA® Internetdienstleistungs GmbH">
//  Copyright (c) ANEXIA® Internetdienstleistungs GmbH. All rights reserved.
//  </copyright>
// ------------------------------------------------------------------------------------------

#region
using Anexia.Validation.Interval.Exception;
using Anexia.Validation.Interval.Open;
using Anexia.Validation.Interval.Verify;
#endregion

namespace Anexia.Validation.IntervalTesting.Verify;

public sealed class OpenIntervalVerificationTest
{
    private static readonly IntervalVerification<int> _verification = new(new OpenInterval<int>(-5, 5));

    [Theory]
    [InlineData(-4)]
    [InlineData(0)]
    [InlineData(2)]
    [InlineData(4)]
    public void VerifyReturnsValueForValidValues(int value) => Assert.Equal(value, _verification.Verify(value));

    [Theory]
    [InlineData(-6)]
    [InlineData(-5)]
    [InlineData(5)]
    [InlineData(6)]
    public void VerifyThrowsExceptionForInValidValues(int value)
    {
        Assert.Throws<ValueOutOfIntervalException<int>>(() => _verification.Verify(value));
    }
}