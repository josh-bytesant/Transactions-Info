﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transactions.Info.Core.Entities.Common
{
    public class CustomerAccountInfo
    {
        public int Id { get; set; }
        [MaxLength(20)]
        [Column("Account Number")]
        [Required]
        public string AccountNumber { get; set; }
        [Required]
        public int IndustryId { get; set; }
        public Industry Industry { get; set; }
    }
}
