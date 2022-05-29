using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UP_Exercise_2
{
    internal class ExceptionFunctions
    {
        public static Exception Ex_Double(string input_str, string data, double min = -1.7976931348623158e+308, double max = 1.7976931348623158e+308)
        {
            try
            {
                double result = Convert.ToDouble(input_str);
                if (result < min)
                {
                    throw new Exception($"Введено число {data} меньше минимального предела: {min}");
                }
                if (result > max)
                {
                    throw new Exception($"Введено число {data} больше максимального предела: {max}");
                }
            }
            catch (Exception ex)
            {
                return ex;
            }
            return null;
        }

        public static Exception Ex_Int(string input_str, string data, int min = -2147483648, int max = 2147483647)
        {
            try
            {
                int result = Convert.ToInt32(input_str);
                if (result < min)
                {
                    throw new Exception($"Введено число {data} меньше минимального предела: {min}");
                }
                if (result > max)
                {
                    throw new Exception($"Введено число {data} больше максимального предела: {max}");
                }
            }
            catch (Exception ex)
            {
                return ex;
            }
            return null;
        }
    }
    internal class MatrixFunctions
    {
        public static bool main_diag(int row, int column) { return row == column; }
        public static bool secondary_diag(int row, int column) { return row == MainWindow.count - column - 1; }
        public static bool top_triag(int row, int column) { return row <= column; }
        public static bool bottom_triag(int row, int column) { return row >= column; }
        public static bool left_triag(int row, int column) { return (row >= column && row < MainWindow.count / 2) || (row >= MainWindow.count / 2 && row < MainWindow.count - column); }
        public static bool right_triag(int row, int column) { return (row <= column && row >= MainWindow.count / 2) || (row < MainWindow.count / 2 && row > MainWindow.count - column - 2); }
        public static List<int> GetResult(int[,] matrix, int count, MainWindow.Function f)
        {
            int min = matrix.Cast<int>().Max();
            int max = matrix.Cast<int>().Min();
            int amount = 0;
            for (int row = 0; row < count; row++)
            {
                for (int column = 0; column < count; column++)
                {
                    if(f(row, column))
                    {
                        if (matrix[row, column] < min)
                        {
                            min = matrix[row, column];
                        }
                        if (matrix[row, column] > max)
                        {
                            max = matrix[row, column];
                        }
                        amount += matrix[row, column];
                    }
                }
            }
            List<int> result = new List<int> { amount, min, max };
            return result;
        }
    }
}