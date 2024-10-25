// --------------------------------------------------------------------------------------------
//  <copyright file = "IllegalIntervalException.cs" company = "ANEXIA® Internetdienstleistungs GmbH">
//  Copyright (c) ANEXIA® Internetdienstleistungs GmbH.All rights reserved.
//  </copyright>
// --------------------------------------------------------------------------------------------

#region

using System.Runtime.Serialization;

#endregion

namespace ANX.Common.Validation.Interval.Exception;

[Serializable]
public sealed class IllegalIntervalException : System.Exception {
    public IllegalIntervalException(object lowerBound, object upperBound)
        : base($"Lower bound of interval must be less than or equal to upper bound {upperBound}, but was {lowerBound}.")
    { }

    private IllegalIntervalException(SerializationInfo info, StreamingContext context)
        : base(info, context)
    { }
}