namespace DemoArandanos.Modelo
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Vis_Pesaje_Variedad-Producto")]
    public partial class Vis_Pesaje_Variedad_Producto
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string Producto { get; set; }

        [StringLength(50)]
        public string N_Producto { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string Variedad { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(50)]
        public string N_Variedad { get; set; }

        [StringLength(10)]
        public string Fecha { get; set; }

        public double? Suma_Cantidad { get; set; }

        public double? Suma_KNeto { get; set; }
    }
}
