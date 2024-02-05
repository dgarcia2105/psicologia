namespace MM.CAAM.Admin.Web.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Prefix { get; set; }
        public string Position { get; set; }
        public DateTime BirthDay { get; set; }
        public DateTime HireDate { get; set; }
        public string Notes { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public ICollection<EmployeeTask> Tasks { get; set; }
        public int StateId { get; set; }
        public string State { get; set; }
        public string HomePhone { get; set; }
        public string Skype { get; set; }
        public string Picture { get; set; }
    }
}
