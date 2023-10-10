namespace SOL.Domain.Models.BusinessEntities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("USER1.ENROLLMENTS")]
    public partial class ENROLLMENTS
    {
        [Key]
        public decimal ENROLLMENTID { get; set; }

        public decimal? STUDENTDNI { get; set; }

        public decimal? COURSEID { get; set; }

        public decimal? SECTIONID { get; set; }
        public bool? STATUS { get; set; }

        [StringLength(50)]
        public string ENROLLMENTTYPE { get; set; }

        public DateTime? ENROLLMENTDATE { get; set; }

        public DateTime? CANCELLATIONDATE { get; set; }

        public virtual COURSES COURSES { get; set; }

        public virtual STUDENTS STUDENTS { get; set; }

        public virtual SECTIONS SECTIONS { get; set; }
    }
}
