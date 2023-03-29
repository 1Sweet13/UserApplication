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
using System.Windows.Shapes;

namespace UserAPP
{
    /// <summary>
    /// Логика взаимодействия для AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        public AuthWindow()
        {
            InitializeComponent();
        }

        private void Button_Auth_CLick(object sender, RoutedEventArgs e) // Получение данных при регистрации от пользователя 
        {
            string login = textBoxLogin.Text.Trim();// Метод Trim() убирает все ненужные пробелы 
            string pass = passBox.Password.Trim();    

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
            else
            {
                textBoxLogin.ToolTip = "";
                textBoxLogin.Background = Brushes.Transparent;
                passBox.ToolTip = "";
                passBox.Background = Brushes.Transparent;

                User authUser = null; // Обращение к базе данных без выделения памяти 

                using (AppContext db = new AppContext()) // using позволяет создать закрыте окружение с кодом подключения базы данных AppContext 
                {
                    authUser = db.Users.Where(b => b.Login == login && b.Pass == pass).FirstOrDefault();    //Переманная может быть любая Обращение к базе данных ищем логин и пароль что ввел пользователь FirstOrDefault() - выбор записи либо налл
                }

                if (authUser != null) // если обьект не равен значению null
                { 
                    MessageBox.Show("Успешно");
                    UserPageWindow userPageWindow = new UserPageWindow(); // При успешной регистрации будем переходить в кабинет пользователя
                    userPageWindow.Show();
                    Hide();
                }
                else
                    MessageBox.Show("Некорректный ввод");
                   
            }
        }

        private void Button_Reg_CLick(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow= new MainWindow();// Создание обьекта выделение памяти
            mainWindow.Show();
            Hide();// Текущее окно прячем
        }
    }
}
