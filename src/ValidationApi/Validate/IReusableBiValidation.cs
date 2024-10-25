// ------------------------------------------------------------------------------------------
//  <copyright file = "IReusableBiValidation.cs" company = "ANEXIA® Internetdienstleistungs GmbH">
//  Copyright (c) ANEXIA® Internetdienstleistungs GmbH. All rights reserved.
//  </copyright>
// ------------------------------------------------------------------------------------------

namespace Anexia.Validation.Api.Validate;

public interface IReusableBiValidation<in TFirst, in TSecond>
{
    bool IsValid(TFirst first, TSecond second);
}