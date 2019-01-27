## Object-Oriented Programming in C#

### Three pillars of OOP: Encapsulation, Inheritance, and Polymorphism
1. Inheritance: Define a general class and then extend it to more specialized classes.
2. Encapsulation: make the fields in a class private and provide access to the fields via public methods.
3. Polymorphism: a variable of a supertype can refer to a subtype object. 

### Abstract and Interface
1. Abstract: is a super class that contains common features of its subclasses.
2. Interface: contains only public static constants and public abstract methods
3. Differences between abstract and interface:
    1. An abstract class is closely linked to inheritance, and there should be a strong relationship between abstract class and its subclasses. While interface can be implemented by any class. 
    2. A class can only extend one abstract class but can implememt multiple interfaces.
    3. Abstract class may provide constructors, instance variables, and some methods with implementation; While interface only provide public static constants and public abstract methods.

### Overloading and Overriding
1. Overloading: define multiple methods with the same name but different signatures.
2. Overriding: provide a new implementation in subclass with the same name, the same signature, and the same return type.

### Static Polymorphism and Dynamic Polymorphism
1. Static polymorphism: early binding, overloading, compile time assignment.
2. Dynamic polymorphism: late binding, overriding, runtime assignment.

### Virtual method and Abstract Method
1. Virtual method can have implementation but provide an option to override it in the derived class.
2. Abstract method has no implementation and must override in subclass. 
