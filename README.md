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
