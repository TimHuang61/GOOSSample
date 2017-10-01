using GOOS_Sample.Models;
using System.Web.Mvc;
using GOOS_Sample.Models.ViewModels;

namespace GOOS_Sample.Controllers
{
    public class BudgetController : Controller
    {
        private IBudgetService _budgetService;

        public BudgetController(IBudgetService budgetService)
        {
            _budgetService = budgetService;
        }

        public ActionResult Add()
        {
            return View();
        }

        // 增加service and controller 的彈性
        // controller透過event來決定顯示的訊息是甚麼
        // 而service則自行判斷來決定觸發甚麼事件
        [HttpPost]
        public ActionResult Add(BudgetAddViewModel model)
        {
            this._budgetService.Created += (sender, e) => ViewBag.Message = "added successfully";
            this._budgetService.Updated += (sender, e) => ViewBag.Message = "updated successfully";
            this._budgetService.Create(model);
            //ViewBag.Message = "added successfully";

            return View(model);
        }


    }
}