// --------------------------------------------------------------------------------------------
//  <copyright file = "IReusableAssertion.cs" company = "ANEXIA® Internetdienstleistungs GmbH">
//  Copyright (c) ANEXIA® Internetdienstleistungs GmbH.All rights reserved.
//  </copyright>
// --------------------------------------------------------------------------------------------

namespace ANX.Common.Validation.Api.CustomInterface;

public interface IAsyncReusableAssertion<in T> {
    Task AssertAsync(IEnumerable<T> values);
}