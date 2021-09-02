using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

internal class Class9 : NativeWindow, IDisposable
{
    private EventHandler<InvalidateEventArgs> eventHandler_0;
    private object object_0;

    public Class9(Control control_0)
    {
        this.object_0 = control_0;
        this.object_0.Disposed += new EventHandler(this.jFjOvbaace);
        base.AssignHandle(control_0.Handle);
    }

    public void Dispose()
    {
        this.ReleaseHandle();
    }

    private void jFjOvbaace(object sender, EventArgs e)
    {
        this.Dispose();
    }

    private void method_0(object sender, EventArgs e)
    {
        this.method_3(new InvalidateEventArgs(new Rectangle(0, 0, this.object_0.Width, this.object_0.Height)));
    }

    public void method_1(EventHandler<InvalidateEventArgs> eventHandler_1)
    {
        EventHandler<InvalidateEventArgs> handler2;
        EventHandler<InvalidateEventArgs> handler = this.eventHandler_0;
        do
        {
            handler2 = handler;
            EventHandler<InvalidateEventArgs> handler3 = (EventHandler<InvalidateEventArgs>) Delegate.Combine(handler2, eventHandler_1);
            handler = Interlocked.CompareExchange<EventHandler<InvalidateEventArgs>>(ref this.eventHandler_0, handler3, handler2);
        }
        while (handler != handler2);
    }

    public void method_2(EventHandler<InvalidateEventArgs> eventHandler_1)
    {
        EventHandler<InvalidateEventArgs> handler2;
        EventHandler<InvalidateEventArgs> handler = this.eventHandler_0;
        do
        {
            handler2 = handler;
            EventHandler<InvalidateEventArgs> handler3 = (EventHandler<InvalidateEventArgs>) Delegate.Remove(handler2, eventHandler_1);
            handler = Interlocked.CompareExchange<EventHandler<InvalidateEventArgs>>(ref this.eventHandler_0, handler3, handler2);
        }
        while (handler != handler2);
    }

    protected void method_3(InvalidateEventArgs invalidateEventArgs_0)
    {
        if (this.eventHandler_0 != null)
        {
            this.eventHandler_0(this.object_0, invalidateEventArgs_0);
        }
    }

    protected override void WndProc(ref Message m)
    {
        switch (m.Msg)
        {
            case 0x114:
            case 0x115:
            case 0x201:
            case 0x20a:
            case 15:
            case 20:
            case 0x100:
                this.method_3(new InvalidateEventArgs(new Rectangle(0, 0, this.object_0.Width, this.object_0.Height)));
                break;
        }
        base.WndProc(ref m);
    }
}

