namespace DSkin.DSkinSv
{
    using System;
    using System.CodeDom.Compiler;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Threading;
    using System.Web.Services;
    using System.Web.Services.Description;
    using System.Web.Services.Protocols;

    [DesignerCategory("code"), DebuggerStepThrough, GeneratedCode("System.Web.Services", "4.0.30319.19408"), WebServiceBinding(Name="SvSoap", Namespace="http://www.cskin.net")]
    internal class Sv : SoapHttpClientProtocol
    {
        private bool bool_0;
        private SendOrPostCallback bunbbBfkVap;
        private cnCompletedEventHandler cnCompletedEventHandler_0;
        private ddyCompletedEventHandler ddyCompletedEventHandler_0;
        private dyCompletedEventHandler dyCompletedEventHandler_0;
        private eCompletedEventHandler eCompletedEventHandler_0;
        private gtCompletedEventHandler gtCompletedEventHandler_0;
        private guCompletedEventHandler guCompletedEventHandler_0;
        private gxCompletedEventHandler gxCompletedEventHandler_0;
        private SendOrPostCallback sendOrPostCallback_0;
        private SendOrPostCallback sendOrPostCallback_1;
        private SendOrPostCallback sendOrPostCallback_2;
        private SendOrPostCallback sendOrPostCallback_3;
        private SendOrPostCallback sendOrPostCallback_4;
        private SendOrPostCallback sendOrPostCallback_5;
        private SendOrPostCallback sendOrPostCallback_6;
        private SendOrPostCallback sendOrPostCallback_7;
        private SendOrPostCallback sendOrPostCallback_8;
        private sjCompletedEventHandler sjCompletedEventHandler_0;
        private suCompletedEventHandler suCompletedEventHandler_0;
        private yzCompletedEventHandler yzCompletedEventHandler_0;

        public Sv()
        {
            this.method_1(Class6.smethod_0("33B58412686095A0398B4DCC0D4EBA32A9933BC63A99BEAC7FDC669FB408848F"));
            if (this.method_52(this.method_0()))
            {
                this.method_3(true);
                this.bool_0 = false;
            }
            else
            {
                this.bool_0 = true;
            }
        }

        [SoapDocumentMethod("http://www.cskin.net/cn", RequestNamespace="http://www.cskin.net", ResponseNamespace="http://www.cskin.net", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped)]
        public string cn(string ml)
        {
            return (string) base.Invoke("cn", new object[] { ml })[0];
        }

        [SoapDocumentMethod("http://www.cskin.net/ddy", RequestNamespace="http://www.cskin.net", ResponseNamespace="http://www.cskin.net", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped)]
        public string ddy(string ml)
        {
            return (string) base.Invoke("ddy", new object[] { ml })[0];
        }

        [SoapDocumentMethod("http://www.cskin.net/dy", RequestNamespace="http://www.cskin.net", ResponseNamespace="http://www.cskin.net", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped)]
        public string dy(string ml)
        {
            return (string) base.Invoke("dy", new object[] { ml })[0];
        }

        [SoapDocumentMethod("http://www.cskin.net/e", RequestNamespace="http://www.cskin.net", ResponseNamespace="http://www.cskin.net", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped)]
        public string e(string ml)
        {
            return (string) base.Invoke("e", new object[] { ml })[0];
        }

        public void eQmbbbhObfg(string string_0, object object_0)
        {
            if (this.sendOrPostCallback_2 == null)
            {
                this.sendOrPostCallback_2 = new SendOrPostCallback(this.method_32);
            }
            base.InvokeAsync("yz", new object[] { string_0 }, this.sendOrPostCallback_2, object_0);
        }

        public void gbubbGlBkaA(ddyCompletedEventHandler ddyCompletedEventHandler_1)
        {
            ddyCompletedEventHandler handler2;
            ddyCompletedEventHandler handler = this.ddyCompletedEventHandler_0;
            do
            {
                handler2 = handler;
                ddyCompletedEventHandler handler3 = (ddyCompletedEventHandler) Delegate.Combine(handler2, ddyCompletedEventHandler_1);
                handler = Interlocked.CompareExchange<ddyCompletedEventHandler>(ref this.ddyCompletedEventHandler_0, handler3, handler2);
            }
            while (handler != handler2);
        }

