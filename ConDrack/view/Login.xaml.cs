using System;
using System.Collections.Generic;
using System.IO;
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
using System.Data.SQLite;
using System.Text.RegularExpressions;

namespace ConDrack.view
{
    /// <summary>
    /// Lógica de interacción para Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
            if (File.Exists("C:/database/User.db"))
            {
                main nas = new main();
                nas.Show();
                this.Close();
            }

        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                DragMove();
            }

        }

        private void mini_Click(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Normal)
            {
                WindowState = WindowState.Minimized;
            }
        }


        private void close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }



        private void inisioSesion(object sender, RoutedEventArgs e)
        {
            string nom = Convert.ToString(nombre.Text);
            string pwd = Convert.ToString(contra.Password);



            Regex re = new Regex(@"[a-z A-Z ]");
            Match m = re.Match(nom);

          Regex r = new Regex(@"[a-z A-Z 0-9 /d]");
            Match sd = r.Match(pwd);

          

            if (m.Success && sd.Success)
            {
           
           
                SQLiteConnection connection;

                if (!File.Exists("C:/database/User.db"))
                {
               
                    string pash = @"C:/database";

                    if (!File.Exists(pash))
                    {
                        DirectoryInfo info = Directory.CreateDirectory(pash);

                    }

                    try
                    {
                        string conStrin = "Data Source = C:/database/User.db";

                        connection = new SQLiteConnection(conStrin);

                        connection.Open();

                        string sqli = "CREATE TABLE user(IDUser integer PRIMARY KEY AUTOINCREMENT, NOMBRE TEXT , CONTRASENA TEXT)";

                        SQLiteCommand sQ = new SQLiteCommand(sqli, connection);

                        sQ.ExecuteNonQuery();

                        if (true)
                        {
                            string sl = "INSERT INTO user ('NOMBRE' , 'CONTRASENA') VALUES(@NOMBRE, @CONTRASENA)";

                            SQLiteCommand sQLite = new SQLiteCommand(sl, connection);

                            sQLite.Parameters.AddWithValue("@NOMBRE", $"{nom}");
                            sQLite.Parameters.AddWithValue("@CONTRASENA", $"{pwd}");
                            sQLite.ExecuteNonQuery();

                            this.Close();
                            
                            
                        }
                        
                    }
                    catch { }

                }
                MessageBox.Show("vuebe abrir la apps");

            }


           




        }
    }
}
