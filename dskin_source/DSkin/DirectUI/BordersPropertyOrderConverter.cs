namespace DSkin.DirectUI
{
    using System;
    using System.ComponentModel;

    public class BordersPropertyOrderConverter : ExpandableObjectConverter
    {
        public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] attributes)
        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(Borders), attributes);
            string[] names = new string[] { "TopWidth", "TopColor", "BottomWidth", "BottomColor", "LeftWidth", "LeftColor", "RightWidth", "RightColor" };
            return properties.Sort(names);
        }

        public override bool GetPropertiesSupported(ITypeDescriptorContext context)
        {
            return true;
        }
    }
}

