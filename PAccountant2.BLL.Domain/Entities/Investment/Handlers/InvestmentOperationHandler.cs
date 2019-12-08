using PAccountant2.Common.Clone;
using System.Collections.Generic;
using System.Linq;

namespace PAccountant2.BLL.Domain.Entities.Investment.Handlers
{
    class InvestmentOperationHandler
    {
        public IEnumerable<InvestmentOperationValueObject> AddNewOperation
            (InvestmentOperationValueObject newOperation, IEnumerable<InvestmentOperationValueObject> currentOperations)
        {
            var clonedOperations = CloneHelper.CloneArray(currentOperations ?? new List<InvestmentOperationValueObject>()).ToList();

            clonedOperations.Add(newOperation);

            return clonedOperations;
        }
    }
}
