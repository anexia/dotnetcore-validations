// --------------------------------------------------------------------------------------------
//  <copyright file = "ReusableTriValidationAssertion.cs" company = "ANEXIA® Internetdienstleistungs GmbH">
//  Copyright (c) ANEXIA® Internetdienstleistungs GmbH.All rights reserved.
//  </copyright>
// --------------------------------------------------------------------------------------------

#region

using ANX.Common.Validation.Api.Validate;

#endregion

namespace ANX.Common.Validation.Api.Assert;

public sealed class
    ReusableTriValidationAssertion<TFirst, TSecond, TThird> : IReusableTriAssertion<TFirst, TSecond, TThird> {
    private readonly Func<TFirst, TSecond, TThird, Exception> _exceptionSupplier;
    private readonly IReusableTriValidation<TFirst, TSecond, TThird> _validation;

    public ReusableTriValidationAssertion(
        IReusableTriValidation<TFirst, TSecond, TThird> validation,
        Func<TFirst, TSecond, TThird, Exception> exceptionSupplier)
    {
        _validation = validation;
        _exceptionSupplier = exceptionSupplier;
    }

    public void Assert(TFirst first, TSecond second, TThird third)
    {
        if(!_validation.IsValid(first, second, third)) throw _exceptionSupplier.Invoke(first, second, third);
    }
}