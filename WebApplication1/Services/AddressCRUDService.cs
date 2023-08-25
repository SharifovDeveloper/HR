using NajotTalim.HR.DataAcces.Entities;
using NajotTalim.HR.DataAcces;
using WebApplication1.Models;

namespace NajotTalim.HR.DataAcces.Services
{
    public class AddressCRUDService : IGenericCRUDService<AddressModel>
    {
        private readonly IAddressRepository _addressRepasitory;
        public AddressCRUDService(IAddressRepository addressRepasitory)
        {
            _addressRepasitory = addressRepasitory;
        }
        public async Task<AddressModel> Create(AddressModel model)
        {
            var address = new Address
            {
                AddressLine1 = model.AddressLine1,
                AddressLine2 = model.AddressLine2,
                PostalCode=model.PostalCode,
                Country = model.Country,
                City = model.City,


            };
            var createdAddress = await _addressRepasitory.CreateAddress(address);
            var result = new AddressModel
            {
                AddressLine1=createdAddress.AddressLine1,
                AddressLine2=createdAddress.AddressLine2,
                PostalCode=createdAddress.PostalCode,
                Country=createdAddress.Country,
                City=createdAddress.City,
                Id=createdAddress.Id,
            };
            return result;
        }

        public async Task<bool> Delete(int id)
        {
            return await _addressRepasitory.DeleteAddress(id);
        }

        public async Task<AddressModel> Get(int id)
        {
            var address = await _addressRepasitory.GetAddress(id);
            var model = new AddressModel
            {
                Id = address.Id,
                AddressLine1 = address.AddressLine1,
                AddressLine2 = address.AddressLine2,
                PostalCode=address.PostalCode,
                Country = address.Country,
                City = address.City,
             
            };
            return model;
        }

        public async Task<IEnumerable<AddressModel>> GetAll()
        {
            var result = new List<AddressModel>();
            var addresses = await _addressRepasitory.GetAddresses();
            foreach (var adress in addresses)
            {
                var model = new AddressModel
                {
                    Id=adress.Id,
                    AddressLine1 = adress.AddressLine1,
                    AddressLine2 = adress.AddressLine2,
                    PostalCode=adress.PostalCode,
                    Country = adress.Country,
                    City = adress.City,
                   
                };
                result.Add(model);
            }
            return result;
        }

        public async Task<AddressModel> Update(int id, AddressModel model)
        {
            var address = new Address
            {
                Id=model.Id,
                AddressLine1=model.AddressLine1,
                AddressLine2 = model.AddressLine2,
                PostalCode=model.PostalCode,
                Country = model.Country,
                City = model.City,

            };
            var updatedEmployee = await _addressRepasitory.UpdateAddress(id, address);
            var result = new AddressModel
            {
               Id=address.Id,
               AddressLine1=address.AddressLine1,
               AddressLine2 = address.AddressLine2,
               PostalCode=address.PostalCode,
               Country = address.Country,
               City = address.City,

            };
            return result;
        }
    }
}


