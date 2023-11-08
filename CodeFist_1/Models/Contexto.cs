using Microsoft.EntityFrameworkCore;



namespace CodeFist_1.Models
{
    public class Contexto : DbContext
    {
        //para que no de error en m-m poner distinto nombre entidad que en BD
        // <nombre entidad>     nombre en BD
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Accesos> Accesos { get; set; }
        public DbSet<Autores> Autoress { get; set; }
        public DbSet<Colecciones> Colecciones { get; set; }
        public DbSet<Editoriales> Editoriales { get; set; }
        public DbSet<Estados_Prestamos> Estados_Prestamos { get; set; }
        public DbSet<Generos> Generos { get; set; }
        public DbSet<Libros> Libross { get; set; }
        public DbSet<Prestamos> Prestamoss { get; set; }
        public DbSet<LibrosPrestamos> Rel_Libros_Prestamos { get; set; }
        public DbSet<AutoresLibros> Rel_Autores_Libros { get; set; }

        public Contexto(DbContextOptions<Contexto> opciones):base(opciones) { 
        
        }

        public Contexto()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)//ids autoincrementables
        {
            modelBuilder.UseSerialColumns();//ids autoincrementables

            //crea una sola columna en vez de dos para la FK   Usuarios-Acces...

            //relacion Acceso-Usuarios
            modelBuilder.Entity<Usuarios>()
            .HasOne(uno => uno.Acceso)
            .WithMany(muchos => muchos.Usuarios_acceso)//campos de acceso
            .HasForeignKey(uno => uno.id_acceso);//campos de usuario

            //Prestamo-Usuarios
            modelBuilder.Entity<Prestamos>()
            .HasOne(uno => uno.Usuario)
            .WithMany(muchos => muchos.Prestamos_usuario)
            .HasForeignKey(uno => uno.id_usuario);

            //Estado-Prestamos
            modelBuilder.Entity<Prestamos>()
            .HasOne(uno => uno.Estado_Prestamo)
            .WithMany(muchos => muchos.Prestamos_estado)
            .HasForeignKey(uno => uno.id_prestamo);

            /*
            //Libros-Prestamos
            modelBuilder.Entity<Libros>()
            .HasMany(e => e.Libros_Prestamos_M)
            .WithMany(e => e.Prestamos_Libros_M)
            .UsingEntity(
            "tabla_intermedia_Libros-Prestamos",
            l => l.HasOne(typeof(Libros)).WithMany().HasForeignKey("id_libro").HasPrincipalKey(nameof(Libros.id_libro)),
            r => r.HasOne(typeof(Prestamos)).WithMany().HasForeignKey("id_prestamo").HasPrincipalKey(nameof(Prestamos.id_prestamo)),
            j => j.HasKey("id_prestamo", "id_libro"));
            */

            //Coleccion-Libros
            modelBuilder.Entity<Libros>()
            .HasOne(uno => uno.Coleccion)
            .WithMany(muchos => muchos.Libros_coleccion)
            .HasForeignKey(uno => uno.id_coleccion);

            //Editorial-Libros
            modelBuilder.Entity<Libros>()
            .HasOne(uno => uno.Editorial)
            .WithMany(muchos => muchos.Libros_editorial)
            .HasForeignKey(uno => uno.id_editorial);

            //Genero-Libros
            modelBuilder.Entity<Libros>()
            .HasOne(uno => uno.Genero)
            .WithMany(muchos => muchos.Libros_genero)
            .HasForeignKey(uno => uno.id_genero);

            /* RELACION UNO A MUCHOS
             modelBuilder.Entity<muchos>()
            .HasOne(c2 => c2.uno)
            .WithMany(c1 => c1.muchosItems)//relacion esta en uno(item)
            .HasForeignKey(c2 => c2.unoId);//campo esta en muchos
             */

            /* RELACION UNO A UNO
            modelBuilder.Entity<uno2>()
            .HasOne(c2 => c2.uno1)
            .WithOne(c1 => c1.uno2)
            .HasForeignKey<uno2>(c2 => c2.uno1Id);
            */

            /* RELACION MUCHOS A MUCHOS (TABLA INTERMEDIA) 
             
                        modelBuilder.Entity<Post>()
            .HasMany(e => e.Tags)
            .WithMany(e => e.Posts)
            .UsingEntity(
            "PostTag",
            l => l.HasOne(typeof(Tag)).WithMany().HasForeignKey("TagsId").HasPrincipalKey(nameof(Tag.id)),
            r => r.HasOne(typeof(Post)).WithMany().HasForeignKey("PostsId").HasPrincipalKey(nameof(Post.id)),
            j => j.HasKey("PostsId", "TagsId"));            
            
            */
            /*
            //Autores-Libros
            modelBuilder.Entity<Autores>()
            .HasMany(e => e.Autores_Libros_M)
            .WithMany(e => e.Libros_Autores_M)
            .UsingEntity(
            "tabla_intermedia_Autores-Libros",
            l => l.HasOne(typeof(Libros)).WithMany().HasForeignKey("id_libro").HasPrincipalKey(nameof(Libros.id_libro)),
            r => r.HasOne(typeof(Autores)).WithMany().HasForeignKey("id_autor").HasPrincipalKey(nameof(Autores.id_autor)),
            j => j.HasKey("id_autor", "id_libro"));
            */
        }

    }
}
