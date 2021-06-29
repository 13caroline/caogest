using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaoGest.src
{
    class MainClass
    {
        public static void Main()
        {
            // --------------------------------------------------------------------- CANIL ----------------------------------------------- 
            //canilDB.insereCanil("random@gmail.com", "192888494", "Novo Canil", 10, 25, "minhapass", "porto", "Rua do teste","Lousada","912839913");

            // canilDB.updateCapacidadeO(""random@gmail.com", 100);

            // canilDB.updatePass("random@gmail.com", "PAAAAASS");

            // canilDB.updateContacto(""random@gmail.com", "935373306");

            // canilDB.deleteCanil(""random@gmail.com");

            /* List<string> list = canilDB.Select("random@gmail.com");
             Console.Write(list[0]);
             Console.Write(list[1]);
             Console.Write(list[2]);
             Console.Write(list[3]);
             Console.Write(list[4]);
             Console.Write(list[5]);
             Console.Write(list[6]);
             Console.Write(list[7]);
             Console.Write(list[8]);
             */


            /* TENTATIVA SO COM LISTA
            List<String> list = canilDB.SelectParcerias("caoSeguro@gmail.com");

            Console.Write(list[0]+'\n');
            Console.Write(list[1] + '\n');
            Console.Write(list[2] + '\n');
            Console.Write(list[3] + '\n');
            Console.Write(list[4] + '\n');
            Console.Write(list[5] + '\n');
            Console.Write(list[6] + '\n');
            Console.Write(list[7] + '\n');
            */

            /*TENTATIVA COM LISTA DE LISTAS
            List<List<String>> list = canilDB.SelectParcerias("caoSeguro@gmail.com");
            try
            {
                Console.Write((list[0])[0]+'\n');
                Console.Write((list[0])[1]+'\n');
                Console.Write((list[0])[2]+'\n');
                Console.Write((list[0])[3]+'\n');
                Console.Write((list[1])[0]+'\n');
                Console.Write((list[1])[1]+'\n');
                Console.Write((list[1])[2]+'\n');
                Console.Write((list[1])[3]+'\n');
            }
            catch (System.ArgumentOutOfRangeException) { }*/

            /*
            List<List<String>> list = canilDB.SelectCaes("caoSeguro@gmail.com");
            try {
            Console.Write((list[0])[0] + '\n');
            Console.Write((list[0])[1] + '\n');
            Console.Write((list[0])[2] + '\n');
            Console.Write((list[0])[3] + '\n');
            Console.Write((list[0])[4] + '\n');
            Console.Write((list[0])[5] + '\n');
            Console.Write((list[0])[6] + '\n');
            Console.Write((list[0])[7] + '\n');
            Console.Write((list[0])[8] + '\n');
            Console.Write((list[0])[9] + '\n');
                Console.Write((list[1])[0] + '\n');
                Console.Write((list[1])[1] + '\n');
                Console.Write((list[1])[2] + '\n');
                Console.Write((list[1])[3] + '\n');
                Console.Write((list[1])[4] + '\n');
                Console.Write((list[1])[5] + '\n');
                Console.Write((list[1])[6] + '\n');
                Console.Write((list[1])[7] + '\n');
                Console.Write((list[1])[8] + '\n');
                Console.Write((list[1])[9] + '\n');

            }
            catch (System.ArgumentOutOfRangeException) { }
            */

            //-------------------------------------------------- UTILIZADOR ---------------------------------------------


            //utilizadorDB.insereUser("joaoMota3@gmail.com", "Joao", "1234", new DateTime(1998, 03, 12), "Porto", "Rua da Padaria", "Lousada", "29481922","Masculino");

            // utilizadorDB.deleteUser("joaoMota@gmail.com");

            // utilizadorDB.updatePass("joao@gmail.com", "Nova");

            // utilizadorDB.updateEmail("joao@gmail.com", "j@gmail.com");
            // utilizadorDB.updateEmail("joao@gmail.com", "j@gmail.com");

            /*   bool x = utilizadorDB.containsKey("joaoMota3@gmail.com");
               Console.Write(x.ToString());*/

            /* bool x =  utilizadorDB.valPass("joaoMota3@gmail.com","1234");

              Console.Write(x.ToString()); */

            //------------------------------------------------------------------Cao--------------------------------------------------------------
            //caoDB.insereCao(5, "peixe", "masculino", "coiso", 1, "golden", "castanho","random@gmail.com" ,2, 1, "medio");

            //  caoDB.updateIdade( 2, 100);
            // caoDB.updateDescricao(2, "Nova desc");
            //caoDB.updateEstado(2, 5);
            //caoDB.updateEsterilizacao(2, 0);
            //caoDB.deleteCao(4);
            /*List<string> list = caoDB.SelectCao(2);
            Console.Write(list[0]);
            Console.Write(list[1]);
            Console.Write(list[2]);
            Console.Write(list[3]);
            Console.Write(list[4]);
            Console.Write(list[5]);
            Console.Write(list[6]);
            Console.Write(list[7]);
            Console.Write(list[8]);
            Console.Write(list[9]);
            Console.Write(list[10]);*/
            //  caoDB.insereFoto(1, "paaaath",2);
            /*List<String> list = utilizadorDB.getFavoritos("Mota@gmail.com");
            try { Console.Write(list[0] + '\n'); }
            catch (System.InvalidCastException) { }
            catch (System.ArgumentOutOfRangeException) { }*/

            //----------------------------------------------HORARIO----------------------------------

            //horarioDB.criaHorario( new DateTime(2020, 04, 13, 15, 00, 00), new DateTime(2020, 04, 13, 17, 00, 00), "random@gmail.com",5);
            // horarioDB.registaHorario( new DateTime(2020, 04, 13, 15, 00, 00), new DateTime(2020, 04, 13, 17, 00, 00), "Mota@gmail.com", "random@gmail.com");


            /*
           List<List<String>> list = horarioDB.selectHorarios("random@gmail.com");
            try
            {
                Console.Write((list[0])[0] + '\n');
                Console.Write((list[0])[1] + '\n');
                Console.Write((list[0])[2] + '\n');
                Console.Write((list[0])[3] + '\n');
            }


            catch (System.ArgumentOutOfRangeException) { `*/



        }
    }
}


