using CompanySoftwareStore.Managers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CompanySoftwareStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SoftwareController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Software> Get()
        {
            var softwareList = SoftwareManager.GetAllSoftware();

            return softwareList;
        }
    }
}