namespace DemoArandanos.Modelo
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VistaApkPesaje")]
    public partial class VistaApkPesaje
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string ID_Fundo { get; set; }

        [StringLength(50)]
        public string nombreFundo { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string ID_Potrero { get; set; }

        [StringLength(50)]
        public string nombrePotrero { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(50)]
        public string ID_Sector { get; set; }

        [StringLength(50)]
        public string nombreSector { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(50)]
        public string ID_Variedad { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(50)]
        public string nombreVariedad { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(50)]
        public string ID_Cuartel { get; set; }

        [StringLength(50)]
        public string nombreCuartel { get; set; }

        [Key]
        [Column(Order = 6)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID_Mapeo { get; set; }

        [Key]
        [Column(Order = 7)]
        [StringLength(50)]
        public string ID_Producto { get; set; }

        [Key]
        [Column(Order = 8)]
        [StringLength(20)]
        public string TipoEnvase { get; set; }

        [Key]
        [Column(Order = 9)]
        public double KilosNetoEnvase { get; set; }

        [Key]
        [Column(Order = 10)]
        [StringLength(50)]
        public string Clase { get; set; }
    }
}
