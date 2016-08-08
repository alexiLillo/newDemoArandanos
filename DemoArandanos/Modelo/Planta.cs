namespace DemoArandanos.Modelo
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Planta")]
    public partial class Planta
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string ID_Planta { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string ID_Hilera { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(50)]
        public string ID_Cuartel { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(50)]
        public string ID_Sector { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(50)]
        public string ID_Potrero { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(50)]
        public string ID_Fundo { get; set; }

        [StringLength(50)]
        public string Estado { get; set; }

        [StringLength(50)]
        public string Fecha_Plantacion { get; set; }

        [StringLength(250)]
        public string Observaciones { get; set; }

        [Key]
        [Column(Order = 6)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID_Mapeo { get; set; }

        public virtual Estado Estado1 { get; set; }

        public virtual Hilera Hilera { get; set; }
    }
}
