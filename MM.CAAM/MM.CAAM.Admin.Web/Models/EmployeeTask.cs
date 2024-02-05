namespace MM.CAAM.Admin.Web.Models
{
    public class EmployeeTask
    {
        public int ID { get; set; }
        public string Subject { get; set; }
        public DateTime StartDate { get; set; } = DateTime.Now;
        public DateTime DueDate { get; set; } =  DateTime.Now;
        public string Status { get; set; }
        public int Priority { get; set; }
        public int Completion { get; set; }
    }
}
