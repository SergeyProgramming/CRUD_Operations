using static System.Console;
namespace CRUDOperations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ApplicationContext applicationContext = new ApplicationContext();
            DataService dataService = new DataService(applicationContext);
            InputOperations inputOperations = new InputOperations(dataService, applicationContext);
            Menu menu = new Menu(inputOperations);
            menu.GetMainMenu();
            menu.GetMenuItem();
        }
    }
}
