namespace DSkin.Html.Adapters
{
    using DSkin.Html.Adapters.Entities;
    using System;

    public abstract class RPen
    {
        protected RPen()
        {
        }

        public abstract RDashStyle DashStyle { set; }

        public abstract double Width { get; set; }
    }
}

