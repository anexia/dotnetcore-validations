// --------------------------------------------------------------------------------------------
//  <copyright file = "IReusableVerification.cs" company = "ANEXIA® Internetdienstleistungs GmbH">
//  Copyright (c) ANEXIA® Internetdienstleistungs GmbH.All rights reserved.
//  </copyright>
// --------------------------------------------------------------------------------------------

namespace ANX.Common.Validation.Api.Verify;

public interface IReusableVerification<T> {
    T Verify(T value);
}