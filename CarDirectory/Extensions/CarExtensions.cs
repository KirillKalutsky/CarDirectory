using CarDirectory.Models;
using CarDirectory.Models.Dto;

namespace CarDirectory.Extensions
{
    public static class CarExtensions
    {
        public static Automobile DtoToAutomobite(this AutomobileDto dto)
        {
            return new Automobile()
            {
                Brand = dto.Brand,
                Color = dto.Color,
                RegisterSign = dto.RegisterSign,
                YearOfIssue = dto.YearOfIssue
            };
        }
    }
}
