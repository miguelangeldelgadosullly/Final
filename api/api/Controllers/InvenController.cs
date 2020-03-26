using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using model;
using service;

namespace api.Controllers
{
    [Route("[controller]")]
    public class InvenController : Controller
    {
        private readonly InvenService _InvenService;

        public InvenController(InvenService InventarioService)
        {
            _InvenService = InventarioService;
        }

        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(
                _InvenService.GetAll()
            );
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(
                _InvenService.Get(id)
            );
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] Inventario model)
        {
            return Ok(
                _InvenService.Add(model)
            );
        }

        // PUT api/values/5
        [HttpPut]
        public IActionResult Put([FromBody] Inventario model)
        {
            return Ok(
                _InvenService.Add(model)
            );
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(
                _InvenService.Delete(id)
            );
        }
    }
}