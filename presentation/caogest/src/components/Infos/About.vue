<template>
    <div id = "about" class = "About">
        <v-card> 
            <v-img src='@/assets/sobre.png'>
                <v-row align = "end" justify = "end">
                    <v-btn text class = "white--text overline font-weight-thin text--secondary" href="https://www.goodfon.com/wallpaper/sobaka-aussi-osen-listia-fon-avstraliiskaia-ovcharka-shcheno.html">hiperligação para a imagem original</v-btn>
                </v-row>
            </v-img> 
        </v-card>
        <v-card flat height= "100" color = "white"></v-card>
        <p class="display-2 font-weight-bold text-center">Missão</p>
        <v-card flat height= "30" color = "white"></v-card>
        <v-card flat class="mx-auto" max-width="1000" fluid>
            <v-card-text class="display-1"> A CãoGest tem como missão dar a cada animal um lar, e a cada dono um animal que corresponda às suas expectativas.
            </v-card-text>
        </v-card>
        
        <v-card flat height= "100" color = "white"></v-card>
        <p class="display-2 font-weight-bold text-center">Visão</p>
        <v-card flat height= "30" color = "white"></v-card>
        <v-card flat class="mx-auto" max-width="1000" fluid>
            <v-card-text class="display-1">Ambicionamos melhorar a gestão de movimento dos cães pelos canis, promovendo a entrada e saída mais célere dos animais, permitindo assim uma melhor qualidade de vida para os animais, bem como uma diminuição da sobrecarga laboral e insuficiência económica que enfrentam os canis. 
            </v-card-text>
        </v-card>

        <v-card flat height= "100" color = "white"></v-card>
        <p class="display-2 font-weight-bold text-center">A Nossa Equipa</p>
        <v-card flat height= "80" color = "white"></v-card>

        <v-card class="mx-auto" max-width="1200" color = "brown lighten-5" elevation="5">
            <v-container fluid flat>
                <v-row justify="space-around">
                    <v-col cols = "6">
                        <v-img 
                            class = "ma-2" 
                            src='@/assets/carolinaavatar.png' 
                            height = "220" 
                            width="220"
                        ></v-img>
                        <v-card-text 
                            class=" display-1 font-weight-medium"
                        > Carolina Cunha
                        </v-card-text>
                    </v-col>

                    <v-col cols = "5">
                        <v-row>
                                <p class="ma-2 display-1 font-weight-medium">Papel: </p> 
                                <span class="ma-2 display-1">Desenvolvimento da Interface </span>
                        </v-row>
                    </v-col>
                </v-row>
            </v-container>
        </v-card>

        <v-card height = "100" flat ></v-card>

         <v-card class="mx-auto" max-width="1200" color = "brown lighten-5" elevation="5">
            <v-container fluid flat>
                <v-row justify="space-around">
                    <v-col cols = "6">
                        <v-img 
                            class = "ma-2" 
                            src='@/assets/joaoavatar.png' 
                            height = "220" 
                            width="220"
                        ></v-img>
                        <v-card-text 
                            class=" display-1 font-weight-medium"
                        > João Diogo Mota
                        </v-card-text>
                    </v-col>

                    <v-col cols = "5">
                        <v-row>
                                <p class=" ma-2 display-1 font-weight-medium">Papel: </p> 
                                <span class=" ma-2 display-1"> Gestão da Base de Dados </span>
                                <span class=" ma-2 display-1"> Desenvolvimento da Interface </span>
                        </v-row>
                    </v-col>
                </v-row>
            </v-container>
        </v-card>

        <v-card height = "100" flat ></v-card>

         <v-card class="mx-auto" max-width="1200" color = "brown lighten-5" elevation="5">
            <v-container fluid flat>
                <v-row justify="space-around">
                    <v-col cols = "6">
                        <v-img 
                            class = "ma-2" 
                            src='@/assets/pedroavatar.png' 
                            height = "220" 
                            width="220"
                        ></v-img>
                        <v-card-text 
                            class=" display-1 font-weight-medium"
                        > Pedro Silva
                        </v-card-text>
                    </v-col>

                    <v-col cols = "5">
                        <v-row >
                                <p class="ma-2 display-1 font-weight-medium">Papel: </p> 
                                <span class=" ma-2 display-1"> Desenvolvimento da API </span>
                        </v-row>
                    </v-col>
                </v-row>
            </v-container>
        </v-card>

        <v-card height = "100" flat ></v-card>

         <v-card class="mx-auto" max-width="1200" color = "brown lighten-5" elevation="5">
            <v-container fluid flat>
                <v-row justify="space-around">
                    <v-col cols = "6">
                        <v-img 
                            class = "ma-2" 
                            src='@/assets/hugoavatar.png' 
                            height = "220" 
                            width="220"
                        ></v-img>
                        <v-card-text 
                            class=" display-1 font-weight-medium"
                        > Hugo Faria
                        </v-card-text>
                    </v-col>

                    <v-col cols = "5">
                        <v-row >
                                <p class="ma-2 display-1 font-weight-medium">Papel: </p> 
                                <span class=" ma-2 display-1"> Desenvolvimento da API </span>
                        </v-row>
                    </v-col>
                </v-row>
            </v-container>
        </v-card>

        <v-card height = "100" flat ></v-card>

         <v-card class="mx-auto" max-width="1200" color = "brown lighten-5" elevation="5">
            <v-container fluid flat>
                <v-row justify="space-around">
                    <v-col cols = "6">
                        <v-img 
                            class = "ma-2" 
                            src='@/assets/sergioavatar.png' 
                            height = "220" 
                            width="220"
                        ></v-img>
                        <v-card-text 
                            class=" display-1 font-weight-medium"
                        > Sérgio Gomes
                        </v-card-text>
                    </v-col>

                    <v-col cols = "5">
                        <v-row >
                                <p class="ma-2 display-1 font-weight-medium">Papel: </p> 
                                <span class=" ma-2 display-1"> Implementação de Métodos de Segurança </span>
                        </v-row>
                    </v-col>
                </v-row>
            </v-container>
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
    </div>
</template>

<script>
export default {
  data() {
    return {
      fab:false,
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
  },   
};
</script>