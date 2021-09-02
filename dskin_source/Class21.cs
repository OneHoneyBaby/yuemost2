using DSkin.Common;
using DSkin.DirectUI;
using System;
using System.Reflection;
using System.Runtime.CompilerServices;

internal class Class21
{
    [CompilerGenerated]
    private DSkin.DirectUI.jsNativeFunction jsNativeFunction_0;
    [CompilerGenerated]
    private MethodInfo methodInfo_0;
    [CompilerGenerated]
    private object object_0;

    public Class21()
    {
        this.method_1(new DSkin.DirectUI.jsNativeFunction(this.method_6));
    }

    [CompilerGenerated]
    public DSkin.DirectUI.jsNativeFunction method_0()
    {
        return this.jsNativeFunction_0;
    }

    [CompilerGenerated]
    internal void method_1(DSkin.DirectUI.jsNativeFunction jsNativeFunction_1)
    {
        this.jsNativeFunction_0 = jsNativeFunction_1;
    }

    [CompilerGenerated]
    public object method_2()
    {
        return this.object_0;
    }

    [CompilerGenerated]
    public void method_3(object object_1)
    {
        this.object_0 = object_1;
    }

    [CompilerGenerated]
    public MethodInfo method_4()
    {
        return this.methodInfo_0;
    }

    [CompilerGenerated]
    internal void method_5(MethodInfo methodInfo_1)
    {
        this.methodInfo_0 = methodInfo_1;
    }

    private long method_6(IntPtr intptr_0, long long_0, long long_1, int int_0)
    {
        ParameterInfo[] parameters = this.method_4().GetParameters();
        object[] objArray = new object[DSkin.DirectUI.JsValue.ArgCount(intptr_0)];
        for (int i = 0; i < objArray.Length; i++)
        {
            DSkin.DirectUI.JsValue value2 = new DSkin.DirectUI.JsValue(intptr_0, i);
            switch (value2.JsType)
            {
                case wkeJSType.WKE_JSTYPE_NUMBER:
                {
                    if (parameters[i].ParameterType != typeof(double))
                    {
                        break;
                    }
                    objArray[i] = value2.ToDouble();
                    continue;
                }
                case wkeJSType.WKE_JSTYPE_STRING:
                {
                    objArray[i] = value2.ToString();
                    continue;
                }
                case wkeJSType.WKE_JSTYPE_BOOLEAN:
                {
                    objArray[i] = value2.ToBool();
                    continue;
                }
                case wkeJSType.WKE_JSTYPE_OBJECT:
                case wkeJSType.WKE_JSTYPE_FUNCTION:
                case wkeJSType.WKE_JSTYPE_UNDEFINED:
                {
                    continue;
                }
                default:
                {
                    continue;
                }
            }
            if (parameters[i].ParameterType == typeof(float))
            {
                objArray[i] = value2.ToFloat();
            }
            else if (parameters[i].ParameterType == typeof(int))
            {
                objArray[i] = value2.ToInt();
            }
        }
        object data = this.method_4().Invoke(this.method_2(), objArray);
        Type returnType = this.method_4().ReturnType;
        long num2 = DSkin.DirectUI.JsValue.JsUndefined(intptr_0);
        if ((returnType == typeof(string)) && (data != null))
        {
            return DSkin.DirectUI.JsValue.JsString(intptr_0, data.ToString());
        }
        if (returnType == typeof(int))
        {
            return DSkin.DirectUI.JsValue.JsInt(intptr_0, data.ToInt());
        }
        if (returnType == typeof(float))
        {
            return DSkin.DirectUI.JsValue.JsFloat(intptr_0, data.ToFloat());
        }
        if (returnType == typeof(double))
        {
            return DSkin.DirectUI.JsValue.JsDouble(intptr_0, data.ToDouble());
        }
        if (returnType != typeof(bool))
        {
            return num2;
        }
        if (data.ToBool())
        {
            return DSkin.DirectUI.JsValue.JsTrue(intptr_0);
        }
        return DSkin.DirectUI.JsValue.JsFalse(intptr_0);
    }
}

