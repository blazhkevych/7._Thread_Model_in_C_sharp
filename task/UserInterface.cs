namespace task
{
    // Предоставляет пользователю возможность изменять настройки окна приложения (цвет фона и текста консоли, размер окна, заголовок и др.).
    internal class UserInterface
    {
        // Хранит все настройки консоли.
        private ApplicationSettingsHelper ash = new ApplicationSettingsHelper();

        // Массив со значениями членов перечисления ConsoleColor.
        private ConsoleColor[] colors = (ConsoleColor[])ConsoleColor.GetValues(typeof(ConsoleColor));

        // Главное меню.
        public void MainMenu()
        {
            string choice;
            do
            {
                Console.WriteLine(@"1. Цвет фона консоли.
2. Цвет текста консоли.
3. Заголовок консоли.
4. Размер окна.
5. Сохранить настройки.
6. Загрузить настройки.
7. Выход.");
                Console.WriteLine();
                Console.WriteLine("Я выбираю: ");
                choice = Console.ReadLine();

                Console.WriteLine();
                switch (choice)
                {
                    case "1":
                        BackgroundColor();
                        break;
                    case "2":
                        ConsoleTextColor();
                        break;
                    case "3":
                        ConsoleTitle();
                        break;
                    case "4":
                        WindowSize();
                        break;
                    case "5":
                        ash.Save();
                        break;
                    case "6":
                        ash.Load();
                        break;
                    case "7":
                        Environment.Exit(0);
                        break;
                }

                MainMenu();
            } while (choice != "1" | choice != "2" | choice != "3" | choice != "4" | choice != "5");
        }

        // Цвет фона консоли.
        private void BackgroundColor()
        {
            Console.WriteLine("Цвет фона консоли.");

            Console.WriteLine("Введите номер цвета из нижеперечисленных.");
            // Отображение всех цветов фона консоли, кроме того, который соответствует текущему фону.
            Console.WriteLine("Все цвета фона консоли, кроме {0}, который соответствует текущему фону:",
               ash.ConsoleBackgroundColor);
            for (int i = 0; i < colors.Length; i++)
            {
                if (colors[i] == ash.ConsoleBackgroundColor) continue;

                Console.ForegroundColor = colors[i]; // Установка цвета текста на выводе.
                Console.WriteLine("   {0}. Цвет фона консоли {1}.", i, colors[i]);
            }

            try
            {
                ash.ConsoleBackgroundColor = colors[Convert.ToInt32(Console.ReadLine())];
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            Console.BackgroundColor = ash.ConsoleBackgroundColor;
            Console.ForegroundColor = ash.ForegroundColor;
            Console.WriteLine();
        }

        // Цвет текста консоли.
        private void ConsoleTextColor()
        {
            Console.WriteLine("Цвет текста консоли.");

            Console.WriteLine("Введите номер цвета из нижеперечисленных.");
            // Все цвета фона, кроме того, который соответствует текущему цвету фона.
            Console.WriteLine("Все цвета текста, кроме {0}, который соответствует текущему цвету текста:",
              ash.ForegroundColor);
            for (int i = 0; i < colors.Length; i++)
            {
                if (colors[i] == ash.ForegroundColor) continue;

                Console.BackgroundColor = colors[i]; // Установка цвета фона на выводе.
                Console.WriteLine("   {0}. Цвет текста {1}.", i, colors[i]);
            }

            try
            {
                ash.ForegroundColor = colors[Convert.ToInt32(Console.ReadLine())];
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            Console.ForegroundColor = ash.ForegroundColor;
            Console.BackgroundColor = ash.ConsoleBackgroundColor;
            Console.WriteLine();
        }

        // Размер окна.
        private void WindowSize()
        {
            int width=0, height=0;
            do
            {
                Console.WriteLine("Введите ширину окна, затем высоту: ");
                try
                {
                    width = Convert.ToInt32(Console.ReadLine());
                    height = Convert.ToInt32(Console.ReadLine());
                    Console.SetWindowSize(width, height);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }

            } while (width <= 0 | width > Console.LargestWindowWidth | height <= 0 | height > Console.LargestWindowHeight);

            ash.ConsoleWindowWidth = width;
            ash.ConsoleWindowHeight = height;
            Console.WriteLine();
        }

        // Заголовок консоли.
        private void ConsoleTitle()
        {
            Console.WriteLine("Введите заголовок для отображения в строке заголовка консоли:");
            string? input = Console.ReadLine();
            Console.Title = input;

            ash.ConsoleTitle = input;
            Console.WriteLine();
        }
    }
}