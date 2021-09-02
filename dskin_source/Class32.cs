using DSkin.Html.Core.Dom;
using System;

internal sealed class Class32 : CssRect
{
    private readonly bool bool_0;
    private readonly bool bool_1;
    private readonly string string_0;

    public Class32(CssBox cssBox_1, string string_1, bool bool_2, bool bool_3) : base(cssBox_1)
    {
        this.string_0 = string_1;
        this.bool_0 = bool_2;
        this.bool_1 = bool_3;
    }

    public override string ToString()
    {
        return string.Format("{0} ({1} char{2})", this.Text.Replace(' ', '-').Replace("\n", @"\n"), this.Text.Length, (this.Text.Length != 1) ? "s" : string.Empty);
    }

    public override bool HasSpaceAfter
    {
        get
        {
            return this.bool_1;
        }
    }

    public override bool HasSpaceBefore
    {
        get
        {
            return this.bool_0;
        }
    }

    public override bool IsLineBreak
    {
        get
        {
            return (this.Text == "\n");
        }
    }

    public override bool IsSpaces
    {
        get
        {
            foreach (char ch in this.Text)
            {
                if (!char.IsWhiteSpace(ch))
                {
                    return false;
                }
            }
            return true;
        }
    }

    public override string Text
    {
        get
        {
            return this.string_0;
        }
    }
}

