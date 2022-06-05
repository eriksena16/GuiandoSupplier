using AutoMapper;
using GuiandoSupplier.Domain.Entities;
using GuiandoSupplier.Domain.Interfaces.Repositories;
using GuiandoSupplier.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuiandoSupplier.Service.Service
{
    public class SupplierService : BaseService<Supplier>, ISupplierService
    {
        private readonly ISupplierRepository _repository;
        private readonly IMapper _mapper;
        public SupplierService(ISupplierRepository repository, IMapper mapper) : base(repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<SupplierDTO> Add(SupplierDTO supplierDto)
        {
            Supplier supplier = _mapper.Map<Supplier>(supplierDto);

            await _repository.Add(supplier);

            return supplierDto;
        }
        public new async Task<List<SupplierDTO>> Get() => _mapper.Map<List<SupplierDTO>>(await _repository.Get());

        public async Task<SupplierDTO> Update(SupplierDTO supplierDTO)
        {
            Supplier supplier = _mapper.Map<Supplier>(supplierDTO);

            return _mapper.Map<SupplierDTO>(await UpdateSupplier(supplier));

        }
        private async Task<Supplier> UpdateSupplier(Supplier supplier)
        {
            if (_repository.Search(c => c.Nome == supplier.Nome && c.CNPJ == supplier.CNPJ && c.Id != supplier.Id).Result.Any()) throw new ArgumentException("já existe um fornecedor com este nome e CNPJ!");
            else
            {
                try
                {
                    await _repository.Update(supplier);
                }
                catch (Exception ex)
                {

                    throw new Exception(ex + "Aconteceu um erro!");
                }

                return supplier;
            }
        }

        public new async Task<SupplierDTO> Get(long id) => _mapper.Map<SupplierDTO>(await _repository.Get(id));

        //public new SupplierDTO GetAsnotrack(long id) => _mapper.Map<SupplierDTO>(repository.GetAsNoTrackingId(id));

        public void Dispose()
        {
            _repository?.Dispose();
        }
    }

}
