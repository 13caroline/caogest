<template>
    <div id = "schedule" class = "schedule">
        <Navbar :id="$route.params.id"/>
        <v-card> 
            <v-img src='@/assets/horários.png'>
            </v-img>
        </v-card>
        <v-card flat height= "100" color = "white"></v-card>

        <v-container>

            <v-card flat height= "100" color = "white"></v-card>

            <v-row>
                <v-col v-for="hor in sortedArray" :key = "hor.dia" cols="12" md="4" >
                    <v-card
                        color="white"
                        class="d-flex align-center"
                        dark
                        height="400"
                    >
                        <v-col>
                            <v-row>
                                <v-flex xs12 text-xs-center>
                                    <div class = "text-center display-1 font-weight-bold black--text">{{semana(hor.dia)}}</div>
                                </v-flex>
                            </v-row>
                            
                            <v-card flat height= "30" color = "white"></v-card>
                            
                            <v-row>
                                <v-flex xs12 text-xs-center>
                                    <div class = "text-center headline black--text">{{date(hor.dataInicio)}} - {{date(hor.dataFim)}}</div>
                                </v-flex>    
                            </v-row>

                            <v-card flat height= "30" color = "white"></v-card>

                            <v-row align = "center" justify = "center">
                                    <v-chip color = "deep-orange lighten-4" class = "black--text">
                                        {{hor.registados}} Voluntários
                                    </v-chip>
                            </v-row>

                            <v-card flat height= "60" color = "white"></v-card>

                            <v-row align = "center" justify = "center">
                                <v-btn v-if="hor.registados == hor.capacidade" bottom absolute disabled class = "headline" light block>Registar em Horário</v-btn>
                                <v-btn v-else bottom absolute class = "headline" color = "brown lighten-4" light block @click="regista(hor)">Registar em Horário</v-btn>
                            </v-row>
                            
                        </v-col>
                    </v-card>
                </v-col>
            </v-row>
        </v-container>
        <div class="text-center ma-2">
        <v-snackbar
          v-model="snackbar"
          :color="color"
          :timeout="timeout"
          bottom
          multi-line
          class = "headline"
        >
          {{ text }}
          <v-btn class = "headline" text @click="fecharSnackbar">Fechar</v-btn>
        </v-snackbar>
        </div>
        <Footer :id="$route.params.id"/>
    </div>
</template>

<script> 
import Navbar from '@/components/NavbarFooter/Navbar.vue'
import Footer from '@/components/NavbarFooter/Footer.vue'
import store from '@/store.js'
import moment from 'moment/moment';
import axios from 'axios'
const lhost = require("@/config/global").host;

export default {
    data: () => ({             
        horario:[] ,
        snackbar: false, 
        color: "", 
        done: false, 
        timeout: 4000,
        text: "", 
    }),
    name: 'HorarioCanil',
    props: ['id', 'id2'], 
    components: { Navbar, 
                  Footer,
                },
    methods: {
        date: function (date) {
            return moment(date).locale("pt").format('LT');
        },
        semana: function (num) {
            if(num === 1) return "Segunda-feira"
            else if (num === 2) return "Terça-feira";
            else if (num === 3) return "Quarta-feira"; 
            else if (num === 4) return "Quinta-feira"; 
            else if (num === 5) return "Sexta-feira"; 
            else if (num === 6) return "Sábado";
            return "Domingo";
        },
        regista: async function(hor){
            try{
                var resposta = 
                    await axios.post(lhost + "/api/HU", 
                    {
                        horario_DataInicio: hor.dataInicio, 
                        horario_DataFim: hor.dataFim, 
                        horario_Dia: hor.dia,
                        horario_Canil_User_Email: this.id2,
                        utilizador_email: this.id,        
                    },
                    { headers: 
                        { "Authorization": 'Bearer ' + store.getters.token }
                    },
                    ); 
            console.log(JSON.stringify(resposta.data));
            this.text = "Registo no horário efetuado com sucesso!";
            this.color = "success"; 
            this.snackbar = true; 
            this.atualiza();
          }
          catch(e){
            if(e.message == "Request failed with status code 401"){
                this.$store.commit("limpaStore");
                this.$router.push("/");
            }
            this.text = "Já se encontra registado neste horário";
            this.color = "warning"; 
            this.snackbar = true; 
          }
      }, 
      fecharSnackbar() {
        this.snackbar = false;
      },
      atualiza: async function(){
        try {
            let response = await axios.get(lhost + "/api/Horarios/" + this.id2,
            { headers: 
              { "Authorization": 'Bearer ' + store.getters.token }
            });
            this.horario = response.data;
        } 
        catch (e) {
            if(e.message == "Request failed with status code 401"){
                this.$store.commit("limpaStore");
                this.$router.push("/");
            }
        }
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
        },
    },
    created: async function(){
        try {
            let response = await axios.get(lhost + "/api/Horarios/" + this.id2,
            { headers: 
              { "Authorization": 'Bearer ' + store.getters.token }
            });
            this.horario = response.data;
        } 
        catch (e) {
            if(e.message == "Request failed with status code 401"){
                this.$store.commit("limpaStore");
                this.$router.push("/");
            }
        }
    }, 
}
</script>
