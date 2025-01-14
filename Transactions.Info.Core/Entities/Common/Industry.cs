using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Transactions.Info.Core.Entities.Common
{
    public class Industry
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }
        [JsonIgnore]
        public ICollection<CustomerAccountInfo> CustomerAccounts { get; set; } = new List<CustomerAccountInfo>();
        public ICollection<IndustryField> IndustryFields { get; set; } = new List<IndustryField>();
    }
}
