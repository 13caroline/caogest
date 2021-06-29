<template>
    <div id = "volunteers" class = "Volunteers">
        <NavbarKennel/>
         <v-card> 
            <v-img src='../assets/voluntarios.png'></v-img>
         </v-card>
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

                        <v-card flat v-for="voluntario in voluntarios" :key="voluntario.nome">
                            <v-layout row wrap :class="`pa-7 voluntario`">
                            <v-flex xs12 md6>
                                <div class="caption grey--text">Nome Voluntário</div>
                                <div>{{ voluntario.nome }}</div>
                            </v-flex>
                            <v-flex xs6 sm4 md2>
                                <div class="caption grey--text">Idade</div>
                                <div>{{ voluntario.idade }} anos</div>
                            </v-flex>
                            <v-flex xs6 sm4 md2>
                                <div class="caption grey--text">Morada</div>
                                <div>{{ voluntario.morada }}</div>
                            </v-flex>
                            <v-flex xs6 sm4 md2>
                                <div class="caption grey--text">Contacto</div>
                                <div>{{ voluntario.contacto}}</div>
                            </v-flex>
                            </v-layout>
                            <v-divider></v-divider>
                        </v-card>
                    </v-container>
                <Footer/>    
    </div>
</template>

<script>
import NavbarKennel from '../components/NavbarKennel.vue'
import Footer from '../components/FooterKennel.vue'
export default {
  data() {
    return {
      voluntarios: [
        { nome: 'Rute Beatriz', idade: 20, morada: 'Rua da Amoreira, Palmeira, Braga', contacto: '911191911'},
        { nome: 'Ricardo Pereira', idade: 35, morada: 'Rua da Porta, Palmeira, Braga', contacto: '923412921'},
        { nome: 'Maria Moreira', idade: 42, morada: 'Rua da Taberna, S.Vitor, Braga', contacto: '930031343'},
        { nome: 'Fernando Silva', idade: 50, morada: 'Rua da Taberna, Caide, Braga', contacto: '930331353'},
        { nome: 'Marta Rebelo', idade: 28, morada: 'Rua da Macieira, Celeirós, Braga', contacto: '961234567'},
      ]
    };
  },
  methods: {
    sortBy(prop){
          this.voluntarios.sort((a,b) => a[prop] < b[prop] ? -1 : 1)
    }
    }, 
    components: {NavbarKennel, Footer}
};
</script>

<style>

</style>