namespace Cloud_CRUD.Models
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class Database_Context : DbContext
    {
        // Your context has been configured to use a 'Database_Context' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'Cloud_CRUD.Models.Database_Context' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'Database_Context' 
        // connection string in the application configuration file.
        public Database_Context()
            : base("name=Database_Context")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
        public virtual DbSet<User_Details> Users { get; set; }
        public virtual DbSet<Files> Files { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}