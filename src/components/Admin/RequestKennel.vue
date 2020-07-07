<template>
    <div id = "requestkennel" class = "Request Kennel" >
        <NavbarAdmin :id="$route.params.id"/>
        <v-card flat height = "100"></v-card>
        <v-card flat height = "100" color = "brown lighten-5">
            <v-card-text class = "display-2 black--text text-center">{{canil.nome}}</v-card-text>
        </v-card>
        
        <v-container>
            <v-card flat height = "40"></v-card>
                <v-card flat color = "white" height = "40"></v-card>
                        
                <v-card width="2000" color = "brown lighten-5">
                    <v-row class = "align-center">
                        <v-col cols = "8">
                            <v-row class="ml-8">
                                <p class = " display-1 font-weight-bold" color = "grey"> E-mail: 
                                    <span class = "display-1 font-weight-regular ">{{canil.email}}</span>
                                </p> 
                            </v-row>

                            <v-card flat color = "brown lighten-5" height = "40"></v-card>

                            <v-row class="ml-8">
                                <p class = " display-1 font-weight-bold" color = "grey"> Morada: 
                                    <span class = "display-1 font-weight-regular ">{{canil.rua}}</span>
                                </p> 
                            </v-row>

                            <v-card flat color = "brown lighten-5" height = "40"></v-card>

                            <v-row class="ml-8">
                                <p class = " display-1 font-weight-bold" color = "grey"> Localidade: 
                                    <span class = "display-1 font-weight-regular ">{{canil.localidade}}</span>
                                </p> 
                            </v-row>

                            <v-card flat color = "brown lighten-5" height = "40"></v-card>

                            <v-row class="ml-8">
                                <p class = " display-1 font-weight-bold" color = "grey"> Distrito: 
                                    <span class = "display-1 font-weight-regular ">{{canil.distrito}}</span>
                                </p> 
                            </v-row>

                            <v-card flat color = "brown lighten-5" height = "40"></v-card>

                            <v-row class="ml-8">
                                <p class = " display-1 font-weight-bold" color = "grey"> NIB: 
                                    <span class = "display-1 font-weight-regular ">{{canil.nib}}</span>
                                </p> 
                            </v-row>

                            <v-card flat color = "brown lighten-5" height = "40"></v-card>

                            <v-row class="ml-8">
                                <p class = " display-1 font-weight-bold" color = "grey"> Contacto: 
                                    <span class = "display-1 font-weight-regular ">{{canil.contacto}}</span>
                                </p> 
                            </v-row>

                            <v-card flat color = "brown lighten-5" height = "100"></v-card>

                            <v-row class="ml-8">
                                <p class = " display-1 font-weight-bold" color = "grey"> Capacidade Total: 
                                    <span class = "display-1 font-weight-regular ">{{canil.capacidadeTotal}}</span>
                                </p> 
                            </v-row>

                            <v-card flat color = "brown lighten-5" height = "20"></v-card>

                            <v-row class="ml-8">
                                <p class = " display-1 font-weight-bold" color = "grey"> Vagas Ocupadas: 
                                    <span class = "display-1 font-weight-regular ">{{canil.capacidadeOcupada}}</span>
                                </p> 
                            </v-row>

                        </v-col>

                        <v-col cols="4">
                            <v-row class="ml-8">
                                <p class = " display-1 font-weight-bold" color = "grey"> HORÁRIO DE FUNCIONAMENTO: </p>
                            </v-row>

                            <v-col v-for="hor in sortedArray" :key = "hor.dia">
                                <v-row class="ml-8">
                                    <p class = "display-1 font-weight-bold ">{{dia(hor.dia)}}
                                        <span class = "display-1 font-weight-regular ">{{date(hor.dataInicio)}} - {{date(hor.dataFim)}}</span>    
                                    </p>  
                                </v-row>    
                            </v-col>
                        </v-col>

                            </v-row>
                        </v-card>
  
        </v-container>
        <v-card flat class = "ma-12">
            <v-row align = "end">
            <v-spacer></v-spacer>
            <v-btn v-if="canil.estado === 'Pendente'" class="ma-4 red--text" x-large color = "red" outlined @click="rejeitarRegisto()">
                Recusar Registo
            </v-btn>
            <v-btn v-else class="ma-4" x-large disabled>
                Recusar Registo
            </v-btn>
             <v-btn v-if="canil.estado === 'Pendente'" type="button" class="ma-4" x-large color = "deep-orange lighten-4" @click="aceitarRegisto()">
                Aceitar Registo
            </v-btn>
            <v-btn v-else class="ma-4" x-large disabled>
                Aceitar Registo
            </v-btn>
           
            </v-row>
        </v-card>
        <Footer :id="$route.params.id"/>
    </div>
</template> 

<script>
import NavbarAdmin from '@/components/NavbarFooter/NavbarAdmin.vue'
import Footer from '@/components/NavbarFooter/Footer.vue'
import store from '@/store.js'
import axios from 'axios'
import moment from 'moment/moment';
const lhost = require("@/config/global").host;

