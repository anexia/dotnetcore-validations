# anx-common-validation
==========

[![](https://img.shields.io/nuget/v/Anexia.Validations "NuGet version badge")](https://www.nuget.org/packages/Anexia.Validations)
[![](https://github.com/anexia/dotnetcore-validations/actions/workflows/test.yml/badge.svg?branch=main "Test status")](https://github.com/anexia/dotnetcore-validations/actions/workflows/test.yml)

This repository holds a solution and two packable libraries for ensuring the validity of object values. May you have to
ensure, that only values within a certain range or interval are given to a class, e.g., the class `Percent.cs` must only
hold values between 0 and 100. In this case, you can use one of the predefined assertions, verifications or validations
to simply throw an exception if a value < 0 or > 100 is passed to the constructor.

## ANX.Common.Validation.Api

This library contains interfaces and classes for ensuring that certain conditions are fullfilled and throwing an
exception otherwise. Typically, these interfaces and classes are used in a constructor to ensure that only valid values
or data structures are used. You can also use them to validate a calculation result or etc.

### ANX.Common.Validation.Api.Validate

You can define a class of type `IValidation`, `IReusableValidation<T>`, `IReusableBiValidation<TFirst,TSecond>`
, `IReusableTriValidation<TFirst,TSecond,TThird` and use this validation with up to three input parameters in
an `ValidationAssertion` (see below).

### ANX.Common.Validation.Api.Assert

This directory includes the main classes `Assertion`, `ValidationAssertion`, `ReusableAssertion<T>`
, `ReusableBiAssertion<TFirst, TSecond>` and `ReusableTriAssertion<TFirst, TSecond, TThird>`.

#### Assertion

You can use an `Assertion` to prove a boolean expression and throwing a custom exception if the boolean expression is
not met.
```
Assertion.Assert(booleanExpression, () => new CustomException());
```

#### ValidationAssertion

You can use a `ValidationAssertion` to prove if Validation of type `IValidation` is valid and throwing a custom
exception otherwise.

 ``` 
    Assertion.Assert(MyValidation, () => new CustomException());
``` 

#### ReusableValidationAssertion<T>

You can use a `ReusableValidationAssertion` to prove if Validation of type `IReusableValidation<T>` is valid and
throwing a custom exception
otherwise: `ReusableValidationAssertion.Assert(MyValidation, value => new CustomException(value));`

#### ReusableAssertion<T>, ReusableBiAssertion<TFirst,TSecond>, ReusableTriAssertion<TFirst,TSecond,TThird>

You can use a `ReusableAssertion<T>`to prove an boolean expression for a given input value of type `T`, e.g. throw an
exception on creating a train station which is virtual:

``` 
    private static readonly IReusableAssertion<TrainStation> _stationMustNotBeVirtual  = new ReusableAssertion<TrainStation>(
        station => station.IsNotVirtual,
        station => new VirtualStationInEmptyRunException(station.TrainStationId));

    public EmptyRunTask(TrainStation origin, TrainStation destination)
    {
        _stationMustNotBeVirtual.Assert(origin);
        _stationMustNotBeVirtual.Assert(destination);
        ...
    }
```

Similarly, you can use `ReusableBiAssertion` or `ReusableTriAssertion`, when you need two or three values in your
boolean expression:

```
    private static readonly IReusableBiAssertion<CirculationStart, TaskSequence> _validSequenceAssertion = 
    new  ReusableBiAssertion<CirculationStart, TaskSequence>(
        (start, sequence) => start.Prepends(sequence),
        (start, sequence) => new CirculationStartAndFirstTaskNotAlignedException(start, sequence.FirstOrDefault()));
```

### ANX.Common.Validation.Api.Verify

This directory contains a `ReusableVerification<T>`class which can be used to verify a given `IReusableAssertion<T>`and
returning `T`, when the binary expression of assertion is true. Use this in an constructor, if you want to verify a
value and assign it to a property:

```
    public sealed class Progress : MemberwiseEquatable<Progress>
    {
        private static readonly ReusableVerification<int> _percentageVerification = new(
            value => value is >= 0 and <= 100,
            value =>  new InvalidProgressValueException(value));

    public Progress(int value)
    {
        Value = _percentageVerification.Verify(value);
    }

    public int Value { get; }
```

## ANX.Common.Validation.Interval

This library contains classes and interfaces for ensuring that only values within a certain interval are passed to an
object constructor. The `IntervalVerification` can be used for any value of type `IComparable`.

We differ between the different intervals:

- Closed, e.g., [-90,90] meaning only values >=-90 and <= 90 are allowed.
- Open, e.g., (-90,90) meaning only values >-90 and < 90 are allowed.
- LeftOpenRightClosed, e.g., (-90,90] meaning only values >-90 and <= 90 are allowed.
- LeftClosedRightOpen, e.g., [-90,90) meaning only values >=-90 and < 90 are allowed.

When you define an invalid interval, where the lower bound is greater than the upper bound, e.g. [0,-10],
an `IllegalIntervalException` is thrown.

A typical usage for the `IntervalVerification` is to ensure that geocoordinates contain only valid values. A
geocoordinate consits of a latitude and a longitude. Whereby, the latitude must be >= -90 and <= 90 and the longitude
must be >-180 and < 180. We can ensure, that objects of type `Latitude` and `Longitude` hold only valid values by
implementing an `IntervalVerification` in their constructors:

```
using ANX.Common.Validation.Interval.Verify
using ANX.Common.Validation.Interval.Common

public sealed class Latitude : MemberwiseEquatable<Latitude>
    {
          private static readonly IntervalVerification<double> _verification = IntervalFactory.Closed(-90, 90);

        public Latitude(double latitude)
        {
            Value = _verification.Verify(latitude);
        }

        public double Value { get; }

        public override string ToString()
        {
            return Value.ToString(CultureInfo.InvariantCulture);
        }
    }
```

```
using ANX.Common.Validation.Interval.Verify
using ANX.Common.Validation.Interval.Common

 public sealed class Longitude : MemberwiseEquatable<Longitude>
    {
      private static readonly IntervalVerification<double> _verification = IntervalFactory.Open(-180, 180);

        public Longitude(double longitude)
        {
            Value = _verification.Verify(longitude);
        }

        public double Value { get; }

        public override string ToString()
        {
            return Value.ToString(CultureInfo.InvariantCulture);
        }
    }
```

Whenever an invalid value is passed to the `Longitude`or `Latitude` constructor an `ValueOutOfIntervalException` is
thrown. So we can ensure, that the objects cannot be created containing semantically wrong values.

The `IntervalFactory` also provides static methods for creating a Verification of LeftOpenRightClosed or
LeftClosedRightOpen intervals. Further, you can optionally pass a custom exception as a third parameter to every factory
method, to throw a specific exception on violation instead of the default `ValueOutOfIntervalException`:

```
var verification = IntervalFactory.LeftClosedRightOpen(-180, 180,(value)=>new CustomException(value));
```

## Authors and acknowledgment

Refactored and adapted by Veronika Taferner & Alex Peruzzi. Do not hestitate if you have any
questions or ideas for extensions.

### Contributing

Contributions are welcomed! Read the [Contributing Guide](CONTRIBUTING.md) for more information.

## Licensing

This project is licensed under the Apache V2 License. See [LICENSE](LICENSE) for more information.
