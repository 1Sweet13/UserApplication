using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Media.Animation;

namespace UserAPP
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        AppContext db;
        public MainWindow()
        {
            InitializeComponent();

            db = new AppContext();  // Ссылка на класс 
            
            DoubleAnimation btnAnimation = new DoubleAnimation(); // Выделяем память под анимацию

            btnAnimation.From = 0;
            btnAnimation.To = 450;
            btnAnimation.Duration = TimeSpan.FromSeconds(1);// Время анимации
            regButton.BeginAnimation(Button.WidthProperty, btnAnimation);

        }

        private void Button_Reg_CLick(object sender, RoutedEventArgs e)
        {
            string login = textBoxLogin.Text.Trim();// Метод Trim() убирает все ненужные пробелы 
            string pass = passBox.Password.Trim();
            string pass_2 = passBox_2.Password.Trim();
            string email = textBoxEmail.Text.Trim().ToLower();

            if (login.Length < 5)
            {
                textBoxLogin.ToolTip = "Это поле введено не корректно!"; // Свойство ToolTip выдает подсказку 
                textBoxLogin.Background = Brushes.DarkRed; // Изменение цвета Brushes
            }
            else if (pass.Length < 5)
            {
                passBox.ToolTip = "Это поле введено не корректно!"; // Свойство ToolTip выдает подсказку 
                passBox.Background = Brushes.Red; // Изменение цвета Brushes
            }
            else if (pass != pass_2)
            {
                passBox_2.ToolTip = "Это поле введено не корректно!"; // Свойство ToolTip выдает подсказку 
                passBox_2.Background = Brushes.DarkRed; // Изменение цвета Brushes
            }

            else if (email.Length < 5 || !email.Contains('@') || !email.Contains('.'))  // 	Возвращает значение, указывающее, встречается ли указанная строка внутри этой строки, используя указанные правила сравнения.
            {
                textBoxEmail.ToolTip = "Это поле введено не корректно!"; // Свойство ToolTip выдает подсказку 
                textBoxEmail.Background = Brushes.DarkRed; // Изменение цвета Brushes
            }
            else // В случае если все проверки успешны 
            {
                textBoxLogin.ToolTip = "";
                textBoxLogin.Background = Brushes.Transparent;
                passBox.ToolTip = "";
                passBox.Background = Brushes.Transparent;
                passBox_2.ToolTip = "";
                passBox_2.Background = Brushes.Transparent;
                textBoxEmail.ToolTip = "";
                textBoxEmail.Background = Brushes.Transparent;

                MessageBox.Show("Успешная регистрация");


                User user = new User(login, email, pass); // Создание обьекта user
                db.Users.Add(user); // Добавление
                db.SaveChanges(); // Сохранение данных

                // При успешной авторизации перебрасывает на страницу авторизации
                AuthWindow authWindow = new AuthWindow(); // Создание объекта
                authWindow.Show();
                Hide();// Скрывает текущее окно 
            }
        }

        private void Button_Window_Outh_CLick(object sender, RoutedEventArgs e) // Переход меду окон
        {
            AuthWindow authWindow = new AuthWindow(); // Создание объекта
            authWindow.Show();
            Hide();// Скрывает текущее окно 
        }
    }
}
