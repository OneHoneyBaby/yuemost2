namespace DSkin
{
    using System;

    public interface ILayeredContainer
    {
        event EventHandler<InvalidateEventArgs> LayeredInvalidated;
    }
}

