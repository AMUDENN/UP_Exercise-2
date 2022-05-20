using System;
using System.Data;
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
        public static List<List<int>> matrix = new List<List<int>>(count);
        public static int count = 10;
        public MainWindow()
        {
            InitializeComponent();
            Get_Random_Matrix(count);
        }
        private void Matrix_Out(List<List<int>> matrix)
        {
            MainDataGrid.RowHeight = 250 / count;
            MainDataGrid.ColumnWidth = 310 / count;
            DataTable data = new DataTable();

            for (int i = 0; i < matrix.Count; i++)
            {
                data.Columns.Add(i.ToString());
            }
            for (int row = 0; row < matrix.Count; row++)
            {
                DataRow datarow = data.NewRow();
                for (int col = 0; col < matrix.Count; col++)
                {
                    datarow[col] = matrix[row][col];
                }
                data.Rows.Add(datarow);
            }
            MainDataGrid.ItemsSource = data.DefaultView;
            All_Out();
        }

        private void SetSize_Button_Click(object sender, RoutedEventArgs e)
        {
            Exception ex = ExceptionFunctions.Ex_Int(size_tbox.Text, "Элемент матрицы", 1, 15);
            count = ex == null ? Convert.ToInt32(size_tbox.Text) : 10;
            Get_Random_Matrix(count);

        }

        private void Get_Random_Matrix(int count)
        {
            matrix = new List<List<int>>(count);
            Random rnd = new Random();
            for (int i = 0; i < count; i++)
            {
                List<int> int_row = new List<int>();
                for (int j = 0; j < count; j++)
                {
                    int_row.Add(rnd.Next(1, 100));
                }
                matrix.Add(int_row);
            }
            Matrix_Out(matrix);
            All_Out();
        }

        private void GetRandom_Button_Click(object sender, RoutedEventArgs e)
        {
            Get_Random_Matrix(count);
        }

        private void Set_Values_Click(object sender, RoutedEventArgs e)
        {
            var items = MainDataGrid.ItemsSource;
            int j = 0;

            foreach (DataRowView row in items)
            {
                for (int i = 0; i < matrix.Count; i++)
                {
                    Exception ex = ExceptionFunctions.Ex_Int(row[i].ToString(), "Элемент матрицы");
                    matrix[j][i] = ex == null ? Convert.ToInt32(row[i].ToString()) : 0;
                }
                j++;
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