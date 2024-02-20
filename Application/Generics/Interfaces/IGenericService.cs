namespace Application.Generics.Interface
{
    public interface IGenericService<SaveDto, Dto, Entity>
        where SaveDto : class
        where Dto : class
        where Entity : class
    {
        Task Update(SaveDto vm, int id);

        Task<SaveDto> Add(SaveDto vm);

        Task Delete(int id);

        Task<SaveDto> GetByIdSaveDto(int id);

        Task<List<Dto>> GetAllDto();
    }
}
