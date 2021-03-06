﻿using Commerce.Core.ViewModel;
using Commerce.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Commerce.Business
{
    public interface IWordPressConnector
    {
        int QueryOrder();
        int QueryProduct();
        PaginatedList<ProductView> ListProduct();
    }
}
