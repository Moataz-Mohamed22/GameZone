namespace GameZone.Settings
{
    public static class FileSettings
    {
        public const string ImagePath = "/assets/Images/Games";
        public const string AllowedExtension = ".jpg,.png,.jpeg";
        public const int MaxFileSaizeInMB = 1;
        public const int MaxFileSaizeInBytes = MaxFileSaizeInMB * 1024 * 1024;
    }
}