        [SoapDocumentMethod("http://www.cskin.net/gt", RequestNamespace="http://www.cskin.net", ResponseNamespace="http://www.cskin.net", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped)]
        public string gt(string ml)
        {
            return (string) base.Invoke("gt", new object[] { ml })[0];
        }

        [SoapDocumentMethod("http://www.cskin.net/gu", RequestNamespace="http://www.cskin.net", ResponseNamespace="http://www.cskin.net", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped)]
        public string gu(string ml)
        {
            return (string) base.Invoke("gu", new object[] { ml })[0];
        }

        [SoapDocumentMethod("http://www.cskin.net/gx", RequestNamespace="http://www.cskin.net", ResponseNamespace="http://www.cskin.net", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped)]
        public string gx(string ml)
        {
            return (string) base.Invoke("gx", new object[] { ml })[0];
        }

        public string method_0()
        {
            return base.Url;
        }

        public void method_1(string string_0)
        {
            if (!((!this.method_52(base.Url) || this.bool_0) || this.method_52(string_0)))
            {
                base.UseDefaultCredentials = false;
            }
            base.Url = string_0;
        }

        public void method_10(yzCompletedEventHandler yzCompletedEventHandler_1)
        {
            yzCompletedEventHandler handler2;
            yzCompletedEventHandler handler = this.yzCompletedEventHandler_0;
            do
            {
                handler2 = handler;
                yzCompletedEventHandler handler3 = (yzCompletedEventHandler) Delegate.Remove(handler2, yzCompletedEventHandler_1);
                handler = Interlocked.CompareExchange<yzCompletedEventHandler>(ref this.yzCompletedEventHandler_0, handler3, handler2);
            }
            while (handler != handler2);
        }

        public void method_11(suCompletedEventHandler suCompletedEventHandler_1)
        {
            suCompletedEventHandler handler2;
            suCompletedEventHandler handler = this.suCompletedEventHandler_0;
            do
            {
                handler2 = handler;
                suCompletedEventHandler handler3 = (suCompletedEventHandler) Delegate.Combine(handler2, suCompletedEventHandler_1);
                handler = Interlocked.CompareExchange<suCompletedEventHandler>(ref this.suCompletedEventHandler_0, handler3, handler2);
            }
            while (handler != handler2);
        }

        public void method_12(suCompletedEventHandler suCompletedEventHandler_1)
        {
            suCompletedEventHandler handler2;
            suCompletedEventHandler handler = this.suCompletedEventHandler_0;
            do
            {
                handler2 = handler;
                suCompletedEventHandler handler3 = (suCompletedEventHandler) Delegate.Remove(handler2, suCompletedEventHandler_1);
                handler = Interlocked.CompareExchange<suCompletedEventHandler>(ref this.suCompletedEventHandler_0, handler3, handler2);
            }
            while (handler != handler2);
        }

        public void method_13(guCompletedEventHandler guCompletedEventHandler_1)
        {
            guCompletedEventHandler handler2;
            guCompletedEventHandler handler = this.guCompletedEventHandler_0;
            do
            {
                handler2 = handler;
                guCompletedEventHandler handler3 = (guCompletedEventHandler) Delegate.Combine(handler2, guCompletedEventHandler_1);
                handler = Interlocked.CompareExchange<guCompletedEventHandler>(ref this.guCompletedEventHandler_0, handler3, handler2);
            }
            while (handler != handler2);
        }

        public void method_14(guCompletedEventHandler guCompletedEventHandler_1)
        {
            guCompletedEventHandler handler2;
            guCompletedEventHandler handler = this.guCompletedEventHandler_0;
            do
            {
                handler2 = handler;
                guCompletedEventHandler handler3 = (guCompletedEventHandler) Delegate.Remove(handler2, guCompletedEventHandler_1);
                handler = Interlocked.CompareExchange<guCompletedEventHandler>(ref this.guCompletedEventHandler_0, handler3, handler2);
            }
            while (handler != handler2);
        }

