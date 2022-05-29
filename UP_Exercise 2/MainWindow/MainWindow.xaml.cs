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
        public static int[,] matrix = new int[,] { };
        public static int count = 10;
        public static Random rnd = new Random();
        public delegate bool Function(int row, int column);
        public MainWindow()
        {
            InitializeComponent();
            matrix = MatrixFunctions.Get_Random_Matrix(count, rnd);
            Matrix_Out(matrix);
            Data_Out();
        }
        private void Matrix_Out(int[,] matrix)
        {
            MainUniformGrid.Children.Clear();
            for (int row = 0; row < count; row++)
            {
                for (int column = 0; column < count; column++)
                {
                    TextBox tb = new TextBox
                    {
                        Text = matrix[row, column].ToString(),
                        Style = (Style)Application.Current.Resources["MatrixTextBoxStyle"],
                        FontSize = 27 - count
                    };
                    MainUniformGrid.Children.Add(tb);
                }
            }
        }
        private void SetSize_Button_Click(object sender, RoutedEventArgs e)
        {
            Exception ex = ExceptionFunctions.Ex_Int(size_tbox.Text, "Размер матрицы", 1, 15);
            count = ex == null ? Convert.ToInt32(size_tbox.Text) : 10;
            matrix = MatrixFunctions.Get_Random_Matrix(count, rnd);
            Matrix_Out(matrix);
            Data_Out();
        }
        private void GetRandom_Button_Click(object sender, RoutedEventArgs e)
        {
            matrix = MatrixFunctions.Get_Random_Matrix(count, rnd);
            Matrix_Out(matrix);
            Data_Out();
        }
        private void Set_Values_Click(object sender, RoutedEventArgs e)
        {
            var items = MainUniformGrid.Children;
            int row = 0, column = 0;
            foreach (TextBox tb in items)
            {
                Exception ex = ExceptionFunctions.Ex_Int(tb.Text, "Элемент матрицы");
                matrix[row, column] = ex == null ? Convert.ToInt32(tb.Text) : 0;
                column++;
                if (column % count == 0) { row++; column = 0; }
            }
            Matrix_Out(matrix);
            Data_Out();
        }
        private void Data_Out()
        {
            List<int> main_diag = MatrixFunctions.GetResult(matrix, count, MatrixFunctions.main_diag);
            List<int> second_diag = MatrixFunctions.GetResult(matrix, count, MatrixFunctions.secondary_diag);
            List<int> top_triang = MatrixFunctions.GetResult(matrix, count, MatrixFunctions.top_triag);
            List<int> bottom_triang = MatrixFunctions.GetResult(matrix, count, MatrixFunctions.bottom_triag);
            List<int> left_triang = MatrixFunctions.GetResult(matrix, count, MatrixFunctions.left_triag);
            List<int> right_triang = MatrixFunctions.GetResult(matrix, count, MatrixFunctions.right_triag);
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
        private void HighLighting(Function f, Style style)
        {
            int row = 0, column = 0;
            foreach (TextBox tb in MainUniformGrid.Children)
            {
                if (f(row, column))
                {
                    tb.Style = style;
                    tb.FontSize = 28 - count;
                }
                column++;
                if (column % count == 0) { row++; column = 0; }
            }
        }
        private void Main_hl(object sender, EventArgs e)
        {
            HighLighting(MatrixFunctions.main_diag, (Style)Application.Current.Resources["MatrixHLTextBoxStyle"]);
        }
        private void Secondary_hl(object sender, EventArgs e)
        {
            HighLighting(MatrixFunctions.secondary_diag, (Style)Application.Current.Resources["MatrixHLTextBoxStyle"]);
        }
        private void Top_hl(object sender, EventArgs e)
        {
            HighLighting(MatrixFunctions.top_triag, (Style)Application.Current.Resources["MatrixHLTextBoxStyle"]);
        }
        private void Bottom_hl(object sender, EventArgs e)
        {
            HighLighting(MatrixFunctions.bottom_triag, (Style)Application.Current.Resources["MatrixHLTextBoxStyle"]);
        }
        private void Left_hl(object sender, EventArgs e)
        {
            HighLighting(MatrixFunctions.left_triag, (Style)Application.Current.Resources["MatrixHLTextBoxStyle"]);
        }
        private void Right_hl(object sender, EventArgs e)
        {
            HighLighting(MatrixFunctions.right_triag, (Style)Application.Current.Resources["MatrixHLTextBoxStyle"]);
        }
        private void Mouse_Leave(object sender, EventArgs e)
        {
            foreach (TextBox tb in MainUniformGrid.Children)
            {
                tb.Style = (Style)Application.Current.Resources["MatrixTextBoxStyle"];
                tb.FontSize = 27 - count;
            }
        }
    }
}