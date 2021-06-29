using System;

namespace ConsoleApp1{
    class Program{
        //-----------------------------------------------------------------------------------------------Iniciar Sessão---------------------------------------------------------------------
        void iniciarSessaoU(string email, string password)
        {
            if (canilDB.containsKey(email) && canilDB.valPalavra(password))
            {
                //Informar para reabrir a pagina
            }
            else
            {
                //Informar o site que não foi reconhecido o email ou a palavra-passe
            }
        }

        void iniciarSessaoCanil(string email, string password)
        {
            if (canilDB.containsKey(email) && canilDB.valPalavra(password))
            {
                //Informar para reabrir a pagina
            }
            else
            {
                //Informar o site que não foi reconhecido o email ou a palavra-passe
            }
        }

        void terminarSessao()
        {
            //... acho que não é preciso fazer nada deste lado...
        }
        //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        //----------------------------------------------------------------------------------------------Funções Utilizador-----------------------------------------------------------------------------
        void adicionarUtilizador(string email, string password, string nome, int cc, DateTime dataNasc, int idade, string morada)
        {
            if (canilDB.containsKey(email))
            {
                //Informar que mail ja existe
            }
            else
            {
                canilDB.adicionarBD(email, password, nome, cc, dataNasc, idade, morada);
            }
        }

        void removerUtilizador(string email)
        {
            canilDB.removerUtilizador(email);
        }

        void alterarPalU(string email, string nPass)
        {
            canilDB.alterarPal(email, nPass);
        }

        void alterarEmailU(string email, string nPass)
        {
            canilDB.editarEmail(email, novoEmail);
        }

        void registaHorario(string emailC, string emailV, DateTime horarioI, DateTime horarioF)
        {
            canilDB.adicionarCanil(emailC, emailV, horarioI, horarioF);
        }

        void desmarcaHorario(string emailC, string emailV, DateTime horarioI, DateTime horarioF)
        {
            canilDB.desmarcaHorario(emailC, emailV, horarioI, horarioF);
        }

        void favoritarCao(string email, int caoID)
        {
            canilDB.favoritarCao(email, caoID);
        }

        void desfavoritarCao(string email, int caoID)
        {
            canilDB.favoritarCao(email, caoID);
        }

        void adotarCao(string email, int caoID)
        {
            canilDB.adotarCao(email, caoID);
            canilDB.adotarCao(caoID);
        }

        void pesquisaCao(string raca, int idade, string local)
        {
            canilDB.pesquisaCao(local);
        }

        void pesquisaCao(string raca, int idade, char sexo, string cor, char porte, string local)
        {
            canilDB.pesquisaCao(raca, idade, sexo, cor, porte, local);
        }

        void pesquisaCaoCanil(string raca, int idade, char sexo, string cor, char porte, string emailC)
        {
            canilDB.pesquisaCaoCanil(raca, idade, sexo, cor, porte, emailC);
        }

        void pesquisaCanil(string local)
        {
            canilDB.canisProximos(local);
        }

        void verParcerias(string emailC)
        {
            List<List<String>> list = new List<List<String>>();
            list = canilDB.SelectParcerias(emailC);
            //Passar lista para o encapsulamento e mandar para site
        }

        //----------------------------------------------------------------------------------------------Funções Canis-----------------------------------------------------------------------------
        void adicionarCanil(string email, string nome, string password, int capO, int capT, string distrito, string rua, string local, string contacto, string nib)
        {
            if (canilDB.containsKey())
            {
                //mensagem de erro
            }
            else canilDB.insereCanil(email, nib, nome, capO, capT, password, distrito, rua, local, contacto);
        }

        void removerCanil(string email)
        {
            canilDB.deleteCanil(email);
        }

        void alterarPalC(string email, string nPass)
        {
            canilDB.updatePass(email, nPass);
        }

        void alterarEmailC(string email, string nEmail)
        {
            canilDB.updateContacto(email, nEmail);
        }

        void adicionarParceria(string emailC, string nome, string info)
        {
            canilDB.adicionarParceria(emailC, nome, info);
        }

        void removerParceria(string emailC, string nome)
        {
            canilDB.removerParceria(emailC, nome);
        }

        void adicionaHorario(string emailC, DateTime horarioI, DateTime horarioF)
        {
            canilDB.adicionarHorario(emailC, horarioI, horarioF);
        }

        void removeHorario(string emailC, DateTime horarioI, DateTime horarioF)
        {
            canilDB.removeHorario(emailC, horarioI, horarioF);
        }

        void adicionarCao(string emailC, char genero, string nome, string cor, string raca, int idade, string descricao)
        {
            int caoId = canilDB.adicionarCao(genero, nome, cor, raca, idade, descricao);
            canilDB.adicionarCao(emailC, caoID);
        }

        void removerCao(string emailC, int caoID)
        {
            canilDB.removerCao(emailC, caoID);
            canilDB.removerCao(caoID);
        }

        void updateCapT(string email, int capT)
        {
            canilDB.updateCapacidadeT(email, capT);
        }

        void updateCapO(string email, int capO)
        {
            canilDB.updateCapacidadeO(email, capO);
        }
    }
}