using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace ShopCar.Views
{
    public class ViewStart : PageModel
    {
        private readonly ILogger<ViewStart> _logger;

        public ViewStart(ILogger<ViewStart> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}