using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

internal class Class2
{
    [CompilerGenerated]
    private Dictionary<string, Class3> dictionary_0;
    [CompilerGenerated]
    private WeakReference weakReference_0;

    public Class2(object object_0)
    {
        this.method_3(new Dictionary<string, Class3>());
        this.method_1(new WeakReference(object_0));
    }

    [CompilerGenerated]
    public WeakReference method_0()
    {
        return this.weakReference_0;
    }

    [CompilerGenerated]
    public void method_1(WeakReference weakReference_1)
    {
        this.weakReference_0 = weakReference_1;
    }

    [CompilerGenerated]
    public Dictionary<string, Class3> method_2()
    {
        return this.dictionary_0;
    }

    [CompilerGenerated]
    public void method_3(Dictionary<string, Class3> dictionary_1)
    {
        this.dictionary_0 = dictionary_1;
    }
}

