<template>
    <div id = "schedule" class = "schedule">
        <NavbarKennel/>
        <v-card> 
            <v-img src='../assets/horários.png'>
            </v-img>
        </v-card>
        <v-card flat height= "100" color = "white"></v-card>

        <v-container>

            <v-card flat height= "100" color = "white"></v-card>

            <v-row>
                <v-col v-for="item in items" :key = "item.dia" cols="12" md="4" >
                    <v-card
                        color="white"
                        class="d-flex align-center"
                        dark
                        
                        height="400"
                    >
                        <v-col>
                            <v-row>
                                <v-flex xs12 text-xs-center>
                                    <div class = "text-center display-1 font-weight-bold black--text">{{item.dia}}</div>
                                </v-flex>
                            </v-row>
                            
                            <v-card flat height= "30" color = "white"></v-card>
                            
                            <v-row>
                                <v-flex xs12 text-xs-center>
                                    <div class = "text-center headline black--text">{{item.hora}}</div>
                                </v-flex>    
                            </v-row>

                            <v-card flat height= "30" color = "white"></v-card>

                            <v-row align = "center" justify = "center">
                                    <v-chip color = "deep-orange lighten-4" class = "black--text">
                                        {{item.voluntarios}} Voluntários
                                    </v-chip>
                            </v-row>

                            <v-card flat height= "60" color = "white"></v-card>

                            <v-row align = "center" justify = "center">
                                <EditarHorario/>
                            </v-row>
                            
                        </v-col>
                    </v-card>
                </v-col>
            </v-row>
        </v-container>
        <Footer/>
    </div>
</template>

<script>
import NavbarKennel from '../components/NavbarKennel.vue'
import Footer from '../components/FooterKennel.vue'
import EditarHorario from '../components/EditarHorario.vue'

export default {
    data: () => ({             
         items: [
            { dia: 'Segunda-feira', hora: '14h-16h', voluntarios: 1}, 
            { dia: 'Terça-feira',hora: '13h-16h', voluntarios: 3},
            { dia: 'Quarta-feira', hora: '14h-16h', voluntarios: 6},
            { dia: 'Quinta-feira', hora: '14h-16h', voluntarios: 7},
            { dia: 'Sexta-feira', hora: '14h-16h', voluntarios: 2},
            { dia: 'Sábado', hora: '11h-13h', voluntarios: 0},
            { dia: 'Domingo', hora: '14h-16h', voluntarios: 4}
            ],
    }),
    components: { NavbarKennel, 
                  Footer, 
                  EditarHorario}
}
</script>