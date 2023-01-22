using OnlineShop.Application.Wrappers;
using OnlineShop.External.Order.Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.External.Order.Application.DataService
{
    public interface IOrderDataService
    {
        Task<ServiceResponse<List<OrderData>>> GetOrderDataByDate(DateTime startDate, CancellationToken cancellationToken);
    }
}