        public void method_15(cnCompletedEventHandler cnCompletedEventHandler_1)
        {
            cnCompletedEventHandler handler2;
            cnCompletedEventHandler handler = this.cnCompletedEventHandler_0;
            do
            {
                handler2 = handler;
                cnCompletedEventHandler handler3 = (cnCompletedEventHandler) Delegate.Combine(handler2, cnCompletedEventHandler_1);
                handler = Interlocked.CompareExchange<cnCompletedEventHandler>(ref this.cnCompletedEventHandler_0, handler3, handler2);
            }
            while (handler != handler2);
        }

        public void method_16(cnCompletedEventHandler cnCompletedEventHandler_1)
        {
            cnCompletedEventHandler handler2;
            cnCompletedEventHandler handler = this.cnCompletedEventHandler_0;
            do
            {
                handler2 = handler;
                cnCompletedEventHandler handler3 = (cnCompletedEventHandler) Delegate.Remove(handler2, cnCompletedEventHandler_1);
                handler = Interlocked.CompareExchange<cnCompletedEventHandler>(ref this.cnCompletedEventHandler_0, handler3, handler2);
            }
            while (handler != handler2);
        }

        public void method_17(dyCompletedEventHandler dyCompletedEventHandler_1)
        {
            dyCompletedEventHandler handler2;
            dyCompletedEventHandler handler = this.dyCompletedEventHandler_0;
            do
            {
                handler2 = handler;
                dyCompletedEventHandler handler3 = (dyCompletedEventHandler) Delegate.Combine(handler2, dyCompletedEventHandler_1);
                handler = Interlocked.CompareExchange<dyCompletedEventHandler>(ref this.dyCompletedEventHandler_0, handler3, handler2);
            }
            while (handler != handler2);
        }

        public void method_18(dyCompletedEventHandler dyCompletedEventHandler_1)
        {
            dyCompletedEventHandler handler2;
            dyCompletedEventHandler handler = this.dyCompletedEventHandler_0;
            do
            {
                handler2 = handler;
                dyCompletedEventHandler handler3 = (dyCompletedEventHandler) Delegate.Remove(handler2, dyCompletedEventHandler_1);
                handler = Interlocked.CompareExchange<dyCompletedEventHandler>(ref this.dyCompletedEventHandler_0, handler3, handler2);
            }
            while (handler != handler2);
        }

        public void method_19(ddyCompletedEventHandler ddyCompletedEventHandler_1)
        {
            ddyCompletedEventHandler handler2;
            ddyCompletedEventHandler handler = this.ddyCompletedEventHandler_0;
            do
            {
                handler2 = handler;
                ddyCompletedEventHandler handler3 = (ddyCompletedEventHandler) Delegate.Remove(handler2, ddyCompletedEventHandler_1);
                handler = Interlocked.CompareExchange<ddyCompletedEventHandler>(ref this.ddyCompletedEventHandler_0, handler3, handler2);
            }
            while (handler != handler2);
        }

        public bool method_2()
        {
            return base.UseDefaultCredentials;
        }

        public void method_20(gtCompletedEventHandler gtCompletedEventHandler_1)
        {
            gtCompletedEventHandler handler2;
            gtCompletedEventHandler handler = this.gtCompletedEventHandler_0;
            do
            {
                handler2 = handler;
                gtCompletedEventHandler handler3 = (gtCompletedEventHandler) Delegate.Combine(handler2, gtCompletedEventHandler_1);
                handler = Interlocked.CompareExchange<gtCompletedEventHandler>(ref this.gtCompletedEventHandler_0, handler3, handler2);
            }
            while (handler != handler2);
        }

        public void method_21(gtCompletedEventHandler gtCompletedEventHandler_1)
        {
            gtCompletedEventHandler handler2;
            gtCompletedEventHandler handler = this.gtCompletedEventHandler_0;
            do
            {
                handler2 = handler;
                gtCompletedEventHandler handler3 = (gtCompletedEventHandler) Delegate.Remove(handler2, gtCompletedEventHandler_1);
                handler = Interlocked.CompareExchange<gtCompletedEventHandler>(ref this.gtCompletedEventHandler_0, handler3, handler2);
            }
            while (handler != handler2);
        }

        public void method_22(string string_0)
        {
            this.method_23(string_0, null);
        }

