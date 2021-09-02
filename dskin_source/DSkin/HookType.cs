namespace DSkin
{
    using System;

    public enum HookType
    {
        CallWndProc = 4,
        CallWndProcRet = 12,
        CBT = 5,
        Debug = 9,
        ForegroundIdle = 11,
        GetMessage = 3,
        Hardware = 8,
        JournalPlayback = 1,
        JournalRecord = 0,
        Keyboard = 2,
        KeyboardLL = 13,
        Mouse = 7,
        MouseLL = 14,
        MsgFilter = -1,
        Shell = 10,
        SysMsgFilter = 6
    }
}

