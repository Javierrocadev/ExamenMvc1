using ExamenMvc1.Data;
using ExamenMvc1.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

#region
//CREATE PROCEDURE SP_REGISTRO_ZAPATILLAS_V8
//(
//    @idZapatilla INT,
//    @posicion INT,
//    @registros INT OUTPUT
//)
//AS
//BEGIN
//    -- Contar el número de registros para la zapatilla especificada
//    SELECT @registros = COUNT(IDPRODUCTO)
//    FROM IMAGENESZAPASPRACTICA
//    WHERE IDPRODUCTO = @idZapatilla;

//--Seleccionar las imágenes de la zapatilla especificada en la posición especificada
//    SELECT IDIMAGEN, IDPRODUCTO, IMAGEN
//    FROM (
//        SELECT 
//            ROW_NUMBER() OVER (ORDER BY IDIMAGEN) AS POSICION,
//        IDIMAGEN, IDPRODUCTO, IMAGEN
//        FROM IMAGENESZAPASPRACTICA
//        WHERE IDPRODUCTO = @idZapatilla
//    ) AS QUERY
//    WHERE QUERY.POSICION = @posicion;
//END
#endregion


namespace ExamenMvc1.Repositories
{
    public class RepositoryZapatilla
    {
        private ZapatillaContext context;

        public RepositoryZapatilla(ZapatillaContext context)
        {
            this.context = context;
        }


        //mis metodos

        public async Task<List<Zapatilla>> GetZapatillasAsync()
        {
            return await this.context.Zapatillas.ToListAsync();
        }


        public async Task<Zapatilla> FindDepartamentosAsync(int id)
        {
            return await this.context.Zapatillas.FirstOrDefaultAsync(x => x.IdZapatilla == id);
        }



        //metodo con PROCEDURE PARA DEVOLVER LAS IMAGENES DE LA ZAPATILLA

        public async Task<ModelImagenPaginacion> GetImagenZapatillaAsync
           (int posicion, int idzapatilla)
        {
            string sql = "SP_REGISTRO_ZAPATILLAS_V8 @posicion, @idzapatilla, "
                + " @registros out";
            SqlParameter pamPosicion = new SqlParameter("@posicion", posicion);
            SqlParameter pamZapatilla =new SqlParameter("@idzapatilla", idzapatilla);
            SqlParameter pamRegistros = new SqlParameter("@registros", -1);
            pamRegistros.Direction = ParameterDirection.Output;
            var consulta =
                this.context.Imagenes.FromSqlRaw
                (sql, pamPosicion, pamZapatilla, pamRegistros);
            //PRIMERO DEBEMOS EJECUTAR LA CONSULTA PARA PODER RECUPERAR 
            //LOS PARAMETROS DE SALIDA
            var datos = await consulta.ToListAsync();
            Imagen imagen = datos.FirstOrDefault();
            int registros = (int)pamRegistros.Value;
            return new ModelImagenPaginacion
            {
                Registros = registros,
                Imagen = imagen
            };
        }
    }
}