        public void method_23(string string_0, object object_0)
        {
            if (this.bunbbBfkVap == null)
            {
                this.bunbbBfkVap = new SendOrPostCallback(this.method_24);
            }
            base.InvokeAsync("sj", new object[] { string_0 }, this.bunbbBfkVap, object_0);
        }

        private void method_24(object object_0)
        {
            if (this.sjCompletedEventHandler_0 != null)
            {
                InvokeCompletedEventArgs args = (InvokeCompletedEventArgs) object_0;
                this.sjCompletedEventHandler_0(this, new sjCompletedEventArgs(args.Results, args.Error, args.Cancelled, args.UserState));
            }
        }

        public void method_25(string string_0)
        {
            this.method_26(string_0, null);
        }

        public void method_26(string string_0, object object_0)
        {
            if (this.sendOrPostCallback_0 == null)
            {
                this.sendOrPostCallback_0 = new SendOrPostCallback(this.method_27);
            }
            base.InvokeAsync("e", new object[] { string_0 }, this.sendOrPostCallback_0, object_0);
        }

        private void method_27(object object_0)
        {
            if (this.eCompletedEventHandler_0 != null)
            {
                InvokeCompletedEventArgs args = (InvokeCompletedEventArgs) object_0;
                this.eCompletedEventHandler_0(this, new eCompletedEventArgs(args.Results, args.Error, args.Cancelled, args.UserState));
            }
        }

        public void method_28(string string_0)
        {
            this.method_29(string_0, null);
        }

        public void method_29(string string_0, object object_0)
        {
            if (this.sendOrPostCallback_1 == null)
            {
                this.sendOrPostCallback_1 = new SendOrPostCallback(this.method_30);
            }
            base.InvokeAsync("gx", new object[] { string_0 }, this.sendOrPostCallback_1, object_0);
        }

        public void method_3(bool bool_1)
        {
            base.UseDefaultCredentials = bool_1;
            this.bool_0 = true;
        }

        private void method_30(object object_0)
        {
            if (this.gxCompletedEventHandler_0 != null)
            {
                InvokeCompletedEventArgs args = (InvokeCompletedEventArgs) object_0;
                this.gxCompletedEventHandler_0(this, new gxCompletedEventArgs(args.Results, args.Error, args.Cancelled, args.UserState));
            }
        }

        public void method_31(string string_0)
        {
            this.eQmbbbhObfg(string_0, null);
        }

        private void method_32(object object_0)
        {
            if (this.yzCompletedEventHandler_0 != null)
            {
                InvokeCompletedEventArgs args = (InvokeCompletedEventArgs) object_0;
                this.yzCompletedEventHandler_0(this, new yzCompletedEventArgs(args.Results, args.Error, args.Cancelled, args.UserState));
            }
        }

        public void method_33(string string_0)
        {
            this.method_34(string_0, null);
        }

        public void method_34(string string_0, object object_0)
        {
            if (this.sendOrPostCallback_3 == null)
            {
                this.sendOrPostCallback_3 = new SendOrPostCallback(this.method_35);
            }
            base.InvokeAsync("su", new object[] { string_0 }, this.sendOrPostCallback_3, object_0);
        }

        private void method_35(object object_0)
        {
            if (this.suCompletedEventHandler_0 != null)
            {
                InvokeCompletedEventArgs args = (InvokeCompletedEventArgs) object_0;
                this.suCompletedEventHandler_0(this, new suCompletedEventArgs(args.Results, args.Error, args.Cancelled, args.UserState));
            }
        }

        public void method_36(string string_0)
        {
            this.method_37(string_0, null);
        }

        public void method_37(string string_0, object object_0)
        {
            if (this.sendOrPostCallback_4 == null)
            {
                this.sendOrPostCallback_4 = new SendOrPostCallback(this.method_38);
            }
            base.InvokeAsync("gu", new object[] { string_0 }, this.sendOrPostCallback_4, object_0);
        }

        private void method_38(object object_0)
        {
            if (this.guCompletedEventHandler_0 != null)
            {
                InvokeCompletedEventArgs args = (InvokeCompletedEventArgs) object_0;
                this.guCompletedEventHandler_0(this, new guCompletedEventArgs(args.Results, args.Error, args.Cancelled, args.UserState));
            }
        }

