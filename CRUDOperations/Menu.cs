using static System.Console;
namespace CRUDOperations
{
    internal class Menu
    {
        private readonly InputOperations _inputOperations;
        public Menu(InputOperations inputOperations)
        {
            _inputOperations = inputOperations;
        }
        internal void GetMainMenu()
        {
            WriteLine("""          
                ---------------------------------------------------------------------------------------------------------------------
                    [МЕНЮ]    1. ПОЛУЧИТЬ ОБЩИЙ СПИСОК КЛИЕНТОВ    F1.          4. ИЗМЕНИТЬ ДАННЫЕ КЛИЕНТА       F4.  
                              2. ДОБАВИТЬ НОВОГО КЛИЕНТА           F2.          5. УДАЛИТЬ ВЫБРАННОГО КЛИЕНТА    F5.
                              3. ПОЛУЧИТЬ ДАННЫЕ  КЛИЕНТА          F3.          6. ПРОВЕРИТЬ ПОДКЛЮЧЕНИЕ К БД.   F6.                                                                                          
                ---------------------------------------------------------------------------------------------------------------------
                                                                                                              [Tab - очистка консоли]                                                                     
                """);
        }
        internal void GetMenuItem()
        {
            ConsoleKey consoleKey = ReadKey().Key;
            switch (consoleKey)
            {
                case ConsoleKey.F1:
                    _inputOperations.GetUsersList();
                    break;
                case ConsoleKey.F2:
                    _inputOperations.AddNewUser();
                    break;
                case ConsoleKey.F3:
                    _inputOperations.GetUser();
                    break;
                case ConsoleKey.F4:
                    _inputOperations.UpdateUser();
                    break;
                case ConsoleKey.F5:
                    _inputOperations.RemoveUser();
                    break;
                case ConsoleKey.F6:
                    _inputOperations.GetConnect();
                    break;
                case ConsoleKey.Tab:
                    Clear();
                    break;
                default:
                    WriteLine("Пункт меню выбран не корректно");
                    break;
            }
        }
    }
}
