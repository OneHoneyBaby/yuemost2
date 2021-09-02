using System;
using System.Reflection;
using System.Runtime.CompilerServices;

internal class Class4
{
    [CompilerGenerated]
    private Func<object, object> func_0;
    [CompilerGenerated]
    private PropertyInfo propertyInfo_0;
    [CompilerGenerated]
    private WeakReference weakReference_0;

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
    public Func<object, object> method_2()
    {
        return this.func_0;
    }

    [CompilerGenerated]
    public void method_3(Func<object, object> func_1)
    {
        this.func_0 = func_1;
    }

    [CompilerGenerated]
    public PropertyInfo method_4()
    {
        return this.propertyInfo_0;
    }

    [CompilerGenerated]
    public void method_5(PropertyInfo propertyInfo_1)
    {
        this.propertyInfo_0 = propertyInfo_1;
    }
}

