using System;
using System.Collections.Generic;
using System.Data;
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
using Пример_таблицы_WPF;

namespace lab1
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

        private void Button_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				//vvod razmera i sozdanie matrix i vivod matrix
				int n = Convert.ToInt32(val_N.Text);
				double[,] matrix = new double[n, n];
				Random rnd = new Random();
				for (int i = 0; i < n; i++)
				{
					for (int j = 0; j < n; j++)
					{
						matrix[i, j] = rnd.NextDouble();
					}
				}
				dataGrid_matrix.ItemsSource = VisualArray.ToDataTable(matrix).DefaultView;


				//gl diag
				double sum1 = 0;
				double sum2 = 0;
				for (int i = 0; i < n; i++)
				{
					sum1 += matrix[i, i];
					sum2 += matrix[i, n - i - 1];
				}
				maindig.Text = Convert.ToString(sum1);
				secdig.Text = Convert.ToString(sum2);
				//compare
				if (sum1 > sum2) rez.Text = "Summa main diag bolshe";
				else rez.Text = "Summa pb diag bolshe";
			}
			catch
			{
				{
					MessageBox.Show("Proizoshla oshibka", "Oshibka");
				}
			}
		}

		private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            dataGrid_matrix.ItemsSource = null;
            maindig.Text = null;
            secdig.Text = null;
            val_N.Text = null;
            rez.Text = null;
        }
    }
}
