// --------------------------------------------------------------------------------------------
//  <copyright file = "IntervalFactory.cs" company = "ANEXIA® Internetdienstleistungs GmbH">
//  Copyright (c) ANEXIA® Internetdienstleistungs GmbH.All rights reserved.
//  </copyright>
// --------------------------------------------------------------------------------------------

#region

using ANX.Common.Validation.Interval.Closed;
using ANX.Common.Validation.Interval.Open;
using ANX.Common.Validation.Interval.Verify;

#endregion

namespace ANX.Common.Validation.Interval.Common;

public static class IntervalFactory {
    public static IntervalVerification<T> Closed<T>(T lowerBound, T upperBound) where T : IComparable<T> =>
        new(new ClosedInterval<T>(lowerBound, upperBound));

    public static IntervalVerification<T> Closed<T>(
        T lowerBound,
        T upperBound,
        Func<T, System.Exception> exceptionSupplier) where T : IComparable<T> =>
        new(new ClosedInterval<T>(lowerBound, upperBound), exceptionSupplier);

    public static IntervalVerification<T> Open<T>(T lowerBound, T upperBound) where T : IComparable<T> =>
        new(new OpenInterval<T>(lowerBound, upperBound));

    public static IntervalVerification<T> Open<T>(
        T lowerBound,
        T upperBound,
        Func<T, System.Exception> exceptionSupplier) where T : IComparable<T> =>
        new(new OpenInterval<T>(lowerBound, upperBound), exceptionSupplier);

    public static IntervalVerification<T> LeftOpenRightClosed<T>(T lowerBound, T upperBound) where T : IComparable<T> =>
        new(new LeftOpenRightClosedInterval<T>(lowerBound, upperBound));

    public static IntervalVerification<T> LeftOpenRightClosed<T>(
        T lowerBound,
        T upperBound,
        Func<T, System.Exception> exceptionSupplier) where T : IComparable<T> =>
        new(new LeftOpenRightClosedInterval<T>(lowerBound, upperBound), exceptionSupplier);

    public static IntervalVerification<T> LeftClosedRightOpen<T>(T lowerBound, T upperBound) where T : IComparable<T> =>
        new(new LeftClosedRightOpenInterval<T>(lowerBound, upperBound));

    public static IntervalVerification<T> LeftClosedRightOpen<T>(
        T lowerBound,
        T upperBound,
        Func<T, System.Exception> exceptionSupplier) where T : IComparable<T> =>
        new(new LeftClosedRightOpenInterval<T>(lowerBound, upperBound), exceptionSupplier);
}