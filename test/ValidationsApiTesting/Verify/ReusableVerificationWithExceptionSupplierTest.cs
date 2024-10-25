// ------------------------------------------------------------------------------------------
//  <copyright file = "ReusableVerificationWithExceptionSupplierTest.cs" company = "ANEXIA® Internetdienstleistungs GmbH">
//  Copyright (c) ANEXIA® Internetdienstleistungs GmbH. All rights reserved.
//  </copyright>
// ------------------------------------------------------------------------------------------

#region
using System;
using Anexia.Validation.Api.Verify;
#endregion

namespace Anexia.Validation.ApiTesting.Verify;

public sealed class ReusableVerificationWithExceptionSupplierTest
{
    private static readonly IReusableVerification<int> _verification = new ReusableVerification<int>(
        value => value > 0,
        value => throw new ArgumentException($"Value {value} must be greater than 0."));

    [Fact]
    public void VerifyDoesNotThrowExceptionForBooleanSupplierReturningTrue() =>
        Assert.Equal(1, _verification.Verify(1));

    [Fact]
    public void VerifyThrowsExceptionForBooleanSupplierReturningFalse()
    {
        Assert.Throws<ArgumentException>(() => _verification.Verify(0));
    }
}