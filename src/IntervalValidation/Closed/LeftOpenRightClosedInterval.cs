// ------------------------------------------------------------------------------------------
//  <copyright file = "LeftOpenRightClosedInterval.cs" company = "ANEXIA® Internetdienstleistungs GmbH">
//  Copyright (c) ANEXIA® Internetdienstleistungs GmbH. All rights reserved.
//  </copyright>
// ------------------------------------------------------------------------------------------

#region
using Anexia.Validation.Interval.Common;
using Equ;
#endregion

namespace Anexia.Validation.Interval.Closed;

public sealed class LeftOpenRightClosedInterval<T> : MemberwiseEquatable<LeftOpenRightClosedInterval<T>>, IInterval<T>
    where T : IComparable<T>
{
    private readonly IntervalBase<T> _intervalBase;

    private LeftOpenRightClosedInterval(IntervalBase<T> intervalBase)
    {
        _intervalBase = intervalBase;
    }

    public LeftOpenRightClosedInterval(T lowerBound, T upperBound)
        : this(new IntervalBase<T>(lowerBound, upperBound))
    { }

    public bool Contains(T value) =>
        _intervalBase.LowerBoundLessThan(value) && _intervalBase.UpperBoundGreaterThanOrEqualTo(value);

    public static bool operator ==(LeftOpenRightClosedInterval<T> left, LeftOpenRightClosedInterval<T> right) =>
        Equals(left, right);

    public static bool operator !=(LeftOpenRightClosedInterval<T> left, LeftOpenRightClosedInterval<T> right) =>
        !Equals(left, right);

    public override string ToString() => $"({_intervalBase}]";
}