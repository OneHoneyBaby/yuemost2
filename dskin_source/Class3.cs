using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;

internal class Class3
{
    private List<Class4> list_0 = new List<Class4>();
    [CompilerGenerated]
    private PropertyInfo propertyInfo_0;

    [CompilerGenerated]
    public PropertyInfo method_0()
    {
        return this.propertyInfo_0;
    }

    [CompilerGenerated]
    public void method_1(PropertyInfo propertyInfo_1)
    {
        this.propertyInfo_0 = propertyInfo_1;
    }

    internal List<Class4> method_2()
    {
        return this.list_0;
    }
}

