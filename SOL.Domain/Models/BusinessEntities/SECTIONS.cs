namespace SOL.Domain.Models.BusinessEntities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("USER1.SECTIONS")]
    public partial class SECTIONS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SECTIONS()
        {
            COURSESECTIONVACANCIES = new HashSet<COURSESECTIONVACANCIES>();
            ENROLLMENTS = new HashSet<ENROLLMENTS>();
        }

        [Key]
        public decimal SECTIONID { get; set; }

        [Required]
        [StringLength(50)]
        public string SECTIONNAME { get; set; }

        public bool? STATUS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<COURSESECTIONVACANCIES> COURSESECTIONVACANCIES { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ENROLLMENTS> ENROLLMENTS { get; set; }
    }
}
