using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace LI4BackEnd
{
    class Canil
    {
        private string email;
        private string nib;
        private string nome;
        private string password;
        private string distrito;
        private string regiao;
        private string localidade;
        private string rua;
        private int capacidadeOcupada;
        private int capacidadeTotal;
        private Dictionary<string, Cao> caes;
        private List<DateTime> horarios;
        private Dictionary<string, User> voluntarios;

        // Declarador por omissão
        public Canil()
        {
            password = "";
            email = "";
            nib = "";
            distrito = "";
            regiao = "";
            localidade = "";
            rua = "";
            capacidadeOcupada = 0;
            capacidadeTotal = 0;
            nome = "";
            caes = new Dictionary<string, Cao>();
            horarios = new List<DateTime>();
            voluntarios = new Dictionary<string, User>();
        }

        // Declarador por parâmetros
        public Canil(string mail, string pword, string nome, string distr, string reg, string local, string ru, int capOc, int capTot, 
                     Dictionary<string, Cao> cs, List<DateTime> hor, Dictionary<string, User> vol)
        {
            password = new string(pword);
            email = new string(mail);
            distrito = new string(distr);
            regiao = new string(reg);
            localidade = new string(local);
            rua = new string(ru);
            nome = new string(nome);
            capacidadeTotal = capTot;
            capacidadeOcupada = capOc;
            caes = new Dictionary<string, Cao>();
            foreach(KeyValuePair<string, Cao> c in cs)
            {
                caes.Add(c.Key, new Cao(c.Value));
            }
            horarios = new List<DateTime>();
            foreach(DateTime d in hor)
            {
                horarios.Add(new DateTime(d.Year, d.Month, d.Day));
            }
            voluntarios = new Dictionary<string, User>();
            foreach(KeyValuePair<string, User> u in vol)
            {
                voluntarios.Add(u.Key, new User(u.Value));
            }

        }

        // Declarador por cópia
        public Canil(Canil c)
        {
            password = c.getPassword();
            email = c.getEmail();
            distrito = c.getDistrito();
            regiao = c.getRegiao();
            localidade = c.getLocalidade();
            rua = c.getRua();
            nome = c.getNome();
            capacidadeOcupada = c.getCapacidadeOcupada();
            capacidadeTotal = c.getCapacidadeTotal();
            caes = new Dictionary<string, Cao>();
            foreach (KeyValuePair<string, Cao> cao in c.getCaes())
            {
                caes.Add(cao.Key, new Cao(cao.Value));
            }
            horarios = new List<DateTime>();
            foreach (DateTime d in c.getHorarios())
            {
                horarios.Add(new DateTime(d.Year, d.Month, d.Day));
            }
            voluntarios = new Dictionary<string, User>();
            foreach (KeyValuePair<string, User> u in c.getVoluntarios())
            {
                voluntarios.Add(u.Key, new User(u.Value));
            }
        }

        // métodos de acesso a atributos

        public string getPassword()
        {
            string pword = new string(password);
            return pword;
        }

        public string getEmail()
        {
            string mail = new string(email);
            return mail;
        }


        public string getDistrito()
        {
            string dist = new string(distrito);
            return distrito;
        }

        public string getRegiao()
        {
            string reg = new string(regiao);
            return reg;
        }

        public string getLocalidade()
        {
            string local = new string(localidade);
            return local;
        }

        public string getRua()
        {
            string ru = new string(rua);
            return ru;
        }

        public string getNome()
        {
            string name = new string(nome);
            return name;
        }

        public int getCapacidadeOcupada()
        {
            int capOc = capacidadeOcupada;
            return capOc;
        }

        public int getCapacidadeTotal()
        {
            int capTot = capacidadeTotal;
            return capTot;
        }

        public Dictionary<string, Cao> getCaes()
        {
            Dictionary<string, Cao> cs = new Dictionary<string, Cao>();
            foreach (KeyValuePair<string, Cao> c in caes)
            {
                cs.Add(c.Key, new Cao(c.Value));
            }
            return cs;


        }

        public List<DateTime> getHorarios()
        {
            List<DateTime> dat = new List<DateTime>();
            foreach (DateTime d in horarios)
            {
                dat.Add(new DateTime(d.Year, d.Month, d.Day));
            }
            return dat;
        }

        public Dictionary<string, User> getVoluntarios()
        {
            Dictionary<string, User> vols = new Dictionary<string, User>();
            foreach (KeyValuePair<string, User> u in voluntarios)
            {
                vols.Add(u.Key, new User(u.Value));
            }
            return vols;
        }


        // Métodos de esctita de atributos;

        public void setEmail(string mail)
        {
            email = new string(mail);
        }

        public void setNib(string iban)
        {
            nib = new string(iban);
        }

        public void setNome(string name)
        {
            nome = new string(name);
        }

        public void setPassword(string pword)
        {
            password = new string(pword);
        }

        public void setDistrito(string dst)
        {
            distrito = new string(dst);
        }

        public void setRegiao(string reg)
        {
            regiao = new string(reg);
        }

        public void setLocalidade(string local)
        {
            localidade = new string(local);
        }

        public void setRua(string ru)
        {
            rua = new string(ru);
        }

        public void setCapacidadeOcupada(int capOc)
        {
            capacidadeOcupada = capOc;
        }

        public void setCapacidadeTotal(int capTot)
        {
            capacidadeTotal = capTot;
        }

        public void setCaes(Dictionary<string, Cao> cs)
        {
            caes = new Dictionary<string, Cao>();
            foreach(KeyValuePair<string, Cao> c in cs)
            {
                caes.Add(c.Key, new Cao(c.Value));
            }
        }

        public void setHorarios(List<DateTime> hors)
        {
            horarios = new List<DateTime>();
            foreach(DateTime d in hors)
            {
                horarios.Add(new DateTime(d.Year, d.Month, d.Day));
            }
        }

        public void setVoluntarios(Dictionary<string, User> vols)
        {
            voluntarios = new Dictionary<string, User>();
            foreach(KeyValuePair<string, User> u in vols)
            {
                voluntarios.Add(u.Key, new User(u.Value));
            }
        }


        // Métodos de conversão de e para objeto/json;
        public Canil loadCanil(string filename)
        {
            Canil canil = new Canil();

            // método de conversão infromação em formato jso para um objecto java;
            // Nota: nomes de atributos em json devem ser iguais aos nomes dos atributos do objeto java;
            canil = JsonConvert.DeserializeObject<Canil>(filename);

            return canil;
        }

        // Cria uma string compatível com json contendo informação relativa a um utilizador;
        public string saveCanil(string mail, string pword, string name, string distr, string reg, string local, string ru, int capOc, int capTot, 
                                Dictionary<string, Cao> cs, List<DateTime> d, Dictionary<string, User> vols)
        {
            // Criação de um Canil com os dados do canil pretendido para escrita posterior
            Canil canil = new Canil(mail, pword, name, distr, reg, local, ru, capOc, capTot, cs, d, vols);

            // Método de conversção de um objecto para uma string compatível com json.
            string json = JsonConvert.SerializeObject(canil);

            return json;
        }
    }
}
