namespace DSkin.DirectUI
{
    using System;

    public class TaskResult
    {
        private object object_0;
        private object object_1;

        public TaskResult(object enforcer, object result)
        {
            this.object_0 = enforcer;
            this.object_1 = result;
        }

        public object Enforcer
        {
            get
            {
                return this.object_0;
            }
        }

        public object Result
        {
            get
            {
                return this.object_1;
            }
        }
    }
}

