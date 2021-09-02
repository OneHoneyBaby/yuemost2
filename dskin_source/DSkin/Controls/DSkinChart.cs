namespace DSkin.Controls
{
    using DSkin.Common;
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Drawing.Text;
    using System.Threading;
    using System.Windows.Forms;

    public class DSkinChart : DSkinBaseControl
    {
        private AppearanceStyles appearanceStyles_0 = AppearanceStyles.Bar_2D_Aurora_FlatCrystal_Glow_NoBorder;
        private Attributes attributes_0;
        private Attributes attributes_1;
        public Color[] Aurora;
        private AxisAttributes axisAttributes_0;
        private BackgroundAttributes backgroundAttributes_0;
        public Color[] BarBrushColor;
        public Color[] BarPenColor;
        private bool bool_0 = false;
        private bool bool_1 = true;
        private bool bool_2 = true;
        private bool bool_3 = true;
        private bool bool_4 = false;
        public Color[] Breeze;
        private byte byte_0 = 0xff;
        private ChartDimensions chartDimensions_0 = ChartDimensions.Chart2D;
        private ChartTypes chartTypes_0 = ChartTypes.Bar;
        private CrystalAttributes crystalAttributes_0;
        private decimal[][] decimal_0;
        private double double_0 = 0.0;
        private double double_1 = -0.830213;
        private double double_2 = 0.0;
        private float[][] float_0;
        private float float_1 = 100f;
        private float float_2 = 0f;
        private float float_3 = 0f;
        private int int_0 = 0;
        private int int_1 = 2;
        private int int_2 = 10;
        private int int_3 = 10;
        private int int_4 = 0;
        private int int_5 = 0;
        private int int_6 = 0;
        private int int_7 = 0;
        private int int_8 = 0;
        private int int_9 = 0;
        private string[] kUitoNvjqx = null;
        private LineConnectionTypes lineConnectionTypes_0 = LineConnectionTypes.Round;
        private string[] mHytfDhuET;
        private object object_0;
        private Painting painting_0;
        private ShadowAttributes shadowAttributes_0;
        private SpecLineAttributes specLineAttributes_0;
        public Color[] StarryNight;
        private string[] string_0;
        private string string_1;
        private string string_2;
        private string string_3;
        private string string_4;
        private string string_5;
        private StrokeStyle strokeStyle_0;
        private TextAttributes textAttributes_0;
        private TextRenderingHint textRenderingHint_0 = TextRenderingHint.SystemDefault;
        private TrendAttributes trendAttributes_0;
        private XAxisAttributes xaxisAttributes_0;

        public event EventHandler DataSourceChanged;

        public DSkinChart()
        {
            Color[] colorArray = new Color[] { Color.FromArgb(0xff, 0xd6, 0xa6, 0xe7), Color.FromArgb(0xff, 0x7f, 0xb8, 210), Color.FromArgb(0xff, 0xe7, 0xd8, 0xa6), Color.FromArgb(0xff, 180, 0xa6, 0xe7), Color.FromArgb(0xff, 0xb5, 0xe7, 0xa6), Color.FromArgb(0xff, 0xe7, 0xa6, 0xa6), Color.FromArgb(0xff, 180, 0xa6, 0xe7), Color.FromArgb(0xff, 0xc6, 0xe7, 0xa6), Color.FromArgb(0xff, 0xe7, 0xa6, 0xe2), Color.FromArgb(0xff, 0xcd, 0xb5, 0x9d), Color.FromArgb(0xff, 0x9d, 0xcd, 200), Color.FromArgb(0xff, 0xde, 0xde, 0xde) };
            this.BarBrushColor = colorArray;
            colorArray = new Color[] { Color.FromArgb(0xff, 120, 0x87, 0x88), Color.FromArgb(0xff, 120, 0x87, 0x88), Color.FromArgb(0xff, 120, 0x87, 0x88), Color.FromArgb(0xff, 120, 0x87, 0x88), Color.FromArgb(0xff, 120, 0x87, 0x88), Color.FromArgb(0xff, 120, 0x87, 0x88), Color.FromArgb(0xff, 120, 0x87, 0x88), Color.FromArgb(0xff, 120, 0x87, 0x88), Color.FromArgb(0xff, 120, 0x87, 0x88), Color.FromArgb(0xff, 120, 0x87, 0x88), Color.FromArgb(0xff, 120, 0x87, 0x88), Color.FromArgb(0xff, 120, 0x87, 0x88) };
            this.BarPenColor = colorArray;
            colorArray = new Color[] { Color.FromArgb(0xff, 0xd6, 0xa6, 0xe7), Color.FromArgb(0xff, 0x7f, 0xb8, 210), Color.FromArgb(0xff, 0xe7, 0xd8, 0xa6), Color.FromArgb(0xff, 180, 0xa6, 0xe7), Color.FromArgb(0xff, 0xb5, 0xe7, 0xa6), Color.FromArgb(0xff, 0xe7, 0xa6, 0xa6), Color.FromArgb(0xff, 180, 0xa6, 0xe7), Color.FromArgb(0xff, 0xc6, 0xe7, 0xa6), Color.FromArgb(0xff, 0xe7, 0xa6, 0xe2), Color.FromArgb(0xff, 0xcd, 0xb5, 0x9d), Color.FromArgb(0xff, 0x9d, 0xcd, 200), Color.FromArgb(0xff, 0xde, 0xde, 0xde) };
            this.Breeze = colorArray;
            colorArray = new Color[] { Color.FromArgb(0xff, 0x19, 0xca, 0x2d), Color.FromArgb(0xff, 0xf4, 0x20, 0x20), Color.FromArgb(0xff, 0x25, 0x20, 0xf2), Color.FromArgb(0xff, 240, 0x20, 0xf2), Color.FromArgb(0xff, 240, 0xf2, 0x20), Color.FromArgb(0xff, 0x20, 0xf2, 0xeb), Color.FromArgb(0xff, 0xf2, 0x97, 0x20), Color.FromArgb(0xff, 0x92, 0xf2, 0x20), Color.FromArgb(0xff, 0x92, 0x20, 0xf2), Color.FromArgb(0xff, 0x20, 0x83, 0xf2), Color.FromArgb(0xff, 0xf2, 0x65, 0x20), Color.FromArgb(0xff, 0x16, 0x99, 0xf5) };
            this.Aurora = colorArray;
            colorArray = new Color[] { Color.FromArgb(0xff, 0x57, 14, 0x4e), Color.FromArgb(0xff, 0x57, 0x37, 14), Color.FromArgb(0xff, 14, 60, 0x57), Color.FromArgb(0xff, 0x57, 0x23, 14), Color.FromArgb(0xff, 0x29, 0x57, 14), Color.FromArgb(0xff, 60, 14, 0x57), Color.FromArgb(0xff, 0x57, 14, 14), Color.FromArgb(0xff, 0x2b, 14, 0x57), Color.FromArgb(0xff, 14, 0x56, 0x57), Color.FromArgb(0xff, 0x3e, 0x57, 14), Color.FromArgb(0xff, 0x3d, 3, 0x38), Color.FromArgb(0xff, 3, 0x21, 0x3d) };
            this.StarryNight = colorArray;
            this.string_1 = "";
            this.string_2 = "";
            this.string_3 = "";
            this.string_4 = "";
            this.string_5 = "";
            this.Breeze.CopyTo(this.BarBrushColor, 0);
            this.ChartTitle.Text = "DSkinChart";
            this.ChartTitle.Font = new Font("Arial", 16f, FontStyle.Bold, GraphicsUnit.Pixel);
            this.ChartTitle.ForeColor = Color.DarkBlue;
            this.XAxis.UnitText = "XAxis";
            this.YAxis.UnitText = "YAxis";
        }

        public void BindChartData(DataSet DataSource)
        {
            if (DataSource != null)
            {
                this.BindChartData(DataSource.Tables[0]);
                DataSource.Dispose();
            }
        }

        public void BindChartData(DataTable DataSource)
        {
            if (DataSource != null)
            {
                ArrayList[] chartData = new ArrayList[DataSource.Columns.Count - 1];
                ArrayList xLabel = new ArrayList();
                ArrayList colorGuider = new ArrayList();
                if (this.XAxis.UnitText == "XAxis")
                {
                    this.XAxis.UnitText = DataSource.Columns[0].ColumnName;
                }
                int num = 0;
                while (num < DataSource.Rows.Count)
                {
                    xLabel.Add(DataSource.Rows[num][0].ToString());
                    num++;
                }
                for (int i = 0; i < (DataSource.Columns.Count - 1); i++)
                {
                    chartData[i] = new ArrayList();
                    for (num = 0; num < DataSource.Rows.Count; num++)
                    {
                        chartData[i].Add(DataSource.Rows[num][i + 1].ToString());
                    }
                    colorGuider.Add(DataSource.Columns[i + 1].ColumnName);
                }
                this.InitializeData(chartData, xLabel, colorGuider);
                DataSource.Dispose();
            }
        }

        public void BindChartData(DataView DataSource)
        {
            if (DataSource != null)
            {
                IList[] chartData = new ArrayList[DataSource.Table.Columns.Count - 1];
                IList xLabel = new ArrayList();
                IList colorGuider = new ArrayList();
                if (this.XAxis.UnitText == "XAxis")
                {
                    this.XAxis.UnitText = DataSource.Table.Columns[0].ColumnName;
                }
                int num2 = 0;
                while (num2 < DataSource.Table.Rows.Count)
                {
                    xLabel.Add(DataSource[num2][0].ToString());
                    num2++;
                }
                for (int i = 0; i < (DataSource.Table.Columns.Count - 1); i++)
                {
                    chartData[i] = new ArrayList();
                    for (num2 = 0; num2 < DataSource.Table.Rows.Count; num2++)
                    {
                        chartData[i].Add(DataSource[num2][i + 1].ToString());
                    }
                    colorGuider.Add(DataSource.Table.Columns[i + 1].ColumnName);
                }
                this.InitializeData(chartData, xLabel, colorGuider);
                DataSource.Dispose();
            }
        }

        public void InitializeData(IList[] ChartData, IList XLabel, IList ColorGuider)
        {
            int groupSize;
            int num8;
            int num10;
            switch (this.Fill.ColorStyle)
            {
                case ColorStyles.Breeze:
                    this.Breeze.CopyTo(this.BarBrushColor, 0);
                    break;

                case ColorStyles.Aurora:
                    this.Aurora.CopyTo(this.BarBrushColor, 0);
                    break;

                case ColorStyles.StarryNight:
                    this.StarryNight.CopyTo(this.BarBrushColor, 0);
                    break;
            }
            switch (this.Stroke.ColorStyle)
            {
                case ColorStyles.Breeze:
                    this.Breeze.CopyTo(this.BarPenColor, 0);
                    break;

                case ColorStyles.Aurora:
                    this.Aurora.CopyTo(this.BarPenColor, 0);
                    break;

                case ColorStyles.StarryNight:
                    this.StarryNight.CopyTo(this.BarPenColor, 0);
                    break;
            }
            if (!this.Fill.Color1.IsEmpty)
            {
                this.BarBrushColor[0] = this.Fill.Color1;
            }
            if (!this.Fill.Color2.IsEmpty)
            {
                this.BarBrushColor[1] = this.Fill.Color2;
            }
            if (!this.Fill.Color3.IsEmpty)
            {
                this.BarBrushColor[2] = this.Fill.Color3;
            }
            if (!this.Stroke.Color1.IsEmpty)
            {
                this.BarPenColor[0] = this.Stroke.Color1;
            }
            if (!this.Stroke.Color2.IsEmpty)
            {
                this.BarPenColor[1] = this.Stroke.Color2;
            }
            if (!this.Stroke.Color3.IsEmpty)
            {
                this.BarPenColor[2] = this.Stroke.Color3;
            }
            int num2 = (base.Height + this.InflateBottom) + this.InflateTop;
            int num3 = 60;
            int num4 = (((num2 - 60) - 40) - this.InflateBottom) - this.InflateTop;
            if (!this.ChartTitle.Show)
            {
                num4 += num3 - 0x1b;
                num3 = 0x1b;
            }
            if (base.DesignMode && (this.object_0 == null))
            {
                ChartData = new ArrayList[] { new ArrayList() };
                if (this.kUitoNvjqx != null)
                {
                    Random random = new Random();
                    for (num10 = 0; num10 < this.kUitoNvjqx.Length; num10++)
                    {
                        ChartData[0].Add(random.Next(100));
                    }
                }
            }
            if (ChartData == null)
            {
                goto Label_04DF;
            }
            int length = ChartData.Length;
            if ((this.GroupSize == 0) || (this.GroupSize > length))
            {
                this.GroupSize = length;
            }
            float[] numArray3 = new float[length];
            for (int i = 0; i < length; i++)
            {
                numArray3[i] = ChartData[i].Count;
            }
            this.int_9 = (int) this.method_6(numArray3);
            this.int_8 = (int) this.method_8(numArray3);
            this.decimal_0 = new decimal[length][];
            int index = 0;
        Label_0320:
            if (index < length)
            {
                this.decimal_0[index] = new decimal[this.int_9];
                int num6 = 0;
                while (true)
                {
                    if (num6 < this.int_9)
                    {
                        if (ChartData[index] != null)
                        {
                            try
                            {
                                this.decimal_0[index][num6] = decimal.Parse(ChartData[index][num6].ToString());
                            }
                            catch (Exception)
                            {
                                this.decimal_0[index][num6] = -0.830213M;
                            }
                        }
                        else
                        {
                            this.decimal_0[index][num6] = -0.830213M;
                        }
                    }
                    else
                    {
                        index++;
                        goto Label_0320;
                    }
                    num6++;
                }
            }
            this.string_0 = new string[this.int_9];
            if (XLabel != null)
            {
                for (num10 = 0; num10 < this.int_9; num10++)
                {
                    if (num10 >= XLabel.Count)
                    {
                        this.string_0[num10] = "null";
                    }
                    else
                    {
                        this.string_0[num10] = XLabel[num10].ToString();
                    }
                }
            }
            else
            {
                num10 = 0;
                while (num10 < this.int_9)
                {
                    this.string_0[num10] = (num10 + 1).ToString();
                    num10++;
                }
            }
            if (ColorGuider != null)
            {
                this.mHytfDhuET = new string[this.GroupSize];
                for (num10 = 0; num10 < this.GroupSize; num10++)
                {
                    if (num10 >= ColorGuider.Count)
                    {
                        this.mHytfDhuET[num10] = "null";
                    }
                    else
                    {
                        this.mHytfDhuET[num10] = ColorGuider[num10].ToString();
                    }
                }
            }
        Label_04DF:
            if (this.MaxValueY != 0.0)
            {
                this.float_1 = (float) this.MaxValueY;
            }
            else
            {
                groupSize = this.GroupSize;
                float[] numArray2 = new float[groupSize];
                for (num8 = 0; num8 < groupSize; num8++)
                {
                    numArray2[num8] = this.method_7(this.decimal_0[num8]);
                }
                this.float_1 = this.method_6(numArray2);
                this.float_1 = this.method_12(this.float_1);
            }
            if (this.float_1 == 0f)
            {
                this.float_1 = 1f;
            }
            groupSize = this.GroupSize;
            float[] numArray = new float[groupSize];
            for (num8 = 0; num8 < groupSize; num8++)
            {
                numArray[num8] = this.method_9(this.decimal_0[num8]);
            }
            this.float_2 = this.method_8(numArray);
            this.float_2 = this.method_12(this.float_2);
            if ((this.MinValueY != 0.0) || (this.MinValueY < this.float_2))
            {
                this.float_2 = (float) this.MinValueY;
            }
            if (this.BaseLineX == -0.830213)
            {
                this.BaseLineX = this.float_2;
            }
            this.float_3 = ((((float) this.BaseLineX) - this.float_2) * num4) / (this.float_1 - this.float_2);
            this.float_0 = new float[this.decimal_0.Length][];
            for (int j = 0; j < this.decimal_0.Length; j++)
            {
                this.float_0[j] = new float[this.decimal_0[j].Length];
                for (int k = 0; k < this.decimal_0[j].Length; k++)
                {
                    this.float_0[j][k] = ((((float) this.decimal_0[j][k]) - this.float_2) * num4) / (this.float_1 - this.float_2);
                }
            }
            if ((this.int_9 == 0) && this.ShowErrorInfo)
            {
                this.ChartTitle.Text = "No Data Found!";
            }
            this.bool_4 = true;
            this.method_32(this.Fill.ShiftStep, "Fill");
            this.method_32(this.Stroke.ShiftStep, "Stroke");
        }

        private float method_10(float[] float_4)
        {
            float num = 0f;
            for (int i = 0; i < float_4.Length; i++)
            {
                num += float_4[i];
            }
            return num;
        }

        private float method_11(decimal[] decimal_1)
        {
            float num = 0f;
            for (int i = 0; i < decimal_1.Length; i++)
            {
                num += (float) decimal_1[i];
            }
            return num;
        }

        private float method_12(float float_4)
        {
            int num = (int) Math.Floor((double) (float_4 / 10f));
            if (num <= 0)
            {
                return float_4;
            }
            if ((float_4 - (num * 10)) > 5f)
            {
                num = (num + 1) * 10;
            }
            else if (((float_4 - (num * 10)) < 5f) && ((float_4 - (num * 10)) > 0f))
            {
                num = (num * 10) + 5;
            }
            else
            {
                num = (int) float_4;
            }
            return (float) num;
        }

        private GraphicsPath method_13(float float_4, float float_5, float float_6, float float_7, float float_8, bool bool_5)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddArc(float_4, float_5, float_8 * 2f, float_8 * 2f, 180f, 90f);
            path.AddLine(float_4 + float_8, float_5, (float_4 + float_6) - float_8, float_5);
            path.AddArc((float_4 + float_6) - (float_8 * 2f), float_5, float_8 * 2f, float_8 * 2f, 270f, 90f);
            if (bool_5)
            {
                path.AddLine((float) (float_4 + float_6), (float) (float_5 + float_8), (float) (float_4 + float_6), (float) (float_5 + float_7));
                path.AddLine(float_4 + float_6, float_5 + float_7, float_4, float_5 + float_7);
                path.AddLine(float_4, float_5 + float_7, float_4, float_5 + float_8);
                return path;
            }
            path.AddLine((float) (float_4 + float_6), (float) (float_5 + float_8), (float) (float_4 + float_6), (float) ((float_5 + float_7) - float_8));
            path.AddArc((float) ((float_4 + float_6) - (float_8 * 2f)), (float) ((float_5 + float_7) - (2f * float_8)), (float) (float_8 * 2f), (float) (float_8 * 2f), 0f, 90f);
            path.AddLine((float) (float_4 + float_8), (float) (float_5 + float_7), (float) ((float_4 + float_6) - float_8), (float) (float_5 + float_7));
            path.AddArc(float_4, (float_5 + float_7) - (2f * float_8), float_8 * 2f, float_8 * 2f, 90f, 90f);
            path.AddLine(float_4, float_5 + float_8, float_4, (float_5 + float_7) - float_8);
            return path;
        }

        private GraphicsPath method_14(Rectangle rectangle_0, float float_4, bool bool_5)
        {
            float left = rectangle_0.Left;
            float top = rectangle_0.Top;
            float width = rectangle_0.Width;
            float height = rectangle_0.Height;
            GraphicsPath path = new GraphicsPath();
            path.AddArc(left, top, float_4 * 2f, float_4 * 2f, 180f, 90f);
            path.AddLine(left + float_4, top, (left + width) - float_4, top);
            path.AddArc((left + width) - (float_4 * 2f), top, float_4 * 2f, float_4 * 2f, 270f, 90f);
            if (bool_5)
            {
                path.AddLine((float) (left + width), (float) (top + float_4), (float) (left + width), (float) (top + height));
                path.AddLine(left + width, top + height, left, top + height);
                path.AddLine(left, top + height, left, top + float_4);
                return path;
            }
            path.AddLine((float) (left + width), (float) (top + float_4), (float) (left + width), (float) ((top + height) - float_4));
            path.AddArc((float) ((left + width) - (float_4 * 2f)), (float) ((top + height) - (2f * float_4)), (float) (float_4 * 2f), (float) (float_4 * 2f), 0f, 90f);
            path.AddLine((float) (left + float_4), (float) (top + height), (float) ((left + width) - float_4), (float) (top + height));
            path.AddArc(left, (top + height) - (2f * float_4), float_4 * 2f, float_4 * 2f, 90f, 90f);
            path.AddLine(left, top + float_4, left, (top + height) - float_4);
            return path;
        }

        private GraphicsPath method_15(float float_4, float float_5, float float_6, float float_7, float float_8, string string_6)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddArc(float_4, float_5, float_8 * 2f, float_8 * 2f, 180f, 90f);
            if (string_6 == "Quad")
            {
                path.AddLine(float_4 + float_8, float_5, float_4 + float_6, float_5);
                path.AddLine(float_4 + float_6, float_5, float_4 + float_6, float_5 + float_7);
            }
            else
            {
                path.AddLine(float_4 + float_8, float_5, (float_4 + float_6) - float_8, float_5);
                path.AddArc((float_4 + float_6) - (float_8 * 2f), float_5, float_8 * 2f, float_8 * 2f, 270f, 90f);
            }
            if ((string_6 == "Half") || (string_6 == "Quad"))
            {
                path.AddLine((float) (float_4 + float_6), (float) (float_5 + float_8), (float) (float_4 + float_6), (float) (float_5 + float_7));
                path.AddLine(float_4 + float_6, float_5 + float_7, float_4, float_5 + float_7);
                path.AddLine(float_4, float_5 + float_7, float_4, float_5 + float_8);
                return path;
            }
            path.AddLine((float) (float_4 + float_6), (float) (float_5 + float_8), (float) (float_4 + float_6), (float) ((float_5 + float_7) - float_8));
            path.AddArc((float) ((float_4 + float_6) - (float_8 * 2f)), (float) ((float_5 + float_7) - (2f * float_8)), (float) (float_8 * 2f), (float) (float_8 * 2f), 0f, 90f);
            path.AddLine((float) (float_4 + float_8), (float) (float_5 + float_7), (float) ((float_4 + float_6) - float_8), (float) (float_5 + float_7));
            path.AddArc(float_4, (float_5 + float_7) - (2f * float_8), float_8 * 2f, float_8 * 2f, 90f, 90f);
            path.AddLine(float_4, float_5 + float_8, float_4, (float_5 + float_7) - float_8);
            return path;
        }

        private void method_16()
        {
            DataView dataSource = this.object_0 as DataView;
            DataTable table = this.object_0 as DataTable;
            DataSet set = this.object_0 as DataSet;
            if (dataSource != null)
            {
                this.BindChartData(dataSource);
            }
            else if (table != null)
            {
                this.BindChartData(table);
            }
            else if (set != null)
            {
                this.BindChartData(set);
            }
            else if ((this.kUitoNvjqx != null) && (this.kUitoNvjqx.Length > 0))
            {
                if ((this.object_0 == null) && base.DesignMode)
                {
                    this.InitializeData(null, this.kUitoNvjqx, null);
                }
                else if (this.object_0 != null)
                {
                    ArrayList[] chartData = null;
                    ArrayList list = this.method_17(this.object_0);
                    if ((list != null) && (list.Count > 0))
                    {
                        ArrayList list2 = this.method_17(list[0]);
                        if (list2 != null)
                        {
                            chartData = new ArrayList[list.Count];
                            chartData[0] = list2;
                            for (int i = 1; i < list.Count; i++)
                            {
                                chartData[i] = this.method_17(list[i]);
                            }
                        }
                        else
                        {
                            chartData = new ArrayList[] { list };
                        }
                    }
                    else
                    {
                        chartData = new ArrayList[0];
                    }
                    this.InitializeData(chartData, this.kUitoNvjqx, null);
                }
            }
        }

        private ArrayList method_17(object object_1)
        {
            ArrayList list = null;
            IList list2 = object_1 as IList;
            IListSource source = object_1 as IListSource;
            if (list2 != null)
            {
                list = new ArrayList();
                foreach (object obj2 in list2)
                {
                    list.Add(obj2);
                }
                return list;
            }
            if (source != null)
            {
                list = new ArrayList();
                foreach (object obj2 in source.GetList())
                {
                    list.Add(obj2);
                }
            }
            return list;
        }

        private void method_18()
        {
            int num;
            string[] strArray = this.AppearanceStyle.ToString().Split(new char[] { '_' });
            string str = strArray[0];
            if (str != null)
            {
                if (str == "Bar")
                {
                    this.ChartType = ChartTypes.Bar;
                }
                else if (str == "Line")
                {
                    this.ChartType = ChartTypes.Line;
                    this.Depth3D = 20;
                }
                else if (str == "Pie")
                {
                    this.ChartType = ChartTypes.Pie;
                    this.Stroke.Color1 = Color.White;
                }
                else if (str == "Stack")
                {
                    this.ChartType = ChartTypes.Stack;
                }
                else if (!(str == "HBar"))
                {
                    if (str == "Trend")
                    {
                        this.ChartType = ChartTypes.Trend;
                        this.Tips.Show = false;
                        this.Depth3D = 20;
                    }
                }
                else
                {
                    this.ChartType = ChartTypes.HBar;
                }
            }
            str = strArray[1];
            if (str != null)
            {
                if (!(str == "2D"))
                {
                    if (str == "3D")
                    {
                        this.Dimension = ChartDimensions.Chart3D;
                    }
                }
                else
                {
                    this.Dimension = ChartDimensions.Chart2D;
                }
            }
            str = strArray[2];
            if (str != null)
            {
                if (str != "Breeze")
                {
                    if (!(str == "Aurora"))
                    {
                        if (str == "StarryNight")
                        {
                            this.StarryNight.CopyTo(this.BarBrushColor, 0);
                            this.Fill.ColorStyle = ColorStyles.StarryNight;
                            if ((this.ChartType == ChartTypes.Line) || (this.ChartType == ChartTypes.Trend))
                            {
                                this.Stroke.ColorStyle = ColorStyles.StarryNight;
                                this.StarryNight.CopyTo(this.BarPenColor, 0);
                            }
                        }
                    }
                    else
                    {
                        this.Fill.ColorStyle = ColorStyles.Aurora;
                        this.Aurora.CopyTo(this.BarBrushColor, 0);
                        if ((this.ChartType == ChartTypes.Line) || (this.ChartType == ChartTypes.Trend))
                        {
                            this.Stroke.ColorStyle = ColorStyles.Aurora;
                            this.Aurora.CopyTo(this.BarPenColor, 0);
                        }
                    }
                }
                else
                {
                    this.Fill.ColorStyle = ColorStyles.Breeze;
                    this.Breeze.CopyTo(this.BarBrushColor, 0);
                    if ((this.ChartType == ChartTypes.Line) || (this.ChartType == ChartTypes.Trend))
                    {
                        this.Stroke.ColorStyle = ColorStyles.Breeze;
                        this.Breeze.CopyTo(this.BarPenColor, 0);
                    }
                }
            }
            switch (strArray[3])
            {
                case "NoCrystal":
                    this.Crystal.Enable = false;
                    if (this.ChartType == ChartTypes.Pie)
                    {
                        this.Stroke.Width = 3;
                    }
                    if (this.Dimension == ChartDimensions.Chart3D)
                    {
                        this.Alpha3D = 160;
                    }
                    goto Label_0550;

                case "FlatCrystal":
                    this.Crystal.Enable = true;
                    this.Crystal.CoverFull = true;
                    this.Crystal.Direction = Direction.TopBottom;
                    if (this.ChartType == ChartTypes.HBar)
                    {
                        this.Crystal.Direction = Direction.RightLeft;
                    }
                    switch (this.Fill.ColorStyle)
                    {
                        case ColorStyles.Breeze:
                            this.Crystal.Contraction = 1;
                            goto Label_03D3;

                        case ColorStyles.Aurora:
                            this.Crystal.Contraction = 1;
                            goto Label_03D3;

                        case ColorStyles.StarryNight:
                            this.Crystal.Contraction = 3;
                            goto Label_03D3;
                    }
                    break;

                case "GlassCrystal":
                    this.Crystal.Enable = true;
                    this.Crystal.CoverFull = false;
                    this.Crystal.Direction = Direction.LeftRight;
                    if (this.ChartType == ChartTypes.HBar)
                    {
                        this.Crystal.Direction = Direction.TopBottom;
                    }
                    if (this.Fill.ColorStyle == ColorStyles.Aurora)
                    {
                        this.RoundRectangle = false;
                    }
                    else
                    {
                        this.RoundRectangle = true;
                    }
                    this.RoundRadius = 3;
                    for (num = 0; num < this.GroupSize; num++)
                    {
                        this.BarPenColor[num % 12] = ColorTranslator.FromHtml("");
                    }
                    if (this.ChartType == ChartTypes.Pie)
                    {
                        this.Stroke.Width = 0;
                    }
                    goto Label_0550;

                case "ThickRound":
                    this.Stroke.Width = 8;
                    this.LineConnectionRadius = 0x12;
                    this.LineConnectionType = LineConnectionTypes.Round;
                    goto Label_0550;

                case "ThickSquare":
                    this.Stroke.Width = 8;
                    this.LineConnectionRadius = 0x12;
                    this.LineConnectionType = LineConnectionTypes.Square;
                    goto Label_0550;

                case "ThinRound":
                    this.Stroke.Width = 2;
                    this.LineConnectionRadius = 8;
                    this.LineConnectionType = LineConnectionTypes.Round;
                    goto Label_0550;

                case "ThinSquare":
                    this.Stroke.Width = 2;
                    this.LineConnectionRadius = 8;
                    this.LineConnectionType = LineConnectionTypes.Square;
                    goto Label_0550;

                default:
                    goto Label_0550;
            }
        Label_03D3:
            if (this.ChartType == ChartTypes.Pie)
            {
                this.Stroke.Width = 0;
            }
            if (this.Dimension == ChartDimensions.Chart3D)
            {
                this.Alpha3D = 200;
                this.Crystal.Direction = Direction.BottomTop;
                this.Crystal.Contraction = 1;
            }
        Label_0550:
            if (!(((this.ChartType == ChartTypes.Line) || (this.ChartType == ChartTypes.Trend)) ? (this.Dimension != ChartDimensions.Chart3D) : true))
            {
                this.Stroke.Width = 1;
                this.Alpha3D = 100;
                if (strArray[3].IndexOf("NoCrystal") > -1)
                {
                    this.Crystal.Enable = false;
                }
                if (strArray[3].IndexOf("FlatCrystal") > -1)
                {
                    this.Crystal.Enable = true;
                    this.Crystal.CoverFull = true;
                    this.Crystal.Direction = Direction.LeftRight;
                }
                if (strArray[3].IndexOf("GlassCrystal") > -1)
                {
                    this.Crystal.Enable = true;
                    this.Crystal.CoverFull = true;
                    this.Crystal.Direction = Direction.TopBottom;
                }
                if (strArray[3].IndexOf("None") > -1)
                {
                    this.LineConnectionType = LineConnectionTypes.None;
                    this.LineConnectionRadius = 0;
                }
                if (strArray[3].IndexOf("Round") > -1)
                {
                    this.LineConnectionType = LineConnectionTypes.Round;
                    this.LineConnectionRadius = 6;
                    this.Stroke.Width = 2;
                }
                if (strArray[3].IndexOf("Square") > -1)
                {
                    this.LineConnectionType = LineConnectionTypes.Square;
                    this.LineConnectionRadius = 10;
                }
            }
            switch (strArray[4])
            {
                case "NoGlow":
                    this.Shadow.Enable = false;
                    break;

                case "Glow":
                    this.Shadow.Enable = true;
                    switch (this.ChartType)
                    {
                        case ChartTypes.Bar:
                            if (this.Fill.ColorStyle != ColorStyles.StarryNight)
                            {
                                this.Shadow.Radius = 3;
                            }
                            else
                            {
                                this.Shadow.Radius = 5;
                            }
                            goto Label_0766;

                        case ChartTypes.Line:
                            if (!strArray[3].Contains("Thin"))
                            {
                                this.Shadow.Radius = 6;
                                this.Shadow.Distance = 4;
                            }
                            else
                            {
                                this.Shadow.Radius = 2;
                                this.Shadow.Distance = 2;
                            }
                            goto Label_0766;
                    }
                    break;
            }
        Label_0766:
            if ((strArray[5] != "NoBorder") && (strArray[5] != "None"))
            {
                for (num = 0; num < 12; num++)
                {
                    this.BarPenColor[num % 12] = Color.White;
                }
            }
            str = strArray[5];
            if (str != null)
            {
                if (str == "NoBorder")
                {
                    if ((this.ChartType != ChartTypes.Line) && (this.ChartType != ChartTypes.Trend))
                    {
                        this.Stroke.Width = 0;
                    }
                    if ((this.ChartType == ChartTypes.Bar) && (this.Dimension == ChartDimensions.Chart3D))
                    {
                        this.Stroke.Width = 1;
                        this.Stroke.ColorStyle = this.Fill.ColorStyle;
                    }
                }
                else if (str == "WhiteBorder")
                {
                    switch (this.ChartType)
                    {
                        case ChartTypes.Bar:
                            if (this.Dimension != ChartDimensions.Chart2D)
                            {
                                this.Stroke.Width = 1;
                                this.Crystal.Contraction = 3;
                                break;
                            }
                            this.Stroke.Width = 4;
                            this.Crystal.Contraction = 3;
                            this.Shadow.Radius = 6;
                            this.RoundRectangle = true;
                            break;

                        case ChartTypes.Pie:
                            this.Stroke.Width = 6;
                            this.Shadow.Radius = 10;
                            break;
                    }
                    this.Shadow.Alpha = 0xff;
                }
                else if ((str == "TextureBorder") && (this.ChartType == ChartTypes.Bar))
                {
                    this.Stroke.Width = 4;
                    this.Crystal.Contraction = 0;
                    this.Shadow.Radius = 5;
                    this.RoundRectangle = false;
                    this.Shadow.Alpha = 0xff;
                    this.Stroke.TextureEnable = true;
                }
            }
        }

        private void method_19(Graphics graphics_0, SolidBrush solidBrush_0, Pen pen_0, int int_10, int int_11, int int_12, int int_13)
        {
            if (this.Shadow.Enable)
            {
                TextShadow shadow = new TextShadow {
                    Radius = this.Shadow.Radius,
                    Distance = this.Shadow.Distance,
                    Alpha = this.Shadow.Alpha,
                    Angle = this.Shadow.Angle
                };
                string action = "Fill";
                if (this.Shadow.Hollow)
                {
                    action = "Draw";
                }
                shadow.DropShadow(graphics_0, new Rectangle(int_10, int_11, int_12, int_13), this.Shadow.Color, action, "Rectangle", null, 1);
            }
            if (this.RoundRectangle)
            {
                graphics_0.SmoothingMode = SmoothingMode.AntiAlias;
                if (this.RoundRadius < 1)
                {
                    this.RoundRadius = 1;
                }
                if (this.ChartType == ChartTypes.HBar)
                {
                    graphics_0.FillPath(solidBrush_0, this.method_13((float) int_10, (float) int_11, (float) int_12, (float) int_13, (float) this.RoundRadius, false));
                }
                else
                {
                    graphics_0.FillPath(solidBrush_0, this.method_13((float) int_10, (float) int_11, (float) int_12, (float) int_13, (float) this.RoundRadius, true));
                }
                if (this.Stroke.Width > 0)
                {
                    if (this.ChartType == ChartTypes.HBar)
                    {
                        graphics_0.DrawPath(pen_0, this.method_13((float) int_10, (float) int_11, (float) int_12, (float) int_13, (float) this.RoundRadius, false));
                    }
                    else
                    {
                        graphics_0.DrawPath(pen_0, this.method_13((float) int_10, (float) int_11, (float) int_12, (float) int_13, (float) this.RoundRadius, true));
                    }
                }
                graphics_0.SmoothingMode = SmoothingMode.None;
            }
            else
            {
                graphics_0.FillRectangle(solidBrush_0, int_10, int_11, int_12, int_13);
                if (this.Stroke.Width > 0)
                {
                    graphics_0.DrawRectangle(pen_0, int_10, int_11, int_12, int_13);
                }
            }
        }

        private void method_20(Graphics graphics_0, SolidBrush solidBrush_0, Pen pen_0, int int_10, int int_11, int int_12, int int_13, int int_14)
        {
            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddLine(int_10, int_11, int_10 - int_14, int_11 + int_14);
            path.AddLine((int) (int_10 - int_14), (int) (int_11 + int_14), (int) ((int_10 - int_14) + int_12), (int) (int_11 + int_14));
            path.AddLine((int_10 - int_14) + int_12, int_11 + int_14, int_10 + int_12, int_11);
            path.AddLine(int_10 + int_12, int_11, int_10, int_11);
            graphics_0.FillPath(solidBrush_0, path);
            graphics_0.FillPath(new SolidBrush(Color.FromArgb(20, Color.Black)), path);
            if (this.Stroke.Width > 0)
            {
                graphics_0.DrawPath(pen_0, path);
            }
            path.Reset();
            path.StartFigure();
            path.AddLine(int_10 + int_12, int_11, (int_10 + int_12) - int_14, int_11 + int_14);
            path.AddLine((int) ((int_10 + int_12) - int_14), (int) (int_11 + int_14), (int) ((int_10 + int_12) - int_14), (int) ((int_11 + int_14) + int_13));
            path.AddLine((int) ((int_10 + int_12) - int_14), (int) ((int_11 + int_14) + int_13), (int) (int_10 + int_12), (int) (int_11 + int_13));
            path.AddLine(int_10 + int_12, int_11 + int_13, int_10 + int_12, int_11);
            graphics_0.FillPath(solidBrush_0, path);
            graphics_0.FillPath(new SolidBrush(Color.FromArgb(40, Color.Black)), path);
            if (this.Stroke.Width > 0)
            {
                graphics_0.DrawPath(pen_0, path);
            }
            path.Reset();
            path.StartFigure();
            path.AddLine((int) (int_10 - int_14), (int) (int_11 + int_14), (int) (int_10 - int_14), (int) ((int_11 + int_14) + int_13));
            path.AddLine((int) (int_10 - int_14), (int) ((int_11 + int_14) + int_13), (int) ((int_10 - int_14) + int_12), (int) ((int_11 + int_14) + int_13));
            path.AddLine((int) ((int_10 - int_14) + int_12), (int) ((int_11 + int_14) + int_13), (int) ((int_10 - int_14) + int_12), (int) (int_11 + int_14));
            path.AddLine((int) ((int_10 - int_14) + int_12), (int) (int_11 + int_14), (int) (int_10 - int_14), (int) (int_11 + int_14));
            graphics_0.FillPath(solidBrush_0, path);
            if (this.Stroke.Width > 0)
            {
                graphics_0.DrawPath(pen_0, path);
            }
            path.Dispose();
        }

        private void method_21(Graphics graphics_0, int int_10, int int_11, int int_12, int int_13, int int_14)
        {
            Point point;
            Point point2;
            Rectangle rectangle = new Rectangle(int_10 - int_14, int_11 + int_14, int_12, int_13);
            rectangle.Inflate(-1 * this.Crystal.Contraction, -1 * this.Crystal.Contraction);
            if (!this.Crystal.CoverFull)
            {
                Rectangle rect = new Rectangle(int_10 - int_14, int_11 + int_14, (int_12 / 2) + 1, int_13);
                if (this.ChartType == ChartTypes.HBar)
                {
                    rect = new Rectangle(int_10 - int_14, int_11 + int_14, int_12, (int_13 / 2) + 1);
                }
                rectangle.Intersect(rect);
            }
            switch (this.Crystal.Direction)
            {
                case Direction.LeftRight:
                    point = new Point(rectangle.Left, 0);
                    point2 = new Point((rectangle.Left + rectangle.Width) + 1, 0);
                    break;

                case Direction.TopBottom:
                    point = new Point(0, rectangle.Top - 1);
                    point2 = new Point(0, rectangle.Top + rectangle.Height);
                    break;

                case Direction.RightLeft:
                    point = new Point(rectangle.Left + rectangle.Width, 0);
                    point2 = new Point(rectangle.Left - 1, 0);
                    break;

                case Direction.BottomTop:
                    point = new Point(0, rectangle.Top + rectangle.Height);
                    point2 = new Point(0, rectangle.Top - 1);
                    break;

                default:
                    point = new Point(rectangle.Left, 0);
                    point2 = new Point(rectangle.Left + (rectangle.Width / 2), 0);
                    break;
            }
            LinearGradientBrush brush = new LinearGradientBrush(point, point2, Color.FromArgb(0xb2, Color.White), Color.FromArgb(0x19, Color.White));
            if (this.RoundRectangle)
            {
                int num = this.RoundRadius - 2;
                if (num < 1)
                {
                    num = 1;
                }
                graphics_0.SmoothingMode = SmoothingMode.AntiAlias;
                graphics_0.FillPath(brush, this.method_15((float) rectangle.Left, (float) rectangle.Top, (float) rectangle.Width, (float) rectangle.Height, (float) num, "Full"));
                graphics_0.SmoothingMode = SmoothingMode.None;
            }
            else
            {
                graphics_0.FillRectangle(brush, rectangle.Left, rectangle.Top, rectangle.Width, rectangle.Height);
            }
            brush.Dispose();
        }

        private void method_22(Graphics graphics_0, string string_6, int int_10, int int_11, int int_12, int int_13, bool bool_5)
        {
            float num;
            if (bool_5)
            {
                int_11 = (int_11 + int_13) + 15;
            }
            SizeF ef = graphics_0.MeasureString(string_6, this.Tips.Font);
            if (int_12 >= ef.Width)
            {
                num = int_10 + ((int_12 - ef.Width) / 2f);
            }
            else
            {
                num = (int_10 + int_12) - ef.Width;
            }
            StringFormat format = new StringFormat {
                Alignment = StringAlignment.Center
            };
            if (this.ChartType == ChartTypes.Stack)
            {
                graphics_0.DrawString(string_6.ToString(), this.Tips.Font, new SolidBrush(this.Tips.ForeColor.ToColor()), new RectangleF(num, (float) int_11, ef.Width, ef.Height), format);
            }
            else
            {
                graphics_0.DrawString(string_6.ToString(), this.Tips.Font, new SolidBrush(this.Tips.ForeColor.ToColor()), new RectangleF(num, (float) (int_11 - 14), ef.Width, ef.Height), format);
            }
            format.Dispose();
        }

        private void method_23(Graphics graphics_0, Pen pen_0, int int_10, int int_11, int int_12, int int_13, int int_14)
        {
            graphics_0.SmoothingMode = SmoothingMode.AntiAlias;
            graphics_0.DrawLine(pen_0, int_13, int_11 + int_12, int_13, int_11);
            graphics_0.DrawLine(pen_0, int_13 - int_10, (int_11 + int_12) + int_10, int_13, int_11 + int_12);
            graphics_0.SmoothingMode = SmoothingMode.None;
            graphics_0.DrawLine(Pens.Black, (int) (int_13 - int_10), (int) (((int_11 + int_12) - 1) + int_10), (int) (int_13 - int_10), (int) (((int_11 + int_12) + 2) + int_10));
        }

        private void method_24(Graphics graphics_0, Pen pen_0, string string_6, int int_10, int int_11, int int_12, int int_13, int int_14)
        {
            StringFormat format = new StringFormat();
            if (this.XAxis.RotateAngle > 0f)
            {
                format.Alignment = StringAlignment.Near;
                GraphicsState gstate = graphics_0.Save();
                graphics_0.TranslateTransform((float) (int_13 - int_10), (float) (((int_11 + int_12) + 1) + int_10));
                graphics_0.RotateTransform(this.XAxis.RotateAngle);
                graphics_0.DrawString(string_6, this.XAxis.Font, new SolidBrush(this.XAxis.ForeColor.ToColor()), 0f, 0f, format);
                graphics_0.Restore(gstate);
            }
            else
            {
                format.Alignment = StringAlignment.Center;
                graphics_0.DrawString(string_6, this.XAxis.Font, new SolidBrush(this.XAxis.ForeColor.ToColor()), new Rectangle((int_13 - (int_14 / 2)) - int_10, ((int_11 + int_10) + int_12) + 1, int_14 + 1, (int) graphics_0.MeasureString(string_6, this.XAxis.Font).Height), format);
            }
            format.Dispose();
        }

        private void method_25(Graphics graphics_0, int int_10, int int_11, int int_12, int int_13)
        {
            if ((this.XAxis.UnitText != null) && this.XAxis.Show)
            {
                graphics_0.DrawString(this.XAxis.UnitText, this.XAxis.UnitFont, new SolidBrush(this.XAxis.ForeColor.ToColor()), (float) (int_12 + int_10), (float) (int_13 + int_11));
            }
            if ((this.YAxis.UnitText != null) && this.YAxis.Show)
            {
                graphics_0.DrawString(this.YAxis.UnitText, this.YAxis.UnitFont, new SolidBrush(this.YAxis.ForeColor.ToColor()), 2f, (float) (int_11 - 0x19));
            }
        }

        private void method_26(Graphics graphics_0, Pen pen_0, string string_6, int int_10, int int_11, int int_12, int int_13, int int_14, int int_15)
        {
            StringFormat format = new StringFormat();
            graphics_0.DrawLine(new Pen(Color.FromArgb(0xff, 220, 220, 220)), int_11, int_14, int_11 + int_13, int_14);
            graphics_0.DrawLine(Pens.Black, int_11 - 3, int_14, int_11, int_14);
            if (this.YAxis.Show)
            {
                graphics_0.DrawString(string_6, this.YAxis.Font, new SolidBrush(this.YAxis.ForeColor.ToColor()), new Rectangle(0, int_14 - 10, int_11 - 4, this.YAxis.Font.Height), format);
            }
            format.Dispose();
        }

        private void method_27(Graphics graphics_0, Pen pen_0, float float_4, float float_5, float float_6, float float_7)
        {
            GraphicsPath gp = new GraphicsPath();
            gp.AddLine(float_4, float_5, float_6, float_7);
            if (this.Shadow.Enable)
            {
                new TextShadow { Radius = this.Shadow.Radius, Distance = this.Shadow.Distance, Alpha = this.Shadow.Alpha, Angle = this.Shadow.Angle }.DropShadow(graphics_0, new Rectangle((int) gp.GetBounds().Left, (int) gp.GetBounds().Top, (int) gp.GetBounds().Width, (int) gp.GetBounds().Height), this.Shadow.Color, "Draw", "Path", gp, this.Stroke.Width);
            }
            graphics_0.DrawPath(pen_0, gp);
            gp.Dispose();
        }

        private void method_28(Graphics graphics_0, Pen pen_0, SolidBrush solidBrush_0, int int_10, float float_4, float float_5, float float_6, int int_11)
        {
            GraphicsPath path = new GraphicsPath();
            if (this.LineConnectionType == LineConnectionTypes.Square)
            {
                path.Reset();
                path.StartFigure();
                path.AddLine((float) (float_5 - float_4), (float) (float_6 - float_4), (float) ((float_5 - float_4) - int_10), (float) ((float_6 - float_4) + int_10));
                path.AddLine((float) ((float_5 - float_4) - int_10), (float) ((float_6 - float_4) + int_10), (float) ((float_5 + float_4) - int_10), (float) ((float_6 - float_4) + int_10));
                path.AddLine((float) ((float_5 + float_4) - int_10), (float) ((float_6 - float_4) + int_10), (float) (float_5 + float_4), (float) (float_6 - float_4));
                path.AddLine((float) (float_5 + float_4), (float) (float_6 - float_4), (float) (float_5 - float_4), (float) (float_6 - float_4));
                path.StartFigure();
                path.AddLine((float) ((float_5 - float_4) - int_10), (float) ((float_6 - float_4) + int_10), (float) ((float_5 + float_4) - int_10), (float) ((float_6 - float_4) + int_10));
                path.AddLine((float) ((float_5 + float_4) - int_10), (float) ((float_6 - float_4) + int_10), (float) ((float_5 + float_4) - int_10), (float) ((float_6 + float_4) + int_10));
                path.AddLine((float) ((float_5 + float_4) - int_10), (float) ((float_6 + float_4) + int_10), (float) ((float_5 - float_4) - int_10), (float) ((float_6 + float_4) + int_10));
                path.AddLine((float) ((float_5 - float_4) - int_10), (float) ((float_6 + float_4) + int_10), (float) ((float_5 - float_4) - int_10), (float) ((float_6 - float_4) + int_10));
                path.StartFigure();
                path.AddLine((float) ((float_5 + float_4) - int_10), (float) ((float_6 - float_4) + int_10), (float) (float_5 + float_4), (float) (float_6 - float_4));
                path.AddLine((float) (float_5 + float_4), (float) (float_6 - float_4), (float) (float_5 + float_4), (float) (float_6 + float_4));
                path.AddLine((float) (float_5 + float_4), (float) (float_6 + float_4), (float) ((float_5 + float_4) - int_10), (float) ((float_6 + float_4) + int_10));
                path.AddLine((float) ((float_5 + float_4) - int_10), (float) ((float_6 + float_4) + int_10), (float) ((float_5 + float_4) - int_10), (float) ((float_6 - float_4) + int_10));
                graphics_0.FillPath(solidBrush_0, path);
                graphics_0.DrawPath(pen_0, path);
            }
            else if (this.LineConnectionType == LineConnectionTypes.Round)
            {
                path.Reset();
                path.AddArc((int) (float_5 - float_4), (int) (float_6 - float_4), this.LineConnectionRadius, this.LineConnectionRadius, 225f, 180f);
                PointF tf = path.PathPoints[0];
                PointF tf2 = path.PathPoints[path.PathPoints.Length - 1];
                PointF tf3 = tf + new SizeF((float) (-1 * int_10), (float) int_10);
                PointF tf4 = tf2 + new SizeF((float) (-1 * int_10), (float) int_10);
                Color[] colorArray2 = new Color[] { this.BarPenColor[int_11 % 12], Color.White, this.BarPenColor[int_11 % 12] };
                float[] numArray = new float[3];
                numArray[1] = 0.3f;
                numArray[2] = 1f;
                float[] numArray2 = numArray;
                ColorBlend blend = new ColorBlend {
                    Colors = colorArray2,
                    Positions = numArray2
                };
                LinearGradientBrush brush = new LinearGradientBrush(tf, tf2, Color.Red, Color.Red) {
                    InterpolationColors = blend
                };
                path.Reset();
                path.StartFigure();
                path.AddArc((int) (float_5 - float_4), (int) (float_6 - float_4), this.LineConnectionRadius, this.LineConnectionRadius, 225f, 180f);
                path.AddLine(tf2, tf4);
                path.AddArc(((int) (float_5 - float_4)) - int_10, ((int) (float_6 - float_4)) + int_10, this.LineConnectionRadius, this.LineConnectionRadius, 225f, 180f);
                path.AddLine(tf3, tf);
                graphics_0.FillPath(brush, path);
                graphics_0.DrawPath(pen_0, path);
                brush.Dispose();
                path.Reset();
                path.StartFigure();
                path.AddEllipse(((int) (float_5 - float_4)) - int_10, ((int) (float_6 - float_4)) + int_10, this.LineConnectionRadius, this.LineConnectionRadius);
                graphics_0.FillPath(new SolidBrush(Color.FromArgb(0xff, this.BarPenColor[int_11 % 12])), path);
                graphics_0.DrawPath(pen_0, path);
            }
            graphics_0.DrawPath(pen_0, path);
            path.Dispose();
        }

        private void method_29(Graphics graphics_0, Pen pen_0, SolidBrush solidBrush_0, int int_10, float float_4, float float_5, float float_6, float float_7, float float_8)
        {
            GraphicsPath path = new GraphicsPath();
            path.Reset();
            path.AddLine(float_5 + float_4, float_6, (float_5 + float_4) - int_10, float_6 + int_10);
            path.AddLine((float) ((float_5 + float_4) - int_10), (float) (float_6 + int_10), (float) ((float_7 - float_4) - int_10), (float) (float_8 + int_10));
            path.AddLine((float_7 - float_4) - int_10, float_8 + int_10, float_7 - float_4, float_8);
            path.AddLine(float_7 - float_4, float_8, float_5 + float_4, float_6);
            graphics_0.FillPath(solidBrush_0, path);
            if (this.Crystal.Enable)
            {
                this.method_30(graphics_0, path, int_10, float_4, float_5, float_6, float_7, float_8);
            }
            graphics_0.DrawPath(pen_0, path);
            path.Dispose();
        }

        private void method_30(Graphics graphics_0, GraphicsPath graphicsPath_0, int int_10, float float_4, float float_5, float float_6, float float_7, float float_8)
        {
            Point point;
            Point point2;
            if (this.Crystal.Direction == Direction.LeftRight)
            {
                point2 = new Point(((int) (float_5 + float_4)) - int_10, ((int) float_6) + int_10);
                point = new Point((int) (float_7 - float_4), (int) float_8);
            }
            else if (this.Crystal.Direction == Direction.RightLeft)
            {
                point = new Point(((int) (float_5 + float_4)) - int_10, ((int) float_6) + int_10);
                point2 = new Point((int) (float_7 - float_4), (int) float_8);
            }
            else if (this.Crystal.Direction == Direction.TopBottom)
            {
                point2 = new Point((int) (float_5 + float_4), (int) float_6);
                point = new Point(((int) (float_5 + float_4)) - int_10, ((int) float_6) + int_10);
            }
            else
            {
                point = new Point((int) (float_5 + float_4), (int) float_6);
                point2 = new Point(((int) (float_5 + float_4)) - int_10, ((int) float_6) + int_10);
            }
            LinearGradientBrush brush = new LinearGradientBrush(point2, point, Color.FromArgb(0xb2, Color.White), Color.FromArgb(0x19, Color.White));
            graphics_0.FillPath(brush, graphicsPath_0);
        }

        private void method_31(float float_4, float float_5, decimal decimal_1)
        {
            if (this.string_1 == "")
            {
                this.string_1 = (float_4 - ((this.LineConnectionRadius + 4) / 2));
                this.string_2 = (this.LineConnectionRadius + 4);
                this.string_3 = (float_5 - ((this.LineConnectionRadius + 4) / 2));
                this.string_4 = (this.LineConnectionRadius + 4);
                this.string_5 = decimal_1;
            }
            else
            {
                this.string_1 = this.string_1 + "," + (float_4 - ((this.LineConnectionRadius + 4) / 2));
                this.string_2 = this.string_2 + "," + (this.LineConnectionRadius + 4);
                this.string_3 = this.string_3 + "," + (float_5 - ((this.LineConnectionRadius + 4) / 2));
                this.string_4 = this.string_4 + "," + (this.LineConnectionRadius + 4);
                this.string_5 = this.string_5 + "," + decimal_1;
            }
        }

        private void method_32(int int_10, string string_6)
        {
            Color[] barBrushColor = new Color[12];
            if (string_6 == "Fill")
            {
                barBrushColor = this.BarBrushColor;
            }
            else if (string_6 == "Stroke")
            {
                barBrushColor = this.BarPenColor;
            }
            int_10 = int_10 % 12;
            for (int i = 0; i < int_10; i++)
            {
                Color color = barBrushColor[0];
                for (int j = 0; j < (barBrushColor.Length - 1); j++)
                {
                    barBrushColor[j] = barBrushColor[j + 1];
                }
                barBrushColor[barBrushColor.Length - 1] = color;
            }
        }

        private void method_33(Graphics graphics_0, int int_10, int int_11, int int_12, int int_13)
        {
            int num;
            int width = base.Width;
            int height = base.Height;
            Color highlight = this.Background.Highlight;
            Color lowlight = this.Background.Lowlight;
            StringFormat format = new StringFormat {
                Alignment = StringAlignment.Far,
                LineAlignment = StringAlignment.Center
            };
            if (this.ChartType != ChartTypes.HBar)
            {
                for (num = 0; num < this.YAxis.LabelCount; num++)
                {
                    if ((num % 2) == 0)
                    {
                        graphics_0.FillRectangle(new SolidBrush(highlight), int_10, int_11 + ((int_13 * num) / this.YAxis.LabelCount), int_12, int_13 / this.YAxis.LabelCount);
                        graphics_0.DrawRectangle(new Pen(lowlight), int_10, int_11 + ((int_13 * num) / this.YAxis.LabelCount), int_12 - 1, (int_13 / this.YAxis.LabelCount) - 1);
                    }
                }
                for (num = 0; num <= this.YAxis.LabelCount; num++)
                {
                    if (this.YAxis.Show)
                    {
                        graphics_0.DrawString((this.float_2 + (((this.float_1 - this.float_2) * (this.YAxis.LabelCount - num)) / ((float) this.YAxis.LabelCount))).ToString(this.YAxis.ValueFormat), this.YAxis.Font, new SolidBrush(this.YAxis.ForeColor.ToColor()), new Rectangle(0, (int_11 + ((int_13 * num) / this.YAxis.LabelCount)) - 10, int_10 - 4, this.YAxis.Font.Height), format);
                    }
                    if (num > 0)
                    {
                        graphics_0.DrawLine(Pens.Black, int_10 - 3, int_11 + ((int_13 * num) / this.YAxis.LabelCount), int_10, int_11 + ((int_13 * num) / this.YAxis.LabelCount));
                    }
                }
                if (this.SpecLine.Show)
                {
                    Brush brush2;
                    if (this.SpecLine.EnableTexture)
                    {
                        brush2 = new HatchBrush(this.SpecLine.TextureStyle, this.SpecLine.Color);
                    }
                    else
                    {
                        brush2 = new SolidBrush(this.SpecLine.Color);
                    }
                    Pen pen = new Pen(brush2, (float) this.SpecLine.Width);
                    graphics_0.DrawLine(pen, (float) (int_10 - 3), (int_11 + int_13) - (((float) (int_13 * this.SpecLine.LowLimit)) / (this.float_1 - this.float_2)), (float) (int_10 + int_12), (int_11 + int_13) - (((float) (int_13 * this.SpecLine.LowLimit)) / (this.float_1 - this.float_2)));
                    graphics_0.DrawLine(pen, (float) (int_10 - 3), (int_11 + int_13) - (((float) (int_13 * this.SpecLine.HighLimit)) / (this.float_1 - this.float_2)), (float) (int_10 + int_12), (int_11 + int_13) - (((float) (int_13 * this.SpecLine.HighLimit)) / (this.float_1 - this.float_2)));
                }
            }
            if (this.ChartTitle.Show)
            {
                format.Alignment = StringAlignment.Center;
                graphics_0.DrawString(this.ChartTitle.Text, this.ChartTitle.Font, new SolidBrush(this.ChartTitle.ForeColor.ToColor()), new Rectangle(int_10, ((int_11 - 2) - ((int) graphics_0.MeasureString(this.ChartTitle.Text, this.ChartTitle.Font).Height)) + this.ChartTitle.OffsetY, int_12, (int) graphics_0.MeasureString(this.ChartTitle.Text, this.ChartTitle.Font).Height), format);
            }
            if ((this.mHytfDhuET != null) && this.ColorGuider.Show)
            {
                for (num = 0; num < this.mHytfDhuET.Length; num++)
                {
                    SolidBrush brush;
                    switch (this.ChartType)
                    {
                        case ChartTypes.Bar:
                            brush = new SolidBrush(this.BarBrushColor[num % 12]);
                            break;

                        case ChartTypes.Line:
                            brush = new SolidBrush(this.BarPenColor[num % 12]);
                            break;

                        default:
                            brush = new SolidBrush(this.BarBrushColor[num % 12]);
                            break;
                    }
                    switch (this.ChartType)
                    {
                        case ChartTypes.Bar:
                            graphics_0.FillRectangle(brush, (int_10 + int_12) + 6, (int_11 + (14 * num)) + 4, 0x12, 8);
                            graphics_0.DrawRectangle(Pens.Gray, (int_10 + int_12) + 6, (int_11 + 4) + (14 * num), 0x11, 7);
                            goto Label_054B;

                        case ChartTypes.Line:
                            graphics_0.DrawLine(new Pen(brush), (int) ((int_10 + int_12) + 6), (int) ((int_11 + (14 * num)) + 8), (int) ((int_10 + int_12) + 0x18), (int) ((int_11 + (14 * num)) + 8));
                            if (this.LineConnectionType != LineConnectionTypes.Square)
                            {
                                break;
                            }
                            graphics_0.FillRectangle(brush, (int_10 + int_12) + 11, (int_11 + (14 * num)) + 4, 8, 8);
                            goto Label_054B;

                        default:
                            graphics_0.FillRectangle(brush, (int_10 + int_12) + 6, (int_11 + (14 * num)) + 4, 0x12, 8);
                            graphics_0.DrawRectangle(Pens.Gray, (int_10 + int_12) + 6, (int_11 + 4) + (14 * num), 0x11, 7);
                            goto Label_054B;
                    }
                    if (this.LineConnectionType == LineConnectionTypes.Round)
                    {
                        graphics_0.SmoothingMode = SmoothingMode.AntiAlias;
                        graphics_0.FillEllipse(brush, (int_10 + int_12) + 11, (int_11 + (14 * num)) + 4, 8, 8);
                    }
                Label_054B:
                    graphics_0.DrawString(this.mHytfDhuET[num], this.ColorGuider.Font, new SolidBrush(this.ColorGuider.ForeColor.ToColor()), (float) ((int_10 + int_12) + 0x1c), (float) ((int_11 + 1) + (14 * num)));
                    brush.Dispose();
                }
            }
            format.Dispose();
        }

        private void method_34(Graphics graphics_0, int int_10, int int_11, int int_12, int int_13)
        {
            int num2;
            int width = base.Width;
            int height = base.Height;
            Rectangle rect = new Rectangle(int_10, int_11, int_12, int_13);
            Rectangle rectangle2 = rect;
            int y = this.Depth3D;
            rectangle2.Offset(-y, y);
            SolidBrush brush = new SolidBrush(this.Background.Highlight);
            Pen pen = new Pen(this.Background.Lowlight);
            GraphicsPath path = new GraphicsPath();
            path.Reset();
            Color.FromArgb(80, 0xee, 0xed, 0xee);
            Color.FromArgb(0xff, 220, 220, 220);
            StringFormat format = new StringFormat {
                Alignment = StringAlignment.Far,
                LineAlignment = StringAlignment.Center
            };
            if (this.ChartType != ChartTypes.HBar)
            {
                for (num2 = 0; num2 < this.YAxis.LabelCount; num2++)
                {
                    if ((num2 % 2) == 0)
                    {
                        graphics_0.FillRectangle(brush, int_10, int_11 + ((int_13 * num2) / this.YAxis.LabelCount), int_12, int_13 / this.YAxis.LabelCount);
                        graphics_0.DrawRectangle(pen, int_10, int_11 + ((int_13 * num2) / this.YAxis.LabelCount), int_12, int_13 / this.YAxis.LabelCount);
                        path.StartFigure();
                        path.AddLine(int_10, int_11 + ((int_13 * num2) / this.YAxis.LabelCount), int_10 - y, (int_11 + ((int_13 * num2) / this.YAxis.LabelCount)) + y);
                        path.AddLine((int) (int_10 - y), (int) ((int_11 + ((int_13 * num2) / this.YAxis.LabelCount)) + y), (int) (int_10 - y), (int) (((int_11 + ((int_13 * num2) / this.YAxis.LabelCount)) + y) + (int_13 / this.YAxis.LabelCount)));
                        path.AddLine(int_10 - y, ((int_11 + ((int_13 * num2) / this.YAxis.LabelCount)) + y) + (int_13 / this.YAxis.LabelCount), int_10, (int_11 + ((int_13 * num2) / this.YAxis.LabelCount)) + (int_13 / this.YAxis.LabelCount));
                        path.AddLine(int_10, (int_11 + ((int_13 * num2) / this.YAxis.LabelCount)) + (int_13 / this.YAxis.LabelCount), int_10, int_11 + ((int_13 * num2) / this.YAxis.LabelCount));
                    }
                }
                graphics_0.FillPath(brush, path);
                graphics_0.DrawPath(pen, path);
                for (num2 = 0; num2 <= this.YAxis.LabelCount; num2++)
                {
                    if (this.YAxis.Show)
                    {
                        graphics_0.DrawString((this.MinValueY + (((this.float_1 - this.MinValueY) * (this.YAxis.LabelCount - num2)) / ((double) this.YAxis.LabelCount))).ToString(this.YAxis.ValueFormat), this.YAxis.Font, new SolidBrush(this.YAxis.ForeColor.ToColor()), new Rectangle(-y, ((int_11 + ((int_13 * num2) / this.YAxis.LabelCount)) - 10) + y, int_10 - 4, this.YAxis.Font.Height), format);
                    }
                    graphics_0.DrawLine(Pens.Black, rectangle2.Left - 3, rectangle2.Top + ((int_13 * num2) / this.YAxis.LabelCount), rectangle2.Left, rectangle2.Top + ((int_13 * num2) / this.YAxis.LabelCount));
                }
            }
            if (this.ChartTitle.Show)
            {
                format.Alignment = StringAlignment.Center;
                graphics_0.DrawString(this.ChartTitle.Text, this.ChartTitle.Font, new SolidBrush(this.ChartTitle.ForeColor.ToColor()), new Rectangle(int_10, ((int_11 - 2) - ((int) graphics_0.MeasureString(this.ChartTitle.Text, this.ChartTitle.Font).Height)) + this.ChartTitle.OffsetY, int_12, (int) graphics_0.MeasureString(this.ChartTitle.Text, this.ChartTitle.Font).Height), format);
            }
            if ((this.mHytfDhuET != null) && this.ColorGuider.Show)
            {
                for (num2 = 0; num2 < this.mHytfDhuET.Length; num2++)
                {
                    SolidBrush brush2;
                    switch (this.ChartType)
                    {
                        case ChartTypes.Bar:
                            brush2 = new SolidBrush(this.BarBrushColor[num2 % 12]);
                            break;

                        case ChartTypes.Line:
                            brush2 = new SolidBrush(this.BarPenColor[num2 % 12]);
                            break;

                        default:
                            brush2 = new SolidBrush(this.BarBrushColor[num2 % 12]);
                            break;
                    }
                    switch (this.ChartType)
                    {
                        case ChartTypes.Bar:
                            graphics_0.FillRectangle(brush2, (int_10 + int_12) + 6, (int_11 + (14 * num2)) + 4, 0x12, 8);
                            graphics_0.DrawRectangle(Pens.Gray, (int_10 + int_12) + 6, (int_11 + 4) + (14 * num2), 0x11, 7);
                            goto Label_05E9;

                        case ChartTypes.Line:
                            graphics_0.DrawLine(new Pen(brush2), (int) ((int_10 + int_12) + 6), (int) ((int_11 + (14 * num2)) + 8), (int) ((int_10 + int_12) + 0x18), (int) ((int_11 + (14 * num2)) + 8));
                            if (this.LineConnectionType != LineConnectionTypes.Square)
                            {
                                break;
                            }
                            graphics_0.FillRectangle(brush2, (int_10 + int_12) + 11, (int_11 + (14 * num2)) + 4, 8, 8);
                            goto Label_05E9;

                        default:
                            graphics_0.FillRectangle(brush2, (int_10 + int_12) + 6, (int_11 + (14 * num2)) + 4, 0x12, 8);
                            graphics_0.DrawRectangle(Pens.Gray, (int_10 + int_12) + 6, (int_11 + 4) + (14 * num2), 0x11, 7);
                            goto Label_05E9;
                    }
                    if (this.LineConnectionType == LineConnectionTypes.Round)
                    {
                        graphics_0.SmoothingMode = SmoothingMode.AntiAlias;
                        graphics_0.FillEllipse(brush2, (int_10 + int_12) + 11, (int_11 + (14 * num2)) + 4, 8, 8);
                    }
                Label_05E9:
                    graphics_0.DrawString(this.mHytfDhuET[num2], this.ColorGuider.Font, new SolidBrush(this.ColorGuider.ForeColor.ToColor()), (float) ((int_10 + int_12) + 0x1c), (float) ((int_11 + 1) + (14 * num2)));
                    brush2.Dispose();
                }
            }
            format.Dispose();
            graphics_0.DrawRectangle(Pens.Gray, rect);
            path.Reset();
            path.StartFigure();
            path.AddLine(rect.Left, rect.Top, rectangle2.Left, rectangle2.Top);
            path.AddLine(rectangle2.Left, rectangle2.Top, rectangle2.Left, rectangle2.Top + rectangle2.Height);
            path.AddLine(rectangle2.Left, rectangle2.Top + rectangle2.Height, rect.Left, rect.Top + rect.Height);
            path.AddLine(rect.Left, rect.Top + rect.Height, rect.Left, rect.Top);
            path.StartFigure();
            path.AddLine(rect.Left, rect.Top + rect.Height, rectangle2.Left, rectangle2.Top + rectangle2.Height);
            path.AddLine(rectangle2.Left, rectangle2.Top + rectangle2.Height, rectangle2.Left + rectangle2.Width, rectangle2.Top + rectangle2.Height);
            path.AddLine((int) (rectangle2.Left + rectangle2.Width), (int) (rectangle2.Top + rectangle2.Height), (int) (rect.Left + rect.Width), (int) (rect.Top + rect.Height));
            path.AddLine(rect.Left + rect.Width, rect.Top + rect.Height, rect.Left, rect.Top + rect.Height);
            graphics_0.DrawPath(Pens.Gray, path);
            path.Dispose();
            brush.Dispose();
            pen.Dispose();
        }

        private void method_35(Graphics graphics_0)
        {
            int width = (base.Width + this.InflateRight) + this.InflateLeft;
            int height = (base.Height + this.InflateBottom) + this.InflateTop;
            int num3 = 50 + this.InflateLeft;
            int num4 = 60 + this.InflateTop;
            int num5 = 100 + this.InflateRight;
            int num6 = 40 + this.InflateBottom;
            int num7 = (width - num3) - num5;
            int num8 = (height - num4) - num6;
            if (!this.ColorGuider.Show)
            {
                num7 += 0x62 - ((int) graphics_0.MeasureString(this.XAxis.UnitText, this.XAxis.UnitFont).Width);
                num5 -= 0x62;
            }
            if (!this.ChartTitle.Show)
            {
                num8 += 0x21;
                num4 -= 0x21;
            }
            StringFormat format = new StringFormat {
                LineAlignment = StringAlignment.Center,
                Alignment = StringAlignment.Center
            };
            if (this.ChartTitle.Show)
            {
                graphics_0.DrawString(this.ChartTitle.Text, this.ChartTitle.Font, new SolidBrush(this.ChartTitle.ForeColor.ToColor()), new Rectangle((num3 + (num7 / 2)) - 160, num4 - 40, 300, 40), format);
            }
            if (this.bool_4)
            {
                int num14;
                int num16;
                int num20;
                int num21;
                int num22;
                SolidBrush brush;
                if ((this.string_0 != null) && this.ColorGuider.Show)
                {
                    for (num21 = 0; num21 < this.int_8; num21++)
                    {
                        brush = new SolidBrush(this.BarBrushColor[num21 % 12]);
                        graphics_0.FillRectangle(brush, ((num3 + num7) + 6) + ((int) ((width - num7) * 0.2)), (num4 + (14 * num21)) + 4, 0x12, 8);
                        graphics_0.DrawRectangle(Pens.Gray, ((num3 + num7) + 6) + ((int) ((width - num7) * 0.2)), (num4 + 4) + (14 * num21), 0x11, 7);
                        graphics_0.DrawString(this.string_0[num21], this.ColorGuider.Font, new SolidBrush(this.ColorGuider.ForeColor.ToColor()), (float) (((num3 + num7) + 0x1c) + ((int) ((width - num7) * 0.2))), (float) ((num4 + 1) + (14 * num21)));
                        brush.Dispose();
                    }
                }
                float num24 = this.method_11(this.decimal_0[0]);
                for (num21 = 0; num21 < this.decimal_0[0].Length; num21++)
                {
                    this.float_0[0][num21] = ((float) this.decimal_0[0][num21]) / num24;
                }
                graphics_0.SmoothingMode = SmoothingMode.AntiAlias;
                if (num7 > num8)
                {
                    num20 = num8;
                    num22 = num20;
                    num16 = num3 + ((num7 - num8) / 2);
                    num14 = num4;
                }
                else
                {
                    num20 = num7;
                    num22 = num20;
                    num16 = num3;
                    num14 = num4 + ((num8 - num7) / 2);
                }
                Rectangle r = new Rectangle(num16, num14, num20, num22);
                r.Inflate(-10, -10);
                float num26 = num16 + (num20 / 2);
                float num25 = num14 + (num22 / 2);
                if (this.Shadow.Enable)
                {
                    new TextShadow { Radius = this.Shadow.Radius, Distance = this.Shadow.Distance, Alpha = this.Shadow.Alpha, Angle = this.Shadow.Angle }.DropShadow(graphics_0, r, this.Shadow.Color, "Fill", "Ellipse", null, 1);
                }
                float num15 = num14;
                float num17 = num16;
                float num18 = num14;
                float startAngle = 0f;
                int num10 = 0;
                if (this.Tips.Show)
                {
                    num10 = 10;
                }
                for (num21 = 0; num21 < this.float_0[0].Length; num21++)
                {
                    float num12;
                    Pen pen;
                    graphics_0.SmoothingMode = SmoothingMode.AntiAlias;
                    brush = new SolidBrush(this.BarBrushColor[num21 % 12]);
                    if (this.Stroke.TextureEnable)
                    {
                        pen = new Pen(new HatchBrush(this.Stroke.TextureStyle, this.BarPenColor[0], Color.Black), (float) this.Stroke.Width);
                    }
                    else
                    {
                        pen = new Pen(this.BarPenColor[0], (float) this.Stroke.Width);
                    }
                    graphics_0.FillPie(brush, r, startAngle, this.float_0[0][num21] * 360f);
                    if (this.Stroke.Width > 0)
                    {
                        graphics_0.DrawPie(pen, r, startAngle, this.float_0[0][num21] * 360f);
                    }
                    float num13 = num25 + ((((float) Math.Sin(((startAngle + (this.float_0[0][num21] * 180f)) * 3.1415926535897931) / 180.0)) * r.Width) / 2f);
                    float num11 = num13;
                    float num9 = num26 + ((((float) Math.Cos(((startAngle + (this.float_0[0][num21] * 180f)) * 3.1415926535897931) / 180.0)) * r.Width) / 2f);
                    if (((startAngle + (this.float_0[0][num21] * 180f)) > 90f) && ((startAngle + (this.float_0[0][num21] * 180f)) < 270f))
                    {
                        num12 = (num16 - 40) - 50;
                        if (!(((Math.Abs((float) (num13 - num15)) < (0x10 + num10)) || (Math.Abs((float) (num11 - num18)) < (0x10 + num10))) ? (Math.Abs((float) (num12 - num17)) >= (num7 / 2)) : true))
                        {
                            num13 = (num15 - 16f) + num10;
                        }
                        if ((this.float_0[0][num21] * 180f) < 360f)
                        {
                            graphics_0.DrawLine(Pens.Gray, num9 - 2f, num11, num12 + 85f, num13);
                        }
                    }
                    else
                    {
                        num12 = (num16 + num20) + 10;
                        if (!(((Math.Abs((float) (num13 - num15)) < (0x10 + num10)) || (Math.Abs((float) (num11 - num18)) < (0x10 + num10))) ? (Math.Abs((float) (num12 - num17)) >= (num7 / 2)) : true))
                        {
                            num13 = (num15 + 16f) + num10;
                        }
                        if ((this.float_0[0][num21] * 180f) < 360f)
                        {
                            graphics_0.DrawLine(Pens.Gray, num9 + 2f, num11, num12 - 2f, num13);
                        }
                    }
                    string s = "";
                    if (this.Tips.Show)
                    {
                        s = string.Concat(new object[] { this.string_0[num21], " - ", this.decimal_0[0][num21], "\n" });
                    }
                    s = s + ((this.float_0[0][num21] * 100f)).ToString("0.00") + "%";
                    if ((this.float_0[0][num21] * 180f) < 360f)
                    {
                        graphics_0.DrawString(s, this.Tips.Font, new SolidBrush(this.Tips.ForeColor.ToColor()), num12, (num13 - 6f) - 5f);
                    }
                    else
                    {
                        graphics_0.DrawString(s, this.Tips.Font, new SolidBrush(this.Tips.ForeColor.ToColor()), (float) ((num9 - 50f) - num10), (float) ((num11 - 6f) - 5f));
                    }
                    num15 = num13;
                    num17 = num12;
                    num18 = num11;
                    startAngle += this.float_0[0][num21] * 360f;
                    pen.Dispose();
                    brush.Dispose();
                }
                if (this.Crystal.Enable)
                {
                    graphics_0.SmoothingMode = SmoothingMode.AntiAlias;
                    if (this.Crystal.CoverFull)
                    {
                        graphics_0.SmoothingMode = SmoothingMode.AntiAlias;
                        Rectangle rect = new Rectangle(r.Left - (r.Width / 4), r.Top - (r.Height / 4), r.Width, r.Height);
                        GraphicsPath path = new GraphicsPath();
                        path.AddEllipse(rect);
                        PathGradientBrush brush2 = new PathGradientBrush(path) {
                            CenterColor = Color.FromArgb(0xa5, Color.White)
                        };
                        brush2.SurroundColors = new Color[] { Color.FromArgb(0, Color.White) };
                        Region region = new Region(path);
                        graphics_0.SetClip(region, CombineMode.Intersect);
                        path = new GraphicsPath();
                        path.AddEllipse(r);
                        region = new Region(path);
                        graphics_0.SetClip(region, CombineMode.Intersect);
                        graphics_0.FillEllipse(brush2, rect);
                        brush2.Dispose();
                        region.Dispose();
                        path.Dispose();
                        graphics_0.SmoothingMode = SmoothingMode.None;
                    }
                    else
                    {
                        Rectangle rectangle3 = new Rectangle(r.Left + (r.Width / 6), r.Top + 3, (r.Width * 2) / 3, (r.Height / 2) - 3);
                        LinearGradientBrush brush3 = new LinearGradientBrush(new Point(rectangle3.Left, rectangle3.Top), new Point(rectangle3.Left, (rectangle3.Top + rectangle3.Height) + 1), Color.FromArgb(230, Color.White), Color.FromArgb(0, Color.White));
                        graphics_0.FillEllipse(brush3, rectangle3);
                        brush3.Dispose();
                        Rectangle rectangle4 = new Rectangle(r.Left, (r.Top + (r.Height / 2)) + 1, r.Width, (r.Height / 2) + 1);
                        LinearGradientBrush brush4 = new LinearGradientBrush(new Point(rectangle4.Left, rectangle4.Top + rectangle4.Height), new Point(rectangle4.Left, rectangle4.Top), Color.FromArgb(230, Color.White), Color.FromArgb(0, Color.White));
                        GraphicsPath path2 = new GraphicsPath();
                        r.Inflate(1, 1);
                        path2.AddEllipse(r);
                        Region region2 = new Region(path2);
                        graphics_0.SetClip(region2, CombineMode.Replace);
                        graphics_0.FillRectangle(brush4, rectangle4);
                        graphics_0.SetClip(new Rectangle(0, 0, width, height));
                        path2.Dispose();
                        region2.Dispose();
                        brush4.Dispose();
                    }
                    graphics_0.SmoothingMode = SmoothingMode.None;
                }
            }
        }

        private void method_36(Graphics graphics_0)
        {
            int num19;
            int num = (base.Width + this.InflateRight) + this.InflateLeft;
            int num2 = (base.Height + this.InflateBottom) + this.InflateTop;
            int num3 = 50 + this.InflateLeft;
            int num4 = 60 + this.InflateTop;
            int num5 = 100 + this.InflateRight;
            int num6 = 40 + this.InflateBottom;
            int num7 = (num - num3) - num5;
            int num8 = (num2 - num4) - num6;
            if (!this.ColorGuider.Show)
            {
                num7 += 0x62 - ((int) graphics_0.MeasureString(this.XAxis.UnitText, this.XAxis.UnitFont).Width);
                num5 -= 0x62;
            }
            if (!this.YAxis.Show)
            {
                num7 += 0x30;
                num3 -= 0x30;
            }
            if (!this.ChartTitle.Show)
            {
                num8 += 0x21;
                num4 -= 0x21;
            }
            int num15 = 0;
            if (this.Dimension == ChartDimensions.Chart3D)
            {
                num15 = (int) (this.Depth3D * 0.85);
                this.method_34(graphics_0, num3, num4, num7, num8);
                num19 = this.Alpha3D;
            }
            else
            {
                this.method_33(graphics_0, num3, num4, num7, num8);
                num19 = 0xff;
            }
            if (this.bool_4)
            {
                Pen pen2 = new Pen(Color.FromArgb(0xff, 220, 220, 220));
                int groupSize = this.GroupSize;
                int num18 = this.int_9;
                if (num18 > 0)
                {
                    int num14;
                    int num16;
                    if (!(this.AutoBarWidth || ((num18 * groupSize) >= 12)))
                    {
                        num16 = (num7 / 4) / 0x10;
                        num14 = 5 * num16;
                    }
                    else
                    {
                        num14 = (int) (((double) (num7 / num18)) / (0.25 + groupSize));
                        num16 = (int) (0.25 * num14);
                    }
                    this.method_37(num8);
                    for (int i = 0; i < num18; i++)
                    {
                        int num21 = i;
                        int num12 = (num3 + ((num14 * num21) * this.GroupSize)) + (num16 * (num21 + 1));
                        int num20 = (int) (((double) num15) / 0.85);
                        this.method_23(graphics_0, pen2, num20, num4, num8, num12 + ((num14 * groupSize) / 2), (num14 * groupSize) + num16);
                        if (this.XAxis.Show && ((i % this.XAxis.SampleSize) == 0))
                        {
                            this.method_24(graphics_0, pen2, this.string_0[i], num20, num4, num8, num12 + ((num14 * groupSize) / 2), (num14 * groupSize) + num16);
                        }
                        bool flag = false;
                        for (int j = 0; j < groupSize; j++)
                        {
                            if (this.decimal_0[j][i] != -0.830213M)
                            {
                                Pen pen;
                                SolidBrush brush;
                                int num13;
                                int num11 = (int) ((this.float_0[j][i] - this.float_3) - 1f);
                                if (num11 < 0)
                                {
                                    num11 = -1 * num11;
                                    num13 = (num4 + num8) - ((int) this.float_3);
                                    flag = true;
                                }
                                else
                                {
                                    num13 = ((num4 + num8) - num11) - ((int) this.float_3);
                                    flag = false;
                                }
                                if ((groupSize == 1) && this.Colorful)
                                {
                                    if (this.Dimension == ChartDimensions.Chart3D)
                                    {
                                        brush = new SolidBrush(Color.FromArgb(num19, this.BarBrushColor[i % 12]));
                                    }
                                    else
                                    {
                                        brush = new SolidBrush(this.BarBrushColor[i % 12]);
                                    }
                                }
                                else if (this.Dimension == ChartDimensions.Chart3D)
                                {
                                    brush = new SolidBrush(Color.FromArgb(num19, this.BarBrushColor[j % 12]));
                                }
                                else
                                {
                                    brush = new SolidBrush(this.BarBrushColor[j % 12]);
                                }
                                if (this.Stroke.TextureEnable)
                                {
                                    pen = new Pen(new HatchBrush(this.Stroke.TextureStyle, this.BarPenColor[j % 12], Color.Gray), (float) this.Stroke.Width);
                                }
                                else
                                {
                                    pen = new Pen(this.BarPenColor[j % 12], (float) this.Stroke.Width);
                                }
                                pen.Alignment = PenAlignment.Inset;
                                if (this.Dimension == ChartDimensions.Chart3D)
                                {
                                    this.method_20(graphics_0, brush, pen, num12, num13, num14, num11, num15);
                                }
                                else
                                {
                                    this.method_19(graphics_0, brush, pen, num12, num13, num14, num11);
                                }
                                if ((this.Crystal.Enable && ((num11 - (this.Crystal.Contraction * 2)) > 2)) && ((num14 - (this.Crystal.Contraction * 2)) > 2))
                                {
                                    this.method_21(graphics_0, num12, num13, num14, num11, num15);
                                }
                                if (this.Tips.Show)
                                {
                                    this.method_22(graphics_0, this.decimal_0[j][i].ToString(), num12, num13, num14, num11, flag);
                                }
                                if (this.string_1 == "")
                                {
                                    this.string_1 = (num12 - num15);
                                    this.string_2 = num14;
                                    this.string_3 = (num13 + num15);
                                    this.string_4 = num11;
                                    this.string_5 = this.decimal_0[j][i];
                                }
                                else
                                {
                                    this.string_1 = this.string_1 + "," + (num12 - num15);
                                    this.string_2 = this.string_2 + "," + num14;
                                    this.string_3 = this.string_3 + "," + (num13 + num15);
                                    this.string_4 = this.string_4 + "," + num11;
                                    this.string_5 = this.string_5 + "," + this.decimal_0[j][i];
                                }
                                num12 += num14;
                            }
                        }
                    }
                }
                pen2.Dispose();
            }
            if (this.Dimension == ChartDimensions.Chart2D)
            {
                graphics_0.DrawRectangle(Pens.Gray, num3, num4, num7, num8);
                graphics_0.DrawLine(Pens.Black, (float) (num3 - 4), (num4 + num8) - this.float_3, (float) ((num3 + num7) - 1), (num4 + num8) - this.float_3);
                graphics_0.DrawLine(Pens.Black, num3, num4, num3, (num4 + num8) + 2);
            }
            this.method_25(graphics_0, num3, num4, num7, num8);
        }

        private void method_37(int int_10)
        {
            for (int i = 0; i < this.decimal_0.Length; i++)
            {
                this.float_0[i] = new float[this.decimal_0[i].Length];
                for (int j = 0; j < this.decimal_0[i].Length; j++)
                {
                    this.float_0[i][j] = ((((float) this.decimal_0[i][j]) - this.float_2) * int_10) / (this.float_1 - this.float_2);
                }
            }
        }

        private void method_38(Graphics graphics_0)
        {
            int num11;
            int num12;
            int num16;
            int num = (base.Width + this.InflateRight) + this.InflateLeft;
            int num2 = (base.Height + this.InflateBottom) + this.InflateTop;
            int num3 = 50 + this.InflateLeft;
            int num4 = 60 + this.InflateTop;
            int num5 = 100 + this.InflateRight;
            int num6 = 40 + this.InflateBottom;
            int num7 = (num - num3) - num5;
            int num8 = (num2 - num4) - num6;
            int groupSize = this.GroupSize;
            decimal[] numArray = new decimal[this.int_9];
            if (!this.ColorGuider.Show)
            {
                num7 += 0x62 - ((int) graphics_0.MeasureString(this.XAxis.UnitText, this.XAxis.UnitFont).Width);
                num5 -= 0x62;
            }
            if (!this.YAxis.Show)
            {
                num7 += 0x30;
                num3 -= 0x30;
            }
            if (!this.ChartTitle.Show)
            {
                num8 += 0x21;
                num4 -= 0x21;
            }
            else if (this.float_2 < 0f)
            {
                this.bool_4 = false;
                if (this.ShowErrorInfo)
                {
                    this.ChartTitle.Text = "StackBar can not accept value < 0";
                }
            }
            if (this.bool_4)
            {
                for (num11 = 0; num11 < this.int_9; num11++)
                {
                    numArray[num11] = 0M;
                    num12 = 0;
                    while (num12 < groupSize)
                    {
                        numArray[num11] += this.decimal_0[num12][num11];
                        num12++;
                    }
                }
                this.float_1 = this.method_12(this.method_7(numArray));
                if (this.MaxValueY != 0.0)
                {
                    this.float_1 = (float) this.MaxValueY;
                }
                for (num11 = 0; num11 < this.int_9; num11++)
                {
                    num12 = 0;
                    while (num12 < groupSize)
                    {
                        this.float_0[num12][num11] = ((((float) this.decimal_0[num12][num11]) - ((float) this.MinValueY)) * num8) / (this.float_1 - ((float) this.MinValueY));
                        num12++;
                    }
                }
            }
            int num21 = 0;
            if (this.Dimension == ChartDimensions.Chart3D)
            {
                num21 = (int) (this.Depth3D * 0.85);
                this.method_34(graphics_0, num3, num4, num7, num8);
                num16 = this.Alpha3D;
            }
            else
            {
                this.method_33(graphics_0, num3, num4, num7, num8);
                num16 = 0xff;
            }
            if (this.bool_4)
            {
                Pen pen2 = new Pen(Color.FromArgb(0xff, 220, 220, 220));
                groupSize = this.GroupSize;
                int num10 = this.int_9;
                if (num10 > 0)
                {
                    int num18;
                    int num19;
                    if (!(this.AutoBarWidth || (num10 >= 12)))
                    {
                        num19 = (num7 / 4) / 0x10;
                        num18 = 5 * num19;
                    }
                    else
                    {
                        num18 = (int) (((double) (num7 / num10)) / 1.25);
                        num19 = (int) (num18 * 0.25);
                    }
                    for (num11 = 0; num11 < num10; num11++)
                    {
                        int num17 = num11;
                        int num20 = (num3 + (num18 * num17)) + (num19 * (num17 + 1));
                        int num14 = 0;
                        int num22 = (int) (((double) num21) / 0.85);
                        graphics_0.SmoothingMode = SmoothingMode.AntiAlias;
                        this.method_23(graphics_0, pen2, num22, num4, num8, num20 + (num18 / 2), num18 + num19);
                        if (this.XAxis.Show && ((num11 % this.XAxis.SampleSize) == 0))
                        {
                            this.method_24(graphics_0, pen2, this.string_0[num11], num22, num4, num8, num20 + (num18 / 2), num18 + num19);
                        }
                        for (num12 = 0; num12 < groupSize; num12++)
                        {
                            if (this.decimal_0[num12][num11] != -0.830213M)
                            {
                                SolidBrush brush;
                                Pen pen;
                                int num13 = ((int) this.float_0[num12][num11]) - 1;
                                int num15 = ((num4 + num8) - num13) - num14;
                                if ((groupSize == 1) && this.Colorful)
                                {
                                    brush = new SolidBrush(Color.FromArgb(num16, this.BarBrushColor[num11 % 12]));
                                }
                                else
                                {
                                    brush = new SolidBrush(Color.FromArgb(num16, this.BarBrushColor[num12 % 12]));
                                }
                                if (this.Stroke.TextureEnable)
                                {
                                    pen = new Pen(new HatchBrush(this.Stroke.TextureStyle, this.BarPenColor[num12 % 12], Color.Gray), (float) this.Stroke.Width);
                                }
                                else
                                {
                                    pen = new Pen(this.BarPenColor[num12 % 12], (float) this.Stroke.Width);
                                }
                                pen.Alignment = PenAlignment.Inset;
                                if (this.Dimension == ChartDimensions.Chart3D)
                                {
                                    this.method_20(graphics_0, brush, pen, num20, num15, num18, num13, num21);
                                }
                                else
                                {
                                    this.method_19(graphics_0, brush, pen, num20, num15, num18, num13);
                                }
                                num14 += num13;
                                if ((this.Crystal.Enable && ((num13 - (this.Crystal.Contraction * 2)) > 2)) && ((num18 - (this.Crystal.Contraction * 2)) > 2))
                                {
                                    this.method_21(graphics_0, num20, num15, num18, num13, num21);
                                }
                                if (this.Tips.Show)
                                {
                                    this.method_22(graphics_0, this.decimal_0[num12][num11].ToString(), num20 - num22, num15 + num22, num18, num13, false);
                                }
                                if (this.string_1 == "")
                                {
                                    this.string_1 = (num20 - num21);
                                    this.string_2 = num18;
                                    this.string_3 = (num15 + num21);
                                    this.string_4 = num13;
                                    this.string_5 = this.decimal_0[num12][num11];
                                }
                                else
                                {
                                    this.string_1 = this.string_1 + "," + (num20 - num21);
                                    this.string_2 = this.string_2 + "," + num18;
                                    this.string_3 = this.string_3 + "," + (num15 + num21);
                                    this.string_4 = this.string_4 + "," + num13;
                                    this.string_5 = this.string_5 + "," + this.decimal_0[num12][num11];
                                }
                            }
                        }
                        num20 += num18;
                    }
                }
                pen2.Dispose();
            }
            if (this.Dimension == ChartDimensions.Chart2D)
            {
                graphics_0.DrawRectangle(Pens.Gray, num3, num4, num7, num8);
                graphics_0.DrawLine(Pens.Black, (int) (num3 - 4), (int) ((num4 + num8) - 1), (int) ((num3 + num7) - 1), (int) ((num4 + num8) - 1));
                graphics_0.DrawLine(Pens.Black, num3, num4, num3, (num4 + num8) + 2);
            }
            this.method_25(graphics_0, num3, num4, num7, num8);
        }

        private void method_39(Graphics graphics_0)
        {
            int num11;
            int num = (base.Width + this.InflateRight) + this.InflateLeft;
            int num2 = (base.Height + this.InflateBottom) + this.InflateTop;
            int num3 = 50 + this.InflateLeft;
            int num4 = 60 + this.InflateTop;
            int num5 = 100 + this.InflateRight;
            int num6 = 40 + this.InflateBottom;
            int num7 = (num - num3) - num5;
            int num8 = (num2 - num4) - num6;
            if (!this.ColorGuider.Show)
            {
                num7 += 0x62 - ((int) graphics_0.MeasureString(this.XAxis.UnitText, this.XAxis.UnitFont).Width);
                num5 -= 0x62;
            }
            if (!this.YAxis.Show)
            {
                num7 += 0x30;
                num3 -= 0x30;
            }
            if (!this.ChartTitle.Show)
            {
                num8 += 0x21;
                num4 -= 0x21;
            }
            int num9 = 0;
            int num10 = 0;
            if (this.Dimension == ChartDimensions.Chart3D)
            {
                num9 = (int) (this.Depth3D * 0.85);
                num10 = this.Depth3D;
                this.method_34(graphics_0, num3, num4, num7, num8);
                num11 = this.Alpha3D;
            }
            else
            {
                this.method_33(graphics_0, num3, num4, num7, num8);
                num11 = 0xff;
            }
            Pen pen = new Pen(Color.FromArgb(0xff, 220, 220, 220));
            if (this.bool_4)
            {
                graphics_0.SmoothingMode = SmoothingMode.AntiAlias;
                int groupSize = this.GroupSize;
                int num18 = this.int_9;
                if (num18 > 0)
                {
                    this.method_37(num8);
                    int num13 = num7 / num18;
                    for (int i = 0; i < groupSize; i++)
                    {
                        float num16;
                        Pen pen2;
                        SolidBrush brush = new SolidBrush(Color.FromArgb(num11, this.BarPenColor[i % 12]));
                        if (this.Stroke.TextureEnable)
                        {
                            pen2 = new Pen(new HatchBrush(this.Stroke.TextureStyle, this.BarPenColor[i % 12], Color.Black), (float) this.Stroke.Width);
                        }
                        else
                        {
                            pen2 = new Pen(this.BarPenColor[i % 12], (float) this.Stroke.Width);
                        }
                        GraphicsPath path = new GraphicsPath();
                        int num12 = num13 / 2;
                        num12 += num3;
                        int index = 0;
                        while (index < (num18 - 1))
                        {
                            if (i == 0)
                            {
                                this.method_23(graphics_0, pen, num10, num4, num8, num12, num13);
                                if (this.XAxis.Show && ((index % this.XAxis.SampleSize) == 0))
                                {
                                    this.method_24(graphics_0, pen, this.string_0[index], num10, num4, num8, num12, num13);
                                }
                            }
                            if (this.decimal_0[i][index] != -0.830213M)
                            {
                                graphics_0.SmoothingMode = SmoothingMode.AntiAlias;
                                if (this.Dimension == ChartDimensions.Chart2D)
                                {
                                    if (this.decimal_0[i][index + 1] != -0.830213M)
                                    {
                                        this.method_27(graphics_0, pen2, (float) num12, (num4 + num8) - this.float_0[i][index], (float) (num12 + num13), (num4 + num8) - this.float_0[i][index + 1]);
                                    }
                                }
                                else
                                {
                                    num16 = this.LineConnectionRadius / 2;
                                    if (this.LineConnectionType == LineConnectionTypes.None)
                                    {
                                        num16 = 0f;
                                    }
                                    this.method_28(graphics_0, pen2, brush, num9, num16, (float) num12, (num4 + num8) - this.float_0[i][index], i);
                                    if (this.decimal_0[i][index + 1] != -0.830213M)
                                    {
                                        this.method_29(graphics_0, pen2, brush, num9, num16, (float) num12, (num4 + num8) - this.float_0[i][index], (float) (num12 + num13), (num4 + num8) - this.float_0[i][index + 1]);
                                    }
                                    if (this.Tips.Show && (this.decimal_0[i][index] != -0.830213M))
                                    {
                                        this.method_22(graphics_0, this.decimal_0[i][index].ToString(), num12 - (num13 / 2), ((num4 + num8) - ((int) this.float_0[i][index])) - (this.LineConnectionRadius / 2), num13, (int) this.float_0[i][index], false);
                                    }
                                    this.method_31((float) (num12 - num9), ((num4 + num9) + num8) - this.float_0[i][index], this.decimal_0[i][index]);
                                }
                            }
                            num12 += num13;
                            index++;
                        }
                        if ((i == 0) && (i == 0))
                        {
                            this.method_23(graphics_0, pen, num10, num4, num8, num12, num13);
                            if (this.XAxis.Show && ((index % this.XAxis.SampleSize) == 0))
                            {
                                this.method_24(graphics_0, pen, this.string_0[index], num10, num4, num8, num12, num13);
                            }
                        }
                        if ((this.Dimension == ChartDimensions.Chart3D) && (this.decimal_0[i][index] != -0.830213M))
                        {
                            num16 = this.LineConnectionRadius / 2;
                            new GraphicsPath();
                            if (this.LineConnectionType == LineConnectionTypes.None)
                            {
                                num16 = 0f;
                            }
                            this.method_28(graphics_0, pen2, brush, num9, num16, (float) num12, (num4 + num8) - this.float_0[i][index], i);
                            if (this.Tips.Show)
                            {
                                this.method_22(graphics_0, this.decimal_0[i][index].ToString(), num12 - (num13 / 2), ((num4 + num8) - ((int) this.float_0[i][index])) - (this.LineConnectionRadius / 2), num13, (int) this.float_0[i][index], false);
                            }
                            this.method_31((float) (num12 - num9), ((num4 + num9) + num8) - this.float_0[i][index], this.decimal_0[i][index]);
                        }
                        pen2.Dispose();
                        path.Dispose();
                        if (this.Dimension == ChartDimensions.Chart2D)
                        {
                            num12 = (num13 / 2) + num3;
                            LineConnectionTypes lineConnectionType = this.LineConnectionType;
                            int lineConnectionRadius = this.LineConnectionRadius;
                            switch (lineConnectionType)
                            {
                                case LineConnectionTypes.Round:
                                    graphics_0.SmoothingMode = SmoothingMode.AntiAlias;
                                    break;

                                case LineConnectionTypes.Square:
                                    graphics_0.SmoothingMode = SmoothingMode.None;
                                    break;
                            }
                            for (int j = 0; j < num18; j++)
                            {
                                if (this.decimal_0[i][j] != -0.830213M)
                                {
                                    switch (lineConnectionType)
                                    {
                                        case LineConnectionTypes.Round:
                                            graphics_0.FillEllipse(brush, (float) (num12 - (lineConnectionRadius / 2)), ((num4 + num8) - this.float_0[i][j]) - (lineConnectionRadius / 2), (float) lineConnectionRadius, (float) lineConnectionRadius);
                                            break;

                                        case LineConnectionTypes.Square:
                                            graphics_0.FillRectangle(brush, (float) (num12 - (lineConnectionRadius / 2)), ((num4 + num8) - this.float_0[i][j]) - (lineConnectionRadius / 2), (float) lineConnectionRadius, (float) lineConnectionRadius);
                                            break;
                                    }
                                    if (this.Tips.Show)
                                    {
                                        this.method_22(graphics_0, this.decimal_0[i][j].ToString(), num12 - (num13 / 2), ((num4 + num8) - ((int) this.float_0[i][j])) - (this.LineConnectionRadius / 2), num13, (int) this.float_0[i][index], false);
                                    }
                                    this.method_31((float) num12, ((num4 + num9) + num8) - this.float_0[i][j], this.decimal_0[i][j]);
                                }
                                num12 += num13;
                            }
                            graphics_0.SmoothingMode = SmoothingMode.AntiAlias;
                        }
                    }
                }
            }
            if (this.Dimension == ChartDimensions.Chart2D)
            {
                graphics_0.DrawRectangle(Pens.Gray, num3, num4, num7, num8);
                graphics_0.DrawLine(Pens.Black, (float) (num3 - 4), (num4 + num8) - this.float_3, (float) ((num3 + num7) - 1), (num4 + num8) - this.float_3);
                graphics_0.DrawLine(Pens.Black, num3, num4, num3, (num4 + num8) + 2);
            }
            this.method_25(graphics_0, num3, num4, num7, num8);
        }

        private void method_40(Graphics graphics_0)
        {
            int num = (base.Width + this.InflateRight) + this.InflateLeft;
            int num2 = (base.Height + this.InflateBottom) + this.InflateTop;
            int x = 50 + this.InflateLeft;
            int y = 60 + this.InflateTop;
            int num5 = 100 + this.InflateRight;
            int num6 = 40 + this.InflateBottom;
            int width = (num - x) - num5;
            int height = (num2 - y) - num6;
            if (!this.ColorGuider.Show)
            {
                width += 0x62 - ((int) graphics_0.MeasureString(this.XAxis.UnitText, this.XAxis.UnitFont).Width);
                num5 -= 0x62;
            }
            if (!this.ChartTitle.Show)
            {
                height += 0x21;
                y -= 0x21;
            }
            StringFormat format = new StringFormat {
                Alignment = StringAlignment.Far,
                LineAlignment = StringAlignment.Center,
                Alignment = StringAlignment.Center
            };
            if (this.ChartTitle.Show)
            {
                graphics_0.DrawString(this.ChartTitle.Text, this.ChartTitle.Font, new SolidBrush(this.ChartTitle.ForeColor.ToColor()), new Rectangle(x, -30 + this.ChartTitle.OffsetY, width, 100), format);
            }
            if (this.bool_4)
            {
                int num10;
                float num11 = this.method_11(this.decimal_0[0]);
                if (num11 > 0f)
                {
                    for (num10 = 0; num10 < this.decimal_0[0].Length; num10++)
                    {
                        this.float_0[0][num10] = ((float) this.decimal_0[0][num10]) / num11;
                    }
                }
                else
                {
                    num10 = 0;
                    while (num10 < this.decimal_0[0].Length)
                    {
                        this.float_0[0][num10] = 0f;
                        num10++;
                    }
                }
                if ((this.string_0 != null) && this.ColorGuider.Show)
                {
                    for (num10 = 0; num10 < this.int_8; num10++)
                    {
                        SolidBrush brush = new SolidBrush(this.BarBrushColor[num10 % 12]);
                        graphics_0.FillRectangle(brush, (x + width) + ((int) ((num - width) * 0.2)), (y + (14 * num10)) + 4, 0x12, 8);
                        graphics_0.DrawRectangle(Pens.Gray, (x + width) + ((int) ((num - width) * 0.2)), (y + 4) + (14 * num10), 0x11, 7);
                        if ((num11 > 0f) && (this.float_0[0][num10] > 0f))
                        {
                            graphics_0.DrawString(this.string_0[num10], this.ColorGuider.Font, new SolidBrush(this.ColorGuider.ForeColor.ToColor()), (float) (((x + width) + 0x16) + ((int) ((num - width) * 0.2))), (float) ((y + 1) + (14 * num10)));
                        }
                        else
                        {
                            graphics_0.DrawString(this.string_0[num10] + "(0)", this.ColorGuider.Font, new SolidBrush(this.ColorGuider.ForeColor.ToColor()), (float) (((x + width) + 0x16) + ((int) ((num - width) * 0.2))), (float) ((y + 1) + (14 * num10)));
                        }
                        brush.Dispose();
                    }
                }
                graphics_0.SmoothingMode = SmoothingMode.AntiAlias;
                int num13 = 30;
                PointF[] tfArray2 = new PointF[this.float_0[0].Length];
                PointF[] tfArray = new PointF[this.float_0[0].Length];
                float[] numArray = new float[this.float_0[0].Length];
                Rectangle rect = new Rectangle(x, y, width, height);
                rect.Inflate((int) ((-1 * width) * 0.1), (int) ((-1 * height) * 0.0));
                rect.Offset((int) (((-1 * width) * 0.1) / 2.0), 0);
                Rectangle rectangle2 = rect;
                rectangle2.Offset(0, 30);
                float num20 = rect.Left + (rect.Width / 2);
                float num21 = rect.Top + (rect.Height / 2);
                graphics_0.DrawEllipse(Pens.Silver, rectangle2);
                GraphicsPath path = new GraphicsPath();
                GraphicsPath path2 = new GraphicsPath();
                float startAngle = 0f;
                if (num11 > 0f)
                {
                    for (num10 = 0; num10 < this.float_0[0].Length; num10++)
                    {
                        numArray[num10] = startAngle;
                        if (this.float_0[0][num10] > 0f)
                        {
                            path.AddArc(rect, startAngle, this.float_0[0][num10] * 360f);
                            tfArray2[num10] = path.PathPoints[0];
                        }
                        else if ((num10 == 0) || (num10 == (this.float_0[0].Length - 1)))
                        {
                            tfArray2[num10] = new PointF((float) (rect.Left + rect.Width), (float) (rect.Top + (rect.Height / 2)));
                        }
                        else if (this.float_0[0][num10 + 1] > 0f)
                        {
                            path.AddArc(rect, startAngle, this.float_0[0][num10 + 1] * 360f);
                            tfArray2[num10] = path.PathPoints[0];
                        }
                        else
                        {
                            tfArray2[num10] = tfArray2[num10 - 1];
                        }
                        startAngle += this.float_0[0][num10] * 360f;
                        if ((numArray[num10] >= 0f) && (numArray[num10] <= 180f))
                        {
                            path2.AddLine(num20, num21, num20, num21 + num13);
                            path2.AddLine(num20, num21 + num13, tfArray2[num10].X, tfArray2[num10].Y + num13);
                            path2.AddLine(tfArray2[num10].X, tfArray2[num10].Y + num13, tfArray2[num10].X, tfArray2[num10].Y);
                            path2.AddLine(tfArray2[num10].X, tfArray2[num10].Y, num20, num21);
                            graphics_0.FillPath(new SolidBrush(Color.FromArgb(200, this.BarBrushColor[num10 % 12])), path2);
                            path2.Reset();
                        }
                        path.Reset();
                    }
                    startAngle = 0f;
                    for (num10 = 0; num10 < this.float_0[0].Length; num10++)
                    {
                        numArray[num10] = startAngle;
                        if (this.float_0[0][num10] > 0f)
                        {
                            path.AddArc(rect, startAngle, (this.float_0[0][num10] * 360f) / 2f);
                            tfArray[num10] = path.PathPoints[path.PathPoints.Length - 1];
                        }
                        else if ((num10 == 0) || (num10 == (this.float_0[0].Length - 1)))
                        {
                            tfArray[num10] = new PointF((float) (rect.Left + rect.Width), (float) (rect.Top + (rect.Height / 2)));
                        }
                        else if (this.float_0[0][num10 + 1] > 0f)
                        {
                            path.AddArc(rect, startAngle, (this.float_0[0][num10 + 1] * 360f) / 2f);
                            tfArray[num10] = path.PathPoints[path.PathPoints.Length - 1];
                        }
                        else
                        {
                            tfArray[num10] = tfArray[num10 - 1];
                        }
                        startAngle += this.float_0[0][num10] * 360f;
                        path.Reset();
                    }
                }
                if (num11 > 0f)
                {
                    for (num10 = 0; num10 < this.float_0[0].Length; num10++)
                    {
                        if (this.float_0[0][num10] > 0f)
                        {
                            byte alpha = 0xff;
                            if ((num10 < (this.float_0[0].Length - 1)) && (numArray[num10 + 1] <= 180f))
                            {
                                alpha = 200;
                            }
                            graphics_0.FillPie(new SolidBrush(Color.FromArgb(alpha, this.BarBrushColor[num10 % 12])), rect, numArray[num10], this.float_0[0][num10] * 360f);
                            if ((this.Crystal.Enable && this.Crystal.CoverFull) && (((this.float_0[0][num10] * 360f) > 30f) && ((this.float_0[0][num10] * 360f) <= 180f)))
                            {
                                if (num10 < (this.float_0[0].Length - 1))
                                {
                                    graphics_0.FillPie(new LinearGradientBrush(tfArray2[num10], tfArray2[num10 + 1], Color.FromArgb(0xb2, Color.White), Color.FromArgb(0x19, Color.White)), rect, numArray[num10], this.float_0[0][num10] * 360f);
                                }
                                else
                                {
                                    graphics_0.FillPie(new LinearGradientBrush(tfArray2[num10], tfArray2[0], Color.FromArgb(0x80, Color.White), Color.FromArgb(0, Color.White)), rect, numArray[num10], this.float_0[0][num10] * 360f);
                                }
                            }
                        }
                    }
                }
                else
                {
                    graphics_0.FillPie(new SolidBrush(Color.FromArgb(200, this.BarBrushColor[0])), rect, 0f, 360f);
                }
                if (num11 > 0f)
                {
                    for (num10 = 0; num10 < this.float_0[0].Length; num10++)
                    {
                        if ((this.float_0[0][num10] > 0f) && (numArray[num10] < 180f))
                        {
                            float left;
                            float num18;
                            float num19;
                            if (num10 < (this.float_0[0].Length - 1))
                            {
                                if (numArray[num10 + 1] <= 180f)
                                {
                                    left = tfArray2[num10 + 1].X;
                                    num18 = tfArray2[num10 + 1].Y;
                                    num19 = numArray[num10 + 1] - numArray[num10];
                                }
                                else
                                {
                                    left = rect.Left;
                                    num18 = rect.Top + (rect.Height / 2);
                                    num19 = 180f - numArray[num10];
                                }
                            }
                            else
                            {
                                left = rect.Left;
                                num18 = rect.Top + (rect.Height / 2);
                                num19 = 180f - numArray[num10];
                            }
                            path2.AddArc(rect, numArray[num10], num19);
                            path2.AddLine(left, num18, left, num18 + num13);
                            path2.AddArc(rectangle2, numArray[num10], num19);
                            path2.AddLine(tfArray2[num10].X, tfArray2[num10].Y + num13, tfArray2[num10].X, tfArray2[num10].Y);
                            graphics_0.FillPath(new SolidBrush(Color.FromArgb(220, this.BarBrushColor[num10 % 12])), path2);
                            path2.Reset();
                        }
                    }
                }
                else
                {
                    path2.AddArc(rect, 0f, 180f);
                    path2.AddLine(rect.X, rect.Y + (rect.Height / 2), rect.X, (rect.Y + (rect.Height / 2)) + num13);
                    path2.AddArc(rectangle2, 0f, 180f);
                    path2.AddLine((int) (rect.X + rect.Width), (int) ((rect.Y + (rect.Height / 2)) + num13), (int) (rect.X + rect.Width), (int) (rect.Y + (rect.Height / 2)));
                    graphics_0.FillPath(new SolidBrush(Color.FromArgb(220, this.BarBrushColor[0])), path2);
                    path2.Reset();
                }
                Point point = new Point(rect.Left, 0);
                Point point2 = new Point(rect.Left + rect.Width, 0);
                Color[] colorArray2 = new Color[] { Color.FromArgb(180, Color.Black), Color.FromArgb(100, Color.White), Color.FromArgb(180, Color.Black) };
                float[] numArray2 = new float[3];
                numArray2[1] = 0.7f;
                numArray2[2] = 1f;
                float[] numArray3 = numArray2;
                ColorBlend blend = new ColorBlend {
                    Colors = colorArray2,
                    Positions = numArray3
                };
                LinearGradientBrush brush2 = new LinearGradientBrush(point, point2, Color.Red, Color.Red) {
                    InterpolationColors = blend
                };
                GraphicsPath path3 = new GraphicsPath();
                path3.AddArc(rect, 0f, 180f);
                path3.AddLine(rect.Left, rect.Top + (rect.Height / 2), rectangle2.Left, rectangle2.Top + (rectangle2.Height / 2));
                path3.AddArc(rectangle2, 0f, 180f);
                path3.AddLine((int) (rectangle2.Left + rectangle2.Width), (int) (rectangle2.Top + (rectangle2.Height / 2)), (int) (rect.Left + rect.Width), (int) (rect.Top + (rect.Height / 2)));
                graphics_0.FillPath(brush2, path3);
                float num14 = (rect.Left + rect.Width) + 20;
                float num15 = 0f;
                float num16 = 0f;
                float num9 = 0f;
                for (num10 = 0; num10 < this.float_0[0].Length; num10++)
                {
                    if (this.float_0[0][num10] > 0f)
                    {
                        float num22 = (num20 + tfArray[num10].X) / 2f;
                        float num23 = (num21 + tfArray[num10].Y) / 2f;
                        string s = "";
                        if ((this.float_0[0][num10] * 360f) >= 20f)
                        {
                            if (this.Tips.Show)
                            {
                                s = this.string_0[num10] + "\n" + this.decimal_0[0][num10].ToString() + "\n";
                            }
                            float num25 = this.float_0[0][num10] * 100f;
                            s = s + num25.ToString("0.0") + "%";
                            graphics_0.DrawString(s, this.Tips.Font, new SolidBrush(this.Tips.ForeColor.ToColor()), (float) (num22 - 10f), (float) (num23 - 4f));
                        }
                        else
                        {
                            if (numArray[num10] < 180f)
                            {
                                if (num16 == 0f)
                                {
                                    num16 = rect.Top + (rect.Height / 2);
                                }
                                else
                                {
                                    num16 += 16f;
                                    if (this.Tips.Show)
                                    {
                                        num16 += 12f;
                                    }
                                }
                                num15 = num16;
                            }
                            else
                            {
                                if (num9 == 0f)
                                {
                                    num9 = rect.Top - ((rect.Top - y) / 4);
                                }
                                else
                                {
                                    num9 += 16f;
                                    if (this.Tips.Show)
                                    {
                                        num9 += 12f;
                                    }
                                }
                                num15 = num9;
                            }
                            if (this.Tips.Show)
                            {
                                s = this.string_0[num10] + "\n";
                            }
                            s = s + ((this.float_0[0][num10] * 100f)).ToString("0.0") + "%";
                            graphics_0.DrawString(s, this.Tips.Font, new SolidBrush(this.Tips.ForeColor.ToColor()), num14, num15);
                            graphics_0.DrawLine(Pens.Gray, num14, num15 + 6f, tfArray[num10].X, tfArray[num10].Y);
                        }
                    }
                }
                path.Dispose();
                path2.Dispose();
                graphics_0.DrawEllipse(Pens.Silver, rect);
            }
        }

        private void method_41(Graphics graphics_0)
        {
            int num23;
            int num = (base.Width + this.InflateRight) + this.InflateLeft;
            int num2 = (base.Height + this.InflateBottom) + this.InflateTop;
            int num3 = 50 + this.InflateLeft;
            int num4 = 60 + this.InflateTop;
            int num5 = 100 + this.InflateRight;
            int num6 = 40 + this.InflateBottom;
            int num7 = (num - num3) - num5;
            int num8 = (num2 - num4) - num6;
            if (!this.ColorGuider.Show)
            {
                num7 += 0x62 - ((int) graphics_0.MeasureString(this.XAxis.UnitText, this.XAxis.UnitFont).Width);
                num5 -= 0x62;
            }
            if (!this.YAxis.Show)
            {
                num7 += 0x30;
                num3 -= 0x30;
            }
            if (!this.ChartTitle.Show)
            {
                num8 += 0x21;
                num4 -= 0x21;
            }
            if (this.ShowErrorInfo && (this.float_2 < 0f))
            {
                this.ChartTitle.Text = "HBar Chart can not accept value<0";
                this.bool_4 = false;
            }
            int num9 = 0;
            if (this.Dimension == ChartDimensions.Chart3D)
            {
                num9 = (int) (this.Depth3D * 0.85);
                this.method_34(graphics_0, num3, num4, num7, num8);
                num23 = this.Alpha3D;
            }
            else
            {
                this.method_33(graphics_0, num3, num4, num7, num8);
                num23 = 0xff;
            }
            for (int i = 0; i <= this.YAxis.LabelCount; i++)
            {
                this.method_23(graphics_0, new Pen(Color.FromArgb(0xff, 220, 220, 220)), (int) (((double) num9) / 0.85), num4, num8, num3 + ((num7 * i) / this.YAxis.LabelCount), num7 / this.YAxis.LabelCount);
                if (this.XAxis.Show)
                {
                    this.method_24(graphics_0, new Pen(Color.FromArgb(0xff, 220, 220, 220)), (this.float_2 + (((this.float_1 - this.float_2) * (this.YAxis.LabelCount - i)) / ((float) this.YAxis.LabelCount))).ToString(this.YAxis.ValueFormat), (int) (((double) num9) / 0.85), num4, num8, num3 + ((num7 * (this.YAxis.LabelCount - i)) / this.YAxis.LabelCount), num7 / this.YAxis.LabelCount);
                }
            }
            if (this.bool_4)
            {
                Pen pen = new Pen(Color.FromArgb(0xff, 220, 220, 220));
                int groupSize = this.GroupSize;
                int num12 = this.int_9;
                if (num12 > 0)
                {
                    int num15;
                    int num21;
                    if (!(this.AutoBarWidth || ((num12 * groupSize) >= 12)))
                    {
                        num21 = (num8 / 4) / 0x10;
                        num15 = 5 * num21;
                    }
                    else
                    {
                        num15 = (int) (((double) (num8 / num12)) / (0.25 + groupSize));
                        num21 = (int) (0.25 * num15);
                    }
                    this.method_37(num8);
                    for (int j = 0; j < num12; j++)
                    {
                        int num20 = j;
                        int num16 = num3;
                        int num14 = (num4 + ((num15 * num20) * this.GroupSize)) + (num21 * (num20 + 1));
                        int num22 = (int) (((double) num9) / 0.85);
                        this.method_26(graphics_0, pen, this.string_0[j], num22, num3, num4, num7, num14 + ((num15 * groupSize) / 2), num15);
                        bool flag = false;
                        for (int k = 0; k < groupSize; k++)
                        {
                            if (this.decimal_0[k][j] != -0.830213M)
                            {
                                SolidBrush brush;
                                Pen pen2;
                                int num17 = (int) ((((this.float_0[k][j] * num7) / ((float) num8)) - this.float_3) - 1f);
                                if ((groupSize == 1) && this.Colorful)
                                {
                                    if (this.Dimension == ChartDimensions.Chart3D)
                                    {
                                        brush = new SolidBrush(Color.FromArgb(num23, this.BarBrushColor[j % 12]));
                                    }
                                    else
                                    {
                                        brush = new SolidBrush(this.BarBrushColor[j % 12]);
                                    }
                                }
                                else if (this.Dimension == ChartDimensions.Chart3D)
                                {
                                    brush = new SolidBrush(Color.FromArgb(num23, this.BarBrushColor[k % 12]));
                                }
                                else
                                {
                                    brush = new SolidBrush(this.BarBrushColor[k % 12]);
                                }
                                if (this.Stroke.TextureEnable)
                                {
                                    pen2 = new Pen(new HatchBrush(this.Stroke.TextureStyle, this.BarPenColor[k % 12], Color.Gray), (float) this.Stroke.Width);
                                }
                                else
                                {
                                    pen2 = new Pen(this.BarPenColor[k % 12], (float) this.Stroke.Width);
                                }
                                pen2.Alignment = PenAlignment.Inset;
                                if (this.Dimension == ChartDimensions.Chart3D)
                                {
                                    this.method_20(graphics_0, brush, pen2, num16, num14, num17, num15, num9);
                                }
                                else
                                {
                                    this.method_19(graphics_0, brush, pen2, num16, num14, num17, num15);
                                }
                                if ((this.Crystal.Enable && ((num15 - (this.Crystal.Contraction * 2)) > 2)) && ((num17 - (this.Crystal.Contraction * 2)) > 2))
                                {
                                    this.method_21(graphics_0, num16, num14, num17, num15, num9);
                                }
                                if (this.Tips.Show)
                                {
                                    this.method_22(graphics_0, this.decimal_0[k][j].ToString(), num16, num14 + 15, num17, num15, flag);
                                }
                                if (this.string_1 == "")
                                {
                                    this.string_1 = (num16 - num9);
                                    this.string_2 = num17;
                                    this.string_3 = (num14 + num9);
                                    this.string_4 = num15;
                                    this.string_5 = this.decimal_0[k][j];
                                }
                                else
                                {
                                    this.string_1 = this.string_1 + "," + (num16 - num9);
                                    this.string_2 = this.string_2 + "," + num17;
                                    this.string_3 = this.string_3 + "," + (num14 + num9);
                                    this.string_4 = this.string_4 + "," + num15;
                                    this.string_5 = this.string_5 + "," + this.decimal_0[k][j];
                                }
                                num14 += num15;
                            }
                        }
                    }
                }
                pen.Dispose();
            }
            if (this.Dimension == ChartDimensions.Chart2D)
            {
                graphics_0.DrawRectangle(Pens.Gray, num3, num4, num7, num8);
                graphics_0.DrawLine(Pens.Black, (float) (num3 - 4), (num4 + num8) - this.float_3, (float) ((num3 + num7) - 1), (num4 + num8) - this.float_3);
                graphics_0.DrawLine(Pens.Black, num3, num4, num3, (num4 + num8) + 2);
            }
            string unitText = this.YAxis.UnitText;
            this.YAxis.UnitText = this.XAxis.UnitText;
            this.XAxis.UnitText = unitText;
            this.method_25(graphics_0, num3, num4, num7 + 10, num8);
        }

        private void method_42(Graphics graphics_0)
        {
            int num19;
            int num = (base.Width + this.InflateRight) + this.InflateLeft;
            int num2 = (base.Height + this.InflateBottom) + this.InflateTop;
            int num3 = 50 + this.InflateLeft;
            int num4 = 60 + this.InflateTop;
            int num5 = 100 + this.InflateRight;
            int num6 = 40 + this.InflateBottom;
            int num7 = (num - num3) - num5;
            int num8 = (num2 - num4) - num6;
            if (this.string_0 == null)
            {
                this.string_0 = new string[0];
            }
            DateTime[] timeArray = new DateTime[this.string_0.Length];
            int index = 0;
            while (true)
            {
                if (index >= this.string_0.Length)
                {
                    break;
                }
                try
                {
                    timeArray[index] = DateTime.Parse(this.string_0[index]);
                }
                catch (Exception)
                {
                    this.ChartTitle.Text = "The first column of your data must be DateTime!";
                    this.bool_4 = false;
                }
                index++;
            }
            int num10 = 0;
            DateTime start = this.Trend.Start;
            while (start <= this.Trend.End)
            {
                switch (this.Trend.TimeSpan)
                {
                    case TimeSpanTypes.Year:
                        start = start.AddYears(1);
                        break;

                    case TimeSpanTypes.Month:
                        start = start.AddMonths(1);
                        break;

                    case TimeSpanTypes.Day:
                        start = start.AddDays(1.0);
                        break;

                    case TimeSpanTypes.Hour:
                        start = start.AddHours(1.0);
                        break;

                    case TimeSpanTypes.Minute:
                        start = start.AddMinutes(1.0);
                        break;

                    case TimeSpanTypes.Second:
                        start = start.AddSeconds(1.0);
                        break;

                    case TimeSpanTypes.Millisecond:
                        start = start.AddMilliseconds(1.0);
                        break;

                    default:
                        start = start.AddDays(1.0);
                        break;
                }
                num10++;
            }
            if (num10 == 0)
            {
                this.bool_4 = false;
                this.ChartTitle.Text = "Please set DSkinChart.Trend attribute for TrendChart.";
            }
            if (!this.ColorGuider.Show)
            {
                num7 += 0x62 - ((int) graphics_0.MeasureString(this.XAxis.UnitText, this.XAxis.UnitFont).Width);
                num5 -= 0x62;
            }
            if (!this.YAxis.Show)
            {
                num7 += 0x30;
                num3 -= 0x30;
            }
            if (!this.ChartTitle.Show)
            {
                num8 += 0x21;
                num4 -= 0x21;
            }
            int num13 = 0;
            int num16 = 0;
            if (this.Dimension == ChartDimensions.Chart3D)
            {
                num13 = (int) (this.Depth3D * 0.85);
                num16 = this.Depth3D;
                this.method_34(graphics_0, num3, num4, num7, num8);
                num19 = this.Alpha3D;
            }
            else
            {
                this.method_33(graphics_0, num3, num4, num7, num8);
                num19 = 0xff;
            }
            Pen pen2 = new Pen(Color.FromArgb(0xff, 220, 220, 220));
            if (this.bool_4)
            {
                DateTime[] timeArray2 = new DateTime[num10 + 1];
                num10 = 0;
                start = this.Trend.Start;
                while (start < this.Trend.End)
                {
                    timeArray2[num10] = start;
                    switch (this.Trend.TimeSpan)
                    {
                        case TimeSpanTypes.Year:
                            start = start.AddYears(1);
                            break;

                        case TimeSpanTypes.Month:
                            start = start.AddMonths(1);
                            break;

                        case TimeSpanTypes.Day:
                            start = start.AddDays(1.0);
                            break;

                        case TimeSpanTypes.Hour:
                            start = start.AddHours(1.0);
                            break;

                        case TimeSpanTypes.Minute:
                            start = start.AddMinutes(1.0);
                            break;

                        case TimeSpanTypes.Second:
                            start = start.AddSeconds(1.0);
                            break;

                        case TimeSpanTypes.Millisecond:
                            start = start.AddMilliseconds(1.0);
                            break;

                        default:
                            start = start.AddDays(1.0);
                            break;
                    }
                    num10++;
                }
                timeArray2[num10] = this.Trend.End;
                int num21 = num7 / num10;
                index = 0;
                while (index <= num10)
                {
                    if ((index != 0) && (index != num10))
                    {
                        this.method_23(graphics_0, pen2, num16, num4, num8, num3 + (index * num21), num21);
                    }
                    this.method_24(graphics_0, pen2, timeArray2[index].ToString(this.Trend.ValueFormat), num16, num4, num8, num3 + (index * num21), num21);
                    index++;
                }
                graphics_0.SmoothingMode = SmoothingMode.AntiAlias;
                int groupSize = this.GroupSize;
                int num18 = this.int_9;
                if (num18 > 0)
                {
                    for (int i = 0; i < groupSize; i++)
                    {
                        Pen pen;
                        int num15 = num3;
                        SolidBrush brush = new SolidBrush(Color.FromArgb(num19, this.BarPenColor[i % 12]));
                        if (this.Stroke.TextureEnable)
                        {
                            pen = new Pen(new HatchBrush(this.Stroke.TextureStyle, this.BarPenColor[i % 12], Color.Black), (float) this.Stroke.Width);
                        }
                        else
                        {
                            pen = new Pen(this.BarPenColor[i % 12], (float) this.Stroke.Width);
                        }
                        GraphicsPath path = new GraphicsPath();
                        for (index = 0; index < num18; index++)
                        {
                            TimeSpan span;
                            int num12 = num3;
                            switch (this.Trend.TimeSpan)
                            {
                                case TimeSpanTypes.Day:
                                    span = (TimeSpan) (timeArray[index] - this.Trend.Start);
                                    span = (TimeSpan) (this.Trend.End - this.Trend.Start);
                                    num12 += (int) ((span.TotalHours / span.TotalHours) * num7);
                                    break;

                                case TimeSpanTypes.Hour:
                                    span = (TimeSpan) (timeArray[index] - this.Trend.Start);
                                    span = (TimeSpan) (this.Trend.End - this.Trend.Start);
                                    num12 += (int) ((span.TotalMinutes / span.TotalMinutes) * num7);
                                    break;

                                case TimeSpanTypes.Minute:
                                    span = (TimeSpan) (timeArray[index] - this.Trend.Start);
                                    span = (TimeSpan) (this.Trend.End - this.Trend.Start);
                                    num12 += (int) ((span.TotalSeconds / span.TotalSeconds) * num7);
                                    break;

                                case TimeSpanTypes.Second:
                                    span = (TimeSpan) (timeArray[index] - this.Trend.Start);
                                    span = (TimeSpan) (this.Trend.End - this.Trend.Start);
                                    num12 += (int) ((span.TotalMilliseconds / span.TotalMilliseconds) * num7);
                                    break;

                                case TimeSpanTypes.Millisecond:
                                    span = (TimeSpan) (timeArray[index] - this.Trend.Start);
                                    span = (TimeSpan) (this.Trend.End - this.Trend.Start);
                                    num12 += (int) ((span.TotalMilliseconds / span.TotalMilliseconds) * num7);
                                    break;

                                default:
                                    span = (TimeSpan) (timeArray[index] - this.Trend.Start);
                                    span = (TimeSpan) (this.Trend.End - this.Trend.Start);
                                    num12 += (int) ((span.TotalDays / span.TotalDays) * num7);
                                    break;
                            }
                            if ((this.decimal_0[i][index] != -0.830213M) && (timeArray[index] <= this.Trend.End))
                            {
                                if (this.Dimension == ChartDimensions.Chart2D)
                                {
                                    graphics_0.SmoothingMode = SmoothingMode.AntiAlias;
                                    if (((index > 0) && (num12 >= num15)) && (this.decimal_0[i][index - 1] != -0.830213M))
                                    {
                                        this.method_27(graphics_0, pen, (float) num15, (num4 + num8) - this.float_0[i][index - 1], (float) num12, (num4 + num8) - this.float_0[i][index]);
                                    }
                                    graphics_0.SmoothingMode = SmoothingMode.None;
                                    LineConnectionTypes lineConnectionType = this.LineConnectionType;
                                    int lineConnectionRadius = this.LineConnectionRadius;
                                    switch (lineConnectionType)
                                    {
                                        case LineConnectionTypes.Round:
                                            graphics_0.FillEllipse(brush, (float) (num12 - (lineConnectionRadius / 2)), ((num4 + num8) - this.float_0[i][index]) - (lineConnectionRadius / 2), (float) lineConnectionRadius, (float) lineConnectionRadius);
                                            break;

                                        case LineConnectionTypes.Square:
                                            graphics_0.FillRectangle(brush, (float) (num12 - (lineConnectionRadius / 2)), ((num4 + num8) - this.float_0[i][index]) - (lineConnectionRadius / 2), (float) lineConnectionRadius, (float) lineConnectionRadius);
                                            break;
                                    }
                                }
                                else if (this.Dimension == ChartDimensions.Chart3D)
                                {
                                    graphics_0.SmoothingMode = SmoothingMode.AntiAlias;
                                    float num9 = this.LineConnectionRadius / 2;
                                    if (this.LineConnectionType == LineConnectionTypes.None)
                                    {
                                        num9 = 0f;
                                    }
                                    this.method_28(graphics_0, pen, brush, num13, num9, (float) num12, (num4 + num8) - this.float_0[i][index], i);
                                    if (((index > 0) && (num12 >= num15)) && (this.decimal_0[i][index - 1] != -0.830213M))
                                    {
                                        this.method_29(graphics_0, pen, brush, num13, num9, (float) num15, (num4 + num8) - this.float_0[i][index - 1], (float) num12, (num4 + num8) - this.float_0[i][index]);
                                    }
                                }
                                if (this.Tips.Show)
                                {
                                    this.method_22(graphics_0, this.decimal_0[i][index].ToString(), num12, ((num4 + num8) - ((int) this.float_0[i][index])) - (this.LineConnectionRadius / 2), num12 - num15, (int) this.float_0[i][index], false);
                                }
                                this.method_31((float) (num12 - num13), ((num4 + num13) + num8) - this.float_0[i][index], this.decimal_0[i][index]);
                            }
                            num15 = num12;
                        }
                        pen.Dispose();
                        path.Dispose();
                    }
                }
            }
            if (this.Dimension == ChartDimensions.Chart2D)
            {
                graphics_0.DrawRectangle(Pens.Gray, num3, num4, num7, num8);
                graphics_0.DrawLine(Pens.Black, (float) (num3 - 4), (num4 + num8) - this.float_3, (float) ((num3 + num7) - 1), (num4 + num8) - this.float_3);
                graphics_0.DrawLine(Pens.Black, num3, num4, num3, (num4 + num8) + 2);
            }
            this.method_25(graphics_0, num3, num4, num7, num8);
        }

        private float method_6(float[] float_4)
        {
            float num = 0f;
            for (int i = 0; i < float_4.Length; i++)
            {
                if (float_4[i] > num)
                {
                    num = float_4[i];
                }
            }
            return num;
        }

        private float method_7(decimal[] decimal_1)
        {
            float num = 0f;
            for (int i = 0; i < decimal_1.Length; i++)
            {
                if (((float) decimal_1[i]) > num)
                {
                    num = (float) decimal_1[i];
                }
            }
            return num;
        }

        private float method_8(float[] float_4)
        {
            float num = float_4[0];
            for (int i = 0; i < float_4.Length; i++)
            {
                if (float_4[i] < num)
                {
                    num = float_4[i];
                }
            }
            return num;
        }

        private float method_9(decimal[] decimal_1)
        {
            float num = (float) decimal_1[0];
            for (int i = 0; i < decimal_1.Length; i++)
            {
                if (((float) decimal_1[i]) < num)
                {
                    num = (float) decimal_1[i];
                }
            }
            return num;
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            this.method_16();
        }

        protected virtual void OnDataSourceChanged(EventArgs e)
        {
            if (this.IottjlEvEi != null)
            {
                this.IottjlEvEi(this, e);
            }
        }

        protected override void OnLayeredPaint(PaintEventArgs e)
        {
            base.OnLayeredPaint(e);
            Graphics graphics = e.Graphics;
            GraphicsState gstate = graphics.Save();
            graphics.TextRenderingHint = this.textRenderingHint_0;
            this.method_18();
            switch (this.ChartType)
            {
                case ChartTypes.Bar:
                    this.method_36(graphics);
                    break;

                case ChartTypes.Line:
                    this.method_39(graphics);
                    break;

                case ChartTypes.Pie:
                    if (this.Dimension != ChartDimensions.Chart2D)
                    {
                        this.method_40(graphics);
                        break;
                    }
                    this.method_35(graphics);
                    break;

                case ChartTypes.Stack:
                    this.method_38(graphics);
                    break;

                case ChartTypes.HBar:
                    this.method_41(graphics);
                    break;

                case ChartTypes.Trend:
                    this.method_42(graphics);
                    break;

                default:
                    this.method_35(graphics);
                    break;
            }
            graphics.Restore(gstate);
        }

        [DefaultValue(typeof(byte), "255"), Description("Color alpha of 3D Chart.\n3D 图形的透明度"), ReadOnly(true), Category("DSkinChart")]
        public byte Alpha3D
        {
            get
            {
                return this.byte_0;
            }
            set
            {
                this.byte_0 = value;
            }
        }

        [Category("DSkinChart"), Description("Chart appearance style\n图表的外观样式(你只需设置这一个属性再绑定数据，一切OK了)")]
        public AppearanceStyles AppearanceStyle
        {
            get
            {
                return this.appearanceStyles_0;
            }
            set
            {
                this.appearanceStyles_0 = value;
                this.method_18();
                base.Invalidate();
            }
        }

        [Category("DSkinChart"), Description("Auto calculate bar width.\n3D 自动计算柱子宽度，如果数据很少请设为false,否则柱子会很宽"), DefaultValue(true)]
        public bool AutoBarWidth
        {
            get
            {
                return this.bool_1;
            }
            set
            {
                this.bool_1 = value;
            }
        }

        [Description("Background Attributes\n图形背景属性集合"), DesignerSerializationVisibility(DesignerSerializationVisibility.Content), Category("DSkinChart")]
        public BackgroundAttributes Background
        {
            get
            {
                if (this.backgroundAttributes_0 == null)
                {
                    this.backgroundAttributes_0 = new BackgroundAttributes();
                }
                return this.backgroundAttributes_0;
            }
            set
            {
                this.backgroundAttributes_0 = value;
            }
        }

        [Category("DSkinChart"), Description("Set a baseline for chart, if value is less than baseline the bar will grouth under X axies.\n设定基线值，如果数值小于基线，则图形向着Y负方向增长"), DefaultValue((double) -0.830213)]
        public double BaseLineX
        {
            get
            {
                return this.double_1;
            }
            set
            {
                this.double_1 = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content), Category("DSkinChart"), Description("Chart title\n图表标题属性集合")]
        public TextAttributes ChartTitle
        {
            get
            {
                if (this.textAttributes_0 == null)
                {
                    this.textAttributes_0 = new TextAttributes();
                }
                return this.textAttributes_0;
            }
            set
            {
                this.textAttributes_0 = value;
            }
        }

        [DefaultValue(0), ReadOnly(true), Description("Chart Type\n统计图的类型(如 折线图:Line)"), Category("DSkinChart")]
        public ChartTypes ChartType
        {
            get
            {
                return this.chartTypes_0;
            }
            set
            {
                this.chartTypes_0 = value;
            }
        }

        [DefaultValue(true), Description("Use different colors on 1 group data.\n 只有一组数据的时候，是否使用多种颜色"), Category("DSkinChart")]
        public bool Colorful
        {
            get
            {
                return this.bool_2;
            }
            set
            {
                this.bool_2 = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content), Description("Color Guider Attributes\n颜色图例的属性集合"), Category("DSkinChart")]
        public Attributes ColorGuider
        {
            get
            {
                if (this.attributes_0 == null)
                {
                    this.attributes_0 = new Attributes();
                }
                return this.attributes_0;
            }
            set
            {
                this.attributes_0 = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content), Description("Crystal Attributes\n水晶效果属性集合"), Category("DSkinChart")]
        public CrystalAttributes Crystal
        {
            get
            {
                if (this.crystalAttributes_0 == null)
                {
                    this.crystalAttributes_0 = new CrystalAttributes();
                }
                return this.crystalAttributes_0;
            }
            set
            {
                this.crystalAttributes_0 = value;
            }
        }

        [RefreshProperties(RefreshProperties.Repaint), DefaultValue((string) null), AttributeProvider(typeof(IListSource)), Category("数据")]
        public object DataSource
        {
            get
            {
                return this.object_0;
            }
            set
            {
                if (this.object_0 != value)
                {
                    if ((value != null) && (!(value is IList) && !(value is IListSource)))
                    {
                        throw new ArgumentException("数据源必须为集合");
                    }
                    this.object_0 = value;
                    this.OnDataSourceChanged(EventArgs.Empty);
                    if (base.Created)
                    {
                        this.method_16();
                    }
                    base.Invalidate();
                }
            }
        }

        [Category("DSkinChart"), Description("Depth of 3D effect.\n3D 效果的纵向深度"), ReadOnly(true), DefaultValue(10)]
        public int Depth3D
        {
            get
            {
                return this.int_3;
            }
            set
            {
                this.int_3 = value;
            }
        }

        [ReadOnly(true), DefaultValue(0), Category("DSkinChart"), Description("Dimension of the chart.\n图形维数2D/3D")]
        public ChartDimensions Dimension
        {
            get
            {
                return this.chartDimensions_0;
            }
            set
            {
                this.chartDimensions_0 = value;
            }
        }

        [Description("Fill Style\n填充属性集合"), DesignerSerializationVisibility(DesignerSerializationVisibility.Content), Category("DSkinChart")]
        public Painting Fill
        {
            get
            {
                if (this.painting_0 == null)
                {
                    this.painting_0 = new Painting();
                }
                return this.painting_0;
            }
            set
            {
                this.painting_0 = value;
            }
        }

        [Category("DSkinChart"), ReadOnly(true), DefaultValue(0), Description("Count of Bars in Bar-Chart of one Element\n柱状图中每个元素包含的柱子的数量")]
        public int GroupSize
        {
            get
            {
                return this.int_0;
            }
            set
            {
                this.int_0 = value;
            }
        }

        [Category("DSkinChart"), DefaultValue(0), Description("To enlarge height of background and keep the size of chart.\n增大背景高度，保持图形大小不变,可以为负数(缩小)")]
        public int InflateBottom
        {
            get
            {
                return this.int_5;
            }
            set
            {
                this.int_5 = value;
                base.Invalidate();
            }
        }

        [Description("To enlarge width of background and keep the size of chart.\n增大背景宽度，保持图形大小不变,可以为负数(缩小)"), DefaultValue(0), Category("DSkinChart")]
        public int InflateLeft
        {
            get
            {
                return this.int_7;
            }
            set
            {
                this.int_7 = value;
                base.Invalidate();
            }
        }

        [Description("To enlarge width of background and keep the size of chart.\n增大背景宽度，保持图形大小不变,可以为负数(缩小)"), DefaultValue(0), Category("DSkinChart")]
        public int InflateRight
        {
            get
            {
                return this.int_4;
            }
            set
            {
                this.int_4 = value;
                base.Invalidate();
            }
        }

        [Category("DSkinChart"), DefaultValue(0), Description("To enlarge width of background and keep the size of chart.\n增大背景宽度，保持图形大小不变,可以为负数(缩小)")]
        public int InflateTop
        {
            get
            {
                return this.int_6;
            }
            set
            {
                this.int_6 = value;
                base.Invalidate();
            }
        }

        [Category("DSkinChart"), Description("Line Connector Radias(Width) (For line Chart)\n线条连接点的半径(宽度)（针对 折线图）"), DefaultValue(10)]
        public int LineConnectionRadius
        {
            get
            {
                return this.int_2;
            }
            set
            {
                this.int_2 = value;
            }
        }

        [Category("DSkinChart"), ReadOnly(true), DefaultValue(0), Description("Line Connection Type (For line Chart)\n线条连接点的样式（针对 折线图）")]
        public LineConnectionTypes LineConnectionType
        {
            get
            {
                return this.lineConnectionTypes_0;
            }
            set
            {
                this.lineConnectionTypes_0 = value;
            }
        }

        [DefaultValue(0), Category("DSkinChart"), Description("Max Value of Y Axis\n自定义纵坐标的最大值，用来统一调整柱子的高度")]
        public double MaxValueY
        {
            get
            {
                return this.double_0;
            }
            set
            {
                if (value != 0.0)
                {
                    this.double_0 = value;
                }
                else
                {
                    this.double_0 = 0.0;
                }
            }
        }

        [Description("Min Value of Y Axis\n自定义纵坐标的最小值，用来统一调整柱子的高度"), DefaultValue(0), Category("DSkinChart")]
        public double MinValueY
        {
            get
            {
                return this.double_2;
            }
            set
            {
                this.double_2 = value;
            }
        }

        [Description("Round Radius(For Bar Chart)\n圆角半径（针对Bar-Chart）"), Category("DSkinChart"), DefaultValue(2)]
        public int RoundRadius
        {
            get
            {
                return this.int_1;
            }
            set
            {
                this.int_1 = value;
            }
        }

        [DefaultValue(false), ReadOnly(true), Description("Enable Round Rectangle(For Bar Chart)\n使用圆角矩形（针对Bar-Chart）"), Category("DSkinChart")]
        public bool RoundRectangle
        {
            get
            {
                return this.bool_0;
            }
            set
            {
                this.bool_0 = value;
            }
        }

        [Category("DSkinChart"), Description("Shadow Attributes\n投影属性集合"), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ShadowAttributes Shadow
        {
            get
            {
                if (this.shadowAttributes_0 == null)
                {
                    this.shadowAttributes_0 = new ShadowAttributes();
                }
                return this.shadowAttributes_0;
            }
            set
            {
                this.shadowAttributes_0 = value;
            }
        }

        [Category("DSkinChart"), DefaultValue(true), Description("Whether show the Error information.\n是否显示错误信息")]
        public bool ShowErrorInfo
        {
            get
            {
                return this.bool_3;
            }
            set
            {
                this.bool_3 = value;
            }
        }

        [Category("DSkinChart"), DesignerSerializationVisibility(DesignerSerializationVisibility.Content), Description("Spec Line attributes\nSpec Line的属性集合")]
        public SpecLineAttributes SpecLine
        {
            get
            {
                if (this.specLineAttributes_0 == null)
                {
                    this.specLineAttributes_0 = new SpecLineAttributes();
                }
                return this.specLineAttributes_0;
            }
            set
            {
                this.specLineAttributes_0 = value;
            }
        }

        [Category("DSkinChart"), Description("Fill Style\n填充属性集合"), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public StrokeStyle Stroke
        {
            get
            {
                if (this.strokeStyle_0 == null)
                {
                    this.strokeStyle_0 = new StrokeStyle();
                }
                return this.strokeStyle_0;
            }
            set
            {
                this.strokeStyle_0 = value;
            }
        }

        [Description("文本渲染模式"), DefaultValue(typeof(TextRenderingHint), "SystemDefault"), Category("外观")]
        public virtual TextRenderingHint TextRenderMode
        {
            get
            {
                return this.textRenderingHint_0;
            }
            set
            {
                if (this.textRenderingHint_0 != value)
                {
                    this.textRenderingHint_0 = value;
                    base.Invalidate();
                }
            }
        }

        [Description("Attributes of value tips\n数值标签的属性集合"), DesignerSerializationVisibility(DesignerSerializationVisibility.Content), Category("DSkinChart")]
        public Attributes Tips
        {
            get
            {
                if (this.attributes_1 == null)
                {
                    this.attributes_1 = new Attributes();
                }
                return this.attributes_1;
            }
            set
            {
                this.attributes_1 = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content), Category("DSkinChart"), Description("Trend chart special attributes\n趋势图的特殊属性集合")]
        public TrendAttributes Trend
        {
            get
            {
                if (this.trendAttributes_0 == null)
                {
                    this.trendAttributes_0 = new TrendAttributes();
                }
                return this.trendAttributes_0;
            }
            set
            {
                this.trendAttributes_0 = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content), Description("XLabels Attributes\nX坐标属性集合"), Category("DSkinChart")]
        public XAxisAttributes XAxis
        {
            get
            {
                if (this.xaxisAttributes_0 == null)
                {
                    this.xaxisAttributes_0 = new XAxisAttributes();
                }
                return this.xaxisAttributes_0;
            }
            set
            {
                this.xaxisAttributes_0 = value;
            }
        }

        [DefaultValue((string) null), Category("DSkinChart"), Description("X轴标签集合")]
        public string[] XLabels
        {
            get
            {
                return this.kUitoNvjqx;
            }
            set
            {
                this.kUitoNvjqx = value;
                if (base.DesignMode && base.Created)
                {
                    this.method_16();
                }
                base.Invalidate();
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content), Description("YLabels Attributes\nY坐标属性集合"), Category("DSkinChart")]
        public AxisAttributes YAxis
        {
            get
            {
                if (this.axisAttributes_0 == null)
                {
                    this.axisAttributes_0 = new AxisAttributes();
                }
                return this.axisAttributes_0;
            }
            set
            {
                this.axisAttributes_0 = value;
            }
        }

        public enum AppearanceStyles
        {
            None_None_None_None_None_None,
            Bar_2D_Breeze_NoCrystal_NoGlow_NoBorder,
            Bar_2D_Breeze_NoCrystal_Glow_NoBorder,
            Bar_2D_Breeze_NoCrystal_Glow_WhiteBorder,
            Bar_2D_Breeze_FlatCrystal_NoGlow_NoBorder,
            Bar_2D_Breeze_FlatCrystal_Glow_NoBorder,
            Bar_2D_Breeze_FlatCrystal_Glow_WhiteBorder,
            Bar_2D_Breeze_FlatCrystal_Glow_TextureBorder,
            Bar_2D_Aurora_NoCrystal_NoGlow_NoBorder,
            Bar_2D_Aurora_NoCrystal_Glow_NoBorder,
            Bar_2D_Aurora_NoCrystal_Glow_WhiteBorder,
            Bar_2D_Aurora_FlatCrystal_NoGlow_NoBorder,
            Bar_2D_Aurora_FlatCrystal_Glow_NoBorder,
            Bar_2D_Aurora_FlatCrystal_Glow_WhiteBorder,
            Bar_2D_Aurora_FlatCrystal_Glow_TextureBorder,
            Bar_2D_Aurora_GlassCrystal_NoGlow_NoBorder,
            Bar_2D_Aurora_GlassCrystal_Glow_NoBorder,
            Bar_2D_Aurora_GlassCrystal_Glow_WhiteBorder,
            Bar_2D_StarryNight_FlatCrystal_Glow_NoBorder,
            Bar_2D_StarryNight_FlatCrystal_Glow_WhiteBorder,
            Bar_2D_StarryNight_FlatCrystal_Glow_TextureBorder,
            Bar_2D_StarryNight_GlassCrystal_NoGlow_NoBorder,
            Bar_3D_Breeze_NoCrystal_NoGlow_NoBorder,
            Bar_3D_Breeze_FlatCrystal_NoGlow_NoBorder,
            Bar_3D_Aurora_NoCrystal_NoGlow_NoBorder,
            Bar_3D_Aurora_FlatCrystal_NoGlow_NoBorder,
            Bar_3D_StarryNight_NoCrystal_NoGlow_NoBorder,
            Bar_3D_StarryNight_FlatCrystal_NoGlow_NoBorder,
            Line_2D_Aurora_ThickRound_NoGlow_NoBorder,
            Line_2D_Aurora_ThickRound_Glow_NoBorder,
            Line_2D_Aurora_ThickSquare_NoGlow_NoBorder,
            Line_2D_Aurora_ThickSquare_Glow_NoBorder,
            Line_2D_Aurora_ThinRound_NoGlow_NoBorder,
            Line_2D_Aurora_ThinRound_Glow_NoBorder,
            Line_2D_Aurora_ThinSquare_NoGlow_NoBorder,
            Line_2D_Aurora_ThinSquare_Glow_NoBorder,
            Line_2D_StarryNight_ThickRound_NoGlow_NoBorder,
            Line_2D_StarryNight_ThickRound_Glow_NoBorder,
            Line_2D_StarryNight_ThickSquare_NoGlow_NoBorder,
            Line_2D_StarryNight_ThickSquare_Glow_NoBorder,
            Line_2D_StarryNight_ThinRound_NoGlow_NoBorder,
            Line_2D_StarryNight_ThinRound_Glow_NoBorder,
            Line_2D_StarryNight_ThinSquare_NoGlow_NoBorder,
            Line_2D_StarryNight_ThinSquare_Glow_NoBorder,
            Line_3D_Breeze_NoCrystalNone_NoGlow_NoBorder,
            Line_3D_Breeze_NoCrystalRound_NoGlow_NoBorder,
            Line_3D_Breeze_NoCrystalSquare_NoGlow_NoBorder,
            Line_3D_Breeze_FlatCrystalNone_NoGlow_NoBorder,
            Line_3D_Breeze_FlatCrystalRound_NoGlow_NoBorder,
            Line_3D_Breeze_FlatCrystalSquare_NoGlow_NoBorder,
            Line_3D_Breeze_GlassCrystalNone_NoGlow_NoBorder,
            Line_3D_Breeze_GlassCrystalRound_NoGlow_NoBorder,
            Line_3D_Breeze_GlassCrystalSquare_NoGlow_NoBorder,
            Line_3D_Aurora_NoCrystalNone_NoGlow_NoBorder,
            Line_3D_Aurora_NoCrystalRound_NoGlow_NoBorder,
            Line_3D_Aurora_NoCrystalSquare_NoGlow_NoBorder,
            Line_3D_Aurora_FlatCrystalNone_NoGlow_NoBorder,
            Line_3D_Aurora_FlatCrystalRound_NoGlow_NoBorder,
            Line_3D_Aurora_FlatCrystalSquare_NoGlow_NoBorder,
            Line_3D_Aurora_GlassCrystalNone_NoGlow_NoBorder,
            Line_3D_Aurora_GlassCrystalRound_NoGlow_NoBorder,
            Line_3D_Aurora_GlassCrystalSquare_NoGlow_NoBorder,
            Line_3D_StarryNight_NoCrystalNone_NoGlow_NoBorder,
            Line_3D_StarryNight_NoCrystalRound_NoGlow_NoBorder,
            Line_3D_StarryNight_NoCrystalSquare_NoGlow_NoBorder,
            Line_3D_StarryNight_FlatCrystalNone_NoGlow_NoBorder,
            Line_3D_StarryNight_FlatCrystalRound_NoGlow_NoBorder,
            Line_3D_StarryNight_FlatCrystalSquare_NoGlow_NoBorder,
            Line_3D_StarryNight_GlassCrystalNone_NoGlow_NoBorder,
            Line_3D_StarryNight_GlassCrystalRound_NoGlow_NoBorder,
            Line_3D_StarryNight_GlassCrystalSquare_NoGlow_NoBorder,
            Pie_2D_Breeze_NoCrystal_NoGlow_NoBorder,
            Pie_2D_Breeze_NoCrystal_NoGlow_WhiteBorder,
            Pie_2D_Breeze_NoCrystal_Glow_WhiteBorder,
            Pie_2D_Breeze_FlatCrystal_NoGlow_NoBorder,
            Pie_2D_Breeze_FlatCrystal_Glow_WhiteBorder,
            Pie_2D_Breeze_GlassCrystal_NoGlow_NoBorder,
            Pie_2D_Breeze_GlassCrystal_Glow_WhiteBorder,
            Pie_2D_Aurora_NoCrystal_NoGlow_NoBorder,
            Pie_2D_Aurora_NoCrystal_NoGlow_WhiteBorder,
            Pie_2D_Aurora_NoCrystal_Glow_WhiteBorder,
            Pie_2D_Aurora_FlatCrystal_NoGlow_NoBorder,
            Pie_2D_Aurora_FlatCrystal_Glow_WhiteBorder,
            Pie_2D_Aurora_GlassCrystal_NoGlow_NoBorder,
            Pie_2D_Aurora_GlassCrystal_Glow_WhiteBorder,
            Pie_2D_StarryNight_NoCrystal_NoGlow_NoBorder,
            Pie_2D_StarryNight_NoCrystal_NoGlow_WhiteBorder,
            Pie_2D_StarryNight_NoCrystal_Glow_WhiteBorder,
            Pie_2D_StarryNight_FlatCrystal_NoGlow_NoBorder,
            Pie_2D_StarryNight_FlatCrystal_Glow_WhiteBorder,
            Pie_2D_StarryNight_GlassCrystal_NoGlow_NoBorder,
            Pie_2D_StarryNight_GlassCrystal_Glow_WhiteBorder,
            Pie_3D_Aurora_NoCrystal_NoGlow_NoBorder,
            Pie_3D_Aurora_FlatCrystal_NoGlow_NoBorder,
            Pie_3D_Breeze_NoCrystal_NoGlow_NoBorder,
            Pie_3D_Breeze_FlatCrystal_NoGlow_NoBorder,
            Pie_3D_StarryNight_NoCrystal_NoGlow_NoBorder,
            Pie_3D_StarryNight_FlatCrystal_NoGlow_NoBorder,
            Stack_2D_Breeze_NoCrystal_NoGlow_NoBorder,
            Stack_2D_Breeze_NoCrystal_Glow_NoBorder,
            Stack_2D_Breeze_NoCrystal_Glow_WhiteBorder,
            Stack_2D_Breeze_FlatCrystal_NoGlow_NoBorder,
            Stack_2D_Breeze_FlatCrystal_Glow_NoBorder,
            Stack_2D_Breeze_FlatCrystal_Glow_WhiteBorder,
            Stack_2D_Breeze_FlatCrystal_Glow_TextureBorder,
            Stack_2D_Aurora_NoCrystal_Glow_WhiteBorder,
            Stack_2D_Aurora_FlatCrystal_NoGlow_NoBorder,
            Stack_2D_Aurora_FlatCrystal_Glow_NoBorder,
            Stack_2D_Aurora_FlatCrystal_Glow_WhiteBorder,
            Stack_2D_Aurora_FlatCrystal_Glow_TextureBorder,
            Stack_2D_Aurora_GlassCrystal_NoGlow_NoBorder,
            Stack_2D_Aurora_GlassCrystal_Glow_NoBorder,
            Stack_2D_Aurora_GlassCrystal_Glow_WhiteBorder,
            Stack_2D_StarryNight_FlatCrystal_Glow_NoBorder,
            Stack_2D_StarryNight_FlatCrystal_Glow_WhiteBorder,
            Stack_2D_StarryNight_FlatCrystal_Glow_TextureBorder,
            Stack_2D_StarryNight_GlassCrystal_NoGlow_NoBorder,
            Stack_3D_Breeze_NoCrystal_NoGlow_NoBorder,
            Stack_3D_Breeze_FlatCrystal_NoGlow_NoBorder,
            Stack_3D_Aurora_NoCrystal_NoGlow_NoBorder,
            Stack_3D_Aurora_FlatCrystal_NoGlow_NoBorder,
            Stack_3D_StarryNight_NoCrystal_NoGlow_NoBorder,
            Stack_3D_StarryNight_FlatCrystal_NoGlow_NoBorder,
            HBar_2D_Breeze_NoCrystal_NoGlow_NoBorder,
            HBar_2D_Breeze_NoCrystal_Glow_NoBorder,
            HBar_2D_Breeze_NoCrystal_Glow_WhiteBorder,
            HBar_2D_Breeze_FlatCrystal_NoGlow_NoBorder,
            HBar_2D_Breeze_FlatCrystal_Glow_NoBorder,
            HBar_2D_Breeze_FlatCrystal_Glow_WhiteBorder,
            HBar_2D_Breeze_FlatCrystal_Glow_TextureBorder,
            HBar_2D_Aurora_NoCrystal_NoGlow_NoBorder,
            HBar_2D_Aurora_NoCrystal_Glow_NoBorder,
            HBar_2D_Aurora_NoCrystal_Glow_WhiteBorder,
            HBar_2D_Aurora_FlatCrystal_NoGlow_NoBorder,
            HBar_2D_Aurora_FlatCrystal_Glow_NoBorder,
            HBar_2D_Aurora_FlatCrystal_Glow_WhiteBorder,
            HBar_2D_Aurora_FlatCrystal_Glow_TextureBorder,
            HBar_2D_Aurora_GlassCrystal_NoGlow_NoBorder,
            HBar_2D_Aurora_GlassCrystal_Glow_NoBorder,
            HBar_2D_Aurora_GlassCrystal_Glow_WhiteBorder,
            HBar_2D_StarryNight_FlatCrystal_Glow_NoBorder,
            HBar_2D_StarryNight_FlatCrystal_Glow_WhiteBorder,
            HBar_2D_StarryNight_FlatCrystal_Glow_TextureBorder,
            HBar_2D_StarryNight_GlassCrystal_NoGlow_NoBorder,
            Trend_2D_Aurora_ThickRound_NoGlow_NoBorder,
            Trend_2D_Aurora_ThickRound_Glow_NoBorder,
            Trend_2D_Aurora_ThickSquare_NoGlow_NoBorder,
            Trend_2D_Aurora_ThickSquare_Glow_NoBorder,
            Trend_2D_Aurora_ThinRound_NoGlow_NoBorder,
            Trend_2D_Aurora_ThinRound_Glow_NoBorder,
            Trend_2D_Aurora_ThinSquare_NoGlow_NoBorder,
            Trend_2D_Aurora_ThinSquare_Glow_NoBorder,
            Trend_2D_StarryNight_ThickRound_NoGlow_NoBorder,
            Trend_2D_StarryNight_ThickRound_Glow_NoBorder,
            Trend_2D_StarryNight_ThickSquare_NoGlow_NoBorder,
            Trend_2D_StarryNight_ThickSquare_Glow_NoBorder,
            Trend_2D_StarryNight_ThinRound_NoGlow_NoBorder,
            Trend_2D_StarryNight_ThinRound_Glow_NoBorder,
            Trend_2D_StarryNight_ThinSquare_NoGlow_NoBorder,
            Trend_2D_StarryNight_ThinSquare_Glow_NoBorder,
            Trend_3D_Breeze_NoCrystalNone_NoGlow_NoBorder,
            Trend_3D_Breeze_NoCrystalRound_NoGlow_NoBorder,
            Trend_3D_Breeze_NoCrystalSquare_NoGlow_NoBorder,
            Trend_3D_Breeze_FlatCrystalNone_NoGlow_NoBorder,
            Trend_3D_Breeze_FlatCrystalRound_NoGlow_NoBorder,
            Trend_3D_Breeze_FlatCrystalSquare_NoGlow_NoBorder,
            Trend_3D_Breeze_GlassCrystalNone_NoGlow_NoBorder,
            Trend_3D_Breeze_GlassCrystalRound_NoGlow_NoBorder,
            Trend_3D_Breeze_GlassCrystalSquare_NoGlow_NoBorder,
            Trend_3D_Aurora_NoCrystalNone_NoGlow_NoBorder,
            Trend_3D_Aurora_NoCrystalRound_NoGlow_NoBorder,
            Trend_3D_Aurora_NoCrystalSquare_NoGlow_NoBorder,
            Trend_3D_Aurora_FlatCrystalNone_NoGlow_NoBorder,
            Trend_3D_Aurora_FlatCrystalRound_NoGlow_NoBorder,
            Trend_3D_Aurora_FlatCrystalSquare_NoGlow_NoBorder,
            Trend_3D_Aurora_GlassCrystalNone_NoGlow_NoBorder,
            Trend_3D_Aurora_GlassCrystalRound_NoGlow_NoBorder,
            Trend_3D_Aurora_GlassCrystalSquare_NoGlow_NoBorder,
            Trend_3D_StarryNight_NoCrystalNone_NoGlow_NoBorder,
            Trend_3D_StarryNight_NoCrystalRound_NoGlow_NoBorder,
            Trend_3D_StarryNight_NoCrystalSquare_NoGlow_NoBorder,
            Trend_3D_StarryNight_FlatCrystalNone_NoGlow_NoBorder,
            Trend_3D_StarryNight_FlatCrystalRound_NoGlow_NoBorder,
            Trend_3D_StarryNight_FlatCrystalSquare_NoGlow_NoBorder,
            Trend_3D_StarryNight_GlassCrystalNone_NoGlow_NoBorder,
            Trend_3D_StarryNight_GlassCrystalRound_NoGlow_NoBorder,
            Trend_3D_StarryNight_GlassCrystalSquare_NoGlow_NoBorder
        }

        public enum ChartDimensions
        {
            Chart2D,
            Chart3D
        }

        public enum ChartTypes
        {
            Bar,
            Line,
            Pie,
            Stack,
            HBar,
            Trend,
            Bubble,
            FloatBar,
            Linear,
            Histogram,
            BoxPlot
        }

        public enum ColorStyles
        {
            None,
            Breeze,
            Aurora,
            StarryNight
        }

        public enum Direction
        {
            LeftRight,
            TopBottom,
            RightLeft,
            BottomTop
        }

        public enum LineConnectionTypes
        {
            Round,
            Square,
            None
        }

        public enum TimeSpanTypes
        {
            Year,
            Month,
            Day,
            Hour,
            Minute,
            Second,
            Millisecond
        }
    }
}

