using System.Collections.Generic;

namespace Core.Web.Data.Repository
{
    public interface ISolicitudRepository
    {
        IEnumerable<dynamic> listar_sucursal();

        void Insertardireccion(string direccion,string latitud,string longitud);
    }
}