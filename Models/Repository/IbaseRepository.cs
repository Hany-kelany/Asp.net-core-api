using Microsoft.AspNetCore.JsonPatch;

namespace Api.Models.Repository
{
    public interface IbaseRepository<T , T2 > where T : class
    {
        List<T> GetAll();
        T GetById(int id);
        T GetByName(string name);

        void DeleteById(int id);
        void DeleteByName(string name);

        void Add(T2 entity);

        T Update(int id, T2 entity);
        T UpdateWithPatch(JsonPatchDocument<T> entity, int id);
    }
}
