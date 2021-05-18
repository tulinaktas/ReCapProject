using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IFakeFindexService
    {
       bool CheckFindex(int carMinFindex, int customerFindexScore);
    }
}
