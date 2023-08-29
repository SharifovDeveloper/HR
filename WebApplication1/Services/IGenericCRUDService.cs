﻿namespace NajotTalim.HR.DataAcces.Services
{
    public interface IGenericCRUDService<T> where T : class
    {
        Task<T> Create(T employee);
        Task<IEnumerable<T>> GetAll();
        Task<T> Get(int id);
        Task<T> Update(int id, T employee);
        Task<bool> Delete(int id);
    }
}
