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
                Console.WriteLine("One or both vectors in not exist");
                return false;
            }
            if (vec1.vector.Length == vec2.vector.Length) return true;
            return false;
        }

        public static bool operator != (Vector vec1, Vector vec2)
        {
            if (vec1.vector == null || vec2.vector == null)
            {
                Console.WriteLine("One or both vectors in not exist");
                return false;
            }
            if (vec1.vector.Length != vec2.vector.Length) return true;
            return false;
        }

        public static Vector operator +(Vector vec1, Vector vec2)
        {
            try
            {
                Vector new_vector = new Vector(vec1.vector.Length);
                Console.Write("Addition ");
                Console.WriteLine();
                for (int i = 0; i < vec1.vector.Length || i < vec2.vector.Length; i++)
                    new_vector.vector[i] = vec1.vector[i] + vec2.vector[i];
                return new_vector;
            }
            catch
            {
                Console.WriteLine("Vector lengths are not equal, addition impossible");
                return null;
            }
        }
        
        public static Vector operator -(Vector vec1, Vector vec2)
        {
            try
            {
                Vector new_vector = new Vector(vec1.vector.Length);
                Console.Write("Subtraction ");
                Console.WriteLine();
                for (int i = 0; i < vec1.vector.Length || i < vec2.vector.Length; i++)
                    new_vector.vector[i] = vec1.vector[i] - vec2.vector[i];
                return new_vector;
            }
            catch
            {
                Console.WriteLine("Vector lengths are not equal, addition impossible");
                return null;
            }
        }
        
        public static Vector operator *(Vector vec1, Vector vec2)
        {
            try
            {
                Vector new_vector = new Vector(vec1.vector.Length);
                Console.Write("Multiplication ");
                Console.WriteLine();
                for (int i = 0; i < vec1.vector.Length || i < vec2.vector.Length; i++)
                    new_vector.vector[i] = vec1.vector[i] * vec2.vector[i];
                return new_vector;
            }
            catch
            {
                Console.WriteLine("Vector lengths are not equal, addition impossible");
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
        public static int[] add(int n)
        {
            int[] tmp = new int[n];
            for (int i = 0; i < n; i++)
            {
                Console.Write($"Enter the value of the vector:");
                tmp[i] = Convert.ToInt32(Console.ReadLine());
            }
            return tmp;
        }
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter the length vector");
            Console.WriteLine();
            int k1= Convert.ToInt32(Console.ReadLine()), k2 = Convert.ToInt32(Console.ReadLine());
            Vector vec1 = new Vector(add(k1)), vec2 = new Vector(add(k2)), tmp;
            Console.WriteLine();
            Console.WriteLine("Value vectors: ");
            vec1.output();
            vec2.output();
            try
            {
                tmp = vec1 + vec2;
                tmp.output();
                tmp = vec1 - vec2;
                tmp.output();
                tmp = vec1 * vec2;
                tmp.output();
            }
            catch
            {
                Console.WriteLine("Error");
            }
        }
    }
}