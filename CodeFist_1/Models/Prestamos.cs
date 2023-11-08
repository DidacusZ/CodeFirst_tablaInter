﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeFist_1.Models
{
    public class Prestamos
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_prestamo { get; set; }

        public int id_libro { get; set; }//FK-Libros
        public Libros Libro { get; set; }

        public int id_usuario { get; set; }//FK-Usuarios
        public Usuarios Usuario { get; set; }

        public int cantidad_libro { get; set; }

        public DateTime fch_inicio_prestamo { get; set; }
        public DateTime fch_fin_prestamo { get; set; }
        public DateTime fch_entrega_prestamo { get; set; }
        
        public int id_estado_prestamo { get; set; }//FK-Estados_Prestamos
        public Estados_Prestamos Estado_Prestamo { get; set; }

        //public ICollection<LibrosPrestamos> Rel_Prestamos_Libros { get; set; }//un libro puede tener muchos Rel_Autores_Libros
        p//ublic List<Libros> Prestamos_Libros_M { get; set; } = new();//un libro puede tener muchos Rel_Autores_Libros
    }
}
