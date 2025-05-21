namespace OOP_LAB3.Models
{
    public class BookCustomer
    {
        public int Id { get; set; }
        public int? BookId { get; set; }
        public int? CustomerId { get; set; }
        
        public Book? Book { get; set; }
        public Customer? Customer { get; set; }
    }
}
