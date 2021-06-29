using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace LI4BackEnd
{
    class Cao
    {

        // Atributos
        private string idCao;
        private string nome;
        private int sexo;
        private string descricao;
        private int estado;
        private string raca;
        private string cor;

        // Declarador por omissão
        public Cao()
        {
            idCao = "";
            nome = "";
            sexo = 0;
            descricao = "";
            estado = 0;
            raca = "";
            cor = "";
        }


        // Declarador por parâmetros
        public Cao(string id, string name, int sx, string desc, int st, string rac, string cr)
        {
            idCao = new string(id);
            nome = new string(name);
            sexo = sx;
            descricao = new string(desc);
            estado = st;
            raca = new string(rac);
            cor = new string(cr);
        }

        // Declarador por cópia
        public Cao(Cao c)
        {
            this.idCao = c.getIdCao();
            this.nome = c.getNome();
            this.sexo = c.getSexo();
            this.descricao = c.getDescricao();
            this.estado = c.getEstado();
            this.raca = c.getRaca();
            this.cor = c.getCor();
        }

        // Métodos de acesso a Atributos
        public string getIdCao()
        {
            string id = new string(idCao);
            return id;
        }

        public string getNome()
        {
            string name = new string(nome);
            return name;
        }

        public int getSexo()
        {
            int sx = sexo;
            return sx;
        }

        public string getDescricao()
        {
            string desc = new string(descricao);
            return desc;
        }

        public int getEstado()
        {
            int st = estado;
            return st;
        }

        public string getRaca()
        {
            string rac = new string(raca);
            return rac;
        }

        public string getCor()
        {
            string cr = new string(cor);
            return cr;
        }

        // Métodos de escrita de atributos

        public void setIdCao(string id)
        {
            idCao = new string(id);
        }

        public void setNome(string name)
        {
            nome = new string(name);
        }

        public void setSexo(int sx)
        {
            sexo = sx;
        }

        public void setDescricao(string desc)
        {
            descricao = new string(desc);
        }

        public void setEstado(int st)
        {
            estado = st;
        }

        public void setRaca(string race)
        {
            raca = new string(race);
        }

        public void setCor(string color)
        {
            cor = new string(color);
        }

        // Métodos de Conversão de e para objecto/JSon
        public Cao loadCao(string filename)
        {
            Cao cao = new Cao();

            // método de conversão infromação em formato jso para um objecto java;
            // Nota: nomes de atributos em json devem ser iguais aos nomes dos atributos do objeto java;
            cao = JsonConvert.DeserializeObject<Cao>(filename);

            return cao;
        }

        // Cria uma string compatível com json contendo informação relativa a um utilizador;
        public string saveCao(string id, string name, int sx, string desc, int st, string rac, string cr)
        {
            // Criação de um Canil com os dados do canil pretendido para escrita posterior
            Cao cao = new Cao(id, name, sx, desc, st, rac, cr);

            // Método de conversção de um objecto para uma string compatível com json.
            string json = JsonConvert.SerializeObject(cao);

            return json;
        }
    }
}
