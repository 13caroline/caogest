<template>
    <div id = "voluntariado" class = "voluntariado">
        <v-card> 
            <v-img src='@/assets/voluntariado.png'>
              <v-row align = "end" justify = "end">
                  <v-btn text class = "white--text overline font-weight-thin text--secondary" href="https://www.jakpost.travel/vwall/mJbJox_animal-human-friendship-images-wallpapers-lovesove-human-and/">hiperligação para a imagem original</v-btn>
              </v-row>
            </v-img>
        </v-card>
        <v-card flat height= "100" color = "white"></v-card>

        <v-container class="my-5">
            <v-row align="center" justify="center">
            <v-card flat >
                <v-card-title class="my-5 display-2 font-weight-bold text-center">Canis em Voluntariado</v-card-title>
            </v-card>
        </v-row>
        
        <v-card flat height = "50"></v-card>

        <CanisVoluntariado :id="$route.params.id" />

        <v-card flat height="100"></v-card>
        <v-row align="center" justify="center">
            <v-card flat >
                <v-card-title class = "my-5 display-2 font-weight-bold text-center">Horários de Voluntariado Registados</v-card-title>
            </v-card>
        </v-row>
            <v-card flat height = "50"></v-card>

         <v-layout row class="mb-1"> 
            <v-tooltip top>
                <template v-slot:activator="{ on }">
                    <v-btn class = "ma-2" text @click="sortBy('nome_canil')" v-on="on">
                        <v-icon left small>pets</v-icon>    
                        <span class = "caption text-lowercase">Por canil</span>
                    </v-btn>  
                </template>
                <span>Ordenar horarios por nome de canil</span> 
            </v-tooltip>

            <v-tooltip top>
                <template v-slot:activator="{ on }">
                    <v-btn class = "ma-2" text @click="sortBy('horario_Dia')" v-on="on">
                        <v-icon left small>pets</v-icon>    
                        <span class = "caption text-lowercase">Por dia</span>
                    </v-btn>  
                </template>
                <span>Ordenar horarios por dia da semana</span> 
            </v-tooltip>
        </v-layout>

      <v-card flat height = "20"></v-card>
      <v-card class = "mx-auto" height = "80" width="2000" flat color = "brown lighten-5" v-if="this.horarios.length === 0"> 
        <v-card-title class = "display-1 text-center justify-center"> Não está registado em nenhum horário </v-card-title>
        
      </v-card>
      <v-card v-else flat v-for="(horario, index) in horarios" :key="index" >
        <v-layout row wrap :class="`pa-7 horario ${semana(horario.horario_Dia)}`">
          <v-flex xs8 md4>
            <div class="caption grey--text">Dia</div>
            <div class=" headline">{{ semana(horario.horario_Dia) }}</div>
          </v-flex>
          <v-flex xs12 md6>
            <div class="caption grey--text">Nome Canil</div>
            <div class=" headline">{{ horario.nome_canil }}</div>
          </v-flex>
          <v-flex xs8 md2>
            <div class="caption grey--text">Hora</div>
            <div class="method headline">{{date(horario.horario_DataInicio)}} - {{date(horario.horario_DataFim)}}</div>
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
import axios from 'axios'
import store from '@/store.js'
const lhost = require("@/config/global").host;
import CanisVoluntariado from '@/components/Utilizador/canisVoluntariado.vue'

export default {
  data() {
    return {
      horarios: [],
      dialog:false, 
      fab:false,
     
    };
  },
  name: 'Voluntariado',    
  props: ['id'], 
  components:{
      CanisVoluntariado,
  },
  methods: {
    sortBy(prop){
          this.horarios.sort((a,b) => a[prop] < b[prop] ? -1 : 1)
    },
    sortByData(prop){
          this.horarios.sort((a,b) => a[prop] < b[prop] ? 1 : -1)
    },
    semana: function (num) {
            if(num === 1) return "Segunda-feira"
            else if (num === 2) return "Terça-feira";
            else if (num === 3) return "Quarta-feira"; 
            else if (num === 4) return "Quinta-feira"; 
            else if (num === 5) return "Sexta-feira"; 
            else if (num === 6) return "Sábado";
            return "Domingo";
    },
    
    date: function (date) {
            return moment(date).locale("pt").format('LT');
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
      let response = await axios.get(lhost + "/api/HU/" + this.id,
        { headers: 
          { "Authorization": 'Bearer ' + store.getters.token }
        });
      this.horarios = response.data;
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
.horario.Segunda-feira {
  border-left: 4px solid #C5E1A5;
}

.horario.Terça-feira  {
  border-left: 4px solid #FFE082;
}

.horario.Quarta-feira  {
  border-left: 4px solid #B39DDB;
}

.horario.Quinta-feira  {
    border-left: 4px solid #EF9A9A;
}

.horario.Sexta-feira {
    border-left: 4px solid #B2EBF2;
}

.horario.Sábado {
    border-left: 4px solid #FFE0B2; 
}

.horario.Domingo {
    border-left: 4px solid #F0F4C3; 
}

</style>
