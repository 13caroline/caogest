<template>
  <div id="adoptionrequest">

    <v-card flat height="200" color="white"></v-card>

    <v-container class="my-5" >

        <v-layout row class="mb-1"> 
            <v-tooltip top>
                <template v-slot:activator="{ on }">
                    <v-btn class = "ma-2" text @click="sortBy('nome_Utilizador')" v-on="on">
                        <v-icon left small>person</v-icon>    
                        <span class = "caption text-lowercase">Por nome de utilizador</span>
                    </v-btn>  
                </template>
                <span>Ordenar pedidos por nome de utilizador</span> 
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
                <v-btn class = "ma-2" text @click="sortByData('estado')" v-on="on">
                  <v-icon left small>info</v-icon>    
                  <span class = "caption text-lowercase">Por estado</span>
                </v-btn> 
              </template>
              <span>Ordenar pedidos por estado do pedido</span>
            </v-tooltip>  
        </v-layout>

       <v-card flat height = "100"></v-card>
      <v-card class = " mx-auto" height = "80" width="2000" flat color = "brown lighten-5" v-if="this.pedidos.length === 0"> 
        <v-card-title class = "display-1 text-center justify-center"> Não existem pedidos de adoção </v-card-title>
      </v-card>
      <v-card v-else flat v-for="pedido in pedidos" :key="pedido.nPedido">
        <v-layout row wrap :class="`pa-7 pedido ${pedido.estado}`">
          <v-flex xs8 md4>
            <div class="caption grey--text">Nome Utilizador</div>
            <div class=" headline">{{ pedido.nome_Utilizador }}</div>
          </v-flex>
          <v-flex xs8 md2>
            <div class="caption grey--text">Nome Cão</div>
            <div class=" headline">{{ pedido.cao_idCao }}</div>
          </v-flex>
          <v-flex xs8 md3>
            <div class="caption grey--text">Data de Submissão</div>
            <div class="method headline">{{date(pedido.data)}}</div>
          </v-flex>
          <v-flex>
               <v-chip :color="project_status(pedido.estado)" class="black--text caption my-2" @click="pedidoadocao(pedido)">{{pedido.estado}}</v-chip> 
          </v-flex>
          <v-flex xs1 md1>
            <v-row align="center" justify="center">
              <v-col>
                <v-tooltip right v-if="(diasPassados(pedido) && pedido.estado === 'Aceite')">
                  <template v-slot:activator="{ on}">
                    <v-btn x-small fab depressed v-on="on" @click="openDecision(pedido)" color ="red lighten-3">
                      <v-icon>
                        priority_high
                      </v-icon>
                    </v-btn> 
                  </template>
                  Foi ultrapassado o limite de 10 dias
              </v-tooltip>

              <v-tooltip right v-else>
                <template v-slot:activator="{ on}">
                  <v-btn x-small fab depressed v-on="on" color ="grey lighten-4">
                    <v-icon>
                      priority_high
                    </v-icon>
                  </v-btn> 
                </template>
                Não existem assuntos pendentes
               </v-tooltip>
              </v-col>
            </v-row>
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
    <v-row justify="center">
    <v-dialog v-model="dialog" persistent max-width = "800" max-height = "800">
      <v-card>
        <v-card-title class="display-1">Fecho do Processo de Adoção</v-card-title>
        <v-card-text class = "headline">Após um pedido de adoção ser aceite, o utilizador tem um prazo de 10 dias para ir buscar a sua nova alma gémea. Após esse período, o canil deve indicar se este processo foi corretamente concluído.</v-card-text>
        <v-card-actions>
          <v-spacer></v-spacer>
          <v-btn large color="red lighten-3" class=" headline ma-4" @click="expiraPedido()">Adoção Interrompida</v-btn>
          <v-btn large color="light-green lighten-3" class="headline ma-4" @click="concluiPedido()">Adoção concluída</v-btn>
        </v-card-actions>
      </v-card>
    </v-dialog>
  </v-row>
  </div>
</template>

<script>
import moment from 'moment/moment';
import axios from 'axios'
import store from '@/store.js'
const lhost = require("@/config/global").host;

