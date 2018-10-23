using App01_ConsultarCEP.Servico.Modelo;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace App01_ConsultarCEP.Servico
{
    public class ViaCEPServico
    {
        private static string enderecoURL = "https://viacep.com.br/ws/{0}/json/";

        public static Endereco BuscarEnderecoViaCEP(string cep)
        {
            string novoEnderecoURL = string.Format(enderecoURL, cep);

            WebClient wc = new WebClient();
            string conteudo =  wc.DownloadString(novoEnderecoURL);

            return JsonConvert.DeserializeObject<Endereco>(conteudo);
        }
    }
}
