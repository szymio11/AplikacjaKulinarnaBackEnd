using System;
using Microsoft.AspNetCore.Mvc;

namespace AplikacjaKulinarna.API.Controllers
{
    public class ApiControllerBase : Controller
    {
      protected Guid UserId => User?.Identity?.IsAuthenticated==true ?
          Guid.Parse(User.Identity.Name) :
                      Guid.Empty;
    }
}