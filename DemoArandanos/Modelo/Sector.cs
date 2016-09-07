namespace DemoArandanos.Modelo
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Sector")]
    public partial class Sector
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Sector()
        {
            Cuartel = new HashSet<Cuartel>();
        }

        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string ID_Sector { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string ID_Potrero { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(50)]
        public string ID_Fundo { get; set; }

        [StringLength(50)]
        public string Nombre { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cuartel> Cuartel { get; set; }

        public virtual Potrero Potrero { get; set; }
    }
}
