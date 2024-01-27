using BookManagementClassLibrary.Domains;

namespace BookManagementClassLibrary.Repositories
{
    public class UserFunctions
    {
        private readonly UserRepository<User> _userRepository;

        public UserFunctions(UserRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public User GetUser(User user)
        {
            return _userRepository.Get(user);
        }

        public void UpdateUser(User user)
        {
            _userRepository.Update(user);
        }

        public void DeleteUser(User user)
        {
            _userRepository.Delete(user);
        }

        public void ChangePassword(User user, string newPassword)
        {
            var userInfo = _userRepository.Get(user);
            userInfo.Password = newPassword;
            _userRepository.Update(userInfo);
        }

        public void UpdateUserDetails(User user, string firstName, string lastName, string email)
        {
            var userInfo = _userRepository.Get(user);
            userInfo.FirstName = firstName;
            userInfo.LastName = lastName;
            userInfo.Email = email;
            _userRepository.Update(userInfo);
        }
    }

}