export default {
    data: () => ({
        canil: {},
        horario:[], 
    }),
    name: 'PedidoRegisto',
    props: ['id', 'id2'], 
    components: { NavbarAdmin, 
                  Footer, 
    },
    
    created: async function(){
        try {
            let response = await axios.get(lhost + "/api/Canis/" + this.id2,
            { headers: 
              { "Authorization": 'Bearer ' + store.getters.token }
            });
            this.canil = response.data;
            this.horario = response.data.horarios;
            this.ready = true;
        } 
        catch (e) {
            if(e.message == "Request failed with status code 401"){
                this.$store.commit("limpaStore");
                this.$router.push("/");
            }
        }
    },
    methods: {
        aceitarRegisto: async function(){
           try{ 
                var resposta = 
                await axios.put(lhost + "/api/Canis/" + this.id2 , 
                {
                    email: this.canil.email,
                    nib: this.canil.nib, 
                    nome: this.canil.nome, 
                    capacidadeOcupada: this.canil.capacidadeOcupada,
                    capacidadeTotal: this.canil.capacidadeTotal, 
                    distrito: this.canil.distrito, 
                    rua: this.canil.rua, 
                    localidade: this.canil.localidade, 
                    contacto: this.canil.contacto, 
                    estado: "Aceite", 
                    encriptado: this.canil.encriptado,
                },
                {
                    headers: { "Authorization": 'Bearer ' + store.getters.token }
                });
                this.$router.push("/pagina/admin/" + this.id); 
                console.log(JSON.stringify(resposta.data));
           }
           catch(e){
            if(e.message == "Request failed with status code 401"){
                this.$store.commit("limpaStore");
                this.$router.push("/");
            }
          }

          try{
                await axios.post(lhost + "/api/Mails",{
                    email: this.canil.email,
                    assunto: "CãoGest - Resposta ao pedido de registo",
                    texto: "O seu pedido de registo na plataforma CãoGest foi aprovado, pelo que poderá aceder à mesma." + '\n' + '\n' + "A equipa, " + '\n' + "CãoGest." ,
                },
                { headers: 
                    { "Authorization": 'Bearer ' + store.getters.token }
                });
          }
          catch(e){
              if(e.message == "Request failed with status code 401"){
                this.$store.commit("limpaStore");
                this.$router.push("/");
            }
          }
        },
        rejeitarRegisto: async function(){
           try{ 
                let vm = this;
                var resposta = 
                await axios.put(lhost + "/api/Canis/" + this.id2 , 
                {
                    email: vm.canil.email,
                    nib: vm.canil.nib, 
                    nome: vm.canil.nome, 
                    capacidadeOcupada: vm.canil.capacidadeOcupada,
                    capacidadeTotal: vm.canil.capacidadeTotal, 
                    distrito: vm.canil.distrito, 
                    rua: vm.canil.rua, 
                    localidade: vm.canil.localidade, 
                    contacto: vm.canil.contacto, 
                    estado: "Rejeitado", 
                    encriptado:1,
                },
                {
                    headers: { "Authorization": 'Bearer ' + store.getters.token }
                });
                this.$router.push("/pagina/admin/" + this.id); 
                console.log(JSON.stringify(resposta.data));
           }
           catch(e){
            if(e.message == "Request failed with status code 401"){
                this.$store.commit("limpaStore");
                this.$router.push("/");
            }
          }

          try{
                await axios.post(lhost + "/api/Mails",{
                    email: this.canil.email,
                    assunto: "CãoGest - Resposta ao pedido de registo",
                    texto: "O seu pedido de registo na plataforma CãoGest foi recusado." + '\n' + "Para mais informações, entre em contacto conosco através de caogest@outlook.pt" + '\n' + '\n' + "A equipa, " + '\n' + "CãoGest." ,
                },
                { headers: 
                    { "Authorization": 'Bearer ' + store.getters.token }
                });
          }
          catch(e){
              if(e.message == "Request failed with status code 401"){
                this.$store.commit("limpaStore");
                this.$router.push("/");
            }
          }
        },
        date: function (date) {
            return moment(date).locale("pt").format('LT');
        },
        dia: function (num) {
            if(num === 1) return "Segunda-feira"
            else if (num === 2) return "Terça-feira";
            else if (num === 3) return "Quarta-feira"; 
            else if (num === 4) return "Quinta-feira"; 
            else if (num === 5) return "Sexta-feira"; 
            else if (num === 6) return "Sábado";
            return "Domingo";
        }
    }, 
    computed: {
        sortedArray: function() {
            function compare(a, b) {
            if (a.dia < b.dia)
                return -1;
            if (a.dia > b.dia)
                return 1;
            return 0;
            }

            return this.horario.slice(0).sort(compare);
        }
    }, 
}
</script>     