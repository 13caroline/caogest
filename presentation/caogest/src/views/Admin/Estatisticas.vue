<template>
    <div id="entreemcontacto" class="entreemcontacto">
        <NavbarAdmin  :id="$route.params.id"/>
        <v-card>
            <v-img src="@/assets/estatisticas.png">
                <v-row align = "end" justify = "end">
                    <v-btn text class = "white--text overline font-weight-thin text--secondary" href="https://www.facebook.com/zmyslowska.photo/photos/the-cutestcanon-1dx-and-canon-135mm-f20l/1481841221867109/">hiperligação para a imagem original</v-btn>
                </v-row>    
            </v-img>
        </v-card>
        <v-card flat height="150" color="white"></v-card>

        <v-container fluid grid-list-md>
            <v-layout row wrap>
            <v-flex
                md3
                sm6
                xs12
                full
                v-for="(stat, index) in stats"
                v-bind:key="index"
            >
                <v-card :class="stat.bgColor" dark>
                    <v-container fluid grid-list-sm dark>
                        <v-layout class="mt-6 mb-6 mx-6" row wrap>
                        <v-flex sm3 hidden-xs-only>
                            <v-icon class="mx-0" x-large dark>{{ stat.icon }}</v-icon>
                        </v-flex>
                        <v-flex sm9 xs12>
                            <v-layout class="mt-0 mb-0 pa-0" row wrap>
                            <v-flex d-flex xs12>
                                <div class="silver--text headline">{{ stat.title }}</div>
                            </v-flex>
                            <v-flex d-flex xs12 class="mx-4">
                                <div class="silver--text display-1">{{ stat.data }}</div>
                                &nbsp;&nbsp;
                                
                            </v-flex>
                            </v-layout>
                        </v-flex>
                        </v-layout>
                    </v-container>
                </v-card>
            </v-flex>
            </v-layout>
            <v-card height = "100" flat></v-card>
            <v-row>
                <v-col>
                    <v-layout row wrap>
                        <v-flex full>
                            <v-card light flat height = "1000">
                                <v-card-title class = "display-1 justify-center">Tipos de Utilizadores</v-card-title>
                                <v-card flat height= "100"></v-card>
                                <canisVSusers :width="600" :height="600"></canisVSusers>
                            </v-card>
                        </v-flex>
                    </v-layout>
                </v-col>
                <v-col>
                    <v-layout row wrap>
                        <v-flex full>
                            <v-card light flat height = "1000">
                                <v-card-title class = "display-1 justify-center">Pedidos de Registo de Canis</v-card-title>
                                <v-card flat height= "100"></v-card>
                                <pedidosRegisto :width="600" :height="600"></pedidosRegisto>
                            </v-card>
                        </v-flex>
                    </v-layout>
                </v-col>
                <v-col>
                    <v-layout row wrap>
                        <v-flex full>
                            <v-card light flat height = "1000">
                                <v-card-title class = "display-1 justify-center">Pedidos de Adoção</v-card-title>
                                <v-card flat height= "100"></v-card>
                                <nPedidos :width="600" :height="600"></nPedidos>
                            </v-card>
                        </v-flex>
                    </v-layout>
                </v-col>
            </v-row>

            <v-row>
                <v-col cols = "4">
                    <v-layout row wrap>
                        <v-flex ful4>
                            <v-card light flat height = "1000">
                                <v-card-title class = "display-1 justify-center">Número de Cães Adotados por Porte</v-card-title>
                                <v-card flat height= "100"></v-card>
                                <pedidosPorte :width="600" :height="600"></pedidosPorte>
                            </v-card>
                        </v-flex>
                    </v-layout>
                </v-col>
                <v-col cols = "8">
                    <v-layout row wrap>
                        <v-flex full>
                            <v-card light flat height = "1000">
                                <v-card-title class = "display-1 justify-center">Número de Cães Adotados por Mês</v-card-title>
                                <v-card flat height= "100"></v-card>
                                <nPedidosMes :width="600" :height="600"></nPedidosMes>
                            </v-card>
                        </v-flex>
                    </v-layout>
                </v-col>
            </v-row>

            <v-layout row wrap>
                <v-flex full>
                    <v-card light flat height = "1000">
                        <v-card-title class = "display-2">Número de Donativos por Mês</v-card-title>
                        <v-card flat height= "100"></v-card>
                        <donativosStats :width="600" :height="600"></donativosStats>
                    </v-card>
                </v-flex>
            </v-layout>
        </v-container>
        <v-btn
            v-scroll="onScroll"
            x-large
            v-show="fab"
            fab
            depressed
            fixed
            bottom
            right
            class = "ma-6"
            color="deep-orange lighten-4"
            @click="toTop"
        >
            <v-icon>keyboard_arrow_up</v-icon>
         </v-btn>   
        <Footer  :id="$route.params.id"/>
    </div>    
