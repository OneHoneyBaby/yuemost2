namespace DSkin.Common
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    public static class BindingEngine
    {
        private static Dictionary<int, Class2> dictionary_0 = new Dictionary<int, Class2>();

        public static void ClearInvalidBinding()
        {
            List<int> list = new List<int>();
            foreach (KeyValuePair<int, Class2> pair in dictionary_0)
            {
                if ((pair.Value.method_0().Target != null) && (pair.Value.method_2().Count != 0))
                {
                    List<string> list2 = new List<string>();
                    foreach (KeyValuePair<string, Class3> pair2 in pair.Value.method_2())
                    {
                        if (pair2.Value.method_2().Count > 0)
                        {
                            List<Class4> list3 = new List<Class4>();
                            foreach (Class4 class2 in pair2.Value.method_2())
                            {
                                if (class2.method_0().Target == null)
                                {
                                    list3.Add(class2);
                                }
                            }
                            foreach (Class4 class2 in list3)
                            {
                                pair2.Value.method_2().Remove(class2);
                            }
                        }
                        if (pair2.Value.method_2().Count == 0)
                        {
                            list2.Add(pair2.Key);
                        }
                    }
                    foreach (string str in list2)
                    {
                        pair.Value.method_2().Remove(str);
                    }
                }
                if ((pair.Value.method_0().Target == null) || (pair.Value.method_2().Count == 0))
                {
                    list.Add(pair.Key);
                    if (pair.Value.method_0().Target != null)
                    {
                        INotifyPropertyChanged target = pair.Value.method_0().Target as INotifyPropertyChanged;
                        if (target != null)
                        {
                            target.PropertyChanged -= new PropertyChangedEventHandler(BindingEngine.smethod_0);
                        }
                    }
                }
            }
            foreach (int num in list)
            {
                dictionary_0.Remove(num);
            }
        }

        public static void ClearPropertyBinding<S, T, SP, TP>(this S source, T target, Expression<Func<S, SP>> sourceProperty, Expression<Func<T, TP>> targetProperty) where S: INotifyPropertyChanged
        {
            int hashCode = source.GetHashCode();
            if (dictionary_0.ContainsKey(hashCode))
            {
                Class2 class2 = dictionary_0[hashCode];
                if (class2.method_0().Target == source)
                {
                    Func<Class4, bool> predicate = null;
                    PropertyInfo propertyInfo = GetPropertyInfo<S, SP>(sourceProperty);
                    PropertyInfo tp = GetPropertyInfo<T, TP>(targetProperty);
                    Class3 class4 = null;
                    if (class2.method_2().ContainsKey(propertyInfo.Name))
                    {
                        class4 = class2.method_2()[propertyInfo.Name];
                        if (predicate == null)
                        {
                            <>c__DisplayClass4<S, T, SP, TP> class3;
                            predicate = new Func<Class4, bool>(class3, (IntPtr) this.<ClearPropertyBinding>b__2);
                        }
                        Class4 item = class4.method_2().FirstOrDefault<Class4>(predicate);
                        if (item != null)
                        {
                            class4.method_2().Remove(item);
                        }
                        if (class4.method_2().Count == 0)
                        {
                            class2.method_2().Remove(propertyInfo.Name);
                        }
                    }
                    if (class2.method_2().Count == 0)
                    {
                        dictionary_0.Remove(hashCode);
                        source.PropertyChanged -= new PropertyChangedEventHandler(BindingEngine.smethod_0);
                    }
                }
            }
        }

        public static PropertyInfo GetPropertyInfo<T, TR>(Expression<Func<T, TR>> select)
        {
            Expression body = select.Body;
            if (body.NodeType == ExpressionType.Convert)
            {
                return (((body as UnaryExpression).Operand as MemberExpression).Member as PropertyInfo);
            }
            if (body.NodeType == ExpressionType.MemberAccess)
            {
                return ((body as MemberExpression).Member as PropertyInfo);
            }
            return null;
        }

        public static void SetPropertyBinding<S, T, SP, TP>(this S source, T target, Expression<Func<S, SP>> sourceProperty, Expression<Func<T, TP>> targetProperty, Func<object, object> convert, bool rightAwayUpdate = true) where S: INotifyPropertyChanged
        {
            int hashCode = source.GetHashCode();
            Class2 class2 = null;
            if (!dictionary_0.ContainsKey(hashCode))
            {
                class2 = new Class2(source);
                dictionary_0.Add(hashCode, class2);
                source.PropertyChanged += new PropertyChangedEventHandler(BindingEngine.smethod_0);
            }
            else
            {
                class2 = dictionary_0[hashCode];
            }
            if (class2.method_0().Target != source)
            {
                throw new TargetException("相同的哈希值，但是对象不同！");
            }
            PropertyInfo propertyInfo = GetPropertyInfo<S, SP>(sourceProperty);
            PropertyInfo info2 = GetPropertyInfo<T, TP>(targetProperty);
            Class3 class3 = null;
            if (class2.method_2().ContainsKey(propertyInfo.Name))
            {
                class3 = class2.method_2()[propertyInfo.Name];
            }
            else
            {
                Class3 class4 = new Class3();
                class4.method_1(propertyInfo);
                class3 = class4;
                class2.method_2().Add(propertyInfo.Name, class3);
            }
            Class4 item = new Class4();
            item.method_1(new WeakReference(target));
            item.method_5(info2);
            item.method_3(convert);
            class3.method_2().Add(item);
            if (rightAwayUpdate)
            {
                smethod_0(source, new PropertyChangedEventArgs(propertyInfo.Name));
            }
        }

        private static void smethod_0(object sender, PropertyChangedEventArgs e)
        {
            int hashCode = sender.GetHashCode();
            if (dictionary_0.ContainsKey(hashCode))
            {
                Class2 class2 = dictionary_0[hashCode];
                if (class2.method_2().ContainsKey(e.PropertyName))
                {
                    Class3 class3 = class2.method_2()[e.PropertyName];
                    object obj2 = class3.method_0().GetValue(class2.method_0().Target, null);
                    List<Class4> list = null;
                    foreach (Class4 class4 in class3.method_2())
                    {
                        if (class4.method_0().Target != null)
                        {
                            if (class4.method_2() != null)
                            {
                                class4.method_4().SetValue(class4.method_0().Target, class4.method_2().Invoke(obj2), null);
                            }
                            else
                            {
                                class4.method_4().SetValue(class4.method_0().Target, obj2, null);
                            }
                        }
                        else
                        {
                            if (list == null)
                            {
                                list = new List<Class4>();
                            }
                            list.Add(class4);
                        }
                    }
                    if (list != null)
                    {
                        foreach (Class4 class4 in list)
                        {
                            class3.method_2().Remove(class4);
                        }
                    }
                }
            }
        }
    }
}

