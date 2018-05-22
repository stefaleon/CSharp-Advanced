## [C# Advanced Topics](https://www.udemy.com/csharp-advanced/)

by [Mosh Hamedani](https://programmingwithmosh.com/)


## 01 GENERICS

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

* lambda: `Func<double, double> CalcSecPow = x => x * x;`

We can use `Func<T, T>` to define the type of the delegate that is expressed with a lambda.

* BookRepository: Use of the `FindAll` method of SystemCollections.Generic.List<T> with lambda expressions to create concise code.

```
var cheapBooks = books.FindAll(b => b.Price < 20);
```
