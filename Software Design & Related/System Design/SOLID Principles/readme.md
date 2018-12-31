# SOLID Principles

## Single Responsibility Principle (SRP)
1. Every class should have only one job to do.
2. Following SRP leads to lower coupling and higher cohesion
3. Mang small classes with distinct responsibilities result in a more flexible design

## Open-Close Principle (OCP)
1. A software module or class should be open for extension and closed for modification.
2. Three approaches to achieve OCP:
    1. Parameters (Procedural Programming): 
        1. Allow client to control behavior specifics via a parameter
        2. Combined with delegates/lambda, can be very powerful approach
    2. Inheritance: Child types override behaviour of a base class (or interface)
    3. Composition / Strategy pattern
        1. Client code depends on abstraction
        2. Provides a 'plug in' model
        3. Implementations utilize inheritance, client utilize composition
3. Conformance to OCP yields flexibility, reusability, and maintainability.

## Liskov Substitution Principle (LSP)
1. A derived class must be substitutable for its base class.
2. Remember IS-SUBSTITUTABLE-FOR instead of IS-A.

## Interface Segregation Principle (ISP)
1. Each interface should have a specific purpose, and clients should not be forced to implement an interface that does not share the purpose
2. Keep interface small, cohesive, and focused
3. Whenever possible, let the client define the interface 

## Dependency Inversion Principle (DIP)
1. High-level module should not depend on low-level module.