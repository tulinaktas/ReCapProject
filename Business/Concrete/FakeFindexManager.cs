using Business.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class FakeFindexManager : IFakeFindexService
    {
        public bool CheckFindex(int carMinFindex, int customerFindexScore)
        {
            return carMinFindex <= customerFindexScore ? true : false;
        }
    }
}
