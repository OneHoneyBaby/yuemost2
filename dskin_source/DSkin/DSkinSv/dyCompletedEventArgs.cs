namespace DSkin.DSkinSv
{
    using System;
    using System.CodeDom.Compiler;
    using System.ComponentModel;
    using System.Diagnostics;

    [DebuggerStepThrough, GeneratedCode("System.Web.Services", "4.0.30319.19408"), DesignerCategory("code")]
    public class dyCompletedEventArgs : AsyncCompletedEventArgs
    {
        private object[] object_0;

        internal dyCompletedEventArgs(object[] results, Exception exception, bool cancelled, object userState) : base(exception, cancelled, userState)
        {
            this.object_0 = results;
        }

        public string Result
        {
            get
            {
                base.RaiseExceptionIfNecessary();
                return (string) this.object_0[0];
            }
        }
    }
}

