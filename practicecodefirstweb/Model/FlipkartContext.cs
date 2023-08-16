using Microsoft.EntityFrameworkCore;

namespace practicecodefirstweb.Model
{
    public class FlipkartContext:DbContext
    {
        public FlipkartContext(DbContextOptions<FlipkartContext>options) 
            :base(options) 
        { 

        }  

        public DbSet<Category> CategoryModel { get; set; }
        

        
    }
}
