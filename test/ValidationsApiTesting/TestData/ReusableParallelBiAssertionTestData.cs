// ------------------------------------------------------------------------------------------
//  <copyright file = "ReusableParallelBiAssertionTestData.cs" company = "ANEXIA® Internetdienstleistungs GmbH">
//  Copyright (c) ANEXIA® Internetdienstleistungs GmbH. All rights reserved.
//  </copyright>
// ------------------------------------------------------------------------------------------

#region
using System;
using Xunit;
#endregion

namespace ANX.Common.Validation.ApiTesting.TestData;

public static class ParallelBiAssertionTestData
{
    public static TheoryData<int[]> GetErraticTestList()
    {
        var value = new int[10000];
        var random = new Random();

        for(var i = 0; i < 10000 - 2; i++)
        {
            value[i] = random.Next();
        }

        //just making the test odds free
        value[10000 - 2] = 10;
        value[10000 - 1] = 9;

        return new TheoryData<int[]>
        {
            value
        };
    }

    public static TheoryData<int[]> GetFirstNumberSmallerTestList()
    {
        var value = new int[10000];

        for(var i = 0; i < 10000; i++)
        {
            value[i] = i;
        }

        return new TheoryData<int[]>
        {
            value
        };
    }
}