using VideoClone.Core.Utilities.Results;
using VideoClone.Entities.Concrete;
using VideoClone.Entities.DTOs;

namespace VideoClone.Business.Abstract;

public interface ICategoryService
{
    IDataResult<IList<CategoryDto>> GetList();
    IDataResult<Category> GetById(Guid id);
    IResult Add(CategoryCreateUpdateDto categoryDto);
    IResult Update(Guid id, CategoryCreateUpdateDto categoryDto);
}