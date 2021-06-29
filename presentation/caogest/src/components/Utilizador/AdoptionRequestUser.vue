<template>
  <div id="adoptionrequest">
    <v-card flat height="200" color="white"></v-card>
    <p class="my-5 display-2 font-weight-bold text-center">Pedidos de Adoção</p>
    <v-card flat height="40" color="white"></v-card>

    <v-container class="my-5">

         <v-layout row class="mb-1"> 
            <v-tooltip top>
                <template v-slot:activator="{ on }">
                    <v-btn class = "ma-2" text @click="sortBy('nome_Canil')" v-on="on">
                        <v-icon left small>pets</v-icon>    
                        <span class = "caption text-lowercase">Por canil</span>
                    </v-btn>  
                </template>
                <span>Ordenar pedidos por nome de canil</span> 
            </v-tooltip>

            <v-tooltip top>    
              <template v-slot:activator="{ on }">
                <v-btn class = "ma-2" text @click="sortByData('data')" v-on="on">
                  <v-icon left small>today</v-icon>    
                  <span class = "caption text-lowercase">Por data</span>
                </v-btn> 
              </template>
              <span>Ordenar pedidos por data de submissão</span>
            </v-tooltip>  

            <v-tooltip top>
                <template v-slot:activator="{ on }">
                    <v-btn class = "ma-2" text @click="sortBy('estado')" v-on="on">
                        <v-icon left small>info</v-icon>    
                        <span class = "caption text-lowercase">Por estado</span>
                    </v-btn>  
                </template>
                <span>Ordenar pedidos por estado do pedido</span> 
            </v-tooltip>
        </v-layout>

      <v-card flat height = "100"></v-card>
      <v-card class = "mx-auto" height = "80" width="2000" flat color = "brown lighten-5" v-if="this.pedidos.length === 0"> 
        <v-card-title class = "display-1 text-center justify-center"> Não existem pedidos de adoção </v-card-title>
        
      </v-card>
      <v-card v-else flat v-for="pedido in pedidos" :key="pedido.nPedido">
        <v-layout row wrap :class="`pa-7 pedido ${pedido.estado}`">
          <v-flex xs8 md2>
            <div class="caption grey--text">Nome Cão</div>
            <div class=" headline">{{ pedido.nome_Cao }}</div>
          </v-flex>
          <v-flex xs12 md5>
            <div class="caption grey--text">Nome Canil</div>
            <div class=" headline">{{ pedido.nome_Canil }}</div>
          </v-flex>
          <v-flex xs8 md2>
            <div class="caption grey--text">Data de Submissão</div>
            <div class="method headline">{{date(pedido.data)}}</div>
          </v-flex>
          <v-flex xs8 md2>
               <v-chip :color="project_status(pedido.estado)" class="black--text caption my-2" @click="pedidoadocao(pedido)">{{pedido.estado}}</v-chip> 
            <div>
            </div>
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
import moment from 'moment/moment';
import store from '@/store'
import axios from 'axios'
const lhost = require("@/config/global").host;

export default {
  data() {
    return {
      pedidos: [],
      individual: {},
      dialog:false, 
      fab:false,
      fotos:[],
      utilizador_user_email:"",
      cao_idCao:"", 
      cc:"", 
      tipoMoradia:"", 
      exterior:"", 
      habitacao:"", 
      permissao:"", 
      motivo:"", 
      ausencia:"", 
      alergia:"", 
      donoAnimal:"", 
      descAnimais:"", 
      comprovativo:"", 
    };
  },
  name: 'AdoptionRequest',    
  props: ['id'], 
  methods: {
    sortBy(prop){
          this.pedidos.sort((a,b) => a[prop] < b[prop] ? -1 : 1)
    },
    sortByData(prop){
          this.pedidos.sort((a,b) => a[prop] < b[prop] ? 1 : -1)
    },

    project_status(estado) {
        if (estado == "Aceite") 
          return "#C5E1A5";
        else if (estado == "Pendente") 
          return "#FFE082";
        else if (estado == "Expirado")
          return "#B39DDB";
        else if (estado == "Concluído")
          return "#B2EBF2";
        return "#EF9A9A";
    }, 
    pedidoadocao: function(pedido){
      this.$router.push("/pedido/adocao/" + this.id + '/' + pedido.nPedido );
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
    getPath: function(e) {
           return e.fotos[0].path;
        },
  },
  created: async function(){
    try {
      let response = await axios.get(lhost + "/api/AdocoesUtilizador/" + this.id, 
      { headers: 
          { "Authorization": 'Bearer ' + store.getters.token }
      });
      this.pedidos = response.data;
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

<style>
.pedido.Aceite {
  border-left: 4px solid #C5E1A5;
}

.pedido.Pendente {
  border-left: 4px solid #FFE082;
}

.pedido.Expirado {
  border-left: 4px solid #B39DDB;
}

.pedido.Recusado {
    border-left: 4px solid #EF9A9A;
}

.pedido.Concluído{
    border-left: 4px solid #B2EBF2;
}

</style>

