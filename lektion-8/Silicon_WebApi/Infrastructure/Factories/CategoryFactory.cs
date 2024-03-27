using Infrastructure.Data.Entities;
using Infrastructure.Models;

namespace Infrastructure.Factories;

public class CategoryFactory
{
    public static CategoryEntity Create(CategoryRegistrationForm form)
    {
        try
        {
            return new CategoryEntity
            {
                CategoryName = form.CategoryName,
            };
        }
        catch (Exception ex) { }
        return null!;
    }

    public static Category Create(CategoryEntity entity)
    {
        try
        {
            return new Category
            {
                Id = entity.Id,
                CategoryName = entity.CategoryName,
            };
        }
        catch (Exception ex) { }
        return null!;
    }

    public static IEnumerable<Category> Create(List<CategoryEntity> entities)
    {
        var categories = new List<Category>();

        try
        {
            foreach(var entity in  entities)
                categories.Add(Create(entity));
        }
        catch (Exception ex) { }
        return categories;
    }
}
