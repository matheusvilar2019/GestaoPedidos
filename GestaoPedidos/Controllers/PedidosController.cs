using AutoMapper;
using GestaoPedidos.Data;
using GestaoPedidos.DTOs;
using GestaoPedidos.Models.Entities;
using GestaoPedidos.Models.Enums;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Net.NetworkInformation;

namespace GestaoPedidos.Controllers
{
    [ApiController]
    [Route("v1/Pedidos")]
    public class PedidosController : ControllerBase
    {
        private readonly ILogger<PedidosController> _logger;
        private readonly IMapper _mapper;

        public PedidosController(ILogger<PedidosController> logger,  IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet("{pedidoId:Guid}")]
        public async Task<IActionResult> GetPedidoById([FromRoute] Guid pedidoId, [FromServices] GestaoPedidosDbContext context)
        {
            var pedido = context.Pedidos
                    .Include(x => x.Items)
                    .FirstOrDefault(x => x.Id == pedidoId);

            if (pedido == null) return NotFound();

            var response = _mapper.Map<PedidoResponseDTO>(pedido);

            return Ok(response);
        }

        [HttpGet("{pedidoStatus}")]
        public async Task<IActionResult> GetPedidosByStatus([FromRoute] PedidoStatus pedidoStatus, [FromServices] GestaoPedidosDbContext context)
        {
            var pedidos = await context.Pedidos
                    .Where(x => x.Status == pedidoStatus)
                    .Include(x => x.Items)
                    .ToListAsync();

            if (pedidos == null) return NotFound();

            var response = _mapper.Map<List<PedidoResponseDTO>>(pedidos);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> PostPedido([FromBody] PedidoCreateDTO model, [FromServices] GestaoPedidosDbContext context)
        {
            var pedido = _mapper.Map<Pedido>(model);

            pedido.Status = PedidoStatus.Novo;
            pedido.DataCriacao = DateTime.Now;

            pedido.ValorTotal = pedido.Items.Sum(i => i.Quantidade * i.PrecoUnitario);

            _logger.LogInformation("Criando pedido para o cliente {ClienteNome}", model.ClienteNome);

            context.Pedidos.Add(pedido);
            await context.SaveChangesAsync();

            var response = _mapper.Map<PedidoResponseDTO>(pedido);

            return CreatedAtAction(nameof(GetPedidoById), new { pedidoId = pedido.Id }, response);
        }

        [HttpPatch("{pedidoId:Guid}/cancelar")]
        public async Task<IActionResult> PatchPedidoById([FromRoute] Guid pedidoId, [FromServices] GestaoPedidosDbContext context)
        {
            try
            {
                var pedido = context.Pedidos.FirstOrDefault(x => x.Id == pedidoId);

                if (pedido == null)
                {
                    return NotFound();
                }

                pedido.Cancelar();

                pedido.Status = PedidoStatus.Cancelado; 
                context.Pedidos.Update(pedido);
                await context.SaveChangesAsync();
                
                return Ok($"Pedido cancelado. PedidoId: {pedidoId}.");
            }
            catch (InvalidOperationException ex)
            {
                _logger.LogWarning("Tentativa de cancelar pedido pago. PedidoId: {PedidoId}", pedidoId);
                return BadRequest(ex.Message);
            }
        }
    }
}