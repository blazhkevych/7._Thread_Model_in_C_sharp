namespace task
{
    internal class Program
    {
        /*
         Разработать консольное приложение, состоящее из двух классов:
            класс UserInterface предоставляет пользователю возможность 
           изменять настройки окна приложения (цвет фона и текста консоли, 
           размер окна, заголовок и др.);
            класс ApplicationSettingsHelper хранит настройки окна приложения, 
           а также позволяет их считывать из файла и записывать в файл
         */

        static void Main(string[] args)
        {
            UserInterface ui = new UserInterface();
            ui.MainMenu();
        }
    }
}