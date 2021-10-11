using DETRAN.Persistence.Data.Context;
using Microsoft.AspNetCore.Mvc;

namespace DETRAN.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CondutorController : Controller
    {
        private readonly DetranContext _context;
        public CondutorController(DetranContext context){
            _context = context;
        }
    }
}