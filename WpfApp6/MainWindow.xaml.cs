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


namespace WpfApp6
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

            db = new AppContext();
        }
        private void Bregin_Click(object sender, RoutedEventArgs e)
        {
            string login = tblogin.Text;
           
            string pass = passb1.Password;
            string pass2 = passb2.Password;

            if (login.Length < 5)
            {
                tblogin.ToolTip = "Это поле введено не корректно";
                tblogin.Background = Brushes.LightCoral;
            }
           
            else if (pass.Length < 5)
            {
                passb1.ToolTip = "Это поле введено не корректно";
                passb1.Background = Brushes.LightCoral;
            }
            else if (pass != pass2)
            {
                passb2.ToolTip = "Пароли не совпадают";
                passb2.Background = Brushes.LightCoral;
            }

            else
            {
                tblogin.ToolTip = "";
                tblogin.Background = Brushes.Transparent;
               
                passb1.ToolTip = "";
                passb1.Background = Brushes.Transparent;
                passb2.ToolTip = "";
                passb2.Background = Brushes.Transparent;

                MessageBox.Show("Вы успешно зарегистрировались");

                User user = new User(login, pass);

                db.Users.Add(user);
                db.SaveChanges();
                registation registation = new registation();
                registation.Show();
                this.Hide();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            registation registation = new registation();
            registation.Show();
            this.Hide();
        }
    }
}
