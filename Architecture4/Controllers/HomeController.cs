using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Architecture4.Models;
using BusinessLogicLayer;

namespace Architecture4.Controllers
{
    public class HomeController : Controller
    {
        OrderManipulation orderManipulation;
        WorkManipulation workManipulation;

        public HomeController()
        {
            orderManipulation = new OrderManipulation();
            workManipulation = new WorkManipulation();
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Our Design Studio is ready to help you";
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Our contacts";

            return View();
        }
        public ActionResult OrderCreation()
        {
            return View();
        }

        [HttpPost]
        public async  Task<IActionResult> OrderCreate(OrderView order)
        {
            await orderManipulation.Add(order);
            return RedirectToAction("OrderView");
        }

        public ActionResult WorkCreation()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> WorkCreate(WorkView work)
        {
            await workManipulation.Add(work);
            return RedirectToAction("WorkView");
        }

        public async Task<IActionResult> OrderView()
        {
            ViewBag.Orders = await orderManipulation.GetAll();
            return View();
        }

        public async Task<IActionResult> WorkView()
        {
            ViewBag.Portfolio = await workManipulation.GetAll();
            return View();
        }

        public async Task<IActionResult> DeleteWork(int id)
        {
            await workManipulation.Delete(id);
            return RedirectToAction("WorkView");
        }
        public async Task<IActionResult> DeleteOrder(int id)
        {
            await orderManipulation.Delete(id);
            return RedirectToAction("OrderView");
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
