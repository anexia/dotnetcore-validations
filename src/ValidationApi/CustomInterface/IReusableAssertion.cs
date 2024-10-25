// ------------------------------------------------------------------------------------------
//  <copyright file = "IReusableAssertion.cs" company = "ANEXIA® Internetdienstleistungs GmbH">
//  Copyright (c) ANEXIA® Internetdienstleistungs GmbH. All rights reserved.
//  </copyright>
// ------------------------------------------------------------------------------------------

namespace Anexia.Validation.Api.CustomInterface;

public interface IReusableAssertion<in T>
{
    void Assert(T value);
}