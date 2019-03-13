namespace api_integrador_sistemas.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tbl_permissao_usuario_tela")]
    public partial class PermissaoUsuarioTela
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id_usuario { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id_tela { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id_permissao { get; set; }

        [Required]
        [StringLength(1)]
        public string ativo { get; set; }

        public virtual Permissao tbl_permissao { get; set; }

        public virtual Tela tbl_tela { get; set; }

        public virtual Usuario tbl_usuario { get; set; }
    }
}
