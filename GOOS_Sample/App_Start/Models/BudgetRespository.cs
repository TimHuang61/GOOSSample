using System;
using System.Linq;
using GOOS_Sample.Models;
using GOOS_Sample.Models.DataModels;

namespace GOOS_Sample.App_Start.Models
{
    public class BudgetRespository : IRespository<Budget>
    {
        public Budget Read(Func<Budget, bool> precidate)
        {
            using (var dbContext = new BudgetEntites())
            {
                return dbContext.Budgets.FirstOrDefault(precidate);
            }
        }

        public void Save(Budget entity)
        {
            //using (var dbContext = new BudgetEntites())
            //{
            //    dbContext.Budgets.Add(entity);
            //    dbContext.SaveChanges();
            //}
            using (var dbcontext = new BudgetEntites())
            {
                var budgetFromDb = dbcontext.Budgets.FirstOrDefault(x => x.YearMonth == entity.YearMonth);
                if (budgetFromDb == null)
                {
                    dbcontext.Budgets.Add(entity);
                }
                else
                {
                    budgetFromDb.Amount = entity.Amount;
                }

                dbcontext.SaveChanges();
            }
        }
    }
}