namespace OOP_LAB3.Models
{
    public class Writer
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public List<Book>? Books { get; set; } = new List<Book>();
    }
}
