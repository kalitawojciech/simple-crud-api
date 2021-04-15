using System.Threading.Tasks;
using CRUD.DAL.Entities;
using CRUD.DAL.Repositories.Interfaces;
using CRUD.Services.Dtos.Categories.Response;
using CRUD.Services.Services.Interfaces;
using System.Collections.Generic;
using AutoMapper;
using System;
using CRUD.Services.Exceptions;

namespace CRUD.Services.Services
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

        public async Task<List<CategoryFullInfoResponse>> GetAll()
        {
            List<Category> categoriesFromDb = await _categoryRepository.GetAll();

            var result = _mapper.Map<List<CategoryFullInfoResponse>>(categoriesFromDb);

            return result;
        }

        public async Task<CategoryFullInfoResponse> GetById(Guid id)
        {
            Category categoryFromDb = await _categoryRepository.GetById(id);

            if(categoryFromDb == null)
            {
                throw new NotFoundException("Category with this Id does not exist in db");
            }

            var result = _mapper.Map<CategoryFullInfoResponse>(categoryFromDb);

            return result;
        }
    }
}
