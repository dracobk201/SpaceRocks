using System;

public class CustomEventArgs<T> : EventArgs
{
    public CustomEventArgs(T value)
    {
        NewValue = value;
    }

    public T NewValue { get; }
}
