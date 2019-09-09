using System;
using System.Collections.Generic;
using System.Text;
using BLL.Base;
using BLL.Contracts;
using Models;
using Repositories.Contracts;

namespace BLL
{
    public class ShopManager:Manager<Shop>,IShopManager
    {
        public ShopManager(IShopRepository repository) : base(repository)
        {
        }
    }
}
