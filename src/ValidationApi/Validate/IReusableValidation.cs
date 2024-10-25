// ------------------------------------------------------------------------------------------
//  <copyright file = "IReusableValidation.cs" company = "ANEXIA® Internetdienstleistungs GmbH">
//  Copyright (c) ANEXIA® Internetdienstleistungs GmbH. All rights reserved.
//  </copyright>
// ------------------------------------------------------------------------------------------

namespace ANX.Common.Validation.Api.Validate;

public interface IReusableValidation<in T>
{
    bool IsValid(T value);
}