## [C# Advanced Topics](https://www.udemy.com/csharp-advanced/)

by [Mosh Hamedani](https://programmingwithmosh.com/)


## 01 GENERICS

Examples:

* Generic Dictionary: `GenericDictionary<TKey, TValue>`

* Generic Dictionary 2: cannot add duplicate keys, read keys from the end of the dictionary to the beginning


## 02 DELEGATES

* A delegate in C# is similar to a function pointer in C or C++. Using a delegate allows the programmer to encapsulate a reference to a method inside a delegate object. The delegate object can then be passed to code which can call the referenced method, without having to know at compile time which method will be invoked.

So a **delegate** is a reference to a function, an object that knows how to call a method (or a group of methods).

* Delegates provide flexibility and extensibility as an alternative to interfaces.

* Use delegates on design patterns with events and when only a single method needs to be accessed on the implementation object. When additional methods and properties need to be accessed, an interface will be used instead.

* `Action<in T, in T, ...>`: predefined .NET delegate type, returns void.

* `Func<in T, out T>`: the first parameter is the argument type, the second is the output type.

* Many overloads are available...  `Func<in T1, in T2, in T3, in T4, out TResult>` etc...


## 03 LAMBDA EXPRESSIONS

Examples:

* lambda: `Func<double, double> CalcSecPow = x => x * x;`

We can use `Func<T, T>` to define the type of the delegate that is expressed with a lambda.

* BookRepository: Use of the `FindAll` method of SystemCollections.Generic.List<T> with lambda expressions to create concise code.

```
var cheapBooks = books.FindAll(b => b.Price < 20);
```


## 04 EVENTS

* Use events to communicate between objects in order to create loosely coupled applications.

* In modern .NET versions we can use the **EventHandler** prebuilt delegate instead of defining a custom delegate in order to declare an event.


[Events Overview](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/events/#events-overview)

Events have the following properties:

- The **publisher** determines when an event is **raised**; the **subscribers** determine what action is taken in **response** to the event.

- An event can have multiple subscribers. A subscriber can handle multiple events from multiple publishers.

- Events that have no subscribers are never raised.

- Events are typically used to signal user actions such as button clicks or menu selections in graphical user interfaces.

- When an event has multiple subscribers, the event handlers are invoked synchronously when an event is raised. To invoke events asynchronously, see Calling Synchronous Methods Asynchronously.

- In the .NET Framework class library, events are based on the **EventHandler** delegate and the **EventArgs** base class.





#### The "VideoEncoder" example

In the *VideoEncoder* example scenario, when an encoding process (not implemented) is finished, an event publisher is called.
Then various objects that had been registered as event subscribers, raise the event and each of them behaves according to their own override of the event-publisher-method.


* The *VideoEncoder* class implements:

  * The *VideoEncoded* **event**, using the **System.EventHandler<TEventArgs>** delegate.

  * The *OnVideoEncoded* **event-publisher method** which has to be **protected**, **virtual** and to return **void**.

  * The "main" *Encode* method which eventually calls *OnVideoEncoded*.


* Various "messaging services" (simple classes here) can **subscribe** to the *VideoEncoded* event which is **published** by the *OnVideoEncoded* method call from inside the *VideoEncoder.Encode* method call.

* Each "messaging service" class implements **an override for the *OnVideoEncoded* method**.

* If the appropriate event handler declarations (**subscriptions**) are present, the various calls to the *OnVideoEncoded* overrides will be executed as the *VideoEncoded* event gets raised by the subscribers.




## 05 EXTENSION METHODS


- Extension methods enable you to **"add" methods to existing types without creating a new derived type, recompiling, or otherwise modifying the original type**.

- Extension methods are a special kind of **static** method, but they are **called as if they were instance methods on the extended type**. For client code written in C#, F# and Visual Basic, there is no apparent difference between calling an extension method and the methods that are actually defined in a type.


## 06 LINQ


#### LINQ Extension Methods

* returns `IEnumerable<out T>`, T is Book

```
var cheapBooks = books
                .Where(b => b.Price < 20);
```

* returns `IOrderedEnumerable<TElement>`, a sorted sequence

```
var cheapBooks = books
                .Where(b => b.Price < 20)
                .OrderBy(b => b.Title);
```

* returns `IEnumerable<out T>`, here T is s string

```
var cheapBooksStrings = books
                .Where(b => b.Price < 20)
                .OrderBy(b => b.Title)
                .Select(b => b.Title);  
```

* Single, SingleOrDefault, First, FirstOrDefault, Last, LastOrDefault

* Skip, Take

* Count, Sum, Max, Min, Average ...

* ... [Supported and Unsupported LINQ Methods (LINQ to Entities)](https://docs.microsoft.com/en-us/dotnet/framework/data/adonet/ef/language-reference/supported-and-unsupported-linq-methods-linq-to-entities)



#### LINQ Query Operators

```
var cheapBooksWithQuery =
                from b in books
                where b.Price < 20
                orderby b.Title
                select b;
```



## 07 NULLABLE TYPES

* We cannot assign null to Value types. If this is what we want, we can use the *Nullable* generic structure.

```
//DateTime dateTime = null; // ERROR

Nullable<DateTime> dateTime = null; // OK

// short syntax
DateTime? dateTime2 = null;
```

* Preferred way to get the value of a nullable is by using **GetValueOrDefault()**.

* **GetValueOrDefault()** can also be used in order to assign a value from a nullable to a non nullable.

* **Null coalescing operator ??**:

```
DateTime date5 = date4 ?? DateTime.Today;
```

this translates to "if date4 is null assign today to date5"

it is actually a shortened version of

```
DateTime date5 = (date4 != null) ? date4.GetValueOrDefault() : DateTime.Today;
```




## 08 DYNAMIC

[What is the 'dynamic' type in C# 4.0 used for?](https://stackoverflow.com/questions/2690623/what-is-the-dynamic-type-in-c-sharp-4-0-used-for)

The dynamic keyword is new to C# 4.0, and is used to tell the compiler that a variable's type can change or that it is not known until runtime. Think of it as being able to interact with an Object without having to cast it.

```
dynamic cust = GetCustomer();
cust.FirstName = "foo"; // works as expected
cust.Process(); // works as expected
cust.MissingMethod(); // No method found!
```

Notice we did not need to cast nor declare cust as type Customer. Because we declared it dynamic, the runtime takes over and then searches and sets the FirstName property for us. Now, of course, when you are using a dynamic variable, you are giving up compiler type checking. This means the call cust.MissingMethod() will compile and not fail until runtime. The result of this operation is a RuntimeBinderException because MissingMethod is not defined on the Customer class.

The example above shows how dynamic works when calling methods and properties. Another powerful (and potentially dangerous) feature is being able to reuse variables for different types of data. I'm sure the Python, Ruby, and Perl programmers out there can think of a million ways to take advantage of this, but I've been using C# so long that it just feels "wrong" to me.

answered Apr 22 '10
by Pranay Rana



## 09 EXCEPTION HANDLING

[Exceptions and Exception Handling](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/exceptions/)

The C# language's exception handling features help you deal with any unexpected or exceptional situations that occur when a program is running. Exception handling uses the `try`, `catch`, and `finally` keywords to try actions that may not succeed, to handle failures when you decide that it is reasonable to do so, and to clean up resources afterward. Exceptions can be generated by the common language runtime (CLR), by the .NET Framework or any third-party libraries, or by application code. Exceptions are created by using the `throw` keyword.

In many cases, an exception may be thrown not by a method that your code has called directly, but by another method further down in the call stack. When this happens, the CLR will unwind the stack, looking for a method with a `catch` block for the specific exception type, and it will execute the first such `catch` block that if finds. If it finds no appropriate `catch` block anywhere in the call stack, it will terminate the process and display a message to the user.


#### Exceptions Overview

Exceptions have the following properties:

- Exceptions are types that all ultimately derive from `System.Exception`.

- Use a `try` block around the statements that might throw exceptions.

- Once an exception occurs in the `try` block, the flow of control jumps to the first associated exception handler that is present anywhere in the call stack. In C#, the `catch` keyword is used to define an exception handler.

- If no exception handler for a given exception is present, the program stops executing with an error message.

- Do not catch an exception unless you can handle it and leave the application in a known state. If you catch `System.Exception`, rethrow it using the `throw` keyword at the end of the catch block.

- If a `catch` block defines an exception variable, you can use it to obtain more information about the type of exception that occurred.

- Exceptions can be explicitly generated by a program by using the `throw` keyword.

- Exception objects contain detailed information about the error, such as the state of the call stack and a text description of the error.

- Code in a `finally` block is executed even if an exception is thrown. Use a `finally` block to release resources, for example to close any streams or files that were opened in the `try`  block.

- Managed exceptions in the .NET Framework are implemented on top of the Win32 structured exception handling mechanism.




### The "using" statement

* The **using** statement is mostly used to handle any managed object that implements the `IDisposable` interface. At that time, Structured Exception Handling is used to ensure that the Dispose() of the IDisposable interface implemented by the class is called.

* With the `using` statement, the `finally` block is implied. It is actually applied by the compiler.

* The `using` statement is only useful for objects with a lifetime that does not extend beyond the method in which the objects are constructed. Remember that the objects you instantiate must implement the `System.IDisposable` interface.


### Custom Exceptions

* We can create custom exceptions using the format below:

```
public class FetchVideoApiException : Exception
{
    public FetchVideoApiException(string message, Exception innerException)
        : base(message, innerException)
    {

    }
}
```
