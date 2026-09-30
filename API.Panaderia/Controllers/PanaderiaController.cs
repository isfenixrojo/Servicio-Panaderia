using API.Panaderia.Core.Interfaces;
using API.Panaderia.Dominio.DTOs;
using API.Panaderia.Dominio.Modelos;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Panaderia.Controllers
{
    [Route("api/pan")]
    [ApiController]
    public class PanaderiaController : ControllerBase
    {
        private readonly IPanRepository _repository;
        private readonly IMapper _mapper;

        public PanaderiaController(IPanRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetPanes()
        {
            var pan = await _repository.GetPanAsync();
            var panDTO = _mapper.Map<IEnumerable<ViewPanDTO>>(pan);
            return Ok(panDTO);
        }

        [HttpGet("{idPan:int}", Name = nameof(GetPanById))]
        public async Task<IActionResult> GetPanById(int idPan)
        {
            var pan = await _repository.GetPanByIdAsync(idPan);
            if (pan == null)
            {
                return NotFound(new { mensaje = $"La transaccion con el id {idPan} no existe" });
            }
            var panDTO = _mapper.Map<ViewPanDTO>(pan);
            return Ok(panDTO);
        }

        [HttpPost]
        public async Task<IActionResult> PostTransaccion(CreatePanDTO createPanDTO)
        {
            if (createPanDTO == null)
            {
                return BadRequest(ModelState);
            }

            var pan = _mapper.Map<Pan>(createPanDTO);

            await _repository.PostPanAsync(pan);

            var panDTO = _mapper.Map<ViewPanDTO>(pan);
            return CreatedAtRoute(nameof(GetPanById), new { idPan = pan.IdPan }, panDTO);
        }

        [HttpPut]
        public async Task<ActionResult> UpdatePanAsync(int idPan, UpdatePanDTO updatePanDTO)
        {
            if (updatePanDTO == null)
            {
                return BadRequest(ModelState);
            }
            
            var panDTO = _mapper.Map<Pan>(updatePanDTO);
            return Ok(panDTO);
        }
    }
}
