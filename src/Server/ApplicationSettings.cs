namespace Chameleon.Server
{
    public class StorageOptions
    {
        public string Name { get; set; }
        public string ConnStr { get; set; }
    }

    public class GalleryOptions
    {
        public string Name { get; set; }
        public string APIURL { get; set; }
    }

    public class AppSettings
    {
        public StorageOptions StorageOptions { get; set; }
        public GalleryOptions GalleryOptions { get; set; }
    }
}