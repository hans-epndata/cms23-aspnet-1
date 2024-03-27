using Infrastructure.Data.Entities;
using Infrastructure.Models;

namespace Infrastructure.Factories;

public class CourseFactory
{
    public static CourseEntity Create(CourseRegistrationForm form)
    {
        try
        {
            var datetime = DateTime.Now;

            return new CourseEntity
            {
                Id = Guid.NewGuid().ToString(),
                Title = form.Title,
                Author = form.Author,
                OriginalPrice = form.OriginalPrice,
                Hours = form.Hours,
                IsDigital = form.IsDigital,
                Created = datetime,
                LastUpdated = datetime,
                ImageUrl = form.ImageUrl,
                BigImageUrl = form.BigImageUrl,
            };
        }
        catch (Exception ex) { }
        return null!;
    }

    public static CourseEntity Create(CourseRegistrationForm form, int categoryId)
    {
        try
        {
            var datetime = DateTime.Now;

            return new CourseEntity
            {
                Id = Guid.NewGuid().ToString(),
                Title = form.Title,
                Author = form.Author,
                OriginalPrice = form.OriginalPrice,
                Hours = form.Hours,
                IsDigital = form.IsDigital,
                Created = datetime,
                LastUpdated = datetime,
                ImageUrl = form.ImageUrl,
                BigImageUrl = form.BigImageUrl,
                CategoryId = categoryId
            };
        }
        catch (Exception ex) { }
        return null!;
    }

    public static Course Create(CourseEntity entity)
    {
        try
        {
            return new Course
            {
                Id = entity.Id,
                Title = entity.Title,
                Author = entity.Author,
                OriginalPrice = entity.OriginalPrice,
                DiscountPrice = entity.DiscountPrice,
                Hours = entity.Hours,
                IsDigital = entity.IsDigital,
                IsBestseller = entity.IsBestseller,
                NumberOfLikes = entity.NumberOfLikes,
                LikesInProcent = entity.LikesInProcent,
                ImageUrl = entity.ImageUrl,
                BigImageUrl = entity.BigImageUrl,
                Category = entity.Category!.CategoryName
            };
        }
        catch (Exception ex) { }
        return null!;
    }

    public static IEnumerable<Course> Create(List<CourseEntity> entities)
    {
        var courses = new List<Course>();

        try
        {
            foreach (var entity in entities)
                courses.Add(Create(entity));
        }
        catch (Exception ex) { }
        return courses;
    }
}
