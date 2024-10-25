// ------------------------------------------------------------------------------------------
//  <copyright file = "IntervalBaseTest.cs" company = "ANEXIA® Internetdienstleistungs GmbH">
//  Copyright (c) ANEXIA® Internetdienstleistungs GmbH. All rights reserved.
//  </copyright>
// ------------------------------------------------------------------------------------------

#region
using ANX.Common.Validation.Interval.Common;
using ANX.Common.Validation.Interval.Exception;
using Xunit;
#endregion

namespace ANX.Common.Validation.IntervalTesting.Common;

public sealed class IntervalBaseTest
{
    private static readonly IntervalBase<uint> _intervalBase = new(2, 12);

    [Theory]
    [InlineData(1, false)]
    [InlineData(2, true)]
    [InlineData(5, true)]
    [InlineData(12, true)]
    [InlineData(13, true)]
    public void IsLowerBoundLessThanOrEqualToReturnsCorrectValue(uint value, bool expectedResult) =>
        Assert.Equal(expectedResult, _intervalBase.LowerBoundLessThanOrEqualTo(value));

    [Theory]
    [InlineData(1, false)]
    [InlineData(2, false)]
    [InlineData(5, true)]
    [InlineData(12, true)]
    [InlineData(13, true)]
    public void IsLowerBoundLessThanReturnsCorrectValue(uint value, bool expectedResult) =>
        Assert.Equal(expectedResult, _intervalBase.LowerBoundLessThan(value));

    [Theory]
    [InlineData(1, false)]
    [InlineData(2, true)]
    [InlineData(5, false)]
    public void IsLowerBoundEqualToReturnsCorrectValue(uint value, bool expectedResult) =>
        Assert.Equal(expectedResult, _intervalBase.LowerBoundEqualTo(value));

    [Theory]
    [InlineData(1, true)]
    [InlineData(2, true)]
    [InlineData(5, false)]
    [InlineData(12, false)]
    [InlineData(13, false)]
    public void IsLowerBoundGreaterThanOrEqualToReturnsCorrectValue(uint value, bool expectedResult) =>
        Assert.Equal(expectedResult, _intervalBase.LowerBoundGreaterThanOrEqualTo(value));

    [Theory]
    [InlineData(1, true)]
    [InlineData(2, false)]
    [InlineData(5, false)]
    [InlineData(12, false)]
    [InlineData(13, false)]
    public void IsLowerBoundGreaterThanReturnsCorrectValue(uint value, bool expectedResult) =>
        Assert.Equal(expectedResult, _intervalBase.LowerBoundGreaterThan(value));

    [Theory]
    [InlineData(1, false)]
    [InlineData(2, false)]
    [InlineData(5, false)]
    [InlineData(12, true)]
    [InlineData(13, true)]
    public void IsUpperBoundLessThanOrEqualToReturnsCorrectValue(uint value, bool expectedResult) =>
        Assert.Equal(expectedResult, _intervalBase.UpperBoundLessThanOrEqualTo(value));

    [Theory]
    [InlineData(1, false)]
    [InlineData(2, false)]
    [InlineData(5, false)]
    [InlineData(12, false)]
    [InlineData(13, true)]
    public void IsUpperBoundLessThanReturnsCorrectValue(uint value, bool expectedResult) =>
        Assert.Equal(expectedResult, _intervalBase.UpperBoundLessThan(value));

    [Theory]
    [InlineData(1, false)]
    [InlineData(2, false)]
    [InlineData(5, false)]
    [InlineData(12, true)]
    [InlineData(13, false)]
    public void IsUpperBoundEqualToReturnsCorrectValue(uint value, bool expectedResult) =>
        Assert.Equal(expectedResult, _intervalBase.UpperBoundEqualTo(value));

    [Theory]
    [InlineData(1, true)]
    [InlineData(2, true)]
    [InlineData(5, true)]
    [InlineData(12, true)]
    [InlineData(13, false)]
    public void IsUpperBoundGreaterThanOrEqualToReturnsCorrectValue(uint value, bool expectedResult) =>
        Assert.Equal(expectedResult, _intervalBase.UpperBoundGreaterThanOrEqualTo(value));

    [Theory]
    [InlineData(1, true)]
    [InlineData(2, true)]
    [InlineData(5, true)]
    [InlineData(12, false)]
    [InlineData(13, false)]
    public void IsUpperBoundGreaterThanReturnsCorrectValue(uint value, bool expectedResult) =>
        Assert.Equal(expectedResult, _intervalBase.UpperBoundGreaterThan(value));

    [Fact]
    public void IntervalBaseWithLowerBoundGreaterThanUpperBoundThrowsException()
    {
        var exception = Assert.Throws<IllegalIntervalException>(() => new IntervalBase<uint>(21, 10));

        Assert.Equal(
            "Lower bound of interval must be less than or equal to upper bound 10, but was 21.",
            exception.Message);
    }
}