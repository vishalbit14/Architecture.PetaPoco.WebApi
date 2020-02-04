using System;

namespace Architecture.Data.Infrastructure.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    public class SetValueOnUpdateAttribute : Attribute
    {
        public SetValueOnUpdateAttribute(int setValueOnUpdate)
        {
            SetValueOnUpdate = setValueOnUpdate;
        }
        public int SetValueOnUpdate { get; set; }
    }
}
