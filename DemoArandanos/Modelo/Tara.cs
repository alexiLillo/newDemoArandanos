namespace DemoArandanos.Modelo
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Tara")]
    public partial class Tara
    {
        [Key]
        [StringLength(50)]
        public string ID_Tara { get; set; }

        public decimal Peso { get; set; }

        [Required]
        [StringLength(50)]
        public string Producto { get; set; }

        [Required]
        [StringLength(50)]
        public string Formato { get; set; }

        [StringLength(150)]
        public string Descripcion { get; set; }
    }
}
