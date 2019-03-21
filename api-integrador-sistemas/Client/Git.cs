using System;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using static api_integrador_sistemas.Entity.Enums;

namespace api_integrador_sistemas.Client
{
    public class Git
    {
        #region Variaveis de classe
        HttpClient client;
        Uri usuarioUri;
        string URL = string.Empty;
        #endregion

        #region Conexao com o repositorio
        public Git(string token, REPO repositorio)
        {
            if (repositorio.Equals(REPO.Git))
                URL = ConfigurationManager.AppSettings["git"];
            else if (repositorio.Equals(REPO.Bitbucket))
                URL = ConfigurationManager.AppSettings["bitbucket"];
            else if (repositorio.Equals(REPO.Gitlab))
                URL = ConfigurationManager.AppSettings["gitlab"];

            if (client == null)
            {
                client.BaseAddress = new System.Uri(URL);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("OAuth2", token);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            }
        }
        #endregion

        #region Metodos para buscar o conteudo do repositorio e realizar o clone dos dados
        private void getObject()
        {
            //chamando a api pela url
            System.Net.Http.HttpResponseMessage response = client.GetAsync("api/usuario").Result;

            //se retornar com sucesso busca os dados
            if (response.IsSuccessStatusCode)
            {
                usuarioUri = response.Headers.Location;
                
               // var usuarios = response.Content.ReadAsAsync<IEnumerable<Usuario>>().Result;
            }
        }

        private void postObject(string data, string token)
        {
            HttpContent content = new StringContent(data, UTF8Encoding.UTF8, "application/json");
            HttpResponseMessage messge = client.PostAsync(URL, content).Result;
            string description = string.Empty;
            if (messge.IsSuccessStatusCode)
            {
                string result = messge.Content.ReadAsStringAsync().Result;
                description = result;
            }
        }
        #endregion

        #region Regra para mapear o codigo
        public void listaSistemas()
        {

        }

        public void buscaClasses()
        {

        }

        public void buscaMetodos()
        {

        }
        #endregion

        #region destructor
        ~Git()
        {
            client.Dispose();
            client = null;
        }
        #endregion
    }
}