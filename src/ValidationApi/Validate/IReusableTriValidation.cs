// ------------------------------------------------------------------------------------------
//  <copyright file = "IReusableTriValidation.cs" company = "ANEXIA® Internetdienstleistungs GmbH">
//  Copyright (c) ANEXIA® Internetdienstleistungs GmbH. All rights reserved.
//  </copyright>
// ------------------------------------------------------------------------------------------

namespace Anexia.Validation.Api.Validate;

public interface IReusableTriValidation<in TFirst, in TSecond, in TThird>
{
    bool IsValid(TFirst first, TSecond second, TThird third);
}