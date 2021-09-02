namespace DSkin.Controls
{
    using System.Windows.Forms.Design;

    public class ColorBoxDesginer : ControlDesigner
    {
        public override System.Windows.Forms.Design.SelectionRules SelectionRules
        {
            get
            {
                return (base.SelectionRules & ~System.Windows.Forms.Design.SelectionRules.AllSizeable);
            }
        }
    }
}

