using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ErisCakesWebApi.Data;
using ErisCakesWebApi.Models;
using ErisCakesWebApi.Dto;
using AutoMapper;
using NuGet.Versioning;
using ErisCakesWebApi.Interfaces;
using ErisCakesWebApi.Repository;

namespace ErisCakesWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BakeryRequestsController : ControllerBase
    {
        private readonly IBakeryRequestRepository _bakeryRequestRepository;
        private readonly IMapper _mapper;

        public BakeryRequestsController(IBakeryRequestRepository bakeryRequestRepository, IMapper mapper)
        {
            _bakeryRequestRepository = bakeryRequestRepository;
            _mapper = mapper;
        }

        // GET: api/BakeryRequests
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BakeryRequest>>> GetBakeryRequests()
        {
            return Ok(_mapper.Map<List<BakeryRequestDTO>>(_bakeryRequestRepository.GetBakeryRequests()));
        }
        // GET: api/BakeryRequests/status
        [HttpGet("getByStatus/{status}")]
        public async Task<ActionResult<IEnumerable<BakeryRequest>>> GetBakeryRequestsByStatus(String status)
        {
            return Ok(_mapper.Map<List<BakeryRequestDTO>>(_bakeryRequestRepository.GetBakeryRequestByStatus(status)));
        }

        // GET: api/BakeryRequests/5
        [HttpGet("getById/{id}")]
        public async Task<ActionResult<BakeryRequest>> GetBakeryRequest(int id)
        {
            var bakeryRequest = _bakeryRequestRepository.GetBakeryRequest(id);

            if (bakeryRequest == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<BakeryRequestDTO>(bakeryRequest));
        }

        // PUT: api/BakeryRequests/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBakeryRequest(int id, BakeryRequest bakeryRequest)
        {
            if (id != bakeryRequest.Id)
            {
                return BadRequest();
            }
            return Ok(_bakeryRequestRepository.EditBakeryRequest(bakeryRequest));
        }

        // POST: api/BakeryRequests
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BakeryRequest>> PostBakeryRequest(BakeryRequest bakeryRequest)
        {
            if(bakeryRequest.RecipeStatus != "Pendiente" && bakeryRequest.RecipeStatus != "Terminado" && bakeryRequest.RecipeStatus != "Demorado" && bakeryRequest.RecipeStatus != "Ingresado")
            {
                throw new ArgumentException("El estado del pedido solo se permiten valores como: 'Pendiente', 'Terminado', 'Ingresado' y 'Demorado'");
            }
            if (bakeryRequest.BillingStatus != "Aprobado" && bakeryRequest.BillingStatus != "Rechazado" && bakeryRequest.BillingStatus != "Pendiente")
            {
                throw new ArgumentException("El estado del presupuesto solo se permiten valores como: 'Aprobado', 'Rechazado' y 'Pendiente'");
            }
            if (bakeryRequest.BudgetPice < 0)
            {
                throw new ArgumentException("El precio del presupuesto tiene que se mayor a 0");
            }
            if (bakeryRequest.ShippingPrice < 0)
            {
                throw new ArgumentException("El precio del viaje tiene que se mayor a 0");
            }
            if (bakeryRequest.JobScore < 0 || bakeryRequest.JobScore > 1000)
            {
                throw new ArgumentException("La satisfaccion del cliente tiene que estar entre 0 y 1000");
            }
            _bakeryRequestRepository.CreateBakeryRequest(bakeryRequest);

            return CreatedAtAction("PostBakeryRequest", new { id = bakeryRequest.Id }, bakeryRequest);
        }

        // DELETE: api/BakeryRequests/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBakeryRequest(int id)
        {
            _bakeryRequestRepository.DeleteBakeryRequest(id);
            return Ok();
        }
    }
}
