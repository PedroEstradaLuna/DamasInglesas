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
        private List<int> origen;
        private List<int> destino;
        private Boolean turno = true;
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

            //b43.Image = Properties.Resources.white;

            inicial = new Tablero();
            init();

            origen = new List<int>();
            destino = new List<int>();
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
            generarArbol();
        }

        public void generarArbol()
        {
            int[,] matriz = inicial.getMatriz();
            List<Tablero> hijos = new List<Tablero>();
            List<int> posicion = new List<int>();
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if(matriz[i,j] == 1)
                    {
                        posicion = getPos(inicial, i, j);
                        if(posicion.Count == 4)
                        {
                            Tablero tab = new Tablero();
                            actualizar(posicion, tab, false);
                            hijos.Add(tab);
                        }
                        else if(posicion.Count == 6)
                        {
                            Tablero tab = new Tablero();
                            Tablero tab2 = new Tablero();
                            actualizar(posicion, tab, false);
                            actualizar(posicion, tab2, true);
                            hijos.Add(tab);
                            hijos.Add(tab2);
                        }
                    }
                }
            }
            for(int i = 0; i < hijos.Count; i++)
            {
                hijos[i].imprimir();
                asignarPeso(hijos[i]);
                Console.WriteLine("Peso del hijo "+i+": "+hijos[i].getF().ToString());
            }
        }

        public Tablero poda()
        {
            Tablero res = new Tablero();
            return res;
        }

        // h1: n° de piezas adversario
        // h2: n° de piezas IA
        // h3: n° de Queens IA
        // h4: n° de Queens adversario REVISIÓN
        // FUNCION PERRONA: (h1/12*0.6)+(h2/12*0.3)+(h3/4*0.1)

        public void asignarPeso(Tablero tab)
        {
            double res;
            double h1 = tab.getCountNegras() / 12;
            double h2 = tab.getCountBlancas() / 12;
            double h3 = tab.getQueens() / 4;

            res = (h1 * 0.6) + (h2 * 0.3) + (h3 * 0.1);

            tab.setF(res);
        }

        public void actualizar(List<int> nuevo,Tablero tab,Boolean a)
        {
            int[,] m = tab.getMatriz();
            m[nuevo[0], nuevo[1]] = 2;
            if(!a)
                m[nuevo[2], nuevo[3]] = 1;
            else
                m[nuevo[4], nuevo[5]] = 1;
            tab.updateMatriz(m);
        }

        public List<int> getPos(Tablero tablero,int i, int j)
        {
            int[,] m = tablero.getMatriz();
            List<int> movs = new List<int>();
            try
            {
                movs.Add(i);
                movs.Add(j);
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
            duplas(0, 1);
        }

        private void b03_Click(object sender, EventArgs e)
        {
            duplas(0, 3);
        }

        private void b05_Click(object sender, EventArgs e)
        {
            duplas(0, 5);
        }

        private void b07_Click(object sender, EventArgs e)
        {
            duplas(0, 7);
        }

        private void b10_Click(object sender, EventArgs e)
        {
            duplas(1, 0);
        }

        private void b12_Click(object sender, EventArgs e)
        {
            duplas(1, 2);
        }

        private void b14_Click(object sender, EventArgs e)
        {
            duplas(1, 4);
        }

        private void b16_Click(object sender, EventArgs e)
        {
            duplas(1, 6);
        }

        private void b21_Click(object sender, EventArgs e)
        {
            duplas(2, 1);
        }

        private void b23_Click(object sender, EventArgs e)
        {
            duplas(2, 3);
        }

        private void b25_Click(object sender, EventArgs e)
        {
            duplas(2, 5);
        }

        private void b27_Click(object sender, EventArgs e)
        {
            duplas(2, 7);
        }

        private void b30_Click(object sender, EventArgs e)
        {
            duplas(3, 0);
        }

        private void b32_Click(object sender, EventArgs e)
        {
            duplas(3, 2);
        }

        private void b34_Click(object sender, EventArgs e)
        {
            duplas(3, 4);
        }

        private void b36_Click(object sender, EventArgs e)
        {
            duplas(3, 6);
        }

        private void b41_Click(object sender, EventArgs e)
        {
            duplas(4, 1);
        }

        private void b43_Click(object sender, EventArgs e)
        {
            duplas(4, 3);
        }

        private void b45_Click(object sender, EventArgs e)
        {
            duplas(4, 5);
        }

        private void b47_Click(object sender, EventArgs e)
        {
            duplas(4, 7);
        }

        private void b50_Click(object sender, EventArgs e)
        {
            duplas(5, 0);
        }

        private void b52_Click(object sender, EventArgs e)
        {
            duplas(5, 2);
        }

        private void b54_Click(object sender, EventArgs e)
        {
            duplas(5, 4);
        }

        private void b56_Click(object sender, EventArgs e)
        {
            duplas(5, 6);
        }

        private void b61_Click(object sender, EventArgs e)
        {
            duplas(6, 1);
        }

        private void b63_Click(object sender, EventArgs e)
        {
            duplas(6, 3);
        }

        private void b65_Click(object sender, EventArgs e)
        {
            duplas(6, 5);
        }

        private void b67_Click(object sender, EventArgs e)
        {
            duplas(6, 7);
        }

        private void b70_Click(object sender, EventArgs e)
        {
            duplas(7, 0);
        }

        private void b72_Click(object sender, EventArgs e)
        {
            duplas(7, 2);
        }

        private void b74_Click(object sender, EventArgs e)
        {
            duplas(7, 4);
        }
        private void b76_Click(object sender, EventArgs e)
        {
            duplas(7, 6);
        }


        //---------------------- MOVIMIENTO FICHA NEGRA
        public void duplas(int i,int j)
        {
            if(turno)
                if (origen.Count == 0)
                {
                    // ficha seleccionada
                    origen.Add(i);
                    origen.Add(j);

                    destino = comerNegras();
                    if (destino.Count > 1)
                    {
                        //bloquear todos menos el que necesit comer

                    }
                }
                else if(origen.Count>1 && destino.Count == 0 && (i != origen[0] && j != origen[1]))         //posibles errores! origen = destino
                {
                    
                    //condicion de pieza en blanco 
                    destino.Add(i);
                    destino.Add(j);
                    if (verificar())
                    {
                        PictureBox pasado = getPicture(origen[0], origen[1]);
                        PictureBox futuro = getPicture(destino[0],destino[1]);
                    
                        pasado.Image = null;
                        futuro.Image = global::DamasInglesas.Properties.Resources.black;
                    }
                    origen.Clear();
                    destino.Clear();
                    //turno = false;
                }
        }

        public Boolean verificar()
        {
            Boolean verificar = false;

            if(origen[0] > destino[0])
            {
                // movimiento correcto
                if((getPicture(destino[0],destino[1]).Image == null) && (destino[1] == origen[1] - 1 || destino[1] == origen[1] + 1))
                {
                    verificar = true;
                }
            }
            return verificar;
        }

        public void bloquear()
        {
            b01.Enabled = false;
            b03.Enabled = false;
            b05.Enabled = false;
            b07.Enabled = false;

            b10.Enabled = false;
            b12.Enabled = false;
            b14.Enabled = false;
            b16.Enabled = false;

            b21.Enabled = false;
            b23.Enabled = false;
            b25.Enabled = false;
            b27.Enabled = false;

            b30.Enabled = false;
            b32.Enabled = false;
            b34.Enabled = false;
            b36.Enabled = false;
            
            b41.Enabled = false;
            b43.Enabled = false;
            b45.Enabled = false;
            b47.Enabled = false;

            b50.Enabled = false;
            b52.Enabled = false;
            b54.Enabled = false;
            b56.Enabled = false;
            
            b61.Enabled = false;
            b63.Enabled = false;
            b65.Enabled = false;
            b67.Enabled = false;

            b70.Enabled = false;
            b72.Enabled = false;
            b74.Enabled = false;
            b76.Enabled = false;
        }
        public void desbloquear()
        {

        }

        public void desbloquear(int i, int j)
        {
            String concatenar = i.ToString() + j.ToString();
            switch (concatenar)
            {
                case "01": b01.Enabled = true; break;
                case "03": b03.Enabled = true; break;
                case "05": b05.Enabled = true; break;
                case "07": b07.Enabled = true; break;
                case "10": b10.Enabled = true; break;
                case "12": b12.Enabled = true; break;
                case "14": b14.Enabled = true; break;
                case "16": b16.Enabled = true; break;
                case "21": b00.Enabled = true; break;
                case "23": b00.Enabled = true; break;
                case "25": b00.Enabled = true; break;
                case "27": b00.Enabled = true; break;
                case "30": b00.Enabled = true; break;
                case "32": b00.Enabled = true; break;
                case "34": b00.Enabled = true; break;
                case "36": b00.Enabled = true; break;
                case "41": b00.Enabled = true; break;
                case "43": b00.Enabled = true; break;
                case "45": b00.Enabled = true; break;
                case "47": b00.Enabled = true; break;
                case "50": b00.Enabled = true; break;
                case "52": b00.Enabled = true; break;
                case "54": b00.Enabled = true; break;
                case "56": b00.Enabled = true; break;
                case "61": b00.Enabled = true; break;
                case "63": b00.Enabled = true; break;
                case "65": b00.Enabled = true; break;
                case "67": b00.Enabled = true; break;
                case "70": b00.Enabled = true; break;
                case "72": b00.Enabled = true; break;
                case "74": b00.Enabled = true; break;
                case "76": b00.Enabled = true; break;
            }
        }

        public PictureBox getPicture(int i, int j)
        {
            PictureBox res = null;
            String concatenar = i.ToString() + j.ToString();
            switch (concatenar)
            {
                case "01": res = images[0]; break;
                case "03": res = images[1]; break;
                case "05": res = images[2]; break;
                case "07": res = images[3]; break;
                case "10": res = images[4]; break;
                case "12": res = images[5]; break;
                case "14": res = images[6]; break;
                case "16": res = images[7]; break;
                case "21": res = images[8]; break;
                case "23": res = images[9]; break;
                case "25": res = images[10]; break;
                case "27": res = images[11]; break;
                case "30": res = images[12]; break;
                case "32": res = images[13]; break;
                case "34": res = images[14]; break;
                case "36": res = images[15]; break;
                case "41": res = images[16]; break;
                case "43": res = images[17]; break;
                case "45": res = images[18]; break;
                case "47": res = images[19]; break;
                case "50": res = images[20]; break;
                case "52": res = images[21]; break;
                case "54": res = images[22]; break;
                case "56": res = images[23]; break;
                case "61": res = images[24]; break;
                case "63": res = images[25]; break;
                case "65": res = images[26]; break;
                case "67": res = images[27]; break;
                case "70": res = images[28]; break;
                case "72": res = images[29]; break;
                case "74": res = images[30]; break;
                case "76": res = images[31]; break;
            }
            return res;
        }

        public List<int> comerNegras()
        {
            List<int> res = new List<int>();
            int [,] m = inicial.getMatriz();
            for(int i = 0; i < 8; i++)
            {
                for(int j = 0; j < 8; j++)
                {
                    if(m[i,j] == -1)    // si es una pieza negra, entonces!
                    {
                        if (i - 2 >= 0)        // delimitamos el borde de arriba del tablero
                            if (j - 2 >= 0)    // delimitamos el borde izquierdo del tablero7
                            {
                                if (m[i - 1, j - 1] == 1)
                                {
                                    res.Add(i - 2);
                                    res.Add(j - 2);
                                }
                            }
                            else if (j + 2 <= 7)   // delimitamos el borde derecho de arriba
                            {
                                if (m[i - 1, j + 1] == 1)
                                {
                                    res.Add(i - 2);
                                    res.Add(j + 2);
                                }
                            }
                    }
                }
            }
            return res;
        }
    }
}
