// ------------------------------------------------------------------------------------------
//  <copyright file = "TestConfiguration.cs" company = "ANEXIA® Internetdienstleistungs GmbH">
//  Copyright (c) ANEXIA® Internetdienstleistungs GmbH. All rights reserved.
//  </copyright>
// ------------------------------------------------------------------------------------------

#region
using ANX.Common.Validation.Interval.Verify;
#endregion

namespace ANX.Common.Validation.IntervalTesting.Verify.Data;

public sealed class TestConfiguration
{
    private TestConfiguration(IntervalVerification<int> intervalVerification, int expectedValue)
    {
        ExpectedValue = expectedValue;
        IntervalVerification = intervalVerification;
    }

    public int ExpectedValue { get; }
    private IntervalVerification<int> IntervalVerification { get; }
    public int ActualValue => IntervalVerification.Verify(ExpectedValue);

    public static TestConfiguration Create(IntervalVerification<int> intervalVerification, int value) =>
        new(intervalVerification, value);
}