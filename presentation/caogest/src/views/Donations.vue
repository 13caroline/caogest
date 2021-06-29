<template>
    <div id = "donations" class = "Donativos">
        <Navbar/>
         <v-card> 
            <v-img src='../assets/ask.png'>
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
        <v-card flat height= "100" color = "white"></v-card>
        
        <v-card flat class="mx-auto" max-width="1000" fluid>
            <v-card-text>
                <p class=" display-1">Dirija-se à página do canil a que quer realizar um donativo, a fim de verificar quais as maiores necessidades por parte do mesmo. </p> 
                <v-card flat height= "5" color = "white" class="ma-5"></v-card>
                <p class=" display-1"> Os donativos podem ser realizados sobre as seguintes formas:  </p>
             </v-card-text>
            
        </v-card>
         <v-card flat class="mx-auto" color = "white" max-width="1000" max-height="1000" fluid>
            <v-container fluid flat>
                <v-row justify="space-around">
                        <v-col cols = "6">
                                <v-card>
                                <v-img src= '../assets/bens2.png'
                                height="702px"
                                width = "600px"
                                >
                                </v-img>
                                </v-card>
                        </v-col>
                        <v-col cols = "6">
                            <v-card>
                                <v-img src= '../assets/monetario3.png'
                                height="702px"
                                width = "600px"
                                >
                                </v-img>
                                </v-card>
                        </v-col>
                    </v-row>
                </v-container>
         </v-card>
        <Footer/>
    </div>
</template>

<script>
import Navbar from '../components/Navbar.vue'
import Footer from '../components/Footer.vue'
export default {
    data: () => ({
      cards: [
        { title: 'Monetários', src: '../assets/donativosbens.jpg', flex: 6 },
        { title: 'Bens', src: '../assets/donativosbens.jpg', flex: 6 },
      ],
    }),
    
    components: { Navbar, 
                  Footer }
}
</script>