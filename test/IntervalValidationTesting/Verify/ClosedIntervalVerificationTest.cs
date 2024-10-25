// ------------------------------------------------------------------------------------------
//  <copyright file = "ClosedIntervalVerificationTest.cs" company = "ANEXIA® Internetdienstleistungs GmbH">
//  Copyright (c) ANEXIA® Internetdienstleistungs GmbH. All rights reserved.
//  </copyright>
// ------------------------------------------------------------------------------------------

#region
using ANX.Common.Validation.Interval.Common;
using ANX.Common.Validation.Interval.Exception;
using ANX.Common.Validation.Interval.Verify;
using Xunit;
using static Xunit.Assert;
#endregion

namespace ANX.Common.Validation.IntervalTesting.Verify;

public sealed class ClosedIntervalVerificationTest
{
    private readonly IntervalVerification<int> _verification = IntervalFactory.Closed(-5, 5);

    [Theory]
    [InlineData(-5)]
    [InlineData(0)]
    [InlineData(5)]
    public void VerifyReturnsValueForValidValues(int value) => Equal(value, _verification.Verify(value));

    [Theory]
    [InlineData(-6)]
    [InlineData(6)]
    public void VerifyThrowsExceptionForInValidValues(int value)
    {
        var exception = Throws<ValueOutOfIntervalException<int>>(() => _verification.Verify(value));

        Equal($"Value {value} is not in interval [-5,5].", exception.Message);
    }
}