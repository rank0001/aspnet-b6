using Autofac;
using Microsoft.AspNetCore.Mvc;
using TicketSystem.Layer.Exceptions;
using TicketSystem.Web.Areas.Admin.Models;
using TicketSystem.Web.Models;

namespace TicketSystem.Web.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class TicketPurchaseController : Controller
    {

        private readonly ILifetimeScope _scope;
        private readonly ILogger<TicketPurchaseController> _logger;

        public TicketPurchaseController(ILogger<TicketPurchaseController> logger,
                                        ILifetimeScope scope)
        {
            _scope = scope;
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            var model = _scope.Resolve<TicketPurchaseCreateModel>();
            return View(model);
        }

        public JsonResult GetTickets()
        {
            var dataTableModel = new DataTablesAjaxRequestModel(Request);
            var model = _scope.Resolve<TicketPurchaseListModel>();
            return Json(model.GetPagedCourses(dataTableModel));
        }

        [ValidateAntiForgeryToken, HttpPost]
        public IActionResult Create(TicketPurchaseCreateModel model)
        {
            if (ModelState.IsValid)
            {
                model.Resolve(_scope);

                try
                {
                    model.CreateCourse();

                    TempData["ResponseMessage"] = "Successfuly added a new course.";
                    TempData["ResponseType"] = ResponseTypes.Success;

                    return RedirectToAction("Index");
                }
                catch (DuplicateException ioe)
                {
                    _logger.LogError(ioe, ioe.Message);

                    TempData["ResponseMessage"] = ioe.Message;
                    TempData["ResponseType"] = ResponseTypes.Danger;
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, ex.Message);
                    TempData["ResponseMessage"] = "There was a problem in" +
                        " creating course.";
                    TempData["ResponseType"] = ResponseTypes.Danger;
                }
            }

            return View(model);
        }
        public IActionResult Edit(int id)
        {
            var model = _scope.Resolve<TicketPurchaseEditModel>();
            model.LoadData(id);

            return View(model);
        }

        [ValidateAntiForgeryToken, HttpPost]
        public IActionResult Edit(TicketPurchaseEditModel model)
        {
            if (ModelState.IsValid)
            {
                model.Resolve(_scope);

                try
                {
                    model.EditTicket();

                    TempData["ResponseMessage"] = "Successfuly updated course.";
                    TempData["ResponseType"] = ResponseTypes.Success;

                    return RedirectToAction("Index");
                }
                catch (DuplicateException ioe)
                {
                    _logger.LogError(ioe, ioe.Message);

                    TempData["ResponseMessage"] = ioe.Message;
                    TempData["ResponseType"] = ResponseTypes.Danger;
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, ex.Message);
                    TempData["ResponseMessage"] = "There was a problem in updating course.";
                    TempData["ResponseType"] = ResponseTypes.Danger;
                }
            }

            return View(model);
        }

        [ValidateAntiForgeryToken, HttpPost]
        public IActionResult Delete(int id)
        {
            try
            {
                var model = _scope.Resolve<TicketPurchaseListModel>();
                model.DeleteCourse(id);

                TempData["ResponseMessage"] = "Successfuly deleted course.";
                TempData["ResponseType"] = ResponseTypes.Success;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                TempData["ResponseMessage"] = "There was a problem in deleteing course.";
                TempData["ResponseType"] = ResponseTypes.Danger;
            }

            return RedirectToAction("Index");
        }

    }
}
