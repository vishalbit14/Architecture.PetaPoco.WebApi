using System;

namespace Architecture.Data.Infrastructure.Attributes
{
    [AttributeUsage(AttributeTargets.Method)]
    public class IgnoreAuthenticationAttribute : Attribute
    {
        public IgnoreAuthenticationAttribute(bool ignoreAuthentication)
        {
            Value = ignoreAuthentication;
        }

        public bool Value
        {
            get;
            private set;
        }
    }
}