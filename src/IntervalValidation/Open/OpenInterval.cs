// ------------------------------------------------------------------------------------------
//  <copyright file = "OpenInterval.cs" company = "ANEXIA® Internetdienstleistungs GmbH">
//  Copyright (c) ANEXIA® Internetdienstleistungs GmbH. All rights reserved.
//  </copyright>
// ------------------------------------------------------------------------------------------

#region
using ANX.Common.Validation.Interval.Common;
using Equ;
#endregion

namespace ANX.Common.Validation.Interval.Open;

public sealed class OpenInterval<T> : MemberwiseEquatable<OpenInterval<T>>, IInterval<T>
    where T : IComparable<T>
{
    private readonly IntervalBase<T> _intervalBase;

    private OpenInterval(IntervalBase<T> intervalBase)
    {
        _intervalBase = intervalBase;
    }

    public OpenInterval(T lowerBound, T upperBound)
        : this(new IntervalBase<T>(lowerBound, upperBound))
    { }

    public bool Contains(T value) =>
        _intervalBase.LowerBoundLessThan(value) && _intervalBase.UpperBoundGreaterThan(value);

    public override string ToString() => $"({_intervalBase})";
}