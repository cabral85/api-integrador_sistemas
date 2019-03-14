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
        public int IdUsuario { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdTela { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdPermissao { get; set; }

        [Required]
        [StringLength(1)]
        public string Ativo { get; set; }

        public virtual Permissao Permissao { get; set; }

        public virtual Tela Tela { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
