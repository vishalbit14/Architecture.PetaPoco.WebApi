using System;

namespace Architecture.Data.Infrastructure.Attributes
{
    [AttributeUsage(AttributeTargets.Method)]
    public class FormDataAuthenticationAttribute : Attribute
    {
        public FormDataAuthenticationAttribute(bool formDataAuthentication)
        {
            Value = formDataAuthentication;
        }

        public bool Value
        {
            get;
            private set;
        }
    }

    [AttributeUsage(AttributeTargets.Method)]
    public class IgnoreFormAuthenticationAttribute : Attribute
    {
        public IgnoreFormAuthenticationAttribute(bool formDataAuthentication)
        {
            Value = formDataAuthentication;
        }

        public bool Value
        {
            get;
            private set;
        }
    }
}