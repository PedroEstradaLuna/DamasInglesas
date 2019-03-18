using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DamasInglesas
{
    /*
     * 1 = Fichas blancas
     * 0 = lugar vacio
     * -1 = Fichas negras
     */
    public class Tablero
    {
        private int[,] matriz;
        private int n;
        private int nBlancas;
        private int nNegras;
        private int nQueens;
        private double f;

        public Tablero()
        {
            nBlancas = 0;
            nNegras = 0;
            nQueens = 0;
            n = 8;
            matriz = new int[n,n];
            inicializarTablero();
            f = 0;
            //imprimir();
        }

        public void inicializarTablero()
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

        public int[,] getMatriz()
        {
            return matriz;
        }

        public void updateMatriz(int[,] m)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    matriz[i, j] = m[i, j];
                }
            }
        }

        public int getCountBlancas()
        {
            return nBlancas;
        }

        public int getCountNegras()
        {
            return nNegras;
        }

        public int getQueens()
        {
            return nQueens;
        }

        public void setNegra(List<int> origen, List<int> destino)
        {
            matriz[origen[0], origen[1]] = 2;
            matriz[destino[0], destino[1]] = -1;
        }

        public double getF() { return f; }

        public void setF(double f) { this.f = f; }
    }
}
