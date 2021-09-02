namespace DSkin.Forms
{
    using DSkin;
    using DSkin.Controls;
    using DSkin.DirectUI;
    using DSkin.Properties;
    using System;
    using System.Drawing;
    using System.Media;
    using System.Reflection;
    using System.Windows.Forms;

    public static class DSkinMessageBox
    {
        private static void QhDreUirRV(bool bool_0, DSkinForm dskinForm_0)
        {
            FormClosedEventHandler handler = null;
            Func<bool> action = null;
            EventHandler handler2 = null;
            DSkinForm mask;
            DSkinForm f = dskinForm_0;
            if (bool_0)
            {
                <>c__DisplayClasse classe;
                mask = new DSkinForm {
                    BackColor = Color.FromArgb(150, 0, 0, 0),
                    EnableAnimation = false,
                    FormBorderStyle = FormBorderStyle.None,
                    WindowState = FormWindowState.Maximized,
                    Text = "",
                    ControlBox = false,
                    CanResize = false,
                    MoveMode = MoveModes.None,
                    Opacity = 0.0,
                    ShowInTaskbar = false
                };
                if (handler == null)
                {
                    handler = new FormClosedEventHandler(classe.<ShowMask>b__8);
                }
                f.FormClosed += handler;
                if (action == null)
                {
                    action = new Func<bool>(classe, (IntPtr) this.<ShowMask>b__9);
                }
                mask.DoEffect(action);
                if (handler2 == null)
                {
                    handler2 = new EventHandler(classe.<ShowMask>b__a);
                }
                f.Shown += handler2;
            }
        }

        public static DialogResult Show(string text)
        {
            return Show(text, "");
        }

        public static DialogResult Show(string text, string caption)
        {
            return Show(text, caption, MessageBoxIcon.None);
        }

        public static DialogResult Show(string text, string caption, MessageBoxButtons buttons)
        {
            return smethod_2(null, text, caption, MessageBoxIcon.None, false, buttons);
        }

        public static DialogResult Show(string text, string caption, MessageBoxIcon icon)
        {
            return smethod_2(null, text, caption, icon, false, MessageBoxButtons.OK);
        }

        public static DialogResult Show(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            return smethod_2(null, text, caption, icon, false, buttons);
        }

        public static DialogResult Show(IWin32Window owner, string text, string caption, MessageBoxIcon icon, bool fullScreenMask, MessageBoxButtons buttons)
        {
            return smethod_2(owner, text, caption, icon, false, buttons);
        }

        public static DialogResult Show(IWin32Window owner, string text, string caption, MessageBoxIcon icon, AnimationTypes animationType, bool fullScreenMask, int defaultButtonIndex, params object[] buttons)
        {
            return Show(owner, text, caption, icon, animationType, fullScreenMask, defaultButtonIndex, Color.Empty, null, buttons);
        }

        public static DialogResult Show(IWin32Window owner, string text, string caption, MessageBoxIcon icon, AnimationTypes animationType, bool fullScreenMask, int defaultButtonIndex, Color textColor, Font font, params object[] buttons)
        {
            DSkinButton[] buttonArray = new DSkinButton[buttons.Length];
            for (int i = 0; i < buttons.Length; i++)
            {
                buttonArray[i] = new DSkinButton();
                DSkinButton button = buttonArray[i];
                button.AutoSize = true;
                button.TextPadding = 8;
                button.Radius = 0;
                button.DialogResult = DialogResult.None;
                System.Type type = button.GetType();
                foreach (PropertyInfo info in buttons[i].GetType().GetProperties())
                {
                    type.GetProperty(info.Name).SetValue(button, info.GetValue(buttons[i], null), null);
                }
            }
            return smethod_1(owner, text, caption, icon, animationType, fullScreenMask, defaultButtonIndex, textColor, font, buttonArray);
        }

        private static DialogResult smethod_0(object object_0, string string_0, string string_1, MessageBoxIcon messageBoxIcon_0, AnimationTypes animationTypes_0, bool bool_0, int int_0, params DSkinButton[] buttons)
        {
            return smethod_1(object_0, string_0, string_1, messageBoxIcon_0, animationTypes_0, bool_0, int_0, Color.Empty, null, buttons);
        }

        private static DialogResult smethod_1(object object_0, string string_0, string string_1, MessageBoxIcon messageBoxIcon_0, AnimationTypes animationTypes_0, bool bool_0, int int_0, Color color_0, Font font_0, params DSkinButton[] buttons)
        {
            Color textColor = color_0;
            EventHandler handler = null;
            using (Form0 f = new Form0())
            {
                if (object_0 == null)
                {
                    Form activeForm = Form.ActiveForm;
                    if (!((activeForm == null) || activeForm.InvokeRequired))
                    {
                        f.Owner = activeForm;
                    }
                    else
                    {
                        f.ShowInTaskbar = true;
                    }
                }
                if (f.InvokeRequired)
                {
                    f.TopMost = true;
                }
                if (font_0 == null)
                {
                    if (object_0 != null)
                    {
                        font_0 = ((Form) object_0).Font;
                    }
                    else if (f.Owner != null)
                    {
                        font_0 = f.Owner.Font;
                    }
                    else
                    {
                        font_0 = f.Font;
                    }
                }
                using (Graphics graphics = Graphics.FromHwnd(IntPtr.Zero))
                {
                    StringFormat format = new StringFormat {
                        LineAlignment = StringAlignment.Center
                    };
                    using (StringFormat format2 = format)
                    {
                        SizeF ef = graphics.MeasureString(string_0, font_0, (int) (f.Width - 10), format2);
                        f.Height = ((int) ef.Height) + 100;
                    }
                }
                f.method_25(string_0);
                f.method_27(string_1);
                f.method_31(messageBoxIcon_0);
                f.method_29(buttons);
                f.dSkinLabel1.Font = font_0;
                if (handler == null)
                {
                    <>c__DisplayClass5 class3;
                    handler = new EventHandler(class3.<ShowCore>b__1);
                }
                f.Shown += handler;
                if ((buttons != null) && (buttons.Length > 0))
                {
                    f.AcceptButton = buttons[int_0];
                }
                f.AnimationType = animationTypes_0;
                QhDreUirRV(bool_0, f);
                return f.ShowDialog((IWin32Window) object_0);
            }
        }

        private static DialogResult smethod_2(object object_0, string string_0, string string_1, MessageBoxIcon messageBoxIcon_0, bool bool_0, MessageBoxButtons messageBoxButtons_0)
        {
            string text = string_0;
            string caption = string_1;
            MessageBoxIcon icon = messageBoxIcon_0;
            MessageBoxButtons buttons = messageBoxButtons_0;
            FormClosingEventHandler handler = null;
            EventHandler handler2 = null;
            EventHandler<DuiMouseEventArgs> handler3 = null;
            DSkinForm form = new DSkinForm {
                BackColor = Color.Transparent,
                EnableAnimation = false,
                FormBorderStyle = FormBorderStyle.None,
                CaptionShowMode = TextShowModes.None,
                DrawIcon = false,
                ControlBox = false,
                CanResize = false,
                ShowInTaskbar = false,
                StartPosition = FormStartPosition.CenterScreen,
                Size = new Size(350, 0xfd),
                AutoScaleMode = AutoScaleMode.None,
                Font = new Font("幼圆", 10f, FontStyle.Bold),
                Opacity = 0.0,
                Text = string.IsNullOrEmpty(caption) ? "消息窗" : caption,
                KeyPreview = true
            };
            using (DSkinForm f = form)
            {
                <>c__DisplayClass23 class2;
                <>c__DisplayClass25 class3;
                if (object_0 == null)
                {
                    object_0 = Form.ActiveForm;
                }
                if (object_0 == null)
                {
                    f.ShowInTaskbar = true;
                }
                else
                {
                    if (handler == null)
                    {
                        handler = new FormClosingEventHandler(class2.<ShowCore>b__16);
                    }
                    f.FormClosing += handler;
                }
                if (f.InvokeRequired)
                {
                    f.TopMost = true;
                }
                if (handler2 == null)
                {
                    handler2 = new EventHandler(class2.<ShowCore>b__17);
                }
                f.Load += handler2;
                QhDreUirRV(bool_0, f);
                DuiBaseControl control = new DuiBaseControl {
                    ClientRectangle = new Rectangle(0x4b, 0x20, 200, 180),
                    BackgroundImage = Resources.smethod_1()
                };
                control.BackgroundRender.SudokuDrawBackImage = true;
                control.BackgroundRender.SudokuPartitionWidth = new Padding(0x5b);
                if (handler3 == null)
                {
                    handler3 = new EventHandler<DuiMouseEventArgs>(class2.<ShowCore>b__18);
                }
                f.InnerDuiControl.MouseDown += handler3;
                f.DuiControlCollection_0.Add(control);
                using (Graphics graphics = Graphics.FromHwnd(IntPtr.Zero))
                {
                    StringFormat format = new StringFormat {
                        LineAlignment = StringAlignment.Center
                    };
                    using (StringFormat format2 = format)
                    {
                        SizeF ef = graphics.MeasureString(text, f.Font, (int) (f.Width - 50), format2);
                        if (ef.Height > 80f)
                        {
                            if (ef.Height > 500f)
                            {
                                f.Width = 500;
                                ef = graphics.MeasureString(text, f.Font, (int) (f.Width - 50), format2);
                            }
                            if (ef.Height > (Screen.PrimaryScreen.WorkingArea.Height - 0xb9))
                            {
                                f.Height = Screen.PrimaryScreen.WorkingArea.Height;
                            }
                            else
                            {
                                f.Height = ((int) ef.Height) + 0xb9;
                            }
                            control.Location = new Point((f.Width - control.Width) / 2, (f.Height - control.Height) / 2);
                        }
                    }
                }
                MessageBoxIcon icon = icon;
                if (icon <= MessageBoxIcon.Hand)
                {
                    if ((icon != MessageBoxIcon.None) && (icon == MessageBoxIcon.Hand))
                    {
                        SystemSounds.Hand.Play();
                    }
                }
                else
                {
                    switch (icon)
                    {
                        case MessageBoxIcon.Question:
                            SystemSounds.Question.Play();
                            break;

                        case MessageBoxIcon.Exclamation:
                            SystemSounds.Exclamation.Play();
                            break;

                        case MessageBoxIcon.Asterisk:
                            SystemSounds.Asterisk.Play();
                            break;
                    }
                }
                f.DoEffect(new Func<bool>(class3, (IntPtr) this.<ShowCore>b__19));
                DialogResult result = f.ShowDialog((IWin32Window) object_0);
                if (object_0 != null)
                {
                    ((Form) object_0).BringToFront();
                }
                return result;
            }
        }
    }
}

