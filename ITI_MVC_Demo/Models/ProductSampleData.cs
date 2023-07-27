namespace ITI_MVC_Demo.Models
{
    public class ProductSampleData
    {
        List<Product> products;
        public ProductSampleData()
        {
            products = new List<Product>();
            products.Add(new Product() { Id = 1, Name = "IPhone1", Price = 10000, Image = "Capture.PNG", Description = "phone1" });
            products.Add(new Product() { Id = 2, Name = "IPhone2", Price = 20000, Image = "Capture.PNG", Description = "phone2" });
            products.Add(new Product() { Id = 3, Name = "IPhone3", Price = 30000, Image = "Capture.PNG", Description = "phone3" });
            products.Add(new Product() { Id = 4, Name = "IPhone4", Price = 40000, Image = "Capture.PNG", Description = "phone4" });
        }
        public List<Product> GetAll()
        {
            return products;
        }
        public Product GetById(int id)
        {
            return products.FirstOrDefault(e => e.Id == id);
        }
    }
}