</template>

<script>
import NavbarAdmin from '@/components/NavbarFooter/NavbarAdmin.vue'
import Footer from '@/components/NavbarFooter/Footer.vue'
import nPedidos from '@/components/chart/estadoPedidos'
import canisVSusers from '@/components/chart/canisVSusers'
import nPedidosMes from '@/components/chart/nPedidosMes'
import pedidosPorte from '@/components/chart/pedidosPorte'
import pedidosRegisto from '@/components/chart/pedidosRegisto'
import donativosStats from '@/components/chart/donativosStat'
import store from '@/store.js'
import axios from 'axios'
const lhost = require("@/config/global").host;

export default {
    data: () => ({
        fab:false,
        stats: [],
    }),
    name: 'Estatistica',
    props: ['id'], 
    components: { NavbarAdmin, 
                  Footer,
                  nPedidos,
                  canisVSusers, 
                  nPedidosMes,
                  pedidosPorte,
                  pedidosRegisto,
                  donativosStats
    },
    mounted() {
    this.getNumeroUtilizadores();
    this.getNumeroCaes();
    this.getNumeroVoluntarios();
    this.getNumeroAdocoes();
    },
    methods: {
        onScroll (e) {
            if (typeof window === 'undefined') return
            const top = window.pageYOffset ||   e.target.scrollTop || 0
            this.fab = top > 20
        },
        toTop () {
            this.$vuetify.goTo(0)
        },
        getNumeroUtilizadores: async function() {
            try{
                let response = await axios.get(lhost + "/api/Stats/Users", 
                { headers: 
                    { "Authorization": 'Bearer ' + store.getters.token }
                });

                this.stats.push({
                    bgColor: "brown darken-2",
                    icon: "person",
                    title: "Número de Utilizadores Registados",
                    data: response.data - 1,
                });
            }
            catch(error){
                 if(error.message == "Request failed with status code 401"){
                this.$store.commit("limpaStore");
                this.$router.push("/");
            }
            }
        },
        async getNumeroCaes() {
            try{
                let response = await axios.get(lhost + "/api/Stats/Caes", 
                { headers: 
                    { "Authorization": 'Bearer ' + store.getters.token }
                });
                this.stats.push({
                    bgColor: "brown darken-2",
                    icon: "pets",
                    title: "Número de Cães Registados",
                    data: response.data,
                });
            }
            catch(error){
                 if(error.message == "Request failed with status code 401"){
                this.$store.commit("limpaStore");
                this.$router.push("/");
            }
            }
        },
        async getNumeroVoluntarios() {
            try{
                let response = await axios.get(lhost + "/api/Stats/Voluntarios", 
                { headers: 
                    { "Authorization": 'Bearer ' + store.getters.token }
                });
                this.stats.push({
                    bgColor: "brown darken-2",
                    icon: "accessibility_new",
                    title: "Número de Voluntários",
                    data: response.data,
                });
            }
            catch(error){
                 if(error.message == "Request failed with status code 401"){
                this.$store.commit("limpaStore");
                this.$router.push("/");
            }
            }
        },
        async getNumeroAdocoes() {
            try{
                let response = await axios.get(lhost + "/api/Stats/Adocoes", 
                    { headers: 
                        { "Authorization": 'Bearer ' + store.getters.token }
                    });
                this.stats.push({
                    bgColor: "brown darken-2",
                    icon: "home",
                    title: "Número de Adoções Realizadas",
                    data: response.data,
                });
            }
            catch(error) {
                if(error.message == "Request failed with status code 401"){
                this.$store.commit("limpaStore");
                this.$router.push("/");
            }
            }
        },
    },
}
</script>

<style>
#Estatistica {
  font-family: "Avenir", Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
</style>
