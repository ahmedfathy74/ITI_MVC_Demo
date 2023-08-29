using Microsoft.EntityFrameworkCore;

namespace ITI_MVC_Demo.Models
{
    //databse name -name server - authantic

    public class ITIEntity : DbContext
    {
        public ITIEntity() : base()
        {

        }
        //injection need to this constructor

        public ITIEntity(DbContextOptions options):base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.; Initial Catalog=ITIMVCDB ;Integrated Security=True;");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
