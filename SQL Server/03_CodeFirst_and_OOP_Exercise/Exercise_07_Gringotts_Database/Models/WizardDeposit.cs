namespace Exercise_07_Gringotts_Database.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class WizardDeposit
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        public string FirstName  { get; set; }

        [StringLength(60)]
        public string LastName { get; set; }

        [Column(TypeName = "text")]
        public string Notes { get; set; }

        public int Age { get; set; }

        [StringLength(100)]
        public string MagicWandCreator { get; set; }

        public int MagicWandSize { get; set; }

        [StringLength(20)]
        public string DepositGroup { get; set; }

        [Column(TypeName = "date")]
        public DateTime DepositStartDate { get; set; }

        public decimal DepositAmount { get; set; }
        public decimal DepositInterest { get; set; }
        public decimal DepositCharge { get; set; }

        [Column(TypeName = "date")]
        public DateTime DepositExpirationDate { get; set; }

        //[Column(TypeName = "bit")]
        public bool IsDepositExpired { get; set; }
    }
}
