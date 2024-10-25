// --------------------------------------------------------------------------------------------
//  <copyright file = "IntervalVerificationTest.cs" company = "ANEXIA® Internetdienstleistungs GmbH">
//  Copyright (c) ANEXIA® Internetdienstleistungs GmbH.All rights reserved.
//  </copyright>
// --------------------------------------------------------------------------------------------

#region

using ANX.Common.Validation.IntervalTesting.Verify.Data;
using Xunit;

#endregion

namespace ANX.Common.Validation.IntervalTesting.Verify;

public sealed class IntervalVerificationTest {
    [Theory]
    [ClassData(typeof(IntervalVerificationData))]
    public void VerifyReturnsInputValueWhenValueIsInInterval(TestConfiguration testConfiguration) =>
        Assert.Equal(testConfiguration.ExpectedValue, testConfiguration.ActualValue);

    [Theory]
    [ClassData(typeof(IntervalVerificationExceptionData))]
    public void VerifyThrowsExceptionWhenValueIsNotInInterval(ExceptionTestConfiguration exceptionTestConfiguration)
    {
        var actualException = Assert.Throws(
            exceptionTestConfiguration.ExceptionType,
            exceptionTestConfiguration.ExceptionSupplier);

        Assert.Equal(exceptionTestConfiguration.ExpectedExceptionMessage, actualException.Message);
    }
}