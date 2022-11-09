using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class TdcCatEstadosPagoPedido
    {
        public TdcCatEstadosPagoPedido()
        {
            TdcTchEstadoPedidos = new HashSet<TdcTchEstadoPedido>();
        }

        public string MdUuid { get; set; } = null!;
        public DateTime MdDate { get; set; }
        public int Id { get; set; }
        public string CodEstadoPago { get; set; } = null!;
        public string? DesEstadoPago { get; set; }

        public virtual ICollection<TdcTchEstadoPedido>? TdcTchEstadoPedidos { get; set; }
    }
}
