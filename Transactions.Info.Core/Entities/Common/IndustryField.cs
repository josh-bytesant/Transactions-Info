﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transactions.Info.Core.Entities.Common
{
    public class IndustryField
    {
        public int Id { get; set; }
        [Required]
        public int IndustryId { get; set; }
        [Required]
        [MaxLength(255)]
        public string Field { get; set; }
    }
}
