namespace DemoArandanos.Modelo
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Vis_Fun-Pot-Sec-Cua-Hil-Est-Var")]
    public partial class Vis_Fun_Pot_Sec_Cua_Hil_Est_Var
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string ID_Fundo { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string ID_Potrero { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(50)]
        public string ID_Sector { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(50)]
        public string ID_Cuartel { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(50)]
        public string ID_Hilera { get; set; }

        [StringLength(50)]
        public string Estado { get; set; }

        [StringLength(50)]
        public string Variedad { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(50)]
        public string ID_Planta { get; set; }
    }
}
