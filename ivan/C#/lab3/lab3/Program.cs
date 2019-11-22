using System;

namespace lab3
{
    class Vector
    {
         int[] vector;

        public Vector()
        {
            vector = null;
        }

        public Vector(int[] new_vector)
        {
            vector = new_vector;
        }

        public Vector(int n)
        {
            vector = new int[n];
            for (int i = 0; i < n; i++)
                vector[i] = i;
        }

        public static bool operator == (Vector vec1, Vector vec2)
        {
            if (vec1.vector == null || vec2.vector == null)
            {
                Console.WriteLine("Один или оба вектора не существует");
                return false;
            }
            if (vec1.vector.Length == vec2.vector.Length) return true;
            return false;
        }

        public static bool operator != (Vector vec1, Vector vec2)
        {
            if (vec1.vector == null || vec2.vector == null)
            {
                Console.WriteLine("Один или оба вектора не существует");
                return false;
            }
            if (vec1.vector.Length != vec2.vector.Length ) return true;
            return false;
        }

        public static Vector operator +(Vector vec1, Vector vec2)
        {
            try
            {
                Vector tmp = new Vector(vec1.vector.Length);
                Console.Write("Сложение ");
                Console.WriteLine();
                for (int i = 0; i < vec1.vector.Length || i < vec2.vector.Length; i++)
                    tmp.vector[i] = vec1.vector[i] + vec2.vector[i];
                return tmp;
            }
            catch 
            {
                Console.WriteLine("Длины векторов не равны, сложение невозможно");
                return null;
            }
        }
        
        public static Vector operator -(Vector vec1, Vector vec2)
        {
            try
            {
                Vector tmp = new Vector(vec1.vector.Length);
                Console.Write("Вычитание ");
                Console.WriteLine();
                for (int i = 0; i < vec1.vector.Length || i < vec2.vector.Length; i++)
                    tmp.vector[i] = vec1.vector[i] - vec2.vector[i];
                return tmp;
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Длины векторов не равны, сложение невозможно");
                return null;
            }
        }
        
        public static Vector operator *(Vector vec1, Vector vec2)
        {
            try
            {
                Vector tmp = new Vector(vec1.vector.Length);
                Console.Write("Умножение ");
                Console.WriteLine();
                for (int i = 0; i < vec1.vector.Length || i < vec2.vector.Length; i++)
                    tmp.vector[i] = vec1.vector[i] * vec2.vector[i];
                return tmp;
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Длины векторов не равны, сложение невозможно");
                return null;
            }
        }
        
        public void output()
        {
            for (int i = 0; i < vector.Length; i++)
                Console.Write("{0, 4}", vector[i]); 
            Console.WriteLine();    
        }
    }
  internal class Program
  {
      public static int c = 1;
        public static int[] add(int n)
        {
            int[] tmp2 = new int[n];
            for (int i = 0; i < n; i++)
            {
                Console.Write($"Введите значения для вектора {c}: ");
                tmp2[i] = Convert.ToInt32(Console.ReadLine());
            }
            c++;
            return tmp2;
        }
        public static void Main(string[] args)
        {
            string a = "-";
            Console.Write("Введите размер векторов их (2)");
            Console.WriteLine();
            int k1= Convert.ToInt32(Console.ReadLine()), k2 = Convert.ToInt32(Console.ReadLine());
            Vector vec1 = new Vector(add(k1)), vec2 = new Vector(add(k2)), tmp;
            Console.WriteLine();
            Console.WriteLine("Заданные вектора: ");
            Console.WriteLine(("").PadRight(24, '-'));
            vec1.output();
            vec2.output();
            Console.WriteLine(("").PadRight(24, '-'));
            tmp = vec1 + vec2;
            tmp.output();
            tmp = vec1 - vec2;
            tmp.output();
            tmp = vec1 * vec2;
            tmp.output();
        }
    }
}