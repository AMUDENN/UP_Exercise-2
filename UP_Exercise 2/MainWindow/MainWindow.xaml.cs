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
using System.Collections.ObjectModel;

namespace UP_Exercise_2
{
    public partial class MainWindow : Window
    {
        static int[][] matrix = new int[10][];
        public MainWindow()
        {
            InitializeComponent();
            Get_Random_Matrix();

        }
        private void Matrix_Out(int[][] matrix)
        {
            ObservableCollection<string[]> data = new ObservableCollection<string[]> { };
            for (int i = 0; i < matrix.Length; i++)
            {
                string[] rows = new string[matrix[i].Length];
                for (int j = 0; j < rows.Length; j++)
                {
                    rows[j] = Convert.ToString(matrix[i][j]);
                }
                data.Add(rows);
            }
            MainDataGrid.ItemsSource = data;
            All_Out();
        }
        private void Get_Random_Matrix()
        {
            Random rnd = new Random();
            for (int i = 0; i < matrix.Length; i++)
            {
                int[] int_row = new int[matrix.Length];
                int num;
                for (int j = 0; j < int_row.Length; j++)
                {
                    num = rnd.Next(1, 100);
                    int_row[j] = num;
                }
                matrix[i] = int_row;
            }
            Matrix_Out(matrix);
            All_Out();
        }

        private void GetRandom_Button_Click(object sender, RoutedEventArgs e)
        {
            Get_Random_Matrix();
        }

        private void Set_Values_Click(object sender, RoutedEventArgs e)
        {
            var items = MainDataGrid.ItemsSource;
            int i = 0;
            int j = 0;
            foreach (string[] elem in items)
            {
                string[] row = elem;
                j = 0;
                foreach (var item in row)
                {
                    Exception ex = ExceptionFunctions.Ex_Int(item, "Элемент матрицы");
                    if (ex == null)
                    {
                        matrix[i][j] = Convert.ToInt32(item);
                    }
                    else
                    {
                        matrix[i][j] = 0;
                    }
                    j++;
                }
                i++;
            }
            Matrix_Out(matrix);
            All_Out();
        }

        private void All_Out()
        {
            List<int> main_diag = MatrixFunctions.Main_Diagonal(matrix);
            List<int> second_diag = MatrixFunctions.Secondary_Diagonal(matrix);
            List<int> top_triang = MatrixFunctions.Top_Triangle(matrix);
            List<int> bottom_triang = MatrixFunctions.Bottom_Triangle(matrix);
            List<int> left_triang = MatrixFunctions.Left_Triangle(matrix);
            List<int> right_triang = MatrixFunctions.Right_Triangle(matrix);
            maindiagonal_amount.Text = Convert.ToString(main_diag[0]);
            maindiagonal_min.Text = Convert.ToString(main_diag[1]);
            maindiagonal_max.Text = Convert.ToString(main_diag[2]);
            secondarydiagonal_amount.Text = Convert.ToString(second_diag[0]);
            secondarydiagonal_min.Text = Convert.ToString(second_diag[1]);
            secondarydiagonal_max.Text = Convert.ToString(second_diag[2]);
            toptriangle_amount.Text = Convert.ToString(top_triang[0]);
            toptriangle_min.Text = Convert.ToString(top_triang[1]);
            toptriangle_max.Text = Convert.ToString(top_triang[2]);
            bottomtriangle_amount.Text = Convert.ToString(bottom_triang[0]);
            bottomtriangle_min.Text = Convert.ToString(bottom_triang[1]);
            bottomtriangle_max.Text = Convert.ToString(bottom_triang[2]);
            lefttriangle_amount.Text = Convert.ToString(left_triang[0]);
            lefttriangle_min.Text = Convert.ToString(left_triang[1]);
            lefttriangle_max.Text = Convert.ToString(left_triang[2]);
            righttriangle_amount.Text = Convert.ToString(right_triang[0]);
            righttriangle_min.Text = Convert.ToString(right_triang[1]);
            righttriangle_max.Text = Convert.ToString(right_triang[2]);
        }
    }
}