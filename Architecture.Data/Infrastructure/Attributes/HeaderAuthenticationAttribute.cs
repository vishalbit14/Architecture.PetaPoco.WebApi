using System;

namespace Architecture.Data.Infrastructure.Attributes
{
    [AttributeUsage(AttributeTargets.Method)]
    public class HeaderAuthenticationAttribute : Attribute
    {
        public HeaderAuthenticationAttribute(bool headerAuthentication)
        {
            Value = headerAuthentication;
        }

        public bool Value
        {
            get;
            private set;
        }
    }
}