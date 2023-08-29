using ITI_MVC_Demo.Models;
using Microsoft.EntityFrameworkCore.Storage;

namespace ITI_MVC_Demo.Services
{
    public class EmployeeFRomMEmeoryRepository : IEmployeeRepository
    {
        List<Employee> std = new List<Employee>();
        public EmployeeFRomMEmeoryRepository()
        {
            std.Add(new Employee() { Id = 1, Name = "Mohamed", Salary = 13, Address = "sdsd", Dept_Id = 1 , Image = "P1.jpg"});
            std.Add(new Employee() { Id = 1, Name = "Mohamed", Salary = 13, Address = "sdsd", Dept_Id = 1 , Image = "P1.jpg"});
        }

        public Guid id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public int Create(Employee std)
        {
            throw new System.NotImplementedException();
        }

        public int Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public List<Employee> getAll()
        {
            return std;
        }
        public Employee getById(int id)
        {
            return std.FirstOrDefault();
        }

        public Employee getByNAme(string Name)
        {
            throw new System.NotImplementedException();
        }

        public List<Employee> getSudentByDEptID(int deptID)
        {
            throw new System.NotImplementedException();
        }

        public int Update(int id, Employee student)
        {
            throw new System.NotImplementedException();
        }
    }
}
