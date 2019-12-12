using MediatR;
using PAccountant2.BLL.Interfaces.Account;
using System.Threading;
using System.Threading.Tasks;

namespace PAccountant2.BLL.Application.Accounting.Commands
{
    public class CreateAccountingCommand: IRequest<int>
    {
        public string UserEmail { get; set; }

        public class CreateAccountingCommandHandler : IRequestHandler<CreateAccountingCommand, int>
        {

            private readonly IAccountingDataService _accountingDataService;

            public CreateAccountingCommandHandler(IAccountingDataService accountingDataService)
            {
                _accountingDataService = accountingDataService;
            }


            public async Task<int> Handle(CreateAccountingCommand request, CancellationToken cancellationToken)
            {
                var accingId = await _accountingDataService.CreateAccountingForUser(request.UserEmail);

                return accingId;
            }
        }
    }
}
