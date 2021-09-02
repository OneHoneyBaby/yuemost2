using DSkin.DirectUI.Transform;
using System;
using System.ComponentModel.Design;

internal class Class59 : CollectionEditor
{
    public Class59(Type type_0) : base(type_0)
    {
    }

    protected override bool CanSelectMultipleInstances()
    {
        return true;
    }

    protected override Type[] CreateNewItemTypes()
    {
        return new Type[] { typeof(ScaleTransform), typeof(ShearTransform), typeof(RotateTransform), typeof(TranslateTransform) };
    }
}

