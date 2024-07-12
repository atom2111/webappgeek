using AutoMapper;
using WebAppGeek.Abstraction;
using WebAppGeek.Data;
using WebAppGeek.Dto;
using WebAppGeek.Models;

namespace WebAppGeek.Repository
{
    public class ProductGroupRepository : IProductGroupRepository
    {
        private readonly StorageContext _storageContext;
        private readonly IMapper _mapper;

        public ProductGroupRepository(StorageContext storageContext, IMapper mapper)
        {
            _storageContext = storageContext;
            _mapper = mapper;
        }

        public int AddProductGroup(ProductGroupDto productGroupDto)
        {
            if (_storageContext.ProductGroups.Any(p => p.Name == productGroupDto.Name))
                throw new Exception("Уже есть продукт с таким именем");

            var entity = _mapper.Map<ProductGroup>(productGroupDto);
            _storageContext.ProductGroups.Add(entity);
            _storageContext.SaveChanges();
            return entity.Id;
        }

        public void DeleteProductGroup(int id)
        {
            var entity = _storageContext.ProductGroups.Find(id);
            if (entity == null)
                throw new Exception("Нет группы с таким ID");

            _storageContext.ProductGroups.Remove(entity);
            _storageContext.SaveChanges();
        }

        public IEnumerable<ProductGroupDto> GetAllProductGroups()
        {
            var listDto = _storageContext.ProductGroups.Select(_mapper.Map<ProductGroupDto>).ToList();
            return listDto;
        }
    }
}
