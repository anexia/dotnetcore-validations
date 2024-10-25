// ------------------------------------------------------------------------------------------
//  <copyright file = "ReusableParallelAssertionTestData.cs" company = "ANEXIA® Internetdienstleistungs GmbH">
//  Copyright (c) ANEXIA® Internetdienstleistungs GmbH. All rights reserved.
//  </copyright>
// ------------------------------------------------------------------------------------------

#region
using System;
using System.Collections.Generic;
using Xunit;
#endregion

namespace ANX.Common.Validation.ApiTesting.TestData;

public static class ParallelAssertionTestData
{
    public static TheoryData<int[]> GetErraticTestList()
    {
        var value = new int[10000];
        var random = new Random();

        for(var i = 0; i < 10000; i++)
        {
            value[i] = random.Next();
        }

        return new TheoryData<int[]>
        {
            value
        };
    }

    public static TheoryData<int[]> GetDivisibleByTwoTestList()
    {
        var value = new List<int>(5000);
        var random = new Random();

        for(var i = 0; i < 10000; i++)
        {
            var number = random.Next();
            if(number % 2 == 0) value.Add(number);
        }

        return new TheoryData<int[]>
        {
            value.ToArray()
        };
    }
}