using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace LI4BackEnd
{
    class Mensagem
    {
        // Atributos
        private int tipo;
        private string dadosJson;
        // Declarador por omissão
        public Mensagem()
        {
            tipo = 0;
            dadosJson = "";
        }

        // Declarador por parâmetros
        public Mensagem(int type, string data)
        {
            tipo = type;
            dadosJson = new string(data);
        }

        // Declarador por cópia
        public Mensagem(Mensagem m)
        {
            tipo = m.getTipo();
            dadosJson = new string(m.getDadosJson());
        }

        // Métodos de acesso a atributos
        public int getTipo()
        {
            int type = tipo;
            return type;
        }

       public string getDadosJson()
        {
            string s = new string(this.getDadosJson());
            return s;
        }

        // Métodos de esctrita de atributos

        public void setTipo(int type)
        {
            tipo = type;
        }

        public void setDadosJson(string data)
        {
            dadosJson = new string(data);
        }

        // Métodos de conversão de e para objecto/JSon
        public void loadMensagem(string filename)
        {
            Mensagem msg = new Mensagem();

            // método de conversão infromação em formato jso para um objecto java;
            // Nota: nomes de atributos em json devem ser iguais aos nomes dos atributos do objeto java;
            msg = new Mensagem(JsonConvert.DeserializeObject<Mensagem>(filename));

            

        }

        // Cria uma string compatível com json contendo informação relativa a uma mensagem;
        public string saveMensagem(int type, string data)
        {
            // Criação de uma mensagem com os dados pretendidos para escrita posterior
            Mensagem msg = new Mensagem(type, data);

            // Método de conversção de um objecto para uma string compatível com json.
            string json = JsonConvert.SerializeObject(msg);

            return json;
        }
    }
}
