<template>
  <div id="adoptionrequest">

    <v-card flat height="100" color="white"></v-card>

    <v-container class="my-5">

        <v-layout row class="mb-3"> 
            <v-tooltip top>
                <template v-slot:activator="{ on }">
                    <v-btn class = "ma-2" text @click="sortBy('nome')" v-on="on">
                        <v-icon left small>pets</v-icon>    
                        <span class = "caption text-lowercase">Por nome de canil</span>
                    </v-btn>  
                </template>
                <span>Ordenar pedidos por nome de canil</span> 
            </v-tooltip>

            <v-tooltip top>
                <template v-slot:activator="{ on }">
                    <v-btn class = "ma-2" text @click="sortBy('estado')" v-on="on">
                        <v-icon left small>pets</v-icon>    
                        <span class = "caption text-lowercase">Por estado de pedido</span>
                    </v-btn>  
                </template>
                <span>Ordenar pedidos por estado</span> 
            </v-tooltip>

        </v-layout>

      <v-card flat v-for="pedido in pedidos" :key="pedido.nome">
        <v-layout row wrap :class="`pa-7 pedido ${pedido.estado}`">
          <v-flex xs12 md6>
            <div class="caption grey--text">Nome Canil</div>
            <div class=" headline">{{ pedido.nome }}</div>
          </v-flex>
          <v-flex xs8 md4>
            <div class="caption grey--text">Email Canil</div>
            <div class=" headline">{{ pedido.email}}</div>
          </v-flex>
          <v-flex xs2 sm4 md2>
               <v-chip :color="estadopedido(pedido.estado)" class="black--text caption my-2" @click="pedidoregisto(pedido)">{{pedido.estado}}</v-chip> 
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
import axios from 'axios'
const lhost = require("@/config/global").host;
import store from '@/store.js'

export default {
  props:['id'],
  data() {

    return {
      pedidos: [],
      fab:false,
    };
  },
  methods: {
    sortBy(prop){
          this.pedidos.sort((a,b) => a[prop] < b[prop] ? -1 : 1)
    },
    estadopedido(estado) {
            if (estado == "Aceite") 
              return "#C5E1A5";
            else if (estado == "Pendente") 
              return "#FFE082";
            return "#EF9A9A";
    },
    pedidoregisto: function(pedido){
      this.$router.push("/pedido/registo/" + this.id + '/' + pedido.email);
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
    created: async function(){
        try {
        let response = await axios.get(lhost + "/api/Canis",
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
    },  
};
</script>

<style>
.pedido.Aceite {
  border-left: 4px solid #C5E1A5;
}

.pedido.Pendente {
  border-left: 4px solid #FFE082;
}

.pedido.Rejeitado {
    border-left: 4px solid #EF9A9A;
}

</style>