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
        public MainWindow()
        {
            InitializeComponent();
            Get_Random_Matrix(count);
        }
        private void Matrix_Out(int[,] matrix)
        {
            MainUniformGrid.Children.Clear();
            for (int row = 0; row < count; row++)
            {
                for (int col = 0; col < count; col++)
                {
                    TextBox tb = new TextBox
                    {
                        Text = matrix[row, col].ToString(),
                        Style = (Style)Application.Current.Resources["MatrixTextBoxStyle"]
                    };
                    MainUniformGrid.Children.Add(tb);
                }
            }
            All_Out();
        }
        private void SetSize_Button_Click(object sender, RoutedEventArgs e)
        {
            Exception ex = ExceptionFunctions.Ex_Int(size_tbox.Text, "Размер матрицы", 1, 15);
            count = ex == null ? Convert.ToInt32(size_tbox.Text) : 10;
            Get_Random_Matrix(count);
        }
        private void Get_Random_Matrix(int count)
        {
            matrix = new int[count, count];
            for (int i = 0; i < count; i++)
            {
                for (int j = 0; j < count; j++)
                {
                    matrix[i, j] = rnd.Next(1, 100);
                }
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
            var items = MainUniformGrid.Children;
            int i = 0;
            int j = 0;
            foreach (TextBox tb in items)
            {
                Exception ex = ExceptionFunctions.Ex_Int(tb.Text, "Элемент матрицы");
                matrix[j, i] = ex == null ? Convert.ToInt32(tb.Text) : 0;
                i++;
                if (i % count == 0) { j++; i = 0; }
            }
            Matrix_Out(matrix);
            All_Out();
        }
        private void All_Out()
        {
            List<int> main_diag = MatrixFunctions.Main_Diagonal(matrix, count);
            List<int> second_diag = MatrixFunctions.Secondary_Diagonal(matrix, count);
            List<int> top_triang = MatrixFunctions.Top_Triangle(matrix, count);
            List<int> bottom_triang = MatrixFunctions.Bottom_Triangle(matrix, count);
            List<int> left_triang = MatrixFunctions.Left_Triangle(matrix, count);
            List<int> right_triang = MatrixFunctions.Right_Triangle(matrix, count);
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
        private void Main_hl(object sender, EventArgs e)
        {
            var items = MainUniformGrid.Children;
            int i = 0;
            int j = 0;
            foreach (TextBox tb in items)
            {
                if(i == j)
                {
                    tb.Style = (Style)Application.Current.Resources["MatrixHLTextBoxStyle"];
                }
                i++;
                if (i % count == 0) { j++; i = 0; }
            }
        }
        private void Secondary_hl(object sender, EventArgs e)
        {
            var items = MainUniformGrid.Children;
            int i = 0;
            int j = 0;
            foreach (TextBox tb in items)
            {
                if (i == count - j - 1)
                {
                    tb.Style = (Style)Application.Current.Resources["MatrixHLTextBoxStyle"];
                }
                i++;
                if (i % count == 0) { j++; i = 0; }
            }
        }
        private void Top_hl(object sender, EventArgs e)
        {
            var items = MainUniformGrid.Children;
            int i = 0;
            int j = 0;
            foreach (TextBox tb in items)
            {
                if (i >= j)
                {
                    tb.Style = (Style)Application.Current.Resources["MatrixHLTextBoxStyle"];
                }
                i++;
                if (i % count == 0) { j++; i = 0; }
            }
        }
        private void Bottom_hl(object sender, EventArgs e)
        {
            var items = MainUniformGrid.Children;
            int i = 0;
            int j = 0;
            foreach (TextBox tb in items)
            {
                if (i <= j)
                {
                    tb.Style = (Style)Application.Current.Resources["MatrixHLTextBoxStyle"];
                }
                i++;
                if (i % count == 0) { j++; i = 0; }
            }
        }
        private void Left_hl(object sender, EventArgs e)
        {
            var items = MainUniformGrid.Children;
            int i = 0;
            int j = 0;
            int average = (int)Math.Ceiling(count / 2.0);
            foreach (TextBox tb in items)
            {
                if (i <= j && j < average)
                {
                    tb.Style = (Style)Application.Current.Resources["MatrixHLTextBoxStyle"];
                }
                if (j >= average && i < count - j)
                {
                    tb.Style = (Style)Application.Current.Resources["MatrixHLTextBoxStyle"];
                }
                i++;
                if (i % count == 0) { j++; i = 0; }
            }
        }
        private void Right_hl(object sender, EventArgs e)
        {
            var items = MainUniformGrid.Children;
            int i = 0;
            int j = 0;
            int average = (int)Math.Ceiling(count / 2.0);
            foreach (TextBox tb in items)
            {
                if (i >= count - j - 1 && j < average)
                {
                    tb.Style = (Style)Application.Current.Resources["MatrixHLTextBoxStyle"];
                }
                if (i>=j && j >= average)
                {
                    tb.Style = (Style)Application.Current.Resources["MatrixHLTextBoxStyle"];
                }
                i++;
                if (i % count == 0) { j++; i = 0; }
            }
        }
        private void Mouse_Leave(object sender, EventArgs e)
        {
            var items = MainUniformGrid.Children;
            foreach (TextBox tb in items)
            {
                tb.Style = (Style)Application.Current.Resources["MatrixTextBoxStyle"];
            }
        }
    }
}