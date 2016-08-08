namespace DemoArandanos.Modelo
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Hilera")]
    public partial class Hilera
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Hilera()
        {
            Planta = new HashSet<Planta>();
        }

        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string ID_Hilera { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string ID_Cuartel { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(50)]
        public string ID_Sector { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(50)]
        public string ID_Potrero { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(50)]
        public string ID_Fundo { get; set; }

        [StringLength(50)]
        public string Variedad { get; set; }

        [Key]
        [Column(Order = 5)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID_Mapeo { get; set; }

        public virtual Cuartel Cuartel { get; set; }

        public virtual Map Map { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Planta> Planta { get; set; }
    }
}
