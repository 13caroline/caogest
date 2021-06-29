using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace LI4BackEnd
{
    class User
    {
        // Atributos
        private string email;
        private string password;
        private DateTime data_nascimento;
        private string distrito;
        private string regiao;
        private string localidade;
        private string rua;
        private string cc;
        private Dictionary<string, Cao> favoritos;

        // Declarador por omissão
        public User()
        {
            password = "";
            email = "";
            data_nascimento = new DateTime();
            cc = "";
            distrito = "";
            regiao = "";
            localidade = "";
            rua = "";
            favoritos = new Dictionary<string, Cao>();
        }

        // Declarador por parâmetros
        public User(string mail, string pword, DateTime d_nasc, string distr, string reg, string local, string ru, string cartao, Dictionary<string, Cao> favs)
        {
            password = new string(pword);
            email = new string(mail);
            data_nascimento = new DateTime(d_nasc.Year, d_nasc.Month, d_nasc.Day);
            cc = new string(cartao);
            distrito = new string(distr);
            regiao = new string(reg);
            localidade = new string(local);
            rua = new string(ru);
            favoritos = new Dictionary<string, Cao>();
            foreach(KeyValuePair<string, Cao> c in favs)
            {
                favoritos.Add(c.Key, new Cao(c.Value));
            }

        }

        // Declarador por cópia
        public User(User u)
        {
            password = u.getPassword();
            email = u.getEmail();
            data_nascimento = new DateTime(u.getData_Nascimento().Year, u.getData_Nascimento().Month, u.getData_Nascimento().Day);
            cc = u.getCC();
            distrito = u.getDistrito();
            regiao = u.getRegiao();
            localidade = u.getLocalidade();
            rua = u.getRua();
            favoritos = new Dictionary<string, Cao>();
            foreach(KeyValuePair<string, Cao> c in u.getFavoritos())
            {
                favoritos.Add(c.Key, new Cao(c.Value));
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

        public DateTime getData_Nascimento()
        {
            DateTime d_nasc = new DateTime(data_nascimento.Year, data_nascimento.Month, data_nascimento.Day);
            return d_nasc;
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

        public string getCC()
        {
            string cartao = new string(cc);
            return cartao;
        }

        public Dictionary<string, Cao> getFavoritos()
        {
            Dictionary<string, Cao> favs = new Dictionary<string, Cao>();
            foreach(KeyValuePair<string, Cao> c in favoritos)
            {
                favs.Add(c.Key, new Cao(c.Value));
            }
            return favs;
        }

        // Métodos de esctrita de Atributos;
        public void setEmail(string mail)
        {
            email = new string(mail);
        }

        public void setPassword(string pword)
        {
            password = new string(pword);
        }

        public void setData_Nascimento(DateTime dat)
        {
            data_nascimento = new DateTime(dat.Year, dat.Month, dat.Day);
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
            rua = new string(rua);
        }

        public void setCC(string cartao)
        {
            cc = new string(cartao);
        }

        public void setFavoritos(Dictionary<string, Cao> favs)
        {
            favoritos = new Dictionary<string, Cao>();
            foreach(KeyValuePair<string, Cao> c in favs)
            {
                favoritos.Add(c.Key, new Cao(c.Value));
            }
        }


        // Métodos de Conversão de e para Objeto/JSon;
        public User loadUser(string filename)
        {
            User user = new User();

            // método de conversão infromação em formato jso para um objecto java;
            // Nota: nomes de atributos em json devem ser iguais aos nomes dos atributos do objeto java;
            user = JsonConvert.DeserializeObject<User>(filename);

            return user;
        }

        // Cria uma string compatível com json contendo informação relativa a um utilizador;
        public string saveUser(string mail, string pword, DateTime d_nasc, string distr, string reg, string local, string ru, string cartao, Dictionary<string, Cao> favs)
        {
            // Criação de um User com os dados do utilizador pretendido para escrita posterior
            User user = new User(mail, pword, d_nasc, distr, reg, local, ru, cartao, favs);

            // Método de conversção de um objecto para uma string compatível com json.
            string json = JsonConvert.SerializeObject(user);

            return json;
        }
    }
}
