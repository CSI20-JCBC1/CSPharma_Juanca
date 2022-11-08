﻿using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class TdcCatEstadosEnvioPedido
    {
        public TdcCatEstadosEnvioPedido()
        {
            TdcTchEstadoPedidos = new HashSet<TdcTchEstadoPedido>();
        }

        public string MdUuid { get; set; } = null!;
        public DateTime MdDate { get; set; }
        public int Id { get; set; }
        public string CodEstadoEnvio { get; set; } = null!;
        public string? DesEstadoEnvio { get; set; }

        public virtual ICollection<TdcTchEstadoPedido> TdcTchEstadoPedidos { get; set; }
    }
}
