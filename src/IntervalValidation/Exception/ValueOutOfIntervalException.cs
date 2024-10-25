// ------------------------------------------------------------------------------------------
//  <copyright file = "ValueOutOfIntervalException.cs" company = "ANEXIA® Internetdienstleistungs GmbH">
//  Copyright (c) ANEXIA® Internetdienstleistungs GmbH. All rights reserved.
//  </copyright>
// ------------------------------------------------------------------------------------------

#region
using System.Runtime.Serialization;
using Anexia.Validation.Interval.Common;
#endregion

namespace Anexia.Validation.Interval.Exception;

[Serializable]
public sealed class ValueOutOfIntervalException<T> : System.Exception
{
    public ValueOutOfIntervalException(T value, IInterval<T> interval)
        : base($"Value {value} is not in interval {interval}.")
    { }

    private ValueOutOfIntervalException(SerializationInfo info, StreamingContext context)
        : base(info, context)
    { }
}