<template>
    <div id = "donationskennel" class = "donationsKennel">
        <NavbarAdmin :id="$route.params.id"/>
            <v-card> 
                <v-img src='@/assets/donativosrealizados.png'>
                    <v-row align = "end" justify = "end">
                        <v-btn text class = "white--text overline font-weight-thin text--secondary" href="https://www.1zoom.me/fr/wallpaper/420585/z1845.3/">hiperligação para a imagem original</v-btn>
                    </v-row>   
                </v-img>
            </v-card>
            <v-card flat height= "150" color = "white"></v-card>

                <v-container class="my-5">
                    <v-layout row class="mb-3"> 
                        <v-tooltip top>
                            <template v-slot:activator="{ on }">
                                <v-btn class = "ma-2" text @click="sortBy('valor')" v-on="on">
                                    <v-icon left small>euro</v-icon>    
                                    <span class = "caption text-lowercase">Por quantia</span>
                                </v-btn>  
                            </template>
                            <span>Ordenar pedidos por quantia doada</span> 
                        </v-tooltip>

                        <v-tooltip top>
                            <template v-slot:activator="{ on }">
                                <v-btn class = "ma-2" text @click="sortByNome('canil_user_email')" v-on="on">
                                    <v-icon left small>pets</v-icon>    
                                    <span class = "caption text-lowercase">Por canil</span>
                                </v-btn>  
                            </template>
                            <span>Ordenar pedidos por canil de doação realizada</span> 
                        </v-tooltip>

                        <v-tooltip top>    
                            <template v-slot:activator="{ on }">
                                <v-btn class = "ma-2" text @click="sortBy('data')" v-on="on">
                                    <v-icon left small>today</v-icon>    
                                    <span class = "caption text-lowercase">Por data</span>
                                </v-btn> 
                            </template>
                            <span>Ordenar pedidos por data de submissão</span>
                        </v-tooltip>    
                    </v-layout>

                <v-card flat v-for="donativo in donativos" :key="donativo.nome">
                    <v-layout row wrap class="pa-7 project">
                    <v-flex xs4 sm3>
                        <div class="caption grey--text">Nome Donatário</div>
                        <div class=" headline">{{ donativo.utilizador_user_email }}</div>
                    </v-flex>
                    <v-flex xs4 sm4>
                        <div class="caption grey--text">Nome Canil</div>
                        <div class=" headline">{{ donativo.canil_user_email }}</div>
                    </v-flex>
                    <v-flex xs4 sm2>
                        <div class="caption grey--text">Valor do Donativo</div>
                        <div class=" headline"> {{ donativo.valor }}</div>
                    </v-flex>
                    <v-flex xs4 sm3>
                        <div class="caption grey--text">Data do Donativo</div>
                        <div class=" headline method">{{date(donativo.data)}}</div>
                    </v-flex>
                    </v-layout>
                    <v-divider></v-divider>
                </v-card>
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
            </v-container>
        <Footer :id="$route.params.id"/>
    </div>
</template>

<script>
import moment from 'moment/moment';
import NavbarAdmin from '@/components/NavbarFooter/NavbarAdmin.vue'
import Footer from '@/components/NavbarFooter/FooterAdmin.vue'
import store from '@/store.js'
import axios from 'axios'
const lhost = require("@/config/global").host;

export default {
    props:["id"],
    data() {
        return {
        donativos: [],
        fab:false, 
        };
    },
    methods: {
        sortBy(prop){
            this.donativos.sort((a,b) => a[prop] < b[prop] ? 1 : -1)
        },
        sortByNome(prop){
            this.donativos.sort((a,b) => a[prop] < b[prop] ? -1 : 1)
        },
        date: function (date) {
        return moment(date).locale("pt").format('LL');
        },
        onScroll (e) {
            if (typeof window === 'undefined') return
            const top = window.pageYOffset ||   e.target.scrollTop || 0
            this.fab = top > 20
        },
        toTop () {
        this.$vuetify.goTo(0)
        },
    }, 
     components: {
                NavbarAdmin, 
                Footer,
    }, 
    created: async function(){
        try {
            let response = await axios.get(lhost + "/api/Donativos",
            { headers: 
              { "Authorization": 'Bearer ' + store.getters.token }
            });
            this.donativos = response.data;
            this.ready = true;
        } 
        catch (e) {
            if(e.message == "Request failed with status code 401"){
                this.$store.commit("limpaStore");
                this.$router.push("/");
            }
        }
    },        
};
</script>
