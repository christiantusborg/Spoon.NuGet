Sure, here is the markdown version of the text you provided:

---

## Either Object in C#

The code you provided is a C# implementation of an Either object. An Either object is used to represent a value that can be either of one type or another type. It is often used in functional programming languages to handle errors or alternative outcomes.

To use this implementation of the Either object, you first need to include the namespace `Spoon.NuGet.Core.EitherCore` in your C# file. Then, you can create an instance of the `Either` class by specifying the type of the success value in the angle brackets. For example, if you want to create an Either object that can hold either a string or an error message, you can write:

```csharp
var either = new Either<string>("success value");
var eitherError = new Either<EitherErrorMessage>(new EitherErrorMessage("error message"));
```

You can then use the `Match` method to execute different functions depending on the state of the Either object. For example, you can write:

```csharp
either.Match(
    ex => Console.WriteLine($"Error: {ex.Message}"),
    value => Console.WriteLine($"Success: {value}")
);
```

```csharp
either.Match(
    ex => throw ex,
    value => Console.WriteLine($"Success: {value}")
);
```
This will execute the first function if the Either object is in a faulted state and the second function if it contains a success value. The `Match` method returns the result of executing the appropriate function based on the state of the Either object.

Note that in the example you provided, there are three constructors for the `Either` class: one that takes a faulted exception, one that takes an error message, and one that takes a success value. Depending on which constructor you use, the Either object will be in a different state.

---


```csharp
either.Match(
    ex => throw ex,
    value => Console.WriteLine($"Success: {value}")
);
```




```csharp
var command = new SomeCommand();
var commandResult = await sender.Send(command, cancellationToken);

var result = commandResult.ToResult(typeof(SomeCommandResult));
return result;
```
