using Application.Generics.Interface;
using AutoMapper;
using Domain.Interfaces.Repositories;

namespace Application.Generics.Services
{
    public class GenericService<SaveDto, Dto, Entity> : IGenericService<SaveDto, Dto, Entity>
         where SaveDto : class
         where Dto : class
         where Entity : class
    {
        private readonly IGenericRepository<Entity> _repository;
        private readonly IMapper _mapper;

        public GenericService(IGenericRepository<Entity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public virtual async Task Update(SaveDto vm, int id)
        {
            Entity entity = _mapper.Map<Entity>(vm);
            await _repository.UpdateAsync(entity, id);
        }

        public virtual async Task<SaveDto> Add(SaveDto vm)
        {
            Entity entity = _mapper.Map<Entity>(vm);

            entity = await _repository.AddAsync(entity);

            SaveDto entityVm = _mapper.Map<SaveDto>(entity);

            return entityVm;
        }

        public virtual async Task Delete(int id)
        {
            var product = await _repository.GetByIdAsync(id);
            await _repository.DeleteAsync(product);
        }

        public virtual async Task<SaveDto> GetByIdSaveDto(int id)
        {
            var entity = await _repository.GetByIdAsync(id);

            SaveDto vm = _mapper.Map<SaveDto>(entity);
            return vm;
        }

        public virtual async Task<List<Dto>> GetAllDto()
        {
            var entityList = await _repository.GetAllAsync();

            return _mapper.Map<List<Dto>>(entityList);
        }

    }
}
