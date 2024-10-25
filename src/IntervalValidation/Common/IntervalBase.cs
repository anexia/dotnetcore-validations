// --------------------------------------------------------------------------------------------
//  <copyright file = "IntervalBase.cs" company = "ANEXIA® Internetdienstleistungs GmbH">
//  Copyright (c) ANEXIA® Internetdienstleistungs GmbH.All rights reserved.
//  </copyright>
// --------------------------------------------------------------------------------------------

#region

using ANX.Common.Validation.Api.Assert;
using ANX.Common.Validation.Interval.Exception;
using Equ;

#endregion

namespace ANX.Common.Validation.Interval.Common;

public sealed class IntervalBase<T> : MemberwiseEquatable<IntervalBase<T>> where T : IComparable<T> {
    private static readonly ReusableBiAssertion<T, T> _validIntervalAssertion = new(
        (lower, upper) => lower.CompareTo(upper) <= 0,
        (lower, upper) => new IllegalIntervalException(lower, upper));

    private readonly T _lowerBound;
    private readonly T _upperBound;

    public IntervalBase(T lowerBound, T upperBound)
    {
        _lowerBound = lowerBound;
        _upperBound = upperBound;

        _validIntervalAssertion.Assert(lowerBound, upperBound);
    }

    public bool LowerBoundLessThanOrEqualTo(T value) => _lowerBound.CompareTo(value) <= 0;

    public bool LowerBoundLessThan(T value) => _lowerBound.CompareTo(value) < 0;

    public bool LowerBoundGreaterThanOrEqualTo(T value) => _lowerBound.CompareTo(value) >= 0;

    public bool LowerBoundGreaterThan(T value) => _lowerBound.CompareTo(value) > 0;

    public bool LowerBoundEqualTo(T value) => _lowerBound.CompareTo(value) == 0;

    public bool UpperBoundLessThanOrEqualTo(T value) => _upperBound.CompareTo(value) <= 0;

    public bool UpperBoundLessThan(T value) => _upperBound.CompareTo(value) < 0;

    public bool UpperBoundGreaterThanOrEqualTo(T value) => _upperBound.CompareTo(value) >= 0;

    public bool UpperBoundGreaterThan(T value) => _upperBound.CompareTo(value) > 0;

    public bool UpperBoundEqualTo(T value) => _upperBound.CompareTo(value) == 0;

    public override string ToString() => $"{_lowerBound},{_upperBound}";

    public static bool operator ==(IntervalBase<T> left, IntervalBase<T> right) => Equals(left, right);

    public static bool operator !=(IntervalBase<T> left, IntervalBase<T> right) => !Equals(left, right);
}