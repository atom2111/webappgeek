using WebAppGeek.Dto;

namespace WebAppGeek.Abstraction
{
    public interface IProductGroupRepository
    {
        IEnumerable<ProductGroupDto> GetAllProductGroups();
        int AddProductGroup(ProductGroupDto productGroupDto);
        void DeleteProductGroup(int id);
    }
}
