using ITI_MVC_Demo.Models;

namespace ITI_MVC_Demo.Services
{
    public interface IDepartmentRepository
    {
        int Create(Department dept);
        int Delete(int id);
        List<Department> getAll();
        Department getById(int id);
        int Update(int id, Department dept);
    }
}
