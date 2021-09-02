namespace DSkin.Controls
{
    using System;
    using System.ComponentModel.Design;
    using System.Windows.Forms;

    public class DSkinTabPageCollectionEditor : CollectionEditor
    {
        public DSkinTabPageCollectionEditor(System.Type type) : base(type)
        {
        }

        protected override bool CanSelectMultipleInstances()
        {
            return true;
        }

        protected override object CreateInstance(System.Type itemType)
        {
            if (itemType == typeof(DSkinTabPage))
            {
                return new DSkinTabPage();
            }
            if (itemType == typeof(TabPage))
            {
                return new TabPage();
            }
            return null;
        }

        protected override System.Type[] CreateNewItemTypes()
        {
            return new System.Type[] { typeof(DSkinTabPage), typeof(TabPage) };
        }
    }
}

