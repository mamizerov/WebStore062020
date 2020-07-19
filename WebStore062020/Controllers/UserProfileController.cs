﻿using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebStore062020.Infrastructure.Interfaces;
using WebStore062020.ViewModels;

namespace WebStore062020.Controllers
{
    [Authorize]
    public class UserProfileController : Controller
    {
        public IActionResult Index() => View();

        public async Task<IActionResult> Orders([FromServices] IOrderService OrderService)
        {
            var orders = await OrderService.GetUserOrders(User.Identity.Name);

            return View(orders.Select(order => new UserOrderViewModel
            {
                Id = order.Id,
                Name = order.Name,
                Phone = order.Phone,
                Address = order.Address,
                TotalSum = order.Items.Sum(item => item.Price * item.Quantity)
            }));
        }
    }
}
