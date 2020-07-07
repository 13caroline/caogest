<template>
    <div id = "schedule" class = "schedule">
        <Navbar :id="$route.params.id"/>
        <v-card> 
            <v-img src='@/assets/horários.png'>
                <v-row align = "end" justify = "end">
                        <v-btn text class = "white--text overline font-weight-thin text--secondary" href="http://rebloggy.com/post/photoset-dog-animals-orange-up-autumn-dogs-leaves-border-collie-under-1k-uncropp/122979725672">hiperligação para a imagem original</v-btn>
                </v-row>
            </v-img>
        </v-card>
        <v-card flat height= "100" color = "white"></v-card>

        <v-container>

            <v-card flat height= "100" color = "white"></v-card>

            <v-row>
                <v-card class = "display-1 mx-auto text-center justify-center" width="2000" height = "50" flat color = "brown lighten-5" v-if="sortedArray.length == 0">Este canil não tem horários registados.</v-card>
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
                                    <div class = "text-center display-1 font-weight-bold black--text">{{dia(hor.dia)}}</div>
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
                                        {{hor.capacidade}} Voluntários
                                    </v-chip>
                            </v-row>
                            
                        </v-col>
                    </v-card>
                </v-col>
            </v-row>
        </v-container>
        <Footer :id="$route.params.id"/>
    </div>
</template>

<script>
import Navbar from '@/components/NavbarFooter/NavbarAdmin.vue'
import Footer from '@/components/NavbarFooter/FooterAdmin.vue'
import store from '@/store.js'
import moment from 'moment/moment';
import axios from 'axios'
const lhost = require("@/config/global").host;

export default {
    data: () => ({             
         horario:[] ,
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
    created: async function(){
        try {
            let response = await axios.get(lhost + "/api/Horarios/" + this.id2,
            { headers: 
              { "Authorization": 'Bearer ' + store.getters.token }
            });
            this.horario = response.data;
            this.ready = true;
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