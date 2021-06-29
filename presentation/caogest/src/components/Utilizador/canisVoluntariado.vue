<template>
    <div>
        <v-layout row class="mb-1"> 
            <v-tooltip top>
                <template v-slot:activator="{ on }">
                    <v-btn class = "ma-2" text @click="sortBy('nomeCanil')" v-on="on">
                        <v-icon left small>pets</v-icon>    
                        <span class = "caption text-lowercase">Por canil</span>
                    </v-btn>  
                </template>
                <span>Ordenar canis em voluntariado por nome de canil</span> 
            </v-tooltip>
            <v-tooltip top>
                <template v-slot:activator="{ on }">
                    <v-btn class = "ma-2" text @click="sortBy('localidade')" v-on="on">
                        <v-icon left small>pets</v-icon>    
                        <span class = "caption text-lowercase">Por localidade</span>
                    </v-btn>  
                </template>
                <span>Ordenar canis em voluntariado por localidade</span> 
            </v-tooltip>
        </v-layout>

      <v-card flat height = "20"></v-card>
      <v-card class = "mx-auto" height = "80" width="2000" flat color = "brown lighten-5" v-if="this.canis.length === 0"> 
        <v-card-title class = "display-1 text-center justify-center"> Não se voluntariou para nenhum canil </v-card-title>
      </v-card>
      <v-card v-else flat v-for="(canil, indice) in canis" :key="indice" >
        <v-layout row wrap :class="`pa-7 canil`">
          <v-flex xs8 md6>
            <div class="caption grey--text">Nome Canil</div>
            <div class=" headline"> {{canil.nomeCanil }} </div>
          </v-flex>
          <v-flex xs8 md4>
            <div class="caption grey--text">Localidade</div>
            <div class="method headline">{{canil.localidade}}</div>
          </v-flex>
          <v-flex xs8 md1>
            <div class="caption grey--text">Contacto</div>
            <div class="method headline">{{canil.contacto}}</div>
          </v-flex>
        </v-layout>
        <v-divider></v-divider>
      </v-card>
    </div>
</template>

<script>
import axios from 'axios'
import store from '@/store'
const lhost = require("@/config/global").host;

export default {
    data() {
    return {
      canis: [],
     
    };
  },
  name: 'Voluntariado',    
  props: ['id'], 
  methods: {
    sortBy(prop){
          this.canis.sort((a,b) => a[prop] < b[prop] ? -1 : 1)
    },
    sortByData(prop){
          this.canis.sort((a,b) => a[prop] < b[prop] ? 1 : -1)
    },
  },
  created: async function(){
    try {
      let resposta = await axios.get(lhost + "/api/Voluntarios/Utilizador/" + this.id, 
      { headers: 
          { "Authorization": 'Bearer ' + store.getters.token }
      });
      this.canis = resposta.data; 
      this.ready = true;
    } 
    catch (e) {
      if(e.message == "Request failed with status code 401"){
                this.$store.commit("limpaStore");
                this.$router.push("/");
            }
    }
  }    
};
</script>