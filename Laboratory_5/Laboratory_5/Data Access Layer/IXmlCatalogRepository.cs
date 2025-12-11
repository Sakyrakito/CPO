using Laboratory_5.Business_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratory_5.Data_Access_Layer
{
    public interface IXmlCatalogRepository
    {
        List<Category> LoadCatalog();
        void SaveCatalog(List<Category> categories);
    }
}
