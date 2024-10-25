// ------------------------------------------------------------------------------------------
//  <copyright file = "IInterval.cs" company = "ANEXIA® Internetdienstleistungs GmbH">
//  Copyright (c) ANEXIA® Internetdienstleistungs GmbH. All rights reserved.
//  </copyright>
// ------------------------------------------------------------------------------------------

namespace ANX.Common.Validation.Interval.Common;

public interface IInterval<in T>
{
    bool Contains(T value);
}