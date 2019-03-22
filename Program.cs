using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LCSStringCompare
{
    class Program
    {
      public int[,] GetlcsMatrix( string[] sentence1, string[] sentence2)
        {
            


            int[,] lcsMatrix = new int[sentence1.Length+1, sentence2.Length+1];

            

            for(int i=0; i <= sentence1.Length;i++)
            {
                for(int j=0; j  <= sentence2.Length; j++)
                {
                    if(i==0 || j==0)
                    {
                        lcsMatrix[i, j] = 0;
                    }

                    if((i != 0 && j != 0) && sentence1[i-1] == sentence2[j-1])
                    {
                        lcsMatrix[i, j] = 1 + lcsMatrix[i-1, j - 1];
                    }
                    else if((i != 0 && j != 0) && sentence1[i - 1] != sentence2[j - 1])
                    {
                        lcsMatrix[i,j] =  Math.Max(lcsMatrix[i-1,j], lcsMatrix[i,j-1]);

                    }
                }
            }

            return lcsMatrix;
        }

        public void printMatrix(string[] sentence1, string[] sentence2)
        {
            

            for (int x = 0; x <= sentence1.Length; x++)
            {
                for (int y = 0; y <= sentence2.Length; y++)
                {
                    Console.Write(GetlcsMatrix(sentence1, sentence2)[x, y]);
                }
                Console.WriteLine("\n");
            }


            Console.ReadLine();

        }

        public void GetLCSString(int[,] lcsMatrix, string[] sentence1, string[] sentence2, int m,int n)
        {

            int i = m + 1;
            int j = n + 1;

            if(i > 0 && j > 0 && sentence1[m] == sentence2 [n])
            {
                GetLCSString(lcsMatrix, sentence1, sentence2, m - 1, n - 1);
                Console.Write( sentence1[m]+ " ");

                
            }
            else if( i > 0 && j > 0)
            {
                
                if( lcsMatrix[i,j] ==  lcsMatrix[i-1,j])
                {
                    GetLCSString(lcsMatrix, sentence1, sentence2, m - 1, n);
                }
                else 
                {
                    GetLCSString(lcsMatrix, sentence1, sentence2, m , n-1);
                }
            }
        }

        public void percentPart(int[,] lcsMatrix, int i , int j)
        {
                  
            Console.WriteLine("\nFirst sentence is " + Math.Round((decimal)(lcsMatrix[i, j] * 100) / i,2)+"% copied from second sentence.");
            Console.WriteLine("\nSecond sentence is " + Math.Round((decimal)(lcsMatrix[i, j] * 100) / j,2 )+ "% copied from first sentence.");
        }

        static void Main(string[] args)
        {

            Program p = new Program();
            //Console.WriteLine("Enter first string");
            string sen1 = "Hi I am Karan and I love food.";
            //string sen1 = "a c b a e d";

            //Console.WriteLine("Enter second string");
            string sen2 = "Hello I am Karan and I dont love food.";
            //string sen2 = "a b c a d f a";


            string[] sentence1 = sen1.Split(' ');
            string[] sentence2 = sen2.Split(' ');

            p.GetlcsMatrix(sentence1, sentence2);

            p.printMatrix(sentence1, sentence2);

            Console.WriteLine("Sentence 1: " + sen1);
            Console.WriteLine("Sentence 2: " + sen2);
            Console.Write("Copied sentence structure: ");
            p.GetLCSString(p.GetlcsMatrix(sentence1, sentence2), sentence1, sentence2, sentence1.Length-1,sentence2.Length-1);
            Console.WriteLine("\n");

            p.percentPart(p.GetlcsMatrix(sentence1, sentence2), sentence1.Length,sentence2.Length);
          

            Console.ReadLine();
        }
    }
}
