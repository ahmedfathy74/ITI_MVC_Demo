namespace ITI_MVC_Demo.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string ManagerName { get; set; } = null!;

        public virtual List<Employee>? Employees { get; set; }
    }
}
