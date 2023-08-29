using ITI_MVC_Demo.Models;
using Microsoft.EntityFrameworkCore;

namespace ITI_MVC_Demo.Services
{
    //CRUD DEpartment
    public class DepartmentRepository : IDepartmentRepository
    {
        ITIEntity context;// = new ITIEnitities();
        //REadall
        public DepartmentRepository(ITIEntity _context)
        {
            context = _context;
        }
        public List<Department> getAll()
        {
            return context.Departments.ToList();
        }
        //readone
        public Department getById(int id)
        {
            return context.Departments.Include(e => e.Employees).FirstOrDefault(d => d.Id == id);
        }
        //Create
        public int Create(Department dept)
        {
            context.Departments.Add(dept);
            int raw = context.SaveChanges();
            return raw;
            //insert context
        }
        //Update
        public int Update(int id, Department dept)
        {
            Department oldDEpt = context.Departments.FirstOrDefault(s => s.Id == id);
            oldDEpt.Name = dept.Name;
            oldDEpt.ManagerName = dept.ManagerName;
            int raw = context.SaveChanges();
            return raw;

        }
        //Delete
        public int Delete(int id)
        {
            Department dept =
                context.Departments.FirstOrDefault(s => s.Id == id);
            context.Departments.Remove(dept);
            int raw = context.SaveChanges();
            return raw;
        }
    }
}
