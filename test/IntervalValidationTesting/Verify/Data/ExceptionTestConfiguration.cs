// ------------------------------------------------------------------------------------------
//  <copyright file = "ExceptionTestConfiguration.cs" company = "ANEXIA® Internetdienstleistungs GmbH">
//  Copyright (c) ANEXIA® Internetdienstleistungs GmbH. All rights reserved.
//  </copyright>
// ------------------------------------------------------------------------------------------

#region
using System;
using Anexia.Validation.Interval.Exception;
#endregion

namespace Anexia.Validation.IntervalTesting.Verify.Data;

public sealed class ExceptionTestConfiguration
{
    private readonly string _expectedExceptionMessage;
    private ExceptionTestConfiguration(
        Func<object> exceptionSupplier,
        string expectedExceptionMessage,
        Type? exceptionType = null)
    {
        ExceptionSupplier = exceptionSupplier;
        _expectedExceptionMessage = expectedExceptionMessage;
        ExceptionType = exceptionType ?? typeof(ValueOutOfIntervalException<int>);
    }

    public Func<object> ExceptionSupplier { get; }
    public Type ExceptionType { get; }

    public static ExceptionTestConfiguration Create(
        Func<object> exceptionSupplier,
        string message,
        Type? exceptionType = null) =>
        new(exceptionSupplier, message, exceptionType);

    public override string ToString() => _expectedExceptionMessage;
}