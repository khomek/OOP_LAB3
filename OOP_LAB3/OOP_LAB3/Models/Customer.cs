namespace OOP_LAB3.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string?  Surname { get; set; }
        //many-to-many
        public List<BookCustomer>? BookCustomers { get; set; } = new List<BookCustomer>();

    }
}
