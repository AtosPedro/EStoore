using EStoore.Domain.Entities;
using EStoore.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStoore.Domain.Services
{
    public class SupplierService : ISupplierService
    {
        private readonly ISupplierRepository _supplierRepository;
        public SupplierService(ISupplierRepository supplierRepository)
        {
            _supplierRepository = supplierRepository;
        }

        public async Task<IEnumerable<Supplier>> GetAll()
        {
            return await _supplierRepository.GetAll();
        }

        public async Task<Supplier> GetById(int id)
        {
            return await _supplierRepository.GetById(id);
        }

        public async Task<Supplier> Add(Supplier supplier)
        {
            bool any = _supplierRepository.Search(m => m.Name == supplier.Name).Result.Any();
            if (any)
                return null;

            supplier.CreatedAt = DateTime.Now;
            supplier.CreatedBy = "Eu";

            await _supplierRepository.Add(supplier);
            return supplier;
        }

        public async Task<Supplier> Update(Supplier supplier)
        {
            bool any = _supplierRepository.Search(m => m.Id == supplier.Id).Result.Any();
            if (!any)
                return null;

            supplier.UpdatedAt = DateTime.Now;
            supplier.UpdatedBy = "Eu";

            await _supplierRepository.Update(supplier);
            return supplier;
        }

        public async Task<bool> Remove(Supplier supplier)
        {
            bool any = _supplierRepository.Search(m => m.Id == supplier.Id).Result.Any();
            if (!any)
                return false;

            await _supplierRepository.Remove(supplier);
            return true;
        }

        public async Task<IEnumerable<Supplier>> Search(string supplierName)
        {
            return await _supplierRepository.Search(m => m.Name == supplierName);
        }

        public void Dispose()
        {
            _supplierRepository?.Dispose();
        }
    }
}
