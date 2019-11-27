using PAccountant2.Common.Clone;
using System.Collections.Generic;
using System.Linq;

namespace PAccountant2.BLL.Domain.Entities.Account.Handlers
{
    public class OperationHandler
    {
        public IEnumerable<AccountOperationValueObject> AddNewOperation
            (AccountOperationValueObject newOperation, IEnumerable<AccountOperationValueObject> currentOperations)
        {
            var clonedOperations = CloneHelper.CloneArray(currentOperations ?? new List<AccountOperationValueObject>()).ToList();

            clonedOperations.Add(newOperation);

            return clonedOperations;
        }
    }
}
