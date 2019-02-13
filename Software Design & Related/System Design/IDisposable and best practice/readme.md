# IDisposable and Memory Leak in C#

## Useful resources
1. [Implementing Dispose and Finalize](https://docs.microsoft.com/en-us/dotnet/standard/garbage-collection/implementing-dispose)

## Memory Leak
1. Naive definition: failure to release unreachable memory which can no longer be allocated again by any process during execution of the allocating process. This can mostly be cured by using garbage collection (GC) or detected by automated tools.
2. Subtle definition: failure to release reachable memory which is no longer needed for your program to function correctly.

## IDisposable: provides a mechanism for releasing unmanaged resources
1. Implement IDisposable:
    ```
    public class MayUseUnmanagedResources: IDisposable
    {
        public void Method(){}
        public void Dispose(){}
    }
    ```
2. Apply 'using' statement: **using** statement provides a convenient syntax that ensures the correct use of IDisposable object, it ensures that **Dispose** is called even if an exception occurs within the **using** block.
    ```
    using(var obj = new MayUseUnmanagedResources())
    {
        obj.Method();
    }
    ```
3. The **using** statement is equivalent with the following statement:
    ```
    var obj = new MayUseUnmanagedResources();
    try
    {
        obj.Method();
    }
    finally
    {
        obj.Dispose();
    }
    ```
4. Best practices of IDisposable:
    1. Use IDisposable as soon as you can
    2. If you use IDisposable objects as instance fields, implement IDisposable
    3. Allow Dispose() to be called multiple times and don't throw exceptions
    4. Implement IDisposable to support disposing resources in a class hierarchy
    5. If you are use unmanaged resources, declare a finalizer which cleans them up
    6. Enabled Code Analysis with CA2000 enabled - but don't rely on it
    7. If you implement an interface and use IDisposable fields, extend your interface from IDisposable
    8. If you implement IDisposable, don't implement it explicitly
5. The dispose pattern has two variations:
    1. Implement the IDisposable interface and an additional Dispose(boolean) method. This is the recommended variation and doesn't require overriding the Object.Finalize method.
    2. Implement the IDisposable interface and an additional Dispose(boolean) method, and you also override the Object.Finalize method. You must override **Finalize** to ensure that unmanaged resources are disposed of if your IDisposable.Dispose implementation is not called by a consumer of your type. If you use the recommended technique discussed in the previous bullet, the **System.Runtime.InteropServices.SafeHandle** class does this on your behalf.
6. Summary of IDisposable implementation:
    1. Disposing managed resources
    2. Expecting **Dispose** to be repeatedly called
    3. Allowing inheritors to dispose their resources
    4. Using **finalizers** to clean up unmanaged resources 

## Garbage Collector
1. Garbage Collector: manages the allocation and release of memory for your application.

## What Happens if you Don't Dispose?

### Possible issues:
1. File locks & event handlers
2. Starving SQL connection pool and object leaks

### How to identify potential run-time issues from not disposing resources?
1. Check for defects running the app
2. Check for memory issues profiling the app

### How to identify potential design-time issues from not disposing?
1. Check for issues using static code analysis & manual checks
    1. Static code analysis is not enabled by default
    2. Recommended rules do notinclude CA2000
2. Fix issues and check performance with profiler
3. Implement IDisposable to make Dispose discoverable 