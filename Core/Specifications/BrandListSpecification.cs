using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;


namespace Core.Specifications
{
    public class BrandListSpecification : BaseSpecification<ProductDTO, string>
    {
        public BrandListSpecification()
        {
            AddSelect(x => x.Brand);
            ApplyDistinct();
        }

    }
}
