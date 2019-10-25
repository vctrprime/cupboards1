using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Lasmart.Data.Business.UnitOfWorks.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lasmart.Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public HomeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Cupboards_Read([DataSourceRequest]DataSourceRequest request)
        {
            return Json(_unitOfWork.Cupboards().GetAll().ToDataSourceResult(request));
        }
    }

    
}