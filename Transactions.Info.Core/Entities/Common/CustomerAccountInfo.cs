using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transactions.Info.Core.Entities.Common
{
    public class CustomerAccountInfo
    {
        public int Id { get; set; }
        public string AccountNumber { get; set; }
        public string Industry { get; set; }
        [Column("Field 1")]
        public string Field1 { get; set; }
        [Column("Field 2")]
        public string Field2 { get; set; }
        [Column("Field 3")]
        public string Field3 { get; set; }
    }
}
