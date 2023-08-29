using ITI_MVC_Demo.Models;
using Microsoft.EntityFrameworkCore;

namespace ITI_MVC_Demo.Services
{
    //services Student Model CRUD
    public class EmployeeRepository : IEmployeeRepository
    {
        ITIEntity _context; //= new ITIEnitities();//ioc solid
        public EmployeeRepository(ITIEntity context)
        {
             _context = context;
        }
        public Guid id { get; set; }
        public EmployeeRepository()
        {
            id = Guid.NewGuid();
        }

        //REadall
        public List<Employee> getAll()
        {
            return _context.Employees.Include(e => e.department).ToList();
        }
        //readone
        public Employee getById(int id)
        {
            return _context.Employees.FirstOrDefault(s => s.Id == id);
        }
        public Employee getByNAme(string Name)
        {
            return _context.Employees.FirstOrDefault(s => s.Name == Name);
        }

        public List<Employee> getSudentByDEptID(int deptID)
        {
            return _context.Employees.Where(s => s.Dept_Id == deptID).ToList();
        }
        //Create
        public int Create(Employee std)
        {
            _context.Employees.Add(std);
            int raw = _context.SaveChanges();
            return raw;
            //insert context
        }
        //Update
        public int Update(int id, Employee student)
        {
            Employee oldEmployee = _context.Employees.FirstOrDefault(s => s.Id == id);
            oldEmployee.Name = student.Name;
            oldEmployee.Salary = student.Salary;
            oldEmployee.Dept_Id = student.Dept_Id;
            oldEmployee.Image = student.Image;
            oldEmployee.Address = student.Address;
            int raw = _context.SaveChanges();
            return raw;

        }
        //Delete
        public int Delete(int id)
        {
            Employee emp =
                _context.Employees.FirstOrDefault(s => s.Id == id);

            _context.Employees.Remove(emp);
            int raw = _context.SaveChanges();
            return raw;
        }
    }
}
