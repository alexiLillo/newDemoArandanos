namespace DemoArandanos.Modelo
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Cuartel")]
    public partial class Cuartel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Cuartel()
        {
            Hilera = new HashSet<Hilera>();
        }

        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string ID_Cuartel { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string ID_Sector { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(50)]
        public string ID_Potrero { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(50)]
        public string ID_Fundo { get; set; }

        public double? Superficie { get; set; }

        [StringLength(50)]
        public string Nombre { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Hilera> Hilera { get; set; }
    }
}
