using Microsoft.AspNetCore.Http.HttpResults;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExamenMvc1.Models
{
    [Table("ZAPASPRACTICA")]
    public class Zapatilla
    {
        [Key]
        [Column("IDPRODUCTO")]
        public int IdZapatilla { get; set; }

        [Column("NOMBRE")]
        public string Nombre { get; set; }

        [Column("DESCRIPCION")]
        public string Descripcion { get; set; }

        [Column("PRECIO")]
        public int Precio { get; set; }
    }
}


//CREATE TABLE ZAPASPRACTICA
//(IDPRODUCTO INT NOT NULL PRIMARY KEY,
//NOMBRE NVARCHAR(100),
//DESCRIPCION NVARCHAR(1200),
//PRECIO INT)
//GO
