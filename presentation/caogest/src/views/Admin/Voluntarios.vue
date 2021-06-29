<template>
    <div id = "volunteers" class = "Volunteers">
        <NavbarAdmin :id="$route.params.id"/>
        <v-card> 
            <v-img src='@/assets/voluntarios.png'>
                <v-row align = "end" justify = "end">
                    <v-btn text class = "white--text overline font-weight-thin text--secondary" href="https://stopcambioclimatico.es/2018/04/26/cuidar-los-animales-cuidar-del-medioambiente/">hiperligação para a imagem original</v-btn>
                </v-row>
            </v-img>
        </v-card>
        <v-card flat height= "200" max-width="800" color = "transparent"></v-card>
        <v-container class="my-5">
            <v-layout row class="mb-3"> 
                <v-tooltip top>
                    <template v-slot:activator="{ on }">
                        <v-btn 
                            class = "ma-2" 
                            text 
                            @click="sortByNome('nomeUser')" 
                            v-on="on"
                        >
                            <v-icon 
                                left 
                                small
                            >person
                            </v-icon>    
                                <span 
                                    class = "headline caption text-lowercase"
                                >Por nome
                                </span>
                        </v-btn>  
                    </template>
                    <span>Ordenar voluntários por nome</span> 
                </v-tooltip>

                <v-tooltip top>
                    <template v-slot:activator="{ on }">
                        <v-btn 
                            class = "ma-2" 
                            text 
                            @click="sortByNome('nomeCanil')" 
                            v-on="on"
                        >
                            <v-icon 
                                left 
                                small
                            >pets
                            </v-icon>    
                            <span 
                                class = "headline caption text-lowercase"
                            >Por canil
                            </span>
                        </v-btn>  
                    </template>
                    <span>Ordenar voluntários por canil </span> 
                </v-tooltip>
            </v-layout>

                <v-card flat v-for="voluntario in voluntarios" :key="voluntario.nome">
                     <v-layout row wrap :class="`pa-7 voluntario ${voluntario.sexo}`">
                    <v-flex xs4 sm3>
                        <div class="caption grey--text">Nome</div>
                        <div class = "headline">{{ voluntario.nomeUser }}</div>
                    </v-flex>
                    <v-flex xs4 sm3>
                        <div class="caption grey--text">Email</div>
                        <div class = "headline">{{ voluntario.mailUser}}</div>
                    </v-flex>
                    <v-flex xs4 sm4>
                        <div class="caption grey--text">Nome Canil</div>
                        <div class = "headline">{{ voluntario.nomeCanil }}</div>
                    </v-flex>
                    <v-flex xs4 sm2>
                        <div class="caption grey--text">Data de Nascimento</div>
                        <div class="method headline">{{date(voluntario.data_de_nascimento)}}</div>
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

    data() {
        return {
        voluntarios: [],
        fab:false,
        };
    },
    methods: {
        sortByNome(prop){
            this.voluntarios.sort((a,b) => a[prop] < b[prop] ? -1 : 1)
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
            let response = await axios.get(lhost + "/api/Voluntarios",
            { headers: 
              { "Authorization": 'Bearer ' + store.getters.token }
            });
            this.voluntarios = response.data;
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


<style>
.voluntario.Feminino {
  border-left: 4px solid rgb(240, 200, 219);
}

.voluntario.Masculino {
  border-left: 4px solid rgb(158, 210, 232);
}
 

</style>
