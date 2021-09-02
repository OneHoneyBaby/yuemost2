namespace DSkin.Controls
{
    using DSkin.Common;
    using System;
    using System.Runtime.CompilerServices;

    public static class GlEx
    {
        public static void AddRow(this Collection<DSkinGridListRow> rows, params object[] values)
        {
            DSkinGridListRow row = new DSkinGridListRow();
            DSkinGridList tag = rows.Tag as DSkinGridList;
            if (values != null)
            {
                int num = 0;
                foreach (object obj2 in values)
                {
                    DSkinGridListCell cell2 = new DSkinGridListCell {
                        Value = obj2
                    };
                    if ((tag != null) && (num < tag.Columns.Count))
                    {
                        cell2.DockStyle = tag.Columns[num].DockStyle;
                        cell2.ItemType = tag.Columns[num].ItemType;
                        cell2.ForeColor = tag.ForeColor;
                        cell2.Font = tag.Font;
                        cell2.Template = tag.Columns[num].CellTemplate;
                    }
                    row.Cells.Add(cell2);
                    num++;
                }
            }
            row.Height = tag.RowHeight;
            rows.Add(row);
        }
    }
}

