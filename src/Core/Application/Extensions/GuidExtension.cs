namespace Application.Extensions
{
    public static class GuidExtension
    {
        public static bool NullOrEmpty(this Guid? guid) => guid == Guid.Empty || guid == null;
        public static bool NotNullAndEmpty(this Guid? guid) => guid != Guid.Empty && guid != null;
    }
}