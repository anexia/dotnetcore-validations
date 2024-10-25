// ------------------------------------------------------------------------------------------
//  <copyright file = "LeftClosedRightOpenInterval.cs" company = "ANEXIA® Internetdienstleistungs GmbH">
//  Copyright (c) ANEXIA® Internetdienstleistungs GmbH. All rights reserved.
//  </copyright>
// ------------------------------------------------------------------------------------------

#region
using Anexia.Validation.Interval.Common;
using Equ;
#endregion

namespace Anexia.Validation.Interval.Closed;

public sealed class LeftClosedRightOpenInterval<T> : MemberwiseEquatable<LeftClosedRightOpenInterval<T>>, IInterval<T>
    where T : IComparable<T>
{
    private readonly IntervalBase<T> _intervalBase;

    private LeftClosedRightOpenInterval(IntervalBase<T> intervalBase)
    {
        _intervalBase = intervalBase;
    }

    public LeftClosedRightOpenInterval(T lowerBound, T upperBound)
        : this(new IntervalBase<T>(lowerBound, upperBound))
    { }

    public bool Contains(T value) =>
        _intervalBase.LowerBoundLessThanOrEqualTo(value) && _intervalBase.UpperBoundGreaterThan(value);

    public static bool operator ==(LeftClosedRightOpenInterval<T> left, LeftClosedRightOpenInterval<T> right) =>
        Equals(left, right);

    public static bool operator !=(LeftClosedRightOpenInterval<T> left, LeftClosedRightOpenInterval<T> right) =>
        !Equals(left, right);

    public override string ToString() => $"[{_intervalBase})";
}