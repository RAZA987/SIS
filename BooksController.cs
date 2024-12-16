using System.Linq;
   using System.Net;
   using System.Web.Http;
   using System.Data.Entity;
   using YourNamespace.Models; // Adjust the namespace accordingly

   public class BooksController : ApiController
   {
       private LibraryContext db = new LibraryContext();

       // GET: api/Books
       public IQueryable<Book> GetBooks()
       {
           return db.Books;
       }

       // GET: api/Books/5
       [HttpGet]
       [Route("api/Books/{id}")]
       public IHttpActionResult GetBook(int id)
       {
           Book book = db.Books.Find(id);
           if (book == null)
           {
               return NotFound();
           }

           return Ok(book);
       }

       // POST: api/Books
       [HttpPost]
       public IHttpActionResult PostBook(Book book)
       {
           if (!ModelState.IsValid)
           {
               return BadRequest(ModelState);
           }

           db.Books.Add(book);
           db.SaveChanges();

           return CreatedAtRoute("DefaultApi", new { id = book.Bookno }, book);
       }

       // PUT: api/Books/5
       [HttpPut]
       [Route("api/Books/{id}")]
       public IHttpActionResult PutBook(int id, Book book)
       {
           if (!ModelState.IsValid)
           {
               return BadRequest(ModelState);
           }

           if (id != book.Bookno)
           {
               return BadRequest();
           }

           db.Entry(book).State = EntityState.Modified;

           try
           {
               db.SaveChanges();
           }
           catch (DbUpdateConcurrencyException)
           {
               if (!BookExists(id))
               {
                   return NotFound();
               }
               else
               {
                   throw;
               }
           }

           return StatusCode(HttpStatusCode.NoContent);
       }

       // DELETE: api/Books/5
       [HttpDelete]
       [Route("api/Books/{id}")]
       public IHttpActionResult DeleteBook(int id)
       {
           Book book = db.Books.Find(id);
           if (book == null)
           {
               return NotFound();
           }

           db.Books.Remove(book);
           db.SaveChanges();

           return Ok(book);
       }

       private bool BookExists(int id)
       {
           return db.Books.Count(e => e.Bookno == id) > 0;
       }
   }
