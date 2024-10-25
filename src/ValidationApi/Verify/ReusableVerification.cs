// --------------------------------------------------------------------------------------------
//  <copyright file = "ReusableVerification.cs" company = "ANEXIA® Internetdienstleistungs GmbH">
//  Copyright (c) ANEXIA® Internetdienstleistungs GmbH.All rights reserved.
//  </copyright>
// --------------------------------------------------------------------------------------------

#region

using ANX.Common.Validation.Api.Assert;

#endregion

namespace ANX.Common.Validation.Api.Verify;

public sealed class ReusableVerification<T> : IReusableVerification<T> {
    private readonly IReusableAssertion<T> _assertion;

    public ReusableVerification(IReusableAssertion<T> assertion)
    {
        _assertion = assertion;
    }

    public ReusableVerification(Func<T, bool> predicate, Func<T, Exception> exceptionSupplier)
        : this(new ReusableAssertion<T>(predicate, exceptionSupplier))
    { }

    public T Verify(T value)
    {
        _assertion.Assert(value);

        return value;
    }
}