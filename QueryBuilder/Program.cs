
using QueryBuilder_Lab;
using QueryBuilder_Lab.Models;

var database = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.ToString() + "\\Data\\Lab05.db";

List<Author> authors = new List<Author>();
using(var qb = new QueryBuilder(database))
{
    //Read
    //Console.WriteLine(qb.Read<Author>(1));

    //Create
    //var sk = new Author(99, "Steve", "Bob");
    //qb.Create<Author>(sk);

    //Update 
    //var sk = new Author(02, "Even", "Robbertson");
    //qb.Update<Author>(sk);

    //Delete
    //var sk = new Author(02, "Even", "Robbertson");
    //qb.Delete<Author>(sk);

    //Read all
    authors = qb.ReadAll<Author>();

    //Dispose
    qb.Dispose();
}

    authors.Sort();

foreach(Author a in authors)
{
    Console.WriteLine(a);
}


