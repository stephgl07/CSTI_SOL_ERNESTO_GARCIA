namespace SOL.Domain.Models.BusinessEntities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("USER1.COURSES")]
    public partial class COURSES
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public COURSES()
        {
            COURSESECTIONVACANCIES = new HashSet<COURSESECTIONVACANCIES>();
            ENROLLMENTS = new HashSet<ENROLLMENTS>();
        }

        [Key]
        public decimal COURSEID { get; set; }

        [Required]
        [StringLength(200)]
        public string COURSEDESCRIPTION { get; set; }

        public decimal? CREDITHOURS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<COURSESECTIONVACANCIES> COURSESECTIONVACANCIES { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ENROLLMENTS> ENROLLMENTS { get; set; }
    }
}
