// ------------------------------------------------------------------------------------------
//  <copyright file = "LeftOpenRightClosedIntervalTest.cs" company = "ANEXIA® Internetdienstleistungs GmbH">
//  Copyright (c) ANEXIA® Internetdienstleistungs GmbH. All rights reserved.
//  </copyright>
// ------------------------------------------------------------------------------------------

#region
using Anexia.Validation.Interval.Closed;
using static Xunit.Assert;
#endregion

namespace Anexia.Validation.IntervalTesting.Closed;

public sealed class LeftOpenRightClosedIntervalTest
{
    private static readonly LeftOpenRightClosedInterval<int> _interval = new(-5, 5);

    [Theory]
    [InlineData(-6, false)]
    [InlineData(-5, false)]
    [InlineData(0, true)]
    [InlineData(5, true)]
    [InlineData(6, false)]
    public void ContainsReturnsCorrectResult(int value, bool expectedResult) =>
        Equal(expectedResult, _interval.Contains(value));
}