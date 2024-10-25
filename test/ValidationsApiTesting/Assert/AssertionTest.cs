// ------------------------------------------------------------------------------------------
//  <copyright file = "AssertionTest.cs" company = "ANEXIA® Internetdienstleistungs GmbH">
//  Copyright (c) ANEXIA® Internetdienstleistungs GmbH. All rights reserved.
//  </copyright>
// ------------------------------------------------------------------------------------------

#region
using System;
using System.Diagnostics.CodeAnalysis;
using ANX.Common.Validation.Api.Assert;
using Xunit;
using static Xunit.Assert;
#endregion

namespace ANX.Common.Validation.ApiTesting.Assert;

[SuppressMessage(
    "Ignore, as for internal testing only",
    "S3928:Parameter names used into ArgumentException constructors should match an existing one ")]
public sealed class AssertionTest
{
    [Fact]
    public void StaticAssertDoesNotThrowExceptionForBooleanSupplierReturningTrue() =>
        Assertion.Assert(() => true, () => throw new ArgumentException());

    [Fact]
    public void StaticAssertThrowsExceptionForBooleanSupplierReturningFalse() =>
        Throws<ArgumentException>(() => Assertion.Assert(() => false, () => throw new ArgumentException()));
}