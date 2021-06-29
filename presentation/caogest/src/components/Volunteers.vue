<template>
    <div>
        <v-card flat height= "200" max-width="800" color = "transparent"></v-card>
                    <v-container class="my-5">
                        <v-layout row class="mb-3"> 
                            <v-tooltip top>
                                <template v-slot:activator="{ on }">
                                    <v-btn class = "ma-2" text @click="sortBy('nome')" v-on="on">
                                        <v-icon left small>person</v-icon>    
                                        <span class = "caption text-lowercase">Por nome de voluntário</span>
                                    </v-btn>  
                                </template>
                                <span>Ordenar voluntários por nome</span> 
                            </v-tooltip>

                            <v-tooltip top>
                                <template v-slot:activator="{ on }">
                                    <v-btn class = "ma-2" text @click="sortBy('idade')" v-on="on">
                                        <v-icon left small>person</v-icon>    
                                        <span class = "caption text-lowercase">Por idade de voluntário</span>
                                    </v-btn>  
                                </template>
                                <span>Ordenar voluntários por idade</span> 
                            </v-tooltip>
                        </v-layout>

                        <v-card flat height = "100"></v-card>
                        <v-card class = " mx-auto" height = "80" width="2000" flat color = "brown lighten-5" v-if="this.voluntarios.length === 0"> 
                            <v-card-title class = "display-1 text-center justify-center"> Não existem voluntários associados </v-card-title>
                        </v-card>
                        <v-card v-else flat v-for="voluntario in voluntarios" :key="voluntario.nome">
                            <v-layout row wrap :class="`pa-7 voluntario ${voluntario.sexo}`">
                            <v-flex xs12 md4>
                                <div class="caption grey--text">Nome Voluntário</div>
                                <div>{{ voluntario.nomeUser }}</div>
                            </v-flex>
                            <v-flex xs6 sm4 md4>
                                <div class="caption grey--text">Email</div>
                                <div>{{ voluntario.mailUser }}</div>
                            </v-flex>
                             <v-flex xs6 sm4 md2>
                                <div class="caption grey--text">Idade</div>
                                <div>{{ date(voluntario.data_de_nascimento) }} anos</div>
                            </v-flex>
                            <v-flex xs6 sm4 md2>
                                <div class="caption grey--text">Contacto</div>
                                <div>{{ voluntario.contacto}}</div>
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
    </div>
</template>

<script>
import axios from 'axios'
import store from '@/store.js'
import moment from 'moment/moment';
const lhost = require("@/config/global").host;

export default {
  name:"voluntarios",
  props:['id'],
  data() {
    return {
        fab:false, 
        voluntarios: []
    };
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
    sortBy(prop){
          this.voluntarios.sort((a,b) => a[prop] < b[prop] ? -1 : 1)
    },
    date: function (birthday) {
      return moment().diff(birthday, 'years');
    },
  },
  created: async function(){
        try {
            let response = await axios.get(lhost + "/api/Voluntarios/" + this.id,
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