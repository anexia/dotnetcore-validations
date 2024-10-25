// ------------------------------------------------------------------------------------------
//  <copyright file = "IntervalVerificationExceptionData.cs" company = "ANEXIA® Internetdienstleistungs GmbH">
//  Copyright (c) ANEXIA® Internetdienstleistungs GmbH. All rights reserved.
//  </copyright>
// ------------------------------------------------------------------------------------------

#region
using System;
using System.Collections;
using System.Collections.Generic;
using ANX.Common.Validation.Interval.Common;
using Equ;
using static ANX.Common.Validation.Interval.Common.IntervalFactory;
using static ANX.Common.Validation.IntervalTesting.Verify.Data.ExceptionTestConfiguration;
#endregion

namespace ANX.Common.Validation.IntervalTesting.Verify.Data;

public sealed class IntervalVerificationExceptionData
    : MemberwiseEquatable<IntervalVerificationExceptionData>, IEnumerable<object[]>
{
    private const int LOWER_BOUND = 2;
    private const int UPPER_BOUND = 10;

    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[]
        {
            Create(() => IntervalFactory.Closed(LOWER_BOUND, UPPER_BOUND).Verify(1), Message(1, false, false))
        };

        yield return new object[]
        {
            Create(
                () => IntervalFactory.Closed(LOWER_BOUND, UPPER_BOUND, ExceptionFunction(1, false, false)).Verify(1),
                Message(1, false, false),
                typeof(Exception))
        };

        yield return new object[]
        {
            Create(() => LeftClosedRightOpen(LOWER_BOUND, UPPER_BOUND).Verify(10), Message(10, false))
        };

        yield return new object[]
        {
            Create(
                () => LeftClosedRightOpen(LOWER_BOUND, UPPER_BOUND, ExceptionFunction(10, false)).Verify(10),
                Message(10, false),
                typeof(Exception))
        };

        yield return new object[]
        {
            Create(() => LeftOpenRightClosed(LOWER_BOUND, UPPER_BOUND).Verify(2), Message(2, true, false))
        };

        yield return new object[]
        {
            Create(
                () => LeftOpenRightClosed(LOWER_BOUND, UPPER_BOUND, ExceptionFunction(2, true, false)).Verify(2),
                Message(2, true, false),
                typeof(Exception))
        };

        yield return new object[]
        {
            Create(() => IntervalFactory.Open(LOWER_BOUND, UPPER_BOUND).Verify(10), Message(10))
        };

        yield return new object[]
        {
            Create(
                () => IntervalFactory.Open(LOWER_BOUND, UPPER_BOUND, ExceptionFunction(10)).Verify(10),
                Message(10),
                typeof(Exception))
        };
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    private static Func<int, Exception> ExceptionFunction(int value, bool leftOpen = true, bool rightOpen = true) =>
        _ => new Exception(Message(value, leftOpen, rightOpen));

    private static string Message(int value, bool leftOpen = true, bool rightOpen = true) =>
        $"Value {value} is not in interval {(leftOpen ? "(" : "[")}{LOWER_BOUND},{UPPER_BOUND}{(rightOpen ? ")" : "]")}.";
}