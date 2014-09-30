using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections;
using System.ComponentModel;
using Microsoft.Win32;
namespace l1_1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            ArrayList myAL = new ArrayList();
            int i;

            int y, l = 1, t = 0;
            try
            {
                int itemCount = Convert.ToInt32(tbN.Text);
                int[] mas = new int[itemCount];
                // int k = Convert.ToInt32(tbN.Text);
                Random rnd1 = new Random();
                int number;
                lbMain.Items.Clear();
                lbMain.Items.Add("Исходный массив");
                for (i = 1; i <= itemCount; i++)
                {
                    number = rnd1.Next(1, 15);
                    mas[i - 1] = number;
                    myAL.Add(number);
                    lbMain.Items.Add(number);

                }

                // lbMain.Items.Add(myAL[0]);
                for (i = 1; i < itemCount - 1; i++)
                {

                    if (mas[i] > mas[i - 1] && mas[i] > mas[i + 1]) t++;
                }
                lbMain.Items.Add("элементов массива больших соседей=");
                lbMain.Items.Add(t);
            }
            catch
            {
                lbMain.Items.Clear();
                MessageBox.Show("Error!");
            }
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog myDialog = new SaveFileDialog();
            myDialog.Filter = "Текст(*.TXT)|*.TXT" + "|Все файлы (*.*)|*.* ";

            if (myDialog.ShowDialog() == true)
            {
                string filename = myDialog.FileName;
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(filename, false))
                {
                    foreach (Object item in lbMain.Items)
                    {
                        file.WriteLine(item);
                    }
                }
            }
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
