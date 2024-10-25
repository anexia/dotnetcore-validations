// ------------------------------------------------------------------------------------------
//  <copyright file = "ParallelAssertionTest.cs" company = "ANEXIA® Internetdienstleistungs GmbH">
//  Copyright (c) ANEXIA® Internetdienstleistungs GmbH. All rights reserved.
//  </copyright>
// ------------------------------------------------------------------------------------------

#region
using System;
using System.Threading.Tasks;
using ANX.Common.Validation.Api.Assert.Parallel;
using ANX.Common.Validation.ApiTesting.TestData;
using Xunit;
#endregion

namespace ANX.Common.Validation.ApiTesting.Assert.Parallel;

public sealed class ParallelAssertionTest
{
    private readonly ParallelAssertion<int> _assertion = new(
        i => i % 2 == 0,
        i => new AggregateException($"Not dividable by 2: \"{i}\""));

    [Theory]
    [MemberData(nameof(ParallelAssertionTestData.GetErraticTestList), MemberType = typeof(ParallelAssertionTestData))]
    public async Task ThrowsException(int[] integerList)
    {
        await Xunit.Assert.ThrowsAsync<AggregateException>(async () => await _assertion.AssertAsync(integerList));
    }

    [Theory]
    [MemberData(
        nameof(ParallelAssertionTestData.GetDivisibleByTwoTestList),
        MemberType = typeof(ParallelAssertionTestData))]
    public async Task ValidatesSuccessfully(int[] integerList)
    {
        await _assertion.AssertAsync(integerList);
    }
}