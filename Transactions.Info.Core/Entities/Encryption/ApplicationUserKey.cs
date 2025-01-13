using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transactions.Info.Core.Entities.Encryption
{
    public class ApplicationUserKey
    {
        [Key]
        public string UserName { get; set; }
        public string Key { get; set; }
    }
}
