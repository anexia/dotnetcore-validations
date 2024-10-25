// --------------------------------------------------------------------------------------------
//  <copyright file = "IReusableBiAssertion.cs" company = "ANEXIA® Internetdienstleistungs GmbH">
//  Copyright (c) ANEXIA® Internetdienstleistungs GmbH.All rights reserved.
//  </copyright>
// --------------------------------------------------------------------------------------------

namespace ANX.Common.Validation.Api.Assert;

public interface IReusableBiAssertion<in TFirst, in TSecond> {
    void Assert(TFirst first, TSecond second);
}