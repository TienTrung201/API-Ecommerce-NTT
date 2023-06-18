using Ecommerce_API.Core.Entities;
using Ecommerce_API.Core.Initial;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce_API.Repositories.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private readonly EcommerceDbContext _context;
        public AddressRepository(EcommerceDbContext context)
        {
            _context = context;
        }
        public async Task<AddressEntity> CreateAddress(AddressEntity address)
        {
            await _context.Addresses.AddAsync(address);
            var result = await _context.SaveChangesAsync();
            if (result == 0)
            {
                throw new Exception("Không thể thêm mới address");
            }
            return address;
        }

        public async Task<List<AddressEntity>> GetAllAddress()
        {
            var allAddress = await _context.Addresses.ToListAsync();
            return allAddress;
        }
    }
}
