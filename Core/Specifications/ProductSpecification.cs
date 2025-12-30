using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Xml.Linq;

namespace Core.Specifications
{
    public class ProductSpecification : BaseSpecification<Product>
    {


        public ProductSpecification(ProductSpecParams specParams) : base(x =>
            (
                specParams.Brands == null ||
                !specParams.Brands.Any() ||
                specParams.Brands.Contains(x.Brand)
            ) &&
                (specParams.Types == null || !specParams.Types.Any() || specParams.Types.Contains(x.Type)
            )
        )
        {

            ApplyPaging(specParams.PageSize * (specParams.PageIndex - 1), specParams.PageSize);


            switch (specParams.Sort)
            {
                case "priceAsc":
                    AddOrderBy(x => x.Price);
                    break;
                case "PriceDesc":
                    AddOrderByDescending(x => x.Price);
                    break;
                default:
                    AddOrderBy(x => x.Name);
                    break;
            }
        }
    }
}
