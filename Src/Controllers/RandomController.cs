using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApi_Test.Src.Interfaces;
using WebApi_Test.Src.Services;

namespace WebApi_Test.Src.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RandomController : ControllerBase
    {
        private IScopedPickRandomNumber _pickScopedRnd;
        private ISingltonPickRandomNumber _pickSingltonRandomNumber;
        private ITransiantPickRandomNumber _pickTransientRandomNumber;

        public RandomController(IScopedPickRandomNumber pickScopedRandomNumber, ISingltonPickRandomNumber pickSingltonPickRandomNumber, ITransiantPickRandomNumber pickTransientRandomNumber)
        {
            _pickScopedRnd = pickScopedRandomNumber;
            _pickSingltonRandomNumber = pickSingltonPickRandomNumber;
            _pickTransientRandomNumber = pickTransientRandomNumber;
        }

        
        [HttpGet("/GetRandomNumber")]
        public IActionResult Get()
        {
            var Scopedrnd1 = _pickScopedRnd.rnd;
            var Scopedrnd2 = _pickScopedRnd.rnd2;
            var TransientRnd1 = _pickTransientRandomNumber.rnd2;
            var TransientRnd2 = _pickTransientRandomNumber.rnd2;
            var SingltonRnd1 = _pickSingltonRandomNumber.rnd2;
            var SingltonRnd2 = _pickSingltonRandomNumber.rnd2;
            return Ok(
            new 
                {
                    Scopedrnd1,
                    Scopedrnd2,
                    TransientRnd1,
                    TransientRnd2,
                    SingltonRnd1,
                    SingltonRnd2
                }
            );
        }
    }
}