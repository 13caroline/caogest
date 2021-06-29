<template>
  <div id="adoptionrequest">

    <v-card flat height="200" color="white"></v-card>

    <v-container class="my-5" >

        <v-layout row class="mb-1"> 
            <v-tooltip top>
                <template v-slot:activator="{ on }">
                    <v-btn class = "ma-2" text @click="sortBy('utilizador_user_email')" v-on="on">
                        <v-icon left small>person</v-icon>    
                        <span class = "caption text-lowercase">Por nome de utilizador</span>
                    </v-btn>  
                </template>
                <span>Ordenar pedidos por nome de utilizador</span> 
            </v-tooltip>

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
        </v-layout>

      <v-card flat v-for="pedido in pedidos" :key="pedido.nPedido">
        <v-layout row wrap :class="`pa-7 project ${pedidos.status}`">
          <v-flex xs4 md2>
            <div class="caption grey--text">Nome Utilizador</div>
            <div>{{ pedido.utilizador_user_email }}</div>
          </v-flex>
          <v-flex xs8 md4>
            <div class="caption grey--text">Nome Canil</div>
            <div>{{ pedido.nome_Canil }}</div>
          </v-flex>
          <v-flex xs8 md2>
            <div class="caption grey--text">Nome Cão</div>
            <div>{{ pedido.cao_idCao }}</div>
          </v-flex>
          <v-flex xs8 md2>
            <div class="caption grey--text">Data de Submissão</div>
            <div class="method">{{date(pedido.data)}}</div>
          </v-flex>
          <v-flex xs2 md2>
               <v-chip :color="project_status(pedido.estado)" class="black--text caption my-2" @click="pedidoadocao(pedido)">{{pedido.estado}}</v-chip> 
            <div>
            </div>
          </v-flex>
        </v-layout>
        <v-divider></v-divider>
      </v-card>
    </v-container>

  </div>
</template>

<script>
import moment from 'moment/moment';
import axios from 'axios'
const lhost = require("@/config/global").host;

export default {
  data() {
    return {
      pedidos: [],
    };
  },
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
        return "#EF9A9A";
    },  
    pedidoadocao: function(pedido){
      this.$router.push("/pedidoAdocaoadmin/" + pedido.nPedido);
    }, 
    date: function (date) {
      return moment(date).locale("pt").format('LL');
    }
  },


  created: async function(){
    try {
      let response = await axios.get(lhost + "/api/Adocoes");
      this.pedidos = response.data;
      this.ready = true;
    } 
    catch (e) {
      return e;
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

.pedido.Rejeitado {
    border-left: 4px solid #EF9A9A;
}

</style>