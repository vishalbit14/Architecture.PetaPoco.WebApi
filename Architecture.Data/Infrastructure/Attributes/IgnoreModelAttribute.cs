using System;

namespace Architecture.Data.Infrastructure.Attributes
{
    [AttributeUsage(AttributeTargets.Method)]
    public class IgnoreModelAttribute : Attribute
    {
        public IgnoreModelAttribute(bool ignoreModel)
        {
            Value = ignoreModel;
        }

        public bool Value
        {
            get;
            private set;
        }
    }
}