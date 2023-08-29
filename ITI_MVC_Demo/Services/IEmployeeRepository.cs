using ITI_MVC_Demo.Models;

namespace ITI_MVC_Demo.Services
{
    public interface IEmployeeRepository
    {
        Guid id { get; set; }
        int Create(Employee std);
        int Delete(int id);
        List<Employee> getAll();
        Employee getById(int id);
        Employee getByNAme(string Name);
        List<Employee> getSudentByDEptID(int deptID);
        int Update(int id, Employee student);
    }
}
