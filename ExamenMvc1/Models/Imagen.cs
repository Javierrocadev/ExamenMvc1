using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExamenMvc1.Models
{
    [Table("IMAGENESZAPASPRACTICA")]
    public class Imagen
    {
        [Key]
        [Column("IDIMAGEN")]
        public int IdImagen { get; set; }

        [Column("IDPRODUCTO")]
        public int IdProducto { get; set; }

        [Column("IMAGEN")]
        public string ImagenImagen { get; set; }
    }
}
//select* from ZAPASPRACTICA

//CREATE TABLE IMAGENESZAPASPRACTICA
//(IDIMAGEN INT NOT NULL PRIMARY KEY,
//IDPRODUCTO INT,
//IMAGEN NVARCHAR(1500))
//GO