// --------------------------------------------------------------------------------------------
//  <copyright file = "ParallelContinuousBiAssertionTest.cs" company = "ANEXIA® Internetdienstleistungs GmbH">
//  Copyright (c) ANEXIA® Internetdienstleistungs GmbH.All rights reserved.
//  </copyright>
// --------------------------------------------------------------------------------------------

#region
using System;
using System.Threading.Tasks;
using ANX.Common.Validation.Api.Assert.Parallel;
using ANX.Common.Validation.ApiTesting.TestData;
using Xunit;
#endregion

namespace ANX.Common.Validation.ApiTesting.Assert.Parallel;

public sealed class ParallelContinuousBiAssertionTest
{
    private readonly ParallelContinuousBiAssertion<int> _assertion = new(
        (argOne, argTwo) => argOne < argTwo,
        (argOne, argTwo) => new AggregateException($"{argOne} is not smaller than {argTwo}"));

    [Theory]
    [MemberData(
        nameof(ParallelBiAssertionTestData.GetErraticTestList),
        MemberType = typeof(ParallelBiAssertionTestData))]
    public async Task ThrowsException(int[] integerList)
    {
        await Xunit.Assert.ThrowsAsync<AggregateException>(async () => await _assertion.AssertAsync(integerList));
    }

    [Theory]
    [MemberData(
        nameof(ParallelBiAssertionTestData.GetFirstNumberSmallerTestList),
        MemberType = typeof(ParallelBiAssertionTestData))]
    public async Task ValidatesSuccessfully(int[] integerList)
    {
        await _assertion.AssertAsync(integerList);
    }
}