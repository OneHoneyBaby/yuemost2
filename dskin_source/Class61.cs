using DSkin.Forms;
using System;
using System.ComponentModel.Design;
using System.Drawing;

internal class Class61 : CollectionEditor
{
    public Class61(Type type_0) : base(type_0)
    {
    }

    protected override object CreateInstance(Type itemType)
    {
        return new SystemButton { NormalBackColor = Color.FromArgb(50, 100, 100, 100) };
    }
}

