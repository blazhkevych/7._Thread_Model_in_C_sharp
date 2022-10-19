using System.Text;

namespace task
{
    // Хранит настройки окна приложения, а также позволяет их считывать из файла и записывать в файл.
    internal class ApplicationSettingsHelper
    {
        // Цвет фона консоли.
        private ConsoleColor _ConsoleBackgroundColor;
        public ConsoleColor ConsoleBackgroundColor
        {
            set { _ConsoleBackgroundColor = value; }
            get { return _ConsoleBackgroundColor; }
        }

        // Цвет текста консоли.
        private ConsoleColor _ForegroundColor;
        public ConsoleColor ForegroundColor
        {
            set { _ForegroundColor = value; }
            get { return _ForegroundColor; }
        }

        // Заголовок консоли.
        private string _ConsoleTitle;
        public string ConsoleTitle
        {
            set { _ConsoleTitle = value; }
            get { return _ConsoleTitle; }
        }

        // Размер окна консоли.
        int _ConsoleWindowWidth;     // Ширина.
        public int ConsoleWindowWidth
        {
            set { _ConsoleWindowWidth = value; }
            get { return _ConsoleWindowWidth; }
        }

        int _ConsoleWindowHeight;    // Высота.
        public int ConsoleWindowHeight
        {
            set { _ConsoleWindowHeight = value; }
            get { return _ConsoleWindowHeight; }
        }

        public ApplicationSettingsHelper()
        {
            _ConsoleBackgroundColor = Console.BackgroundColor;
            _ForegroundColor = Console.ForegroundColor;
            _ConsoleTitle = Console.Title;
            _ConsoleWindowWidth = Console.WindowWidth;
            _ConsoleWindowHeight = Console.WindowHeight;
        }

        // Сохранить настройки.
        public void Save()
        {
            try
            {
                StreamWriter sw = new StreamWriter("Settings.txt", false);
                sw.WriteLine((int)_ConsoleBackgroundColor);
                sw.WriteLine((int)_ForegroundColor);
                sw.WriteLine(_ConsoleTitle);
                sw.WriteLine(_ConsoleWindowWidth);
                sw.WriteLine(_ConsoleWindowHeight);
                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        // Загрузить настройки.
        public void Load()
        {
            try
            {
                StreamReader sr = new StreamReader("Settings.txt", Encoding.Default);
                _ConsoleBackgroundColor = (ConsoleColor)Convert.ToInt32(sr.ReadLine());
                _ForegroundColor = (ConsoleColor)Convert.ToInt32(sr.ReadLine());
                _ConsoleTitle = sr.ReadLine();
                _ConsoleWindowWidth = Convert.ToInt32(sr.ReadLine());
                _ConsoleWindowHeight = Convert.ToInt32(sr.ReadLine());
                sr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            SetConsoleSettings();
        }

        // Выставить значения в консоль.
        private void SetConsoleSettings()
        {
            Console.BackgroundColor = ConsoleBackgroundColor;
            Console.ForegroundColor = ForegroundColor;
            Console.Title = _ConsoleTitle;
            Console.WindowWidth = _ConsoleWindowWidth;
            Console.WindowHeight = _ConsoleWindowHeight;
        }
    }
}