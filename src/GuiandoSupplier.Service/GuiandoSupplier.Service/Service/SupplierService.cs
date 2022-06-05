using AutoMapper;
using GuiandoSupplier.Domain.Entities;
using GuiandoSupplier.Domain.Interfaces.Repositories;
using GuiandoSupplier.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
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

        public Task<SupplierDTO> Add(SupplierDTO obj)
        {
            throw new NotImplementedException();
        }

        public Task<SupplierDTO> Update(SupplierDTO obj)
        {
            throw new NotImplementedException();
        }

        Task<List<SupplierDTO>> IBaseService<SupplierDTO>.Get()
        {
            throw new NotImplementedException();
        }

        Task<SupplierDTO> IBaseService<SupplierDTO>.Get(long id)
        {
            throw new NotImplementedException();
        }

        SupplierDTO IBaseService<SupplierDTO>.GetAsnotrack(long id)
        {
            throw new NotImplementedException();
        }
    }

}
