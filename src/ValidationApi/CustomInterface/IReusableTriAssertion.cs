// --------------------------------------------------------------------------------------------
//  <copyright file = "IReusableTriAssertion.cs" company = "ANEXIA® Internetdienstleistungs GmbH">
//  Copyright (c) ANEXIA® Internetdienstleistungs GmbH.All rights reserved.
//  </copyright>
// --------------------------------------------------------------------------------------------

namespace ANX.Common.Validation.Api.CustomInterface;

public interface IReusableTriAssertion<in TFirst, in TSecond, in TThird> {
    void Assert(TFirst first, TSecond second, TThird third);
}