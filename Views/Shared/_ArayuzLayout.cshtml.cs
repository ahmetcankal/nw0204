using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace p0204.Views.Shared
{
    public class _ArayuzLayout : PageModel
    {
        private readonly ILogger<_ArayuzLayout> _logger;

        public _ArayuzLayout(ILogger<_ArayuzLayout> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}