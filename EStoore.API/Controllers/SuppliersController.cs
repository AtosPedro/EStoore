using AutoMapper;
using EStoore.Domain.DTOs.Supplier;
using EStoore.Domain.Entities;
using EStoore.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EStoore.API.Controllers
{
    [Route("supplier")]
    public class SuppliersController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ISupplierService _supplierService;
        public SuppliersController(IMapper mapper, ISupplierService supplierService)
        {
            _mapper = mapper;
            _supplierService = supplierService;
        }

        [HttpGet]
        public async Task<IEnumerable<ReadSupplierDto>> Get()
        {
            var suppliers = await _supplierService.GetAll();
            var readSuppliers = _mapper.Map<IEnumerable<ReadSupplierDto>>(suppliers);
            return readSuppliers;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOne(int id)
        {
            var supplier = await _supplierService.GetById(id);

            if (supplier == null)
                return NotFound();

            var readSupplier = _mapper.Map<ReadSupplierDto>(supplier);
            return Ok(readSupplier);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateSupplierDto supplierDto)
        {
            var supplier = _mapper.Map<Supplier>(supplierDto);
            
            var any = await _supplierService.Add(supplier);

            if (any == null)
                return BadRequest();

            return CreatedAtAction(nameof(Get), new { Id = any.Id }, supplierDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateSupplierDto supplierDto)
        {
            var supplier = _mapper.Map<Supplier>(supplierDto);
            supplier.Id = id;
            var any = await _supplierService.Update(supplier);

            if (any == null)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var supplier = await _supplierService.GetById(id);
            if (supplier == null)
                return NotFound();

            bool success = await _supplierService.Remove(supplier);

            if (!success)
                return BadRequest();

            return NoContent();
        }
    }
}
