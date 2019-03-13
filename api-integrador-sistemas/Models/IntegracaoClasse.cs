namespace api_integrador_sistemas.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tbl_classe_integracao")]
    public partial class IntegracaoClasse
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public int IdClassePrimaria { get; set; }

        public int IdClasseSecundaria { get; set; }

        public virtual Classe ClassePrimaria { get; set; }

        public virtual Classe ClasseSecundaria { get; set; }
    }
}
