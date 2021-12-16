namespace WebAPI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Person")]
    public partial class Person
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string Firstname { get; set; }

        [StringLength(50)]
        public string Lastname { get; set; }

        [StringLength(50)]
        public string IDnumber { get; set; }

        [StringLength(50)]
        public string Adress { get; set; }

        [StringLength(50)]
        public string Phonenumber { get; set; }

        [StringLength(50)]
        public string Email { get; set; }
    }
}
