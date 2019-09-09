using System;
using System.Collections.Generic;
using System.Text;
using DatabaseContext;
using Models;
using Repositories.Base;
using Repositories.Contracts;

namespace Repositories
{
    public class ShopRepository:Repository<Shop>,IShopRepository
    {
        
    }
}
