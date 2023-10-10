namespace SOL.Domain.Models.BusinessEntities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("USER1.STUDENTS")]
    public partial class STUDENTS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public STUDENTS()
        {
            ENROLLMENTS = new HashSet<ENROLLMENTS>();
        }

        [Key]
        public decimal DNI { get; set; }

        [Required]
        [StringLength(50)]
        public string STUDENTCODE { get; set; }

        [Required]
        [StringLength(100)]
        public string FIRSTNAMES { get; set; }

        [Required]
        [StringLength(100)]
        public string LASTNAMES { get; set; }

        public bool? STATUS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ENROLLMENTS> ENROLLMENTS { get; set; }
    }
}
