using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DamasInglesas
{
    /*
     * 1 = Fichas blancas
     * 0 = lugar vacio
     * -1 = Fichas negras
     */
    class Tablero
    {
        private int[,] matriz;
        private int n;
        private int nBlancas;
        private int nNegras;

        public Tablero()
        {
            nBlancas = 0;
            nNegras = 0;
            n = 8;
            matriz = new int[n,n];
            init();
            imprimir();
        }

        public void init()
        {
            for(int i=0; i<n; i++)
            {
                for (int j=0; j < n; j++)
                {
                    if((i%2==0 && j%2 != 0 || i % 2 != 0 && j % 2 == 0 )&& i < 3)
                    {
                        matriz[i, j] = 1;
                        nBlancas++;
                    }

                    if((i % 2 == 0 && j % 2 != 0 || i % 2 != 0 && j % 2 == 0) && i>2 && i < 5)
                    {
                        matriz[i, j] = 2;
                    }

                    if ((i % 2 == 0 && j % 2 != 0 || i % 2 != 0 && j % 2 == 0) && i > 4)
                    {
                        matriz[i, j] = -1;
                        nNegras++;
                    }
                }
            }
        }

      /*  public int[] getPos(int i, int j )
        {
            int[] movs;
            if(matriz[i-1,j-1] == 2)
            {
                movs[]
            }
            if(matriz[i-1,j+1] == 2)
            {

            }
        }*/

        public void imprimir()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(matriz[i,j]+"-");
                }
                Console.WriteLine();
            }
        }
    }
}
