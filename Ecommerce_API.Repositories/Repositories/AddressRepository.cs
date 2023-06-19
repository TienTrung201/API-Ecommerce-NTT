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
        //get
        public async Task<List<AddressEntity>> GetAllAddress()
        {
            var allAddress = await _context.Addresses.ToListAsync();
            return allAddress;
        }
        public async Task<AddressEntity> GetAddressById(int id)
        {
            var address = await _context.Addresses.FirstOrDefaultAsync(u => u.AddressId == id);
            if (address == null)
            {
                throw new Exception("cant't find address");
            }
            return address;
        }

        //create
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
        //update
        public async Task<AddressEntity> UpdateAddress(AddressEntity address)
        {
            _context.Addresses.Update(address);
            var result = await _context.SaveChangesAsync();
            if (result == 0)
            {
                throw new Exception("cant't update address");
            }
            return address;
        }
        //remove
        public async Task<AddressEntity> RemoveAddress(AddressEntity address)
        {
            _context.Addresses.Remove(address);
            var result = await _context.SaveChangesAsync();
            if (result == 0)
            {
                throw new Exception("cant't remove user");
            }
            return address;
        }

      
    }
}
