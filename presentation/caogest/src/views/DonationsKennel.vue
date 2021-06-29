<template>
    <div id = "donationskennel" class = "donationsKennel">
        <NavbarKennel/>
            <v-card> 
                <v-img src='../assets/donationskennel.png'>
                    <v-card flat height= "400" max-width="800" color = "transparent"></v-card>
                    <v-row class="fill-height"
                        align="center"
                        justify="center">
                        <v-col>
                            <v-row
                                class="fill-height"
                                align="center"
                                justify="center"
                            >
                                <div class="display-4 font-weight-bold white--text">Donativos</div>
                            </v-row>
                            <v-card flat height= "70" color = "transparent"></v-card>
                            <v-row class="fill-height"
                                align="center"
                                justify="center">
                                <div class="display-2 font-weight-bold white--text">Os donativos representam a principal e quase única fonte de receita dos canis para a </div>
                                <div class = "display-2 font-weight-bold white--text">prossecução das suas finalidades e dos programas e atividades que, diariamente,</div>
                                <div class = "display-2 font-weight-bold white--text"> desenvolve em prol do bem estar dos cães. </div>
                            </v-row>
                        </v-col>
                    </v-row>
                </v-img>
            </v-card>
            <v-card flat height= "150" color = "white"></v-card>

            <p class="my-5 display-2 font-weight-bold text-center">Donativos Monetários Realizados</p>
            <v-card flat height="40" color="white"></v-card>

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
                                <v-btn class = "ma-2" text @click="sortBy('data')" v-on="on">
                                    <v-icon left small>today</v-icon>    
                                    <span class = "caption text-lowercase">Por data</span>
                                </v-btn> 
                            </template>
                            <span>Ordenar pedidos por data de submissão</span>
                        </v-tooltip>    
                    </v-layout>

                <v-card flat v-for="donativo in donativos" :key="donativo.nome">
                    <v-layout row wrap class="pa-7 donativo">
                    <v-flex xs12 md6>
                        <div class="caption grey--text">Nome</div>
                        <div>{{ donativo.nome }}</div>
                    </v-flex>
                    <v-flex xs6 sm4 md2>
                        <div class="caption grey--text">Data</div>
                        <div>{{ donativo.data }}</div>
                    </v-flex>
                    <v-flex xs6 sm4 md2>
                        <div class="caption grey--text">Valor do Donativo</div>
                        <div>{{ donativo.valor }}</div>
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
      donativos: [
        { nome: 'João Sousa', data: '10th Jan 2010', valor: 1500},
        { nome: 'Maria Alves', data: '15th Feb 2018', valor: 200},
        { nome: 'Vitor Fonseca', data: '4th Dec 2019', valor: 10},
        { nome: 'Cristina Martins', data: '27th Aug 2019', valor: 35},
      ]
    };
  },
  methods: {
    sortBy(prop){
          this.donativos.sort((a,b) => a[prop] < b[prop] ? -1 : 1)
    },
    }, 
     components: {
                NavbarKennel, 
                Footer,
    }, 
};
</script>

<style>

</style>
