using System;

namespace Architecture.Data.Infrastructure.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    public class SetValueOnAddAttribute : Attribute
    {
        public SetValueOnAddAttribute(int setValue)
        {
            SetValue = setValue;
        }
        public int SetValue { get; set; }
        public enum SetValueEnum
        {
            CurrentTime = 1, LoggedInUserId, EpochTime
        }
    }
   
}
