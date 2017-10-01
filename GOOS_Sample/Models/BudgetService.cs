using System;
using GOOS_Sample.Models.DataModels;
using GOOS_Sample.Models.ViewModels;

namespace GOOS_Sample.Models
{
    public class BudgetService : IBudgetService
    {
        private IRespository<Budget> _budgetRespository;

        public BudgetService(IRespository<Budget> budgetRespository)
        {
            _budgetRespository = budgetRespository;
        }

        public event EventHandler Created;

        public event EventHandler Updated;

        public void Create(BudgetAddViewModel model)
        {
            var budget = _budgetRespository.Read(x => x.YearMonth == model.Month);
            if (budget == null)
            {
                this._budgetRespository.Save(new Budget { Amount = model.Amount, YearMonth = model.Month });
                var handler = this.Created;
                handler?.Invoke(this, EventArgs.Empty);
            }
            else
            {
                budget.Amount = model.Amount;
                this._budgetRespository.Save(budget);
                var handler = this.Updated;
                handler?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}