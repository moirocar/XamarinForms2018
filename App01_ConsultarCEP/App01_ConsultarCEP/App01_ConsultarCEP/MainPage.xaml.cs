using App01_ConsultarCEP.Servico;
using App01_ConsultarCEP.Servico.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App01_ConsultarCEP
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            botao.Clicked += Botao_Clicked;
        }

        private void Botao_Clicked(object sender, EventArgs e)
        {
            string value = cep.Text.Trim();
            if (isValidCEP(value))
            {
                try
                {
                    Endereco end = ViaCEPServico.BuscarEnderecoViaCEP(value);

                    if (end != null)
                    {
                        resultado.Text = string.Format("Endereço: {0}, {1} {2}", end.localidade, end.uf, end.logradouro);
                    }
                    else
                    {
                        DisplayAlert("Erro", "Endereço não localizado!", "OK");
                    }
                }
                catch (Exception ex)
                {
                    DisplayAlert("Erro", ex.Message, "OK");
                }
            }
        }

        private bool isValidCEP(string cep)
        {
            bool valid = true;

            if (cep.Length != 8)
            {
                valid = false;
                DisplayAlert("Erro", "CEP inválido!", "OK");
            }

            int novoCEP = 0;
            if (!int.TryParse(cep, out novoCEP))
            {
                valid = false;
                DisplayAlert("Erro", "CEP inválido!", "OK");
            }

            return valid; ;
        }
    }
}
