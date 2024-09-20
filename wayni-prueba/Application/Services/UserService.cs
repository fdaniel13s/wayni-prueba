using wayni_prueba.Domain.Entities;
using wayni_prueba.Domain.Interfaces;

namespace wayni_prueba.Application.Services;


public class UserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public IEnumerable<User> GetAllUsers()
    {
        return _userRepository.GetAll();
    }

    public User GetUserById(int id)
    {
        return _userRepository.GetById(id);
    }

    public void AddUser(User user)
    {
        _userRepository.Add(user);
    }

    public void UpdateUser(User user)
    {
        _userRepository.Update(user);
    }

    public void DeleteUser(int id)
    {
        _userRepository.Delete(id);
    }
}