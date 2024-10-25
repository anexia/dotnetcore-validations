// ------------------------------------------------------------------------------------------
//  <copyright file = "TestConfiguration.cs" company = "ANEXIA® Internetdienstleistungs GmbH">
//  Copyright (c) ANEXIA® Internetdienstleistungs GmbH. All rights reserved.
//  </copyright>
// ------------------------------------------------------------------------------------------

#region
using Anexia.Validation.Interval.Verify;
#endregion

namespace Anexia.Validation.IntervalTesting.Verify.Data;

public sealed class TestConfiguration
{
    private readonly IntervalVerification<int> IntervalVerification;
    private TestConfiguration(IntervalVerification<int> intervalVerification, int expectedValue)
    {
        ExpectedValue = expectedValue;
        IntervalVerification = intervalVerification;
    }

    public int ExpectedValue { get; }
    public int ActualValue => IntervalVerification.Verify(ExpectedValue);

    public static TestConfiguration Create(IntervalVerification<int> intervalVerification, int value) =>
        new(intervalVerification, value);
}