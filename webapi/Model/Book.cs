namespace webapi.Model
{
    public class BookItem
    {
        public string? Title { get; set; }
        public string? Authros { get; set; }
        public string? Publisher { get; set; }
    }

    public class Book
    {
        public VolumeInfo? VolumeInfo { get; set; }
    }
    public class Root
    {
        public required List<Book> Items { get; set; }
    }
    public class VolumeInfo
    {
        public string? Title { get; set; }
        public List<string>? Authors { get; set; }
        public string? Publisher { get; set; }
    }
}
