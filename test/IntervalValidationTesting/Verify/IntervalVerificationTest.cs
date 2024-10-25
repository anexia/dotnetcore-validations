// ------------------------------------------------------------------------------------------
//  <copyright file = "IntervalVerificationTest.cs" company = "ANEXIA® Internetdienstleistungs GmbH">
//  Copyright (c) ANEXIA® Internetdienstleistungs GmbH. All rights reserved.
//  </copyright>
// ------------------------------------------------------------------------------------------

#region
using Anexia.Validation.IntervalTesting.Verify.Data;
#endregion

namespace Anexia.Validation.IntervalTesting.Verify;

public sealed class IntervalVerificationTest
{
    [Theory]
    [ClassData(typeof(IntervalVerificationData))]
    public void VerifyReturnsInputValueWhenValueIsInInterval(TestConfiguration testConfiguration) =>
        Assert.Equal(testConfiguration.ExpectedValue, testConfiguration.ActualValue);

    [Theory]
    [ClassData(typeof(IntervalVerificationExceptionData))]
    public void VerifyThrowsExceptionWhenValueIsNotInInterval(ExceptionTestConfiguration exceptionTestConfiguration)
    {
        Assert.Throws(
            exceptionTestConfiguration.ExceptionType,
            exceptionTestConfiguration.ExceptionSupplier);
    }
}