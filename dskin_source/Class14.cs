using DSkin.Controls;
using DSkin.DirectUI;
using System;
using System.Collections.Generic;

internal class Class14 : IComparer<DuiBaseControl>
{
    private bool bool_0 = false;
    private int int_0 = 0;

    public Class14(int int_1, bool bool_1)
    {
        this.int_0 = int_1;
        this.bool_0 = bool_1;
    }

    public int Compare(DuiBaseControl x, DuiBaseControl y)
    {
        DSkinGridListRow tag = x.Tag as DSkinGridListRow;
        DSkinGridListRow row2 = y.Tag as DSkinGridListRow;
        if ((tag != null) && (row2 != null))
        {
            object obj2 = tag.Cells[this.int_0].Value;
            object obj3 = row2.Cells[this.int_0].Value;
            if ((obj2 != null) && (obj3 != null))
            {
                if (obj2.GetType().IsValueType)
                {
                    return (this.bool_0 ? ((int) (Convert.ToDouble(obj3) - Convert.ToDouble(obj2))) : ((int) (Convert.ToDouble(obj2) - Convert.ToDouble(obj3))));
                }
                return (this.bool_0 ? string.Compare(obj3.ToString(), obj2.ToString()) : string.Compare(obj2.ToString(), obj3.ToString()));
            }
        }
        return 0;
    }
}

