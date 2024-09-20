using wayni_prueba.Domain.Entities;
using wayni_prueba.Domain.Interfaces;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace wayni_prueba.Application.Services
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ILogger<UserService> _logger;

        // Constructor para inyección de dependencias
        public UserService(IUserRepository userRepository, ILogger<UserService> logger)
        {
            _userRepository = userRepository;
            _logger = logger;
        }

        // Método para obtener todos los usuarios
        public IEnumerable<User> GetAllUsers()
        {
            return _userRepository.GetAll();
        }

        // Método para obtener un usuario por su ID
        public User GetUserById(int id)
        {
            return _userRepository.GetById(id);
        }

        // Método para agregar un nuevo usuario
        public void AddUser(User user)
        {
            _logger.LogDebug("Adding user: {@User}", user);

            // Se agrega el usuario y se guardan los cambios
            _userRepository.Add(user);
            _userRepository.SaveChanges();
            _logger.LogDebug("User added successfully: {@User}", user);
        }

        // Método para actualizar un usuario existente
        public void UpdateUser(User user)
        {
            _logger.LogDebug("Updating user: {@User}", user);

            // Se actualiza el usuario y se guardan los cambios
            _userRepository.Update(user);
            _userRepository.SaveChanges();
            _logger.LogDebug("User updated successfully: {@User}", user);
        }

        // Método para eliminar un usuario por su ID
        public void DeleteUser(int id)
        {
            _logger.LogDebug("Deleting user with ID: {UserId}", id);

            // Se elimina el usuario y se guardan los cambios
            _userRepository.Delete(id);
            _userRepository.SaveChanges();
            _logger.LogDebug("User with ID {UserId} deleted successfully", id);
        }
    }
}
