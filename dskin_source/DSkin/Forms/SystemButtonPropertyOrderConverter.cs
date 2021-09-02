namespace DSkin.Forms
{
    using System;
    using System.ComponentModel;

    public class SystemButtonPropertyOrderConverter : ExpandableObjectConverter
    {
        public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] attributes)
        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(SystemButton), attributes);
            string[] names = new string[] { "NormalImage", "HoverImage", "PressImage", "ForeColor", "NormalBackColor", "HoverBackColor", "PressBackColor" };
            return properties.Sort(names);
        }

        public override bool GetPropertiesSupported(ITypeDescriptorContext context)
        {
            return true;
        }
    }
}

