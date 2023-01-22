using OnlineShop.Application.Dto;

namespace OnlineShop.Product.Application.Dto.Product
{
    public class ProductSearchDto : PagedSearchDto
    {
        public Guid? Id { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public string Description { get; set; }
    }
}
