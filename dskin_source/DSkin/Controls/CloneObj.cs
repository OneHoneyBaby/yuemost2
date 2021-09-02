namespace DSkin.Controls
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    public static class CloneObj
    {
        public static TabPage Clone(this TabPage p)
        {
            return new TabPage { 
                Name = p.Name, AutoScroll = p.AutoScroll, AutoScrollMargin = p.AutoScrollMargin, AutoScrollMinSize = p.AutoScrollMinSize, Padding = p.Padding, Margin = p.Margin, Size = p.Size, BackgroundImage = p.BackgroundImage, BackgroundImageLayout = p.BackgroundImageLayout, BorderStyle = p.BorderStyle, Cursor = p.Cursor, Font = p.Font, ForeColor = p.ForeColor, RightToLeft = p.RightToLeft, Anchor = p.Anchor, AutoSize = p.AutoSize, 
                AutoSizeMode = p.AutoSizeMode, BackColor = p.BackColor, Dock = p.Dock, Enabled = p.Enabled, ImageIndex = p.ImageIndex, ImageKey = p.ImageKey, Location = p.Location, MaximumSize = p.MaximumSize, MinimumSize = p.MinimumSize, TabIndex = p.TabIndex, TabStop = p.TabStop, Text = p.Text, ToolTipText = p.ToolTipText, UseVisualStyleBackColor = p.UseVisualStyleBackColor, Visible = p.Visible, Tag = p.Tag
             };
        }
    }
}

