using System.Threading.Tasks;
using PAccountant2.BLL.Interfaces.Authentification;
using PAccountant2.BLL.Interfaces.DTO.DataItems.Authentification;

namespace PAccountant2.BLL.Domain.Entities.Accounting
{
    public class ContragentEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public async Task<int> GetOrCreateContragentIdByName(IContragentDataService contragentService, string contragentName, int acctingId)
        {
            int contragentId;

            if (await contragentService.IsContragentExists(contragentName))
            {
                var data = await contragentService.Get(contragentName);
                contragentId = data.Id;
            }
            else
            {
                var dbData = new ContragentDataItem()
                {
                    AccountingId = acctingId,
                    Name = contragentName
                };

                contragentId = await contragentService.CreateContragent(dbData);
            }

            return contragentId;
        }
    }
}