export default {
  name:"adoption",
  props:['id', 'id2'],
  data() {
    return {
      pedidos: [],
      fab:false,
      dialog: false, 
      nPedido: "", 
      data: "", 
      estado: "", 
      cao_idCao: "", 
      identificacao: "",
      permissao: "", 
      alergia: "", 
      descAnimais: "", 
      ausencia: "",
      habitacao: "", 
      exterior: "", 
      tipoMoradia: "", 
      motivo:"", 
      comprovativo: "", 
      donoAnimal: "",
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
        else if (estado == "Concluído")
          return "#B2EBF2";
        return "#EF9A9A";
    },  
    pedidoadocao: function(pedido){
      this.$router.push("/pedido/adocao/canil/" + this.id + '/' + pedido.nPedido);
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
    diasPassados: function(pedido){
      let dia = moment();
      let dia2 = moment(pedido.data);
      let result = dia.diff(dia2, 'days');
      if (result > 10) return true;
      return false;  
    }, 
    openDecision: function(pedido){
      this.nPedido = pedido.nPedido; 
      this.data = pedido.data;
      this.estado = pedido.estado;
      this.cao_idCao = pedido.cao_idCao;
      this.identificacao = pedido.identificacao;
      this.permissao = pedido.permissao;
      this.alergia = pedido.alergia; 
      this.descAnimais = pedido.descAnimais;
      this.ausencia = pedido.ausencia;
      this.habitacao = pedido.habitacao; 
      this.exterior = pedido.exterior;
      this.tipoMoradia = pedido.tipoMoradia;
      this.motivo = pedido.motivo;
      this.comprovativo = pedido.comprovativo;
      this.donoAnimal = pedido.donoAnimal;
      this.dialog = true; 
    }, 
    expiraPedido: async function(){
      try{ 
        let vm = this;
        var resposta = 
        await axios.put(lhost + "/api/Adocoes/" + vm.nPedido , 
        {
          nPedido: vm.nPedido, 
          data: vm.data, 
          estado: "Expirado", 
          permissao: vm.permissao, 
          alergia: vm.alergia, 
          descAnimais: vm.descAnimais, 
          ausencia: vm.ausencia,
          habitacao: vm.habitacao, 
          exterior: vm.exterior, 
          tipoMoradia: vm.tipoMoradia, 
          motivo: vm.motivo, 
          comprovativo: vm.comprovativo, 
          donoAnimal: vm.donoAnimal,
        },
        { headers: 
          { "Authorization": 'Bearer ' + store.getters.token }
        });

        var res = 
          await axios.put(lhost + "/api/Caes/Adocao/" + this.identificacao,
            {
                idCao: vm.identificacao, 
                estado: "Por Adotar"
            }, 
          { headers: 
            { "Authorization": 'Bearer ' + store.getters.token }
          });

        console.log(JSON.stringify(res.data));
        console.log(JSON.stringify(resposta.data));
       }
       catch(e){
         if(e.message == "Request failed with status code 401"){
                this.$store.commit("limpaStore");
                this.$router.push("/");
            }
       }
       this.dialog = false;
       this.atualiza();
    },
    concluiPedido: async function(){
      try{ 
        let vm = this;
        var resposta = 
        await axios.put(lhost + "/api/Adocoes/" + vm.nPedido , 
        {
          nPedido: vm.nPedido, 
          data: vm.data, 
          estado: "Concluído", 
          permissao: vm.permissao, 
          alergia: vm.alergia, 
          descAnimais: vm.descAnimais, 
          ausencia: vm.ausencia,
          habitacao: vm.habitacao, 
          exterior: vm.exterior, 
          tipoMoradia: vm.tipoMoradia, 
          motivo: vm.motivo, 
          comprovativo: vm.comprovativo, 
          donoAnimal: vm.donoAnimal,
        },
        { headers: 
          { "Authorization": 'Bearer ' + store.getters.token }
        });

        var res = 
          await axios.put(lhost + "/api/Caes/Adocao/" + vm.identificacao,
            {
                idCao: vm.identificacao, 
                estado: "Adotado"
            }, 
          { headers: 
            { "Authorization": 'Bearer ' + store.getters.token }
          });

        console.log(JSON.stringify(resposta.data));
        console.log(JSON.stringify(res.data));
       }
       catch(e){
         if(e.message == "Request failed with status code 401"){
                this.$store.commit("limpaStore");
                this.$router.push("/");
            }
       }
       this.dialog = false;
       this.atualiza();
    },
    atualiza: async function(){
      try {
      let response = await axios.get(lhost + "/api/AdocoesCanil/" + this.id,
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
  },

  created: async function(){
    try {
      let response = await axios.get(lhost + "/api/AdocoesCanil/" + this.id,
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