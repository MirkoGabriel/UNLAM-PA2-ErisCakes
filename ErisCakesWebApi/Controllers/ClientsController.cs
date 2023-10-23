using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ErisCakesWebApi.Data;
using ErisCakesWebApi.Models;
using AutoMapper;
using ErisCakesWebApi.Dto;
using System.Collections.Generic;
using ErisCakesWebApi.Interfaces;
using ErisCakesWebApi.Repository;

namespace ErisCakesWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IClientsRepository _clientsRepository;
        private readonly IMapper _mapper;

        public ClientsController(IClientsRepository clientsRepository, IMapper mapper)
        {
            _clientsRepository = clientsRepository;
            _mapper = mapper;
        }

        // GET: api/Clients1
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Client>>> GetClients()
        {
            return Ok(_mapper.Map<List<ClientDTO>>(_clientsRepository.GetClients()));
        }

        // GET: api/Clients1/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Client>> GetClient(int id)
        {
            var client = _mapper.Map<ClientDTO>(_clientsRepository.GetClient(id));

            if (client == null)
            {
                return NotFound();
            }

            return Ok(client);
        }

        // PUT: api/Clients1/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClient(int id, Client client)
        {
            return Ok(_clientsRepository.EditClient(client));
        }

        // POST: api/Clients1
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Client>> PostClient(Client client)
        {
            _clientsRepository.CreateClient(client);

            return CreatedAtAction("PostClient", new { id = client.Id }, client);
        }

        // DELETE: api/Clients1/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClient(int id)
        {
            _clientsRepository.DeleteClient(id);
            return Ok();
        }

    }
}
