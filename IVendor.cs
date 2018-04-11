using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;

namespace DLA.Repository
{
   public interface IVendor
    {

        int Add(VendorObject VenObj);
        int Update(VendorObject VenObj);
        int Delete(int VendorId);
        VendorObject GetById(int VendorId);
        List<VendorObject> GetAll();
    }
}
