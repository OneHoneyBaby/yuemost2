namespace DSkin.Common
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Reflection.Emit;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    public static class ObjectCopy
    {
        private static Dictionary<Type, Func<object, Dictionary<Struct0, object>, object>> dictionary_0 = new Dictionary<Type, Func<object, Dictionary<Struct0, object>, object>>();
        private static Dictionary<Type, Action<object, Dictionary<Struct0, object>, object>> epGmRgcyc9 = new Dictionary<Type, Action<object, Dictionary<Struct0, object>, object>>();

        public static void ObjectCopyTo<T>(this T source, T target) where T: class
        {
            Action<object, Dictionary<Struct0, object>, object> action;
            if (target == null)
            {
                throw new Exception("将要复制的目标未初始化");
            }
            Type key = source.GetType();
            if (key != target.GetType())
            {
                throw new Exception("要复制的对象类型不同，无法复制");
            }
            Dictionary<Struct0, object> dictionary = new Dictionary<Struct0, object>();
            dictionary.Add(new Struct0(source.GetHashCode(), key.TypeHandle), source);
            if (!epGmRgcyc9.TryGetValue(key, out action))
            {
                action = smethod_2(key, dictionary);
                epGmRgcyc9.Add(key, action);
            }
            action.Invoke(source, dictionary, target);
        }

        private static List<FieldInfo> smethod_0(Type type_0)
        {
            return type_0.GetFields(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance).smethod_4();
        }

        private static Func<object, Dictionary<Struct0, object>, object> smethod_1(Type type_0, Dictionary<Struct0, object> dictionary_1)
        {
            // This item is obfuscated and can not be translated.
            List<FieldInfo> list = smethod_0(type_0);
            DynamicMethod method = new DynamicMethod(string.Format("Clone{0}", Guid.NewGuid()), typeof(object), new Type[] { typeof(object), typeof(Dictionary<Struct0, object>) }, true);
            ILGenerator iLGenerator = method.GetILGenerator();
            iLGenerator.DeclareLocal(type_0);
            iLGenerator.DeclareLocal(type_0);
            iLGenerator.DeclareLocal(typeof(Struct0));
            if (type_0.IsArray)
            {
                Type elementType = type_0.GetElementType();
                LocalBuilder local = iLGenerator.DeclareLocal(typeof(int));
                Label label = iLGenerator.DefineLabel();
                Label loc = iLGenerator.DefineLabel();
                iLGenerator.Emit(OpCodes.Ldarg_0);
                iLGenerator.Emit(OpCodes.Castclass, type_0);
                iLGenerator.Emit(OpCodes.Dup);
                iLGenerator.Emit(OpCodes.Stloc_0);
                iLGenerator.Emit(OpCodes.Ldlen);
                iLGenerator.Emit(OpCodes.Dup);
                iLGenerator.Emit(OpCodes.Ldc_I4_1);
                iLGenerator.Emit(OpCodes.Sub);
                iLGenerator.Emit(OpCodes.Stloc, local);
                iLGenerator.Emit(OpCodes.Newarr, elementType);
                iLGenerator.Emit(OpCodes.Dup);
                iLGenerator.Emit(OpCodes.Stloc_1);
                iLGenerator.Emit(OpCodes.Ldloca_S, 2);
                iLGenerator.Emit(OpCodes.Ldloc_0);
                iLGenerator.Emit(OpCodes.Callvirt, typeof(object).GetMethod("GetHashCode"));
                iLGenerator.Emit(OpCodes.Ldtoken, type_0);
                iLGenerator.Emit(OpCodes.Call, typeof(Struct0).GetConstructor(BindingFlags.Public | BindingFlags.Instance, null, new Type[] { typeof(int), typeof(RuntimeTypeHandle) }, null));
                iLGenerator.Emit(OpCodes.Ldarg_1);
                iLGenerator.Emit(OpCodes.Ldloc_2);
                iLGenerator.Emit(OpCodes.Ldloc_1);
                iLGenerator.Emit(OpCodes.Callvirt, typeof(Dictionary<Struct0, object>).GetMethod("Add"));
                iLGenerator.Emit(OpCodes.Ldloc, local);
                iLGenerator.Emit(OpCodes.Br, label);
                iLGenerator.MarkLabel(loc);
                iLGenerator.Emit(OpCodes.Dup);
                iLGenerator.Emit(OpCodes.Ldloc, local);
                iLGenerator.Emit(OpCodes.Ldloc_0);
                iLGenerator.Emit(OpCodes.Ldloc, local);
                iLGenerator.Emit(OpCodes.Ldelem, elementType);
                if (!(elementType.IsValueType || (elementType == typeof(string))))
                {
                    iLGenerator.EmitCall(OpCodes.Call, typeof(ObjectCopy).GetMethod("CopyImpl", BindingFlags.NonPublic | BindingFlags.Static).MakeGenericMethod(new Type[] { elementType }), null);
                }
                iLGenerator.Emit(OpCodes.Stelem, elementType);
                iLGenerator.Emit(OpCodes.Ldloc, local);
                iLGenerator.Emit(OpCodes.Ldc_I4_1);
                iLGenerator.Emit(OpCodes.Sub);
                iLGenerator.Emit(OpCodes.Dup);
                iLGenerator.Emit(OpCodes.Stloc, local);
                iLGenerator.MarkLabel(label);
                iLGenerator.Emit(OpCodes.Ldc_I4_0);
                iLGenerator.Emit(OpCodes.Clt);
                iLGenerator.Emit(OpCodes.Brfalse, loc);
            }
            else
            {
                Type type;
                iLGenerator.Emit(OpCodes.Newobj, type_0.GetConstructor(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance, null, Type.EmptyTypes, null));
                iLGenerator.Emit(OpCodes.Dup);
                iLGenerator.Emit(OpCodes.Stloc_1);
                iLGenerator.Emit(OpCodes.Ldloca_S, 2);
                iLGenerator.Emit(OpCodes.Ldarg_0);
                iLGenerator.Emit(OpCodes.Castclass, type_0);
                iLGenerator.Emit(OpCodes.Dup);
                iLGenerator.Emit(OpCodes.Stloc_0);
                iLGenerator.Emit(OpCodes.Callvirt, typeof(object).GetMethod("GetHashCode"));
                iLGenerator.Emit(OpCodes.Ldtoken, type_0);
                iLGenerator.Emit(OpCodes.Call, typeof(Struct0).GetConstructor(BindingFlags.Public | BindingFlags.Instance, null, new Type[] { typeof(int), typeof(RuntimeTypeHandle) }, null));
                iLGenerator.Emit(OpCodes.Ldarg_1);
                iLGenerator.Emit(OpCodes.Ldloc_2);
                iLGenerator.Emit(OpCodes.Ldloc_1);
                iLGenerator.Emit(OpCodes.Callvirt, typeof(Dictionary<Struct0, object>).GetMethod("Add"));
                foreach (FieldInfo info in list)
                {
                    if (!info.FieldType.IsValueType && (info.FieldType != typeof(string)))
                    {
                        if (!((!info.FieldType.IsArray || ((info.FieldType.GetArrayRank() <= 1) && (((type = info.FieldType.GetElementType()).IsValueType || (type == typeof(string))) || (type.GetConstructor(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance, null, Type.EmptyTypes, null) != null)))) ? (info.FieldType.IsArray || (info.FieldType.GetConstructor(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance, null, Type.EmptyTypes, null) != null)) : false))
                        {
                            break;
                        }
                        iLGenerator.Emit(OpCodes.Ldloc_1);
                        iLGenerator.Emit(OpCodes.Ldloc_0);
                        iLGenerator.Emit(OpCodes.Ldfld, info);
                        iLGenerator.Emit(OpCodes.Ldarg_1);
                        iLGenerator.EmitCall(OpCodes.Call, typeof(ObjectCopy).GetMethod("CopyImpl", BindingFlags.NonPublic | BindingFlags.Static).MakeGenericMethod(new Type[] { info.FieldType }), null);
                        iLGenerator.Emit(OpCodes.Stfld, info);
                    }
                    else
                    {
                        iLGenerator.Emit(OpCodes.Ldloc_1);
                        iLGenerator.Emit(OpCodes.Ldloc_0);
                        iLGenerator.Emit(OpCodes.Ldfld, info);
                        iLGenerator.Emit(OpCodes.Stfld, info);
                    }
                }
                type_0 = type_0.BaseType;
                while (type_0 == null)
                {
                Label_034A:
                    if (0 == 0)
                    {
                        goto Label_07CF;
                    }
                    foreach (FieldInfo info in type_0.GetFields(BindingFlags.NonPublic | BindingFlags.Instance).smethod_4())
                    {
                        if (!info.FieldType.IsValueType && (info.FieldType != typeof(string)))
                        {
                            if (!((!info.FieldType.IsArray || ((info.FieldType.GetArrayRank() <= 1) && (((type = info.FieldType.GetElementType()).IsValueType || (type == typeof(string))) || (type.GetConstructor(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance, null, Type.EmptyTypes, null) != null)))) ? (info.FieldType.IsArray || (info.FieldType.GetConstructor(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance, null, Type.EmptyTypes, null) != null)) : false))
                            {
                                break;
                            }
                            iLGenerator.Emit(OpCodes.Ldloc_1);
                            iLGenerator.Emit(OpCodes.Ldloc_0);
                            iLGenerator.Emit(OpCodes.Ldfld, info);
                            iLGenerator.Emit(OpCodes.Ldarg_1);
                            iLGenerator.EmitCall(OpCodes.Call, typeof(ObjectCopy).GetMethod("CopyImpl", BindingFlags.NonPublic | BindingFlags.Static).MakeGenericMethod(new Type[] { info.FieldType }), null);
                            iLGenerator.Emit(OpCodes.Stfld, info);
                        }
                        else
                        {
                            iLGenerator.Emit(OpCodes.Ldloc_1);
                            iLGenerator.Emit(OpCodes.Ldloc_0);
                            iLGenerator.Emit(OpCodes.Ldfld, info);
                            iLGenerator.Emit(OpCodes.Stfld, info);
                        }
                    }
                    type_0 = type_0.BaseType;
                }
                goto Label_034A;
            }
        Label_07CF:
            iLGenerator.Emit(OpCodes.Ret);
            return (Func<object, Dictionary<Struct0, object>, object>) method.CreateDelegate(typeof(Func<object, Dictionary<Struct0, object>, object>));
        }

        private static Action<object, Dictionary<Struct0, object>, object> smethod_2(Type type_0, Dictionary<Struct0, object> dictionary_1)
        {
            // This item is obfuscated and can not be translated.
            List<FieldInfo> list = smethod_0(type_0);
            DynamicMethod method = new DynamicMethod(string.Format("Copy{0}", Guid.NewGuid()), null, new Type[] { typeof(object), typeof(Dictionary<Struct0, object>), typeof(object) }, true);
            ILGenerator iLGenerator = method.GetILGenerator();
            iLGenerator.DeclareLocal(type_0);
            iLGenerator.DeclareLocal(type_0);
            iLGenerator.DeclareLocal(typeof(Struct0));
            if (type_0.IsArray)
            {
                Type elementType = type_0.GetElementType();
                LocalBuilder local = iLGenerator.DeclareLocal(typeof(int));
                Label label = iLGenerator.DefineLabel();
                Label loc = iLGenerator.DefineLabel();
                iLGenerator.Emit(OpCodes.Ldarg_0);
                iLGenerator.Emit(OpCodes.Castclass, type_0);
                iLGenerator.Emit(OpCodes.Dup);
                iLGenerator.Emit(OpCodes.Stloc_0);
                iLGenerator.Emit(OpCodes.Ldlen);
                iLGenerator.Emit(OpCodes.Dup);
                iLGenerator.Emit(OpCodes.Ldc_I4_1);
                iLGenerator.Emit(OpCodes.Sub);
                iLGenerator.Emit(OpCodes.Stloc, local);
                iLGenerator.Emit(OpCodes.Ldarg_2);
                iLGenerator.Emit(OpCodes.Castclass, type_0);
                iLGenerator.Emit(OpCodes.Dup);
                iLGenerator.Emit(OpCodes.Stloc_1);
                iLGenerator.Emit(OpCodes.Ldloc, local);
                iLGenerator.Emit(OpCodes.Br, label);
                iLGenerator.MarkLabel(loc);
                iLGenerator.Emit(OpCodes.Dup);
                iLGenerator.Emit(OpCodes.Ldloc, local);
                iLGenerator.Emit(OpCodes.Ldloc_0);
                iLGenerator.Emit(OpCodes.Ldloc, local);
                iLGenerator.Emit(OpCodes.Ldelem, elementType);
                if (!(elementType.IsValueType || (elementType == typeof(string))))
                {
                    iLGenerator.EmitCall(OpCodes.Call, typeof(ObjectCopy).GetMethod("CopyImpl", BindingFlags.NonPublic | BindingFlags.Static).MakeGenericMethod(new Type[] { elementType }), null);
                }
                iLGenerator.Emit(OpCodes.Stelem, elementType);
                iLGenerator.Emit(OpCodes.Ldloc, local);
                iLGenerator.Emit(OpCodes.Ldc_I4_1);
                iLGenerator.Emit(OpCodes.Sub);
                iLGenerator.Emit(OpCodes.Dup);
                iLGenerator.Emit(OpCodes.Stloc, local);
                iLGenerator.MarkLabel(label);
                iLGenerator.Emit(OpCodes.Ldc_I4_0);
                iLGenerator.Emit(OpCodes.Clt);
                iLGenerator.Emit(OpCodes.Brfalse, loc);
            }
            else
            {
                Type type;
                iLGenerator.Emit(OpCodes.Ldarg_2);
                iLGenerator.Emit(OpCodes.Castclass, type_0);
                iLGenerator.Emit(OpCodes.Stloc_1);
                iLGenerator.Emit(OpCodes.Ldarg_0);
                iLGenerator.Emit(OpCodes.Castclass, type_0);
                iLGenerator.Emit(OpCodes.Stloc_0);
                foreach (FieldInfo info in list)
                {
                    if (!info.FieldType.IsValueType && (info.FieldType != typeof(string)))
                    {
                        if (!((!info.FieldType.IsArray || ((info.FieldType.GetArrayRank() <= 1) && (((type = info.FieldType.GetElementType()).IsValueType || (type == typeof(string))) || (type.GetConstructor(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance, null, Type.EmptyTypes, null) != null)))) ? (info.FieldType.IsArray || (info.FieldType.GetConstructor(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance, null, Type.EmptyTypes, null) != null)) : false))
                        {
                            break;
                        }
                        iLGenerator.Emit(OpCodes.Ldloc_1);
                        iLGenerator.Emit(OpCodes.Ldloc_0);
                        iLGenerator.Emit(OpCodes.Ldfld, info);
                        iLGenerator.Emit(OpCodes.Ldarg_1);
                        iLGenerator.EmitCall(OpCodes.Call, typeof(ObjectCopy).GetMethod("CopyImpl", BindingFlags.NonPublic | BindingFlags.Static).MakeGenericMethod(new Type[] { info.FieldType }), null);
                        iLGenerator.Emit(OpCodes.Stfld, info);
                    }
                    else
                    {
                        iLGenerator.Emit(OpCodes.Ldloc_1);
                        iLGenerator.Emit(OpCodes.Ldloc_0);
                        iLGenerator.Emit(OpCodes.Ldfld, info);
                        iLGenerator.Emit(OpCodes.Stfld, info);
                    }
                }
                type_0 = type_0.BaseType;
                while (type_0 == null)
                {
                Label_027A:
                    if (0 == 0)
                    {
                        goto Label_0643;
                    }
                    foreach (FieldInfo info in type_0.GetFields(BindingFlags.NonPublic | BindingFlags.Instance).smethod_4())
                    {
                        if (!info.FieldType.IsValueType && (info.FieldType != typeof(string)))
                        {
                            if (!((!info.FieldType.IsArray || ((info.FieldType.GetArrayRank() <= 1) && (((type = info.FieldType.GetElementType()).IsValueType || (type == typeof(string))) || (type.GetConstructor(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance, null, Type.EmptyTypes, null) != null)))) ? (info.FieldType.IsArray || (info.FieldType.GetConstructor(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance, null, Type.EmptyTypes, null) != null)) : false))
                            {
                                break;
                            }
                            iLGenerator.Emit(OpCodes.Ldloc_1);
                            iLGenerator.Emit(OpCodes.Ldloc_0);
                            iLGenerator.Emit(OpCodes.Ldfld, info);
                            iLGenerator.Emit(OpCodes.Ldarg_1);
                            iLGenerator.EmitCall(OpCodes.Call, typeof(ObjectCopy).GetMethod("CopyImpl", BindingFlags.NonPublic | BindingFlags.Static).MakeGenericMethod(new Type[] { info.FieldType }), null);
                            iLGenerator.Emit(OpCodes.Stfld, info);
                        }
                        else
                        {
                            iLGenerator.Emit(OpCodes.Ldloc_1);
                            iLGenerator.Emit(OpCodes.Ldloc_0);
                            iLGenerator.Emit(OpCodes.Ldfld, info);
                            iLGenerator.Emit(OpCodes.Stfld, info);
                        }
                    }
                    type_0 = type_0.BaseType;
                }
                goto Label_027A;
            }
        Label_0643:
            iLGenerator.Emit(OpCodes.Ret);
            return (Action<object, Dictionary<Struct0, object>, object>) method.CreateDelegate(typeof(Action<object, Dictionary<Struct0, object>, object>));
        }

        private static eEOAkPtWLqHtfYY6ON smethod_3<eEOAkPtWLqHtfYY6ON>(eEOAkPtWLqHtfYY6ON b9fwJSj8ylfH4LpIN1, Dictionary<Struct0, object> dictionary_1) where eEOAkPtWLqHtfYY6ON: class
        {
            object obj2;
            if (b9fwJSj8ylfH4LpIN1 == null)
            {
                return default(eEOAkPtWLqHtfYY6ON);
            }
            Type key = b9fwJSj8ylfH4LpIN1.GetType();
            Struct0 struct2 = new Struct0(b9fwJSj8ylfH4LpIN1.GetHashCode(), key.TypeHandle);
            if (!dictionary_1.TryGetValue(struct2, out obj2))
            {
                Func<object, Dictionary<Struct0, object>, object> func;
                if (!dictionary_0.TryGetValue(key, out func))
                {
                    func = smethod_1(key, dictionary_1);
                    dictionary_0.Add(key, func);
                }
                obj2 = func.Invoke(b9fwJSj8ylfH4LpIN1, dictionary_1);
            }
            return (eEOAkPtWLqHtfYY6ON) obj2;
        }

        private static List<FieldInfo> smethod_4(this FieldInfo[] fieldInfo_0)
        {
            List<FieldInfo> list = new List<FieldInfo>();
            foreach (FieldInfo info in fieldInfo_0)
            {
                list.Add(info);
            }
            return list;
        }

        public static T ToObjectCopy<T>(this T source) where T: class
        {
            Func<object, Dictionary<Struct0, object>, object> func;
            Type key = source.GetType();
            Dictionary<Struct0, object> dictionary = new Dictionary<Struct0, object>();
            if (!dictionary_0.TryGetValue(key, out func))
            {
                func = smethod_1(key, dictionary);
                dictionary_0.Add(key, func);
            }
            return (T) func.Invoke(source, dictionary);
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct Struct0
        {
            private int int_0;
            private RuntimeTypeHandle runtimeTypeHandle_0;
            public Struct0(int int_1, RuntimeTypeHandle runtimeTypeHandle_1)
            {
                this.int_0 = int_1;
                this.runtimeTypeHandle_0 = runtimeTypeHandle_1;
            }
        }
    }
}

