   using System.Data.Entity;

   public class LibraryContext : DbContext
   {
       public DbSet<Book> Books { get; set; }
   }
