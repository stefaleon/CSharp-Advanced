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
