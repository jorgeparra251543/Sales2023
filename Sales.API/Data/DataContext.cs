using Microsoft.EntityFrameworkCore;
using Sales.Shared.Entities;

namespace Sales.API.Data
{
    //Para conectarnos a la Base de Datos DataContext hereda de la clase DbContext que importamos(using Microsoft.EntityFrameworkCore;)
    public class DataContext : DbContext
    {
        //conectarme a la bd, con el costructor, option se lo paso a la clase que hereda base(options)
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        
        }

        //Propiedades de la entidad
        public DbSet<Country> Countries { get; set; }

        //para que cada pais sea unico y no haya repetidos
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Country>().HasIndex(x => x.Name).IsUnique();//creamos definicion para la bd

        }


    }
}
