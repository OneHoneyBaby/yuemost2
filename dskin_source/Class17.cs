using System;
using System.Reflection;
using System.Runtime.CompilerServices;

internal static class Class17
{
    public static object smethod_0(this object object_0, string string_0, params object[] param)
    {
        return object_0.GetType().GetMethod(string_0, BindingFlags.NonPublic | BindingFlags.Instance).Invoke(object_0, param);
    }

    public static hxADEJUbcA2TTk8ABp smethod_1<hxADEJUbcA2TTk8ABp>(this object object_0, string string_0)
    {
        BindingFlags bindingAttr = BindingFlags.NonPublic | BindingFlags.Instance;
        Type type = object_0.GetType();
        PropertyInfo property = type.GetProperty(string_0, BindingFlags.NonPublic | BindingFlags.Instance);
        if (property == null)
        {
            property = type.BaseType.GetProperty(string_0, bindingAttr);
        }
        return (hxADEJUbcA2TTk8ABp) property.GetValue(object_0, null);
    }

    public static object smethod_2(this object object_0, string string_0)
    {
        BindingFlags bindingAttr = BindingFlags.NonPublic | BindingFlags.Instance;
        Type type = object_0.GetType();
        PropertyInfo property = type.GetProperty(string_0, BindingFlags.NonPublic | BindingFlags.Instance);
        if (property == null)
        {
            property = type.BaseType.GetProperty(string_0, bindingAttr);
        }
        return property.GetValue(object_0, null);
    }

    public static void smethod_3(this object object_0, string string_0, object object_1)
    {
        object_0.GetType().GetProperty(string_0, BindingFlags.NonPublic | BindingFlags.Instance).SetValue(object_0, object_1, null);
    }

    public static t7YVNv2ZW2QPL7OO6G smethod_4<t7YVNv2ZW2QPL7OO6G>(this object object_0, string string_0)
    {
        return (t7YVNv2ZW2QPL7OO6G) object_0.GetType().GetField(string_0, BindingFlags.NonPublic | BindingFlags.Instance).GetValue(object_0);
    }
}

