using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Validarcpf
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            string cpfdigitado = txtcpf.Text.Replace(".","").Replace("-", "").Replace(" ","");

            if (string.IsNullOrWhiteSpace(cpfdigitado))
            {
                MessageBox.Show("Digite o CPF","Atenção");
                txtcpf.Focus();
                txtcpf.SelectAll();
                return;
            }

            if(cpfdigitado.Length != 11)
            {
                lblresul.Text = "Informe o CPF com 11 números";
                lblresul.ForeColor = Color.Red;
                return;

            }

            //Separar os  numeros em grupos

            string cpf = cpfdigitado.Substring(0, 9);
            int soma = 0;
            int valorRef = 10;

            for (int i = 0; i <= 8; i++)
            {
                soma += Convert.ToInt32(cpf[i].ToString()) * valorRef--;
            }


            int div1 = (int) soma % 11;

            if (div1 < 2)
            {
                div1 = 0;
            }
            else
            {
                div1 = 11 - div1;
            }

            if(!cpfdigitado.Substring(9, 1).Equals(div1.ToString())){
                MessageBox.Show("Informe um CPF válido", "ATENÇÃO");
                lblresul.ForeColor = Color.Red;
                return;
            }

            // Calcular o segundo digito verificador


            soma = 0;
            valorRef = 11;

            cpf = cpf + div1;

            for(int i = 0 ;i<= 9; i++)
            {
                soma += Convert.ToInt32(cpf[i].ToString()) * valorRef--;

            }

            int div2 = (int)(soma % 11);
            if(div2 < 2)
            {
                div2 = 0;
            }
            else
            {
                div2 = 11 - div2;
            }

            if(!cpfdigitado.Substring(10, 1).Equals(div2.ToString()))
            {
                MessageBox.Show("Informe um CPF válido", "ATENÇÃO");

                lblresul.ForeColor = Color.Red;
                return;

            }

            MessageBox.Show(" CPF válido", "Sucesso");
            lblresul.Text = "CPF digitado é válido";
            lblresul.ForeColor = Color.Blue;
            

        }

        private void lblresul_Click(object sender, EventArgs e)
        {

        }
    }
}
