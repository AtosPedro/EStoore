using EStoore.Domain.Entities;
using EStoore.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStoore.Domain.Services
{
    public class MaterialService : IMaterialService
    {
        private readonly IMaterialRepository _materialRepository;
        public MaterialService(IMaterialRepository materialRepository)
        {
            _materialRepository = materialRepository;
        }

        public async Task<IEnumerable<Material>> GetAll()
        {
            return await _materialRepository.GetAll();
        }

        public async Task<Material> GetById(int id)
        {
            return await _materialRepository.GetById(id);
        }

        public async Task<Material> Add(Material material)
        {
            bool any = _materialRepository.Search(m => m.Name == material.Name).Result.Any();
            if (any)
                return null;

            material.CreatedAt = DateTime.Now;
            material.CreatedBy = "Eu";


            await _materialRepository.Add(material);
            return material;
        }

        public async Task<Material> Update(Material material)
        {
            bool any = _materialRepository.Search(m => m.Id == material.Id).Result.Any();
            if (!any)
                return null;

            material.UpdatedAt = DateTime.Now;
            material.UpdatedBy = "Eu";

            await _materialRepository.Update(material);
            return material;
        }

        public async Task<bool> Remove(Material material)
        {
            bool any = _materialRepository.Search(m => m.Id == material.Id).Result.Any();
            if (!any)
                return false;

            await _materialRepository.Remove(material);
            return true;
        }

        public async Task<IEnumerable<Material>> Search(string materialName)
        {
            return await _materialRepository.Search(m => m.Name == materialName);           
        }

        public async Task<IEnumerable<Material>> GetMaterialsBySupplier(int supplierId)
        {
            return await _materialRepository.GetMaterialsBySupplier(supplierId);
        }

        public async Task<IEnumerable<Material>> SerachMaterialsWithSupplier(string query)
        {
            return await _materialRepository.SerachMaterialsWithSupplier(query);
        }

        public void Dispose()
        {
            _materialRepository?.Dispose();
        }

    }
}
