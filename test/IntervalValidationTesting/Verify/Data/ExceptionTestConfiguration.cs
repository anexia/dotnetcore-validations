// --------------------------------------------------------------------------------------------
//  <copyright file = "ExceptionTestConfiguration.cs" company = "ANEXIA® Internetdienstleistungs GmbH">
//  Copyright (c) ANEXIA® Internetdienstleistungs GmbH.All rights reserved.
//  </copyright>
// --------------------------------------------------------------------------------------------

#region

using System;
using ANX.Common.Validation.Interval.Exception;

#endregion

namespace ANX.Common.Validation.IntervalTesting.Verify.Data;

public sealed class ExceptionTestConfiguration {
    private ExceptionTestConfiguration(
        Func<object> exceptionSupplier,
        string expectedExceptionMessage,
        Type? exceptionType = null)
    {
        ExceptionSupplier = exceptionSupplier;
        ExpectedExceptionMessage = expectedExceptionMessage;
        ExceptionType = exceptionType ?? typeof(ValueOutOfIntervalException<int>);
    }

    public Func<object> ExceptionSupplier { get; }
    public string ExpectedExceptionMessage { get; }
    public Type ExceptionType { get; }

    public static ExceptionTestConfiguration Create(
        Func<object> exceptionSupplier,
        string message,
        Type? exceptionType = null) =>
        new(exceptionSupplier, message, exceptionType);

    public override string ToString() => ExpectedExceptionMessage;
}