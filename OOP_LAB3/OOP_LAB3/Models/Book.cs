namespace OOP_LAB3.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string? Name { get; set; }   
        public int? WriterId { get; set; }
        //one-to-many
        public Writer? Writer { get; set; }
        //many-to-many
        public List<BookCustomer>? BookCustomers { get; set; } = new List<BookCustomer>();
        
    }
}
