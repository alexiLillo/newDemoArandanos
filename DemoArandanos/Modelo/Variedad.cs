namespace DemoArandanos.Modelo
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Variedad")]
    public partial class Variedad
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Variedad()
        {
            Pesaje = new HashSet<Pesaje>();
        }

        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string ID_Variedad { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string ID_Producto { get; set; }

        public virtual Producto Producto { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pesaje> Pesaje { get; set; }
    }
}
