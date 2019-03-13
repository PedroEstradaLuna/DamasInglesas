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
        private Tablero inicial = new Tablero();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
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
        }
    }
}
