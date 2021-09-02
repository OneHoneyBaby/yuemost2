namespace DSkin.Controls
{
    using DSkin.DirectUI;

    public interface IDuiDesigner : IDuiContainer
    {
        DuiControlCollection DuiControlCollection_0 { get; }

        DuiBaseControl InnerDuiControl { get; }
    }
}

