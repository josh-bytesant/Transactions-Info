using Transactions.Info.Core.Entities.Common;

namespace Transactions.Info.Web.Models
{
    //public record AccountInfoDTO(string Id, string AccountNumber, IndustryDTO Industry);
    //public record IndustryDTO(string Name, List<IndustryFieldDTO> IndustryFields);
    //public record IndustryFieldDTO(int Id, string Field);


    public class AccountInfoDTO
    {
        public int Id { get; set; }
        public string AccountNumber { get; set; }
        public int IndustryId { get; set; }
        public Industry Industry { get; set; }
    }

    public class IndustryDTO
    {
        public string Name { get; set; }
        public IndustryFieldDTO[] IndustryFields { get; set; } = Array.Empty<IndustryFieldDTO>();
    }

    public class IndustryFieldDTO
    {
        public int Id { get; set; }
        public string Field { get; set; }
    }

}
