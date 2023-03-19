using AutoMapper;
using JobNetCore6.Core.Models;
using JobNetCore6.DTOs;
using JobNetCore6.Repository;

namespace JobNetCore6.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task AddAsync(CategoryDTOSUa categoryDTO)
        {
            var cate=_mapper.Map<Category>(categoryDTO);
            await _categoryRepository.AddAsync(cate);
        }

        public async Task DeleteAsync(int id)
        {
            var product = await _categoryRepository.GetByIdAsync(id);        
        }

        public async Task<IEnumerable<CategoryDTO>> GetAllAsync()
        {
            var cate=await _categoryRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<CategoryDTO>>(cate);
        }

        public async Task<CategoryDTO> GetByIdAsync(int id)
        {
           var cate=await _categoryRepository.GetByIdAsync(id);
            return _mapper.Map<CategoryDTO>(cate);
        }

        public async Task UpdateAsync(CategoryDTO categoryDTO)
        {
            var cate = _mapper.Map<Category>(categoryDTO);
            await _categoryRepository.UpdateAsync(cate);
        }
    }
}
