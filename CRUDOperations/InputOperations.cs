using static System.Console;
namespace CRUDOperations
{
    internal class InputOperations
    {
        private readonly ApplicationContext _context;
        private readonly DataService _dataService;
        public InputOperations(DataService dataService, ApplicationContext context)
        {
            _dataService = dataService;
            _context = context;
        }
        internal void GetUsersList()
        {
            List<User> cientsList = _dataService.GetUsersList();
            foreach (var clients in cientsList)
            {
                WriteLine($"""
                {clients.Id}. {clients.Name}. {clients.LastName}. {clients.Age}. {clients.Email}.
                --------------------------------------------------------------------------------------------------------------------- 
                """);
            }
        }
        internal void AddNewUser()
        {
            WriteLine("Введите Id: ");
            long id;
            bool idIsParse = long.TryParse(ReadLine(), out id);
            if (idIsParse) { }
            else
            {
                WriteLine("Необходимо число номера id");
                return;
            }
            WriteLine("Введите Имя: "); 
            string? name = ReadLine();
            WriteLine("Введите Фамилию: "); 
            string? lastname = ReadLine();
            WriteLine("Введите Возраст: ");
            long age;
            bool ageParse = long.TryParse(ReadLine(), out age);
            if (ageParse) { }
            else
            {
                WriteLine("Необходимо числовое значение возраста клиента");
                return;
            }
            WriteLine("Введите Емаил: "); 
            string? email = ReadLine();
            User newUser = new User() { Id = id, Name = name, LastName = lastname, Age = age, Email = email };
            long idUser = _dataService.AddUser(newUser);
            WriteLine($"Клиент c id {idUser} добавлен в Базу Данных");
        }
        internal void GetUser()
        {
            WriteLine("Введите id: ");
            long idSearch;
            bool idIsParse = long.TryParse(ReadLine(), out idSearch);
            if (idIsParse) { }
            else
            {
                WriteLine("Необходимо число номера id");
                return;
            }
            _dataService.SearchUser(idSearch);
            List<User> searchUser = _dataService.GetUsersList();
            foreach (var clients in searchUser)
            {
                if (clients.Id == idSearch)
                    WriteLine($"""
                    {clients.Id}. {clients.Name}. {clients.LastName}. {clients.Age}. {clients.Email}.
                    ---------------------------------------------------------------------------------------------------------------------
                    """);
            }
        }
        internal void UpdateUser()
        {
            if (_context.Users != null)
            {
                WriteLine("Введите id: ");
                long idSearch;
                bool idIsParse = long.TryParse(ReadLine(), out idSearch);
                if (idIsParse) { }
                else
                {
                    WriteLine("Необходимо число номера id");
                    return;
                }
                User? updateUser = _dataService.SearchUser(idSearch);
                WriteLine("Изменить Id: ");
                updateUser.Id = long.Parse(ReadLine());
                if (idSearch != updateUser.Id)
                {
                    throw new Exception("id пользователя не известен");
                }
                WriteLine("Изменить Имя: "); 
                updateUser.Name = ReadLine();
                WriteLine("Изменить Фамилию: "); 
                updateUser.LastName = ReadLine();
                WriteLine("Изменить Возраст: "); 
                updateUser.Age = long.Parse(ReadLine());
                WriteLine("Изменить Емаил: "); 
                updateUser.Email = ReadLine();
                _dataService.UpdateUser(updateUser);
            }
        }
        internal void RemoveUser()
        {
            WriteLine("Введите Id: ");
            long idRemove;
            bool idIsParse = long.TryParse(ReadLine(), out idRemove);
            if (idIsParse) { }
            else
            {
                WriteLine("Необходимо число номера id");
                return;
            }
            var user = _dataService.SearchUser(idRemove);
            if (user != null)
            {
                _dataService.DeleteUser(user);
                WriteLine($"Пользователь с id {idRemove} удален.");
            }
            else WriteLine("Такого клиента не существует.");
        }
        internal void GetConnect()
        {
            bool connect = _dataService.GetConnection();
            if (connect) Write($"Подключен к БД {_context}");
            else Write($"Не подключение к БД {_context}");
        }
    }
}
