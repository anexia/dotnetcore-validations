// ------------------------------------------------------------------------------------------
//  <copyright file = "ClosedInterval.cs" company = "ANEXIA® Internetdienstleistungs GmbH">
//  Copyright (c) ANEXIA® Internetdienstleistungs GmbH. All rights reserved.
//  </copyright>
// ------------------------------------------------------------------------------------------

#region
using Anexia.Validation.Interval.Common;
using Equ;
#endregion

namespace Anexia.Validation.Interval.Closed;

public sealed class ClosedInterval<T> : MemberwiseEquatable<ClosedInterval<T>>, IInterval<T>
    where T : IComparable<T>
{
    private readonly IntervalBase<T> _intervalBase;

    private ClosedInterval(IntervalBase<T> intervalBase)
    {
        _intervalBase = intervalBase;
    }

    public ClosedInterval(T lowerBound, T upperBound)
        : this(new IntervalBase<T>(lowerBound, upperBound))
    { }

    public bool Contains(T value) =>
        _intervalBase.LowerBoundLessThanOrEqualTo(value) && _intervalBase.UpperBoundGreaterThanOrEqualTo(value);

    public static bool operator ==(ClosedInterval<T> left, ClosedInterval<T> right) => Equals(left, right);

    public static bool operator !=(ClosedInterval<T> left, ClosedInterval<T> right) => !Equals(left, right);

    public override string ToString() => $"[{_intervalBase}]";
}