        public void method_39(string string_0)
        {
            this.method_40(string_0, null);
        }

        public void method_4(sjCompletedEventHandler sjCompletedEventHandler_1)
        {
            sjCompletedEventHandler handler2;
            sjCompletedEventHandler handler = this.sjCompletedEventHandler_0;
            do
            {
                handler2 = handler;
                sjCompletedEventHandler handler3 = (sjCompletedEventHandler) Delegate.Remove(handler2, sjCompletedEventHandler_1);
                handler = Interlocked.CompareExchange<sjCompletedEventHandler>(ref this.sjCompletedEventHandler_0, handler3, handler2);
            }
            while (handler != handler2);
        }

        public void method_40(string string_0, object object_0)
        {
            if (this.sendOrPostCallback_5 == null)
            {
                this.sendOrPostCallback_5 = new SendOrPostCallback(this.method_41);
            }
            base.InvokeAsync("cn", new object[] { string_0 }, this.sendOrPostCallback_5, object_0);
        }

        private void method_41(object object_0)
        {
            if (this.cnCompletedEventHandler_0 != null)
            {
                InvokeCompletedEventArgs args = (InvokeCompletedEventArgs) object_0;
                this.cnCompletedEventHandler_0(this, new cnCompletedEventArgs(args.Results, args.Error, args.Cancelled, args.UserState));
            }
        }

        public void method_42(string string_0)
        {
            this.method_43(string_0, null);
        }

        public void method_43(string string_0, object object_0)
        {
            if (this.sendOrPostCallback_6 == null)
            {
                this.sendOrPostCallback_6 = new SendOrPostCallback(this.method_44);
            }
            base.InvokeAsync("dy", new object[] { string_0 }, this.sendOrPostCallback_6, object_0);
        }

        private void method_44(object object_0)
        {
            if (this.dyCompletedEventHandler_0 != null)
            {
                InvokeCompletedEventArgs args = (InvokeCompletedEventArgs) object_0;
                this.dyCompletedEventHandler_0(this, new dyCompletedEventArgs(args.Results, args.Error, args.Cancelled, args.UserState));
            }
        }

        public void method_45(string string_0)
        {
            this.method_46(string_0, null);
        }

        public void method_46(string string_0, object object_0)
        {
            if (this.sendOrPostCallback_7 == null)
            {
                this.sendOrPostCallback_7 = new SendOrPostCallback(this.method_47);
            }
            base.InvokeAsync("ddy", new object[] { string_0 }, this.sendOrPostCallback_7, object_0);
        }

        private void method_47(object object_0)
        {
            if (this.ddyCompletedEventHandler_0 != null)
            {
                InvokeCompletedEventArgs args = (InvokeCompletedEventArgs) object_0;
                this.ddyCompletedEventHandler_0(this, new ddyCompletedEventArgs(args.Results, args.Error, args.Cancelled, args.UserState));
            }
        }

        public void method_48(string string_0)
        {
            this.method_49(string_0, null);
        }

        public void method_49(string string_0, object object_0)
        {
            if (this.sendOrPostCallback_8 == null)
            {
                this.sendOrPostCallback_8 = new SendOrPostCallback(this.method_50);
            }
            base.InvokeAsync("gt", new object[] { string_0 }, this.sendOrPostCallback_8, object_0);
        }

        public void method_5(eCompletedEventHandler eCompletedEventHandler_1)
        {
            eCompletedEventHandler handler2;
            eCompletedEventHandler handler = this.eCompletedEventHandler_0;
            do
            {
                handler2 = handler;
                eCompletedEventHandler handler3 = (eCompletedEventHandler) Delegate.Combine(handler2, eCompletedEventHandler_1);
                handler = Interlocked.CompareExchange<eCompletedEventHandler>(ref this.eCompletedEventHandler_0, handler3, handler2);
            }
            while (handler != handler2);
        }

        private void method_50(object object_0)
        {
            if (this.gtCompletedEventHandler_0 != null)
            {
                InvokeCompletedEventArgs args = (InvokeCompletedEventArgs) object_0;
                this.gtCompletedEventHandler_0(this, new gtCompletedEventArgs(args.Results, args.Error, args.Cancelled, args.UserState));
            }
        }

