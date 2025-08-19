using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculadoraIMC
{
    public partial class frmNome : Form
    {
        public frmNome()
        {
            InitializeComponent();
            
}
        private void frmNome_Load(object sender, EventArgs e)
        {
            BackColor = Color.FromArgb(46, 139, 87);
            
        }

        private void txtPeso_TextChanged(object sender, EventArgs e)
        {
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            if(txtPeso.Text == "")
            {
                //mostrar erro se o usuário não adicionar nada
                MessageBox.Show("O valor do peso não pode estar vazio!","ERRO!",MessageBoxButtons.OK,MessageBoxIcon.Error);

                //mudar cor de fundo para deixar claro o erro do usuário
                txtPeso.BackColor = Color.IndianRed;
                txtPeso.ForeColor = Color.WhiteSmoke;

                return;
            }
            else
            {
                //retornar ao normal se estiver certo
                txtPeso.BackColor = Color.White;
                txtPeso.ForeColor= Color.Black;
            }
            //no txtPeso_KeyPress, está impedindo a pessoa de colocar letras.

            if (txtAltura.Text == "")
            {
                // mostrar erro se o usuário não adicionar nada
                MessageBox.Show("O valor da altura não pode estar vazio!", "ERRO!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                //mudar cor de fundo para deixar claro o erro do usuário
                txtAltura.BackColor = Color.IndianRed;
                txtAltura.ForeColor = Color.WhiteSmoke;

                return;
            }
            else
            {
                //retornar ao normal se estiver certo
                txtAltura.BackColor = Color.White;
                txtAltura.ForeColor = Color.Black;
            }
            //no txtAltura_KeyPress, está impedindo a pessoa de colocar letras.

            
            

            //variaveis
            double Peso = double.Parse(txtPeso.Text);
            double Altura = double.Parse(txtAltura.Text);
            double resultado = Peso / (Altura * Altura);

            //mostrar resultado
            txtResultado.Text = resultado.ToString();

            if (resultado < 18.5)
            {
                lblSaude.ForeColor = Color.IndianRed;
                lblSaude.BackColor = Color.White;
                lblSaude.Text = ("Abaixo do peso");
            }
            else if (resultado >= 18.5 & resultado <= 24.9)
            {
                lblSaude.ForeColor = Color.Green;
                lblSaude.BackColor = Color.White;
                lblSaude.Text = ("Peso Saudável");
            }
            else if (resultado >=25 & resultado<=29.9)
            {
                lblSaude.ForeColor = Color.Yellow;
                lblSaude.BackColor = Color.White;
                lblSaude.Text = ("Sobrepeso");    
            }
            else if (resultado >=30 &  resultado <=34.9)
            {
                lblSaude.ForeColor = Color.IndianRed;
                lblSaude.BackColor = Color.White;
                lblSaude.Text = ("Obesidade Grau I");
            }
            else if(resultado >=35 &  resultado <=39.9)
            {
                lblSaude.ForeColor = Color.Red;
                lblSaude.BackColor = Color.White;
                lblSaude.Text = ("Obesidade Grau II");
            }
            else
            {
                lblSaude.ForeColor = Color.DarkRed;
                lblSaude.BackColor = Color.White;
                lblSaude.Text = ("Obesidade Grau III");
            }
        }

        private void txtAltura_KeyPress(object sender, KeyPressEventArgs e)
        {
            //impedir a pessoa de colocar letras na altura
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != ',' && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }

        private void txtPeso_KeyPress(object sender, KeyPressEventArgs e)
        {
            //impedir a pessoa de colocar letras no peso
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != ',' && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }

        private void txtPeso_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //Pular pro próximo text box:
                txtAltura.Focus();
            }
        }

        private void txtAltura_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                //"pressionar" o botão de calcular com o enter.
                btnCalcular.PerformClick();
            }
        }

        private void lblSaude_Click(object sender, EventArgs e)
        {

        }
    }
}
