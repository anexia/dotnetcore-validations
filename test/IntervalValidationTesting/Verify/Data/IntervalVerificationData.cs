// ------------------------------------------------------------------------------------------
//  <copyright file = "IntervalVerificationData.cs" company = "ANEXIA® Internetdienstleistungs GmbH">
//  Copyright (c) ANEXIA® Internetdienstleistungs GmbH. All rights reserved.
//  </copyright>
// ------------------------------------------------------------------------------------------

#region
using System.Collections;
using System.Collections.Generic;
using Anexia.Validation.Interval.Common;
using Equ;
using static Anexia.Validation.Interval.Common.IntervalFactory;
using static Anexia.Validation.IntervalTesting.Verify.Data.TestConfiguration;
#endregion

namespace Anexia.Validation.IntervalTesting.Verify.Data;

public sealed class IntervalVerificationData : MemberwiseEquatable<IntervalVerificationData>, IEnumerable<object[]>
{
    private const int LOWER_BOUND = 2;
    private const int UPPER_BOUND = 10;

    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[] { Create(IntervalFactory.Closed(LOWER_BOUND, UPPER_BOUND), 2) };

        yield return new object[] { Create(IntervalFactory.Closed(LOWER_BOUND, UPPER_BOUND), 10) };

        yield return new object[] { Create(LeftClosedRightOpen(LOWER_BOUND, UPPER_BOUND), 2) };

        yield return new object[] { Create(LeftClosedRightOpen(LOWER_BOUND, UPPER_BOUND), 9) };

        yield return new object[] { Create(LeftOpenRightClosed(LOWER_BOUND, UPPER_BOUND), 3) };

        yield return new object[] { Create(LeftOpenRightClosed(LOWER_BOUND, UPPER_BOUND), 10) };

        yield return new object[] { Create(IntervalFactory.Open(LOWER_BOUND, UPPER_BOUND), 3) };

        yield return new object[] { Create(IntervalFactory.Open(LOWER_BOUND, UPPER_BOUND), 9) };
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}