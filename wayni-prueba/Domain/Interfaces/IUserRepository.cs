using wayni_prueba.Domain.Entities;

namespace wayni_prueba.Domain.Interfaces;

public interface IUserRepository
{
    IEnumerable<User> GetAll();
    User GetById(int id);
    void Add(User user);
    void Update(User user);
    void Delete(int id);
    
    void SaveChanges();
} 