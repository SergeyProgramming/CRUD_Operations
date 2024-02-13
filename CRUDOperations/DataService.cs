namespace CRUDOperations
{
    internal class DataService
    {
        private readonly ApplicationContext _context;
        public DataService(ApplicationContext applicationContext) => _context = applicationContext;
        //Добавить пользователя
        public long AddUser(User user) 
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return user.Id;
        }
        // Удалить пользователя
        public User DeleteUser(User user) 
        {
            _context.Users.Remove(user);
            _context.SaveChanges();
            return user;
        }
        // Обновить данные пользователя
        public User UpdateUser(User user) 
        {
            _context.Users.Update(user);
            _context.SaveChanges();
            return user;
        }
        //Поиск пользователя
        public User? SearchUser(long Id) 
        {
            return _context.Users.FirstOrDefault(users => users.Id == Id);
        }
        //Вывод списка пользователей
        public List<User> GetUsersList()
        {
            return _context.Users.ToList();
        }
        //Проверка соединения с БД
        public bool GetConnection()
        {
            return _context.Database.CanConnect();
        }
    }
}
