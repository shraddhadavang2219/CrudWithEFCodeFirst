using Microsoft.EntityFrameworkCore;

namespace CrudWithEFCodeFirst.Model
{
    public class flipkartContext:DbContext
    {
        public flipkartContext(DbContextOptions<flipkartContext>options)
            :base(options) 
        {

        }
        
        public DbSet<CategoryModel> Category { get; set; }
        

    }
}
