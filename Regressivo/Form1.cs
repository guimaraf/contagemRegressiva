using System;
using System.Windows.Forms;

namespace Regressivo
{
    public partial class Form1 : Form
    {
        public int horas, minutos, segundos, soma;
        public bool relogioFunciona = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            relogioFunciona = true;
            timer1.Interval = 1000;

            if (txtBoxHoras.Text == "")
            {
                horas = 0;
            }
            else
            {
                horas = Convert.ToInt32(txtBoxHoras.Text);
            }
            
            if(txtBoxMinutos.Text == "")
            {
                minutos = 0;
            }
            else
            {
                minutos = Convert.ToInt32(txtBoxMinutos.Text);
            }
            
            if(txtBoxSegundos.Text == "")
            {
                segundos = 0;
            }
            else
            {
                segundos = Convert.ToInt32(txtBoxSegundos.Text);
            }

            soma = (horas * 3600) + (minutos * 60) + segundos;
            timer1.Start();
        }

        private void txtBoxHoras_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 08)
            {
                e.Handled = true;
            }
        }

        private void txtBoxMinutos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 08)
            {
                e.Handled = true;
            }
        }

        private void txtBoxSegundos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 08)
            {
                e.Handled = true;
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            relogioFunciona = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            soma -= 1;
            lblResultado.Text = Convert.ToString(soma);

            if(soma == 0)
            {
                timer1.Stop();
                relogioFunciona = false;
                limparDados();
                rodar();
            }
        }
        
        private void btnLimpar_Click(object sender, EventArgs e)
        {
            limparDados();
        }
        public void limparDados()
        {
            if (!relogioFunciona)
            {
                horas = 0;
                minutos = 0;
                segundos = 0;
                soma = 0;
                lblResultado.Text = "Resultado";
                txtBoxHoras.Text = "";
                txtBoxMinutos.Text = "";
                txtBoxSegundos.Text = "";
            }
        }
        public void rodar()
        {
            //Colocar evento externo para rodar aqui
            MessageBox.Show("Mensagem de teste");
        }
    }
}