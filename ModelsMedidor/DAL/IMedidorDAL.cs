using ModelsMedidor.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsMedidor.DAL
{
    public interface IMedidorDAL
    {
        List<Medidor> ObtenerMedidores();
    }
}
