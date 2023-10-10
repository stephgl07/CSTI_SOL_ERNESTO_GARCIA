namespace SOL.Domain.Models.BusinessEntities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("USER1.COURSESECTIONVACANCIES")]
    public partial class COURSESECTIONVACANCIES
    {
        [Key]
        [Column(Order = 0)]
        public decimal COURSEID { get; set; }

        [Key]
        [Column(Order = 1)]
        public decimal SECTIONID { get; set; }

        public decimal? VACANCIES { get; set; }

        public virtual COURSES COURSES { get; set; }

        public virtual SECTIONS SECTIONS { get; set; }
    }
}
