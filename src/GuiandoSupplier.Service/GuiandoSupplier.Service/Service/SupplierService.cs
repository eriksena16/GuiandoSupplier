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

        public async Task<SupplierDTO> Add(SupplierDTO supplierDTO)
        {
            Supplier supplier = _mapper.Map<Supplier>(supplierDTO);

            if (!Verification(supplier))
            {
                await _repository.Add(supplier);
                return supplierDTO;
            }
            else
                throw new ArgumentException("já existe um fornecedor com este nome");

        }
        public new async Task<List<SupplierDTO>> Get() => _mapper.Map<List<SupplierDTO>>(await _repository.Get());

        public async Task<SupplierDTO> Update(SupplierDTO supplierDTO)
        {
            Supplier supplier = _mapper.Map<Supplier>(supplierDTO);

            if (!Verification(supplier))
            {
                await _repository.Update(supplier);
                return supplierDTO;
            }
            else
                throw new ArgumentException("já existe um fornecedor com este nome!");

        }

        private bool Verification(Supplier supplier) =>
            _repository.Search(c => c.Name == supplier.Name && c.Id != supplier.Id).Result.Any();

        public new async Task<SupplierDTO> Get(long id) => 
            _mapper.Map<SupplierDTO>(await _repository.Get(id));

        public void Dispose()
        {
            _repository?.Dispose();
        }
    }

}
