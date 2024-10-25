// --------------------------------------------------------------------------------------------
//  <copyright file = "ReusableVerificationTest.cs" company = "ANEXIA® Internetdienstleistungs GmbH">
//  Copyright (c) ANEXIA® Internetdienstleistungs GmbH.All rights reserved.
//  </copyright>
// --------------------------------------------------------------------------------------------

#region

using System;
using ANX.Common.Validation.Api.Assert;
using ANX.Common.Validation.Api.Verify;
using Xunit;

#endregion

namespace ANX.Common.Validation.ApiTesting.Verify;

public sealed class ReusableVerificationTest {
    private static readonly IReusableAssertion<int> _assertion = new ReusableAssertion<int>(
        value => value > 0,
        value => throw new ArgumentException($"Value {value} must be greater than 0."));

    private static readonly IReusableVerification<int> _verification = new ReusableVerification<int>(_assertion);

    [Fact]
    public void VerifyDoesNotThrowExceptionForBooleanSupplierReturningTrue() =>
        Xunit.Assert.Equal(1, _verification.Verify(1));

    [Fact]
    public void VerifyThrowsExceptionForBooleanSupplierReturningFalse()
    {
        var exception = Xunit.Assert.Throws<ArgumentException>(() => _verification.Verify(0));

        Xunit.Assert.Equal("Value 0 must be greater than 0.", exception.Message);
    }
}