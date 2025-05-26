using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace BancoSimple2T1.Models
{
    public class Transaccion
    {
        public int TransaccionId { get; set; }
        public decimal Monto { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
        public string Descripcion { get; set; }
        public int? CuentaOrigenId { get; set; }
        public int? CuentaDestinoId { get; set; }

        // Método para validar la transacción
        public bool EsValida()
        {
            if (Monto <= 0) return false;
            if (string.IsNullOrWhiteSpace(Descripcion)) return false;
            if (CuentaOrigenId == null && CuentaDestinoId == null) return false;
            return true;
        }
    }
}
