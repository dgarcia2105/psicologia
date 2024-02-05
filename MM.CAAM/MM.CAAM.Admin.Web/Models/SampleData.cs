namespace MM.CAAM.Admin.Web.Models
{
    public class SampleData
    {
        public static List<Employee> Employees {
            get
            {
                return new List<Employee> { 
                    new Employee{
                        Id = 1,
                        FirstName = "Test",
                        LastName = "Test",
                        Phone = "Test",
                        Prefix = "Mr.",
                        Position = "CEO",
                        BirthDay = DateTime.Parse("1992/05/21"),
                        HireDate = DateTime.Parse("2004/05/21"),
                        Notes = "Inicio...",
                        Email = "sanck.one@gmail.com",
                        Address = "351 S Hill St.",
                        City = "Los Angeles",
                        Tasks = new List<EmployeeTask> {
                            new EmployeeTask
                            {
                                ID = 1,
                                Subject = "Test",
                                StartDate = DateTime.Parse("2024/01/01"),
                                DueDate = DateTime.Parse("2024/01/01"),
                                Status = "Completed",
                                Priority = 1,
                                Completion = 100
                            }
                        },
                        StateId = 1,
                        State = "state",
                        HomePhone = "Home",
                        Skype = "skype",
                        Picture = "Picture"
                    }};
            }
        }
    }
}
