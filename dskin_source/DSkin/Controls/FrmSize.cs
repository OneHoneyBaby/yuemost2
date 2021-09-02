namespace DSkin.Controls
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class FrmSize : Form
    {
        private Button button1;
        private Button button2;
        private IContainer icontainer_0 = null;
        private Size size_0;
        private TextBox textBox1;
        private TextBox textBox2;

        public FrmSize(Size se)
        {
            this.InitializeComponent();
            this.size_0 = se;
            base.StartPosition = FormStartPosition.CenterParent;
            base.FormBorderStyle = FormBorderStyle.FixedSingle;
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.TopMost = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((this.textBox1.BackColor != Color.White) || (this.textBox2.BackColor != Color.White))
            {
                MessageBox.Show("The input value is invalid!");
            }
            else
            {
                base.DialogResult = DialogResult.OK;
                base.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            base.DialogResult = DialogResult.Cancel;
            base.Close();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.icontainer_0 != null))
            {
                this.icontainer_0.Dispose();
            }
            base.Dispose(disposing);
        }

        private void FrmSize_Load(object sender, EventArgs e)
        {
            this.textBox1.Text = this.size_0.Width.ToString();
            this.textBox2.Text = this.size_0.Height.ToString();
            this.textBox1.BackColor = Color.White;
            this.textBox2.BackColor = Color.White;
            this.button1.Text = "OK";
            this.button2.Text = "Cancel";
            base.AcceptButton = this.button1;
            base.CancelButton = this.button2;
        }

        private void InitializeComponent()
        {
            this.textBox1 = new TextBox();
            this.textBox2 = new TextBox();
            this.button1 = new Button();
            this.button2 = new Button();
            base.SuspendLayout();
            this.textBox1.Location = new Point(15, 11);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new Size(60, 0x15);
            this.textBox1.TabIndex = 0;
            this.textBox1.Validating += new CancelEventHandler(this.textBox2_Validating);
            this.textBox2.Location = new Point(15, 0x26);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new Size(60, 0x15);
            this.textBox2.TabIndex = 1;
            this.textBox2.Validating += new CancelEventHandler(this.textBox2_Validating);
            this.button1.Location = new Point(0x51, 9);
            this.button1.Name = "button1";
            this.button1.Size = new Size(0x4b, 0x15);
            this.button1.TabIndex = 2;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new EventHandler(this.button1_Click);
            this.button2.Location = new Point(0x51, 0x24);
            this.button2.Name = "button2";
            this.button2.Size = new Size(0x4b, 0x15);
            this.button2.TabIndex = 3;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new EventHandler(this.button2_Click);
            base.AutoScaleMode = AutoScaleMode.None;
            base.ClientSize = new Size(0xab, 0x43);
            base.Controls.Add(this.button2);
            base.Controls.Add(this.button1);
            base.Controls.Add(this.textBox2);
            base.Controls.Add(this.textBox1);
            base.Name = "FrmSize";
            this.Text = "FrmSize";
            base.Load += new EventHandler(this.FrmSize_Load);
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        private void textBox2_Validating(object sender, CancelEventArgs e)
        {
            TextBox box = sender as TextBox;
            try
            {
                int num = int.Parse(box.Text);
                if (box == this.textBox1)
                {
                    this.size_0.Width = num;
                }
                else
                {
                    this.size_0.Height = num;
                }
                box.BackColor = Color.White;
            }
            catch
            {
                box.BackColor = Color.Yellow;
            }
        }

        public Size ImageSize
        {
            get
            {
                return this.size_0;
            }
            set
            {
                this.size_0 = value;
            }
        }
    }
}

