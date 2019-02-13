using System;

public class DisposeExample : IDisposable
{
    protected SqlConnection _connection;
    private bool _disposed;
    public virtual string GetDate()
    {
        if(_disposed)
        {
            throw new ObjectDisposedException("DisposeExample has been disposed!");
        }

        if(_connection == null)
        {
            // create new connection here
        }
        using(var command = _connection.CreateCommand())
        {
            // do something
        }
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if(_disposed) return;
        if(disposing)
        {
            if(_connection != null)
            {
                _connection.Dispose();
                _connection = null;
            }
            _disposed = true;
        }
    }
}