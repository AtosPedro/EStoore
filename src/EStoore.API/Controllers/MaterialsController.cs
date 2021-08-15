using AutoMapper;
using EStoore.Domain.DTOs.Material;
using EStoore.Domain.Entities;
using EStoore.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EStoore.API.Controllers
{
    [Route("material")]
    public class MaterialsController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IMaterialService _materialService; 
        private readonly ISupplierService _supplierService; 
        public MaterialsController(IMapper mapper, IMaterialService materialService, ISupplierService supplierServices)
        {
            _mapper = mapper;
            _materialService = materialService;
            _supplierService = supplierServices;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var materials = await _materialService.GetAll();
            var readMaterials = _mapper.Map<IEnumerable<ReadMaterialDto>>(materials);
            
            return Ok(readMaterials);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOne(int id)
        {
            var material = await _materialService.GetById(id);

            if (material == null)
                return NotFound();

            var readMaterial = _mapper.Map<ReadMaterialDto>(material);
            return Ok(readMaterial);
        }

        [HttpGet("get-material-by-name/{query}")]
        public async Task<IActionResult> GetByName(string query)
        {
            var material = await _materialService.SerachMaterialsWithSupplier(query);

            if (material == null)
                return NotFound();

            var readMaterial = _mapper.Map<ReadMaterialDto>(material.FirstOrDefault());
            return Ok(readMaterial);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateMaterialDto materialDto)
        {
            var material = _mapper.Map<Material>(materialDto);

            var any = await _materialService.Add(material);

            if (any == null)
                return BadRequest();

            return CreatedAtAction(nameof(Get), new { Id = any.Id}, materialDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id,[FromBody] UpdateMaterialDto materialDto)
        {
            var material = _mapper.Map<Material>(materialDto);
            material.Id = id;
            var any = await _materialService.Update(material);

            if (any == null)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var material = await _materialService.GetById(id);            
            if (material == null)
                return NotFound();

            bool success = await _materialService.Remove(material);

            if (!success)
                return BadRequest();

            return NoContent();
        }
    }
}