        public void method_51(object object_0)
        {
            base.CancelAsync(object_0);
        }

        private bool method_52(string string_0)
        {
            if ((string_0 == null) || (string_0 == string.Empty))
            {
                return false;
            }
            Uri uri = new Uri(string_0);
            return ((uri.Port >= 0x400) && (string.Compare(uri.Host, "localHost", StringComparison.OrdinalIgnoreCase) == 0));
        }

        public void method_6(eCompletedEventHandler eCompletedEventHandler_1)
        {
            eCompletedEventHandler handler2;
            eCompletedEventHandler handler = this.eCompletedEventHandler_0;
            do
            {
                handler2 = handler;
                eCompletedEventHandler handler3 = (eCompletedEventHandler) Delegate.Remove(handler2, eCompletedEventHandler_1);
                handler = Interlocked.CompareExchange<eCompletedEventHandler>(ref this.eCompletedEventHandler_0, handler3, handler2);
            }
            while (handler != handler2);
        }

        public void method_7(gxCompletedEventHandler gxCompletedEventHandler_1)
        {
            gxCompletedEventHandler handler2;
            gxCompletedEventHandler handler = this.gxCompletedEventHandler_0;
            do
            {
                handler2 = handler;
                gxCompletedEventHandler handler3 = (gxCompletedEventHandler) Delegate.Combine(handler2, gxCompletedEventHandler_1);
                handler = Interlocked.CompareExchange<gxCompletedEventHandler>(ref this.gxCompletedEventHandler_0, handler3, handler2);
            }
            while (handler != handler2);
        }

        public void method_8(gxCompletedEventHandler gxCompletedEventHandler_1)
        {
            gxCompletedEventHandler handler2;
            gxCompletedEventHandler handler = this.gxCompletedEventHandler_0;
            do
            {
                handler2 = handler;
                gxCompletedEventHandler handler3 = (gxCompletedEventHandler) Delegate.Remove(handler2, gxCompletedEventHandler_1);
                handler = Interlocked.CompareExchange<gxCompletedEventHandler>(ref this.gxCompletedEventHandler_0, handler3, handler2);
            }
            while (handler != handler2);
        }

        public void method_9(yzCompletedEventHandler yzCompletedEventHandler_1)
        {
            yzCompletedEventHandler handler2;
            yzCompletedEventHandler handler = this.yzCompletedEventHandler_0;
            do
            {
                handler2 = handler;
                yzCompletedEventHandler handler3 = (yzCompletedEventHandler) Delegate.Combine(handler2, yzCompletedEventHandler_1);
                handler = Interlocked.CompareExchange<yzCompletedEventHandler>(ref this.yzCompletedEventHandler_0, handler3, handler2);
            }
            while (handler != handler2);
        }

        public void pvybbTiwhi2(sjCompletedEventHandler sjCompletedEventHandler_1)
        {
            sjCompletedEventHandler handler2;
            sjCompletedEventHandler handler = this.sjCompletedEventHandler_0;
            do
            {
                handler2 = handler;
                sjCompletedEventHandler handler3 = (sjCompletedEventHandler) Delegate.Combine(handler2, sjCompletedEventHandler_1);
                handler = Interlocked.CompareExchange<sjCompletedEventHandler>(ref this.sjCompletedEventHandler_0, handler3, handler2);
            }
            while (handler != handler2);
        }

        [SoapDocumentMethod("http://www.cskin.net/sj", RequestNamespace="http://www.cskin.net", ResponseNamespace="http://www.cskin.net", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped)]
        public string sj(string ml)
        {
            return (string) base.Invoke("sj", new object[] { ml })[0];
        }

        [SoapDocumentMethod("http://www.cskin.net/su", RequestNamespace="http://www.cskin.net", ResponseNamespace="http://www.cskin.net", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped)]
        public string su(string ml)
        {
            return (string) base.Invoke("su", new object[] { ml })[0];
        }

        [SoapDocumentMethod("http://www.cskin.net/yz", RequestNamespace="http://www.cskin.net", ResponseNamespace="http://www.cskin.net", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped)]
        public string yz(string ml)
        {
            return (string) base.Invoke("yz", new object[] { ml })[0];
        }
    }
}

