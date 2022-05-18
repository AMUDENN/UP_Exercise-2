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
        public static List<int> Main_Diagonal(int[][] matrix)
        {
            int min = matrix[0][0];
            int max = matrix[0][0];
            int amount = 0;
            for (int i = 0; i < matrix.Length; i++)
            {
                if (matrix[i][i] < min)
                {
                    min = matrix[i][i];
                }
                if (matrix[i][i] > max)
                {
                    max = matrix[i][i];
                }
                amount += matrix[i][i];
            }
            List<int> result = new List<int> { amount, min, max };
            return result;
        }

        public static List<int> Secondary_Diagonal(int[][] matrix)
        {
            int min = matrix[0][0];
            int max = matrix[0][0];
            int amount = 0;
            for (int i = 0; i < matrix.Length; i++)
            {
                if (matrix[i][matrix.Length - i - 1] < min)
                {
                    min = matrix[i][matrix.Length - i - 1];
                }
                if (matrix[i][matrix.Length - i - 1] > max)
                {
                    max = matrix[i][matrix.Length - i - 1];
                }
                amount += matrix[i][matrix.Length - i - 1];
            }
            List<int> result = new List<int> { amount, min, max };
            return result;
        }

        public static List<int> Top_Triangle(int[][] matrix)
        {
            int min = matrix[0][0];
            int max = matrix[0][0];
            int amount = 0;
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = i; j < matrix[i].Length; j++)
                {
                    if (matrix[i][j] < min)
                    {
                        min = matrix[i][j];
                    }
                    if (matrix[i][j] > max)
                    {
                        max = matrix[i][j];
                    }
                    amount += matrix[i][j];
                }
            }
            List<int> result = new List<int> { amount, min, max };
            return result;
        }
        public static List<int> Bottom_Triangle(int[][] matrix)
        {
            int min = matrix[0][0];
            int max = matrix[0][0];
            int amount = 0;
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < i + 1; j++)
                {
                    if (matrix[i][j] < min)
                    {
                        min = matrix[i][j];
                    }
                    if (matrix[i][j] > max)
                    {
                        max = matrix[i][j];
                    }
                    amount += matrix[i][j];
                }
            }
            List<int> result = new List<int> { amount, min, max };
            return result;
        }
        public static List<int> Left_Triangle(int[][] matrix)
        {
            int min = matrix[0][0];
            int max = matrix[0][0];
            int amount = 0;

            int average = (int)Math.Ceiling(matrix.Length / 2.0);

            for (int i = 0; i < average; i++)
            {
                for (int j = 0; j < i + 1; j++)
                {
                    if (matrix[i][j] < min)
                    {
                        min = matrix[i][j];
                    }
                    if (matrix[i][j] > max)
                    {
                        max = matrix[i][j];
                    }
                    amount += matrix[i][j];
                }
            }
            for (int i = average; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix.Length - i; j++)
                {
                    if (matrix[i][j] < min)
                    {
                        min = matrix[i][j];
                    }
                    if (matrix[i][j] > max)
                    {
                        max = matrix[i][j];
                    }
                    amount += matrix[i][j];
                }
            }
            List<int> result = new List<int> { amount, min, max };
            return result;
        }
        public static List<int> Right_Triangle(int[][] matrix)
        {
            int min = matrix[0][0];
            int max = matrix[0][0];
            int amount = 0;

            int average = (int)Math.Ceiling(matrix.Length / 2.0);

            for (int i = 0; i < average; i++)
            {
                for (int j = matrix.Length - i - 1; j < matrix.Length; j++)
                {
                    if (matrix[i][j] < min)
                    {
                        min = matrix[i][j];
                    }
                    if (matrix[i][j] > max)
                    {
                        max = matrix[i][j];
                    }
                    amount += matrix[i][j];
                }
            }
            for (int i = average; i < matrix.Length; i++)
            {
                for (int j = i; j < matrix.Length; j++)
                {
                    if (matrix[i][j] < min)
                    {
                        min = matrix[i][j];
                    }
                    if (matrix[i][j] > max)
                    {
                        max = matrix[i][j];
                    }
                    amount += matrix[i][j];
                }
            }
            List<int> result = new List<int> { amount, min, max };
            return result;
        }
    }
}
