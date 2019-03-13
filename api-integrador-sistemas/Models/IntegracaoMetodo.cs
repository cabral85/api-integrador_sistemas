namespace api_integrador_sistemas.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tbl_integracao_metodo")]
    public partial class IntegracaoMetodo
    {
        public int Id { get; set; }

        public int? IdMetodoPrimario { get; set; }

        public int? IdMetodoSecundario { get; set; }

        public virtual Metodo MetodoPrimario { get; set; }

        public virtual Metodo MetodoSecundario { get; set; }
    }
}
