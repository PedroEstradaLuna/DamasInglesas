using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DamasInglesas
{
    public partial class Form1 : Form
    {
        private Tablero inicial;
        private PictureBox[] images;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            images = new PictureBox[32];
            images[0] = b01;
            images[1] = b03;
            images[2] = b05;
            images[3] = b07;
            images[4] = b10;
            images[5] = b12;
            images[6] = b14;
            images[7] = b16;

            images[8] = b21;
            images[9] = b23;
            images[10] = b25;
            images[11] = b27;
            images[12] = b30;
            images[13] = b32;
            images[14] = b34;
            images[15] = b36;

            images[16] = b41;
            images[17] = b43;
            images[18] = b45;
            images[19] = b47;
            images[20] = b50;
            images[21] = b52;
            images[22] = b54;
            images[23] = b56;

            images[24] = b61;
            images[25] = b63;
            images[26] = b65;
            images[27] = b67;
            images[28] = b70;
            images[29] = b72;
            images[30] = b74;
            images[31] = b76;
            inicial = new Tablero();
            init();
        }

        private void init()
        {
            //Fichas blancas
            b01.Image = global::DamasInglesas.Properties.Resources.white;
            b03.Image = global::DamasInglesas.Properties.Resources.white;
            b05.Image = global::DamasInglesas.Properties.Resources.white;
            b07.Image = global::DamasInglesas.Properties.Resources.white;
            b10.Image = global::DamasInglesas.Properties.Resources.white;
            b12.Image = global::DamasInglesas.Properties.Resources.white;
            b14.Image = global::DamasInglesas.Properties.Resources.white;
            b16.Image = global::DamasInglesas.Properties.Resources.white;
            b21.Image = global::DamasInglesas.Properties.Resources.white;
            b23.Image = global::DamasInglesas.Properties.Resources.white;
            b25.Image = global::DamasInglesas.Properties.Resources.white;
            b27.Image = global::DamasInglesas.Properties.Resources.white;

            //Fichas negras
            b50.Image = global::DamasInglesas.Properties.Resources.black;
            b52.Image = global::DamasInglesas.Properties.Resources.black;
            b54.Image = global::DamasInglesas.Properties.Resources.black;
            b56.Image = global::DamasInglesas.Properties.Resources.black;
            b61.Image = global::DamasInglesas.Properties.Resources.black;
            b63.Image = global::DamasInglesas.Properties.Resources.black;
            b65.Image = global::DamasInglesas.Properties.Resources.black;
            b67.Image = global::DamasInglesas.Properties.Resources.black;
            b70.Image = global::DamasInglesas.Properties.Resources.black;
            b72.Image = global::DamasInglesas.Properties.Resources.black;
            b74.Image = global::DamasInglesas.Properties.Resources.black;
            b76.Image = global::DamasInglesas.Properties.Resources.black;

            countNegras.Text = inicial.getCountBlancas().ToString();
            countBlancas.Text = inicial.getCountBlancas().ToString();
        }

        public void generarArbol()
        {
            Tablero actual = inicial; // cambiar luego
            List<Tablero> hijos = new List<Tablero>();
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (i + 1 < 8 && j - 1 > 0)
                    {
                        List<int> aux = getPos(actual, i, j);
                        if (aux.Count > 0) //Puede hacer un movimiento
                        {
                            if (aux.Count == 2)
                            {
                                Tablero hijo = actual;
                                avanzar(hijo, aux[0], aux[1]);
                            }
                            else if (aux.Count == 4)
                            {

                            }
                        }
                    }
                }
            }
        }

        public List<int> getPos(Tablero tablero,int i, int j)
        {
            int[,] m = tablero.getMatriz();
            List<int> movs = new List<int>();
            try
            {
                if (m[i + 1, j - 1] == 2)
                {
                    movs.Add(i + 1); // guardando el renglon nuevo
                    movs.Add(j - 1); //guardando la direccion izquierda
                }
                if (m[i + 1, j + 1] == 2)
                {
                    movs.Add(i + 1); // guardando el renglon nuevo
                    movs.Add(j + 1); //guardando la direccion derecha
                }
                tablero.updateMatriz(m);
            }
            catch (Exception e) { }


            return movs;
        }

        public void sincronizar(int i, int j)
        {
            String concatenar = i.ToString() + j.ToString();
            switch (concatenar)
            {
                case "01": images[0].Image = global::DamasInglesas.Properties.Resources.white; break;
                case "03": images[1].Image = global::DamasInglesas.Properties.Resources.white; break;
                case "05": images[2].Image = global::DamasInglesas.Properties.Resources.white; break;
                case "07": images[3].Image = global::DamasInglesas.Properties.Resources.white; break;
                case "10": images[4].Image = global::DamasInglesas.Properties.Resources.white; break;
                case "12": images[5].Image = global::DamasInglesas.Properties.Resources.white; break;
                case "14": images[6].Image = global::DamasInglesas.Properties.Resources.white; break;
                case "16": images[7].Image = global::DamasInglesas.Properties.Resources.white; break;
                case "21": images[8].Image = global::DamasInglesas.Properties.Resources.white; break;
                case "23": images[9].Image = global::DamasInglesas.Properties.Resources.white; break;
                case "25": images[10].Image = global::DamasInglesas.Properties.Resources.white; break;
                case "27": images[11].Image = global::DamasInglesas.Properties.Resources.white; break;
                case "30": images[12].Image = global::DamasInglesas.Properties.Resources.white; break;
                case "32": images[13].Image = global::DamasInglesas.Properties.Resources.white; break;
                case "34": images[14].Image = global::DamasInglesas.Properties.Resources.white; break;
                case "36": images[15].Image = global::DamasInglesas.Properties.Resources.white; break;
                case "41": images[16].Image = global::DamasInglesas.Properties.Resources.white; break;
                case "43": images[17].Image = global::DamasInglesas.Properties.Resources.white; break;
                case "45": images[18].Image = global::DamasInglesas.Properties.Resources.white; break;
                case "47": images[19].Image = global::DamasInglesas.Properties.Resources.white; break;
                case "50": images[20].Image = global::DamasInglesas.Properties.Resources.white; break;
                case "52": images[21].Image = global::DamasInglesas.Properties.Resources.white; break;
                case "54": images[22].Image = global::DamasInglesas.Properties.Resources.white; break;
                case "56": images[23].Image = global::DamasInglesas.Properties.Resources.white; break;
                case "61": images[24].Image = global::DamasInglesas.Properties.Resources.white; break;
                case "63": images[25].Image = global::DamasInglesas.Properties.Resources.white; break;
                case "65": images[26].Image = global::DamasInglesas.Properties.Resources.white; break;
                case "67": images[27].Image = global::DamasInglesas.Properties.Resources.white; break;
                case "70": images[28].Image = global::DamasInglesas.Properties.Resources.white; break;
                case "72": images[29].Image = global::DamasInglesas.Properties.Resources.white; break;
                case "74": images[30].Image = global::DamasInglesas.Properties.Resources.white; break;
                case "76": images[31].Image = global::DamasInglesas.Properties.Resources.white; break;
            }
        }

        public void avanzar(Tablero t, int x, int y)
        {
            int[,] matriz = t.getMatriz();
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if()
                }
            }
        }

        public void comerUno()
        {

        }

        public void comerDos()
        {

        }

        private void b01_Click(object sender, EventArgs e)
        {

        }

        private void b03_Click(object sender, EventArgs e)
        {

        }

        private void b05_Click(object sender, EventArgs e)
        {

        }

        private void b07_Click(object sender, EventArgs e)
        {

        }

        private void b10_Click(object sender, EventArgs e)
        {

        }

        private void b12_Click(object sender, EventArgs e)
        {

        }

        private void b14_Click(object sender, EventArgs e)
        {

        }

        private void b16_Click(object sender, EventArgs e)
        {

        }

        private void b21_Click(object sender, EventArgs e)
        {

        }

        private void b23_Click(object sender, EventArgs e)
        {

        }

        private void b25_Click(object sender, EventArgs e)
        {

        }

        private void b27_Click(object sender, EventArgs e)
        {

        }

        private void b30_Click(object sender, EventArgs e)
        {

        }

        private void b32_Click(object sender, EventArgs e)
        {

        }

        private void b34_Click(object sender, EventArgs e)
        {

        }

        private void b36_Click(object sender, EventArgs e)
        {

        }

        private void b41_Click(object sender, EventArgs e)
        {

        }

        private void b43_Click(object sender, EventArgs e)
        {

        }

        private void b45_Click(object sender, EventArgs e)
        {

        }

        private void b47_Click(object sender, EventArgs e)
        {

        }

        private void b50_Click(object sender, EventArgs e)
        {

        }

        private void b52_Click(object sender, EventArgs e)
        {
            if(b52.Image != null)
            {

            }
        }

        private void b54_Click(object sender, EventArgs e)
        {

        }

        private void b56_Click(object sender, EventArgs e)
        {

        }

        private void b61_Click(object sender, EventArgs e)
        {

        }

        private void b63_Click(object sender, EventArgs e)
        {

        }

        private void b65_Click(object sender, EventArgs e)
        {

        }

        private void b67_Click(object sender, EventArgs e)
        {

        }

        private void b70_Click(object sender, EventArgs e)
        {

        }

        private void b72_Click(object sender, EventArgs e)
        {

        }

        private void b74_Click(object sender, EventArgs e)
        {

        }
        private void b76_Click(object sender, EventArgs e)
        {

        }
    }
}
