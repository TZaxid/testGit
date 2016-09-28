using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattle
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] battleField = initBattleField();
        }

        static void print(int n, int m, int[][] battleField)
        {
            for (int i=0; i<n; i++)
            {
                for (int j=0; j<m; j++)
                {

                }
            }
        }

        static int[,] initBattleField(int n, int m)
        {
            int[,] battleField = new int[n,m];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    
                }
            }
            return ;
        }
    }
}
