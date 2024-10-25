// ------------------------------------------------------------------------------------------
//  <copyright file = "IAsyncReusableAssertion.cs" company = "ANEXIA® Internetdienstleistungs GmbH">
//  Copyright (c) ANEXIA® Internetdienstleistungs GmbH. All rights reserved.
//  </copyright>
// ------------------------------------------------------------------------------------------

namespace Anexia.Validation.Api.CustomInterface;

public interface IAsyncReusableAssertion<in T>
{
    Task AssertAsync(IEnumerable<T> values);
}