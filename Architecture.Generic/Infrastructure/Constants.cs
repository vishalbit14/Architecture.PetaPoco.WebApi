namespace Architecture.Generic.Infrastructure
{
    public class Constants
    {
        public const string AnonymousPermission = "AnonymousPermission";
        public const string AuthorizedPermission = "AuthorizedPermission";

        public const string Culture_EN = "en-GB";
        public const string DataTypeString = "string";
        public const string DataTypeBoolean = "bool";

        #region Date Format

        public const string DateFormatDashed = "dd-MM-yyyy";
        public const string DateFormatSlash = "dd/MM/yyyy";
        public const string DbDateFormat = "yyyy-MM-dd";
        public const string TimeFormat = "HH:mm:ss";
        public const string DbTimeFormat = "HH:mm:ss";

        public const string FullDateTimeFormat = "ddMMyyyyhhmmssfff";
        public const string FullDateTimeDashedFormat = "yyyy-MM-dd hh:mm:ss.fff";

        #endregion

        #region Regex

        public const string RegxEmail = @"^[\w-']+(\.[\w-']+)*@([a-z0-9-]+(\.[a-z0-9-]+)*?\.[a-z]{2,6}|(\d{1,3}\.){3}\d{1,3})(:\d{4})?$";
        public const string RegxPassword = @"^(?=.*?[A-Z])(?=.*?[0-9])(?=.*?[!@#$%^&*()_+}{"":;\'?\/>.<,]).{8,20}$";

        #endregion

        #region Api Keys

        public const string TokenHeaderName = "Authorization";
        public const string KeyHeaderName = "AccessKey";
        public const string RequestModelName = "request";

        #endregion
    }
}
