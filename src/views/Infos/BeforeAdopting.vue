<template>
    <div id = "beforeadopt" class = "Antes De Adotar">
        <Navbar :id="$route.params.id"/>
        <v-card> 
            <v-img src='@/assets/beforeadopting.png'>
                <v-row align = "end" justify = "end">
                    <v-btn text class = "white--text overline font-weight-thin text--secondary" href="https://yandex.uz/collections/user/helen-kutuz/sobaki-oseniu/">hiperligação para a imagem original</v-btn>
                </v-row>
                <v-card flat height= "500" max-width="800" color = "transparent"></v-card>
                <v-row class="fill-height"
                       align="center"
                       justify="center">
                    <v-col>
                        <v-row
                            class="fill-height"
                            align="center"
                            justify="center"
                        >
                            <div class="display-4 font-weight-bold white--text">Antes de Adotar</div>
                        </v-row>
                        <v-card flat height= "50" color = "transparent"></v-card>
                        <v-row class="fill-height"
                            align="center"
                            justify="center">
                            <div class="display-2 font-weight-bold white--text">Adotar um animal requer muita dedicação e responsabilidade por parte do dono. </div>
                            <div class = "display-2 font-weight-bold white--text">Por este motivo, é extremamente importante ponderar antes de tomar a decisão</div>
                            <div class = "display-2 font-weight-bold white--text"> de levar consigo um novo companheiro. </div>
                        </v-row>
                    </v-col>
                </v-row>
            </v-img>
        </v-card>
        <v-card flat height= "150" color = "white"></v-card>
        
        <v-card flat class="mx-auto" max-width="1700" fluid>
            <v-card-text class=" display-1">Para adotar um cão, é necessário ter em especial atenção: </v-card-text> 
        </v-card>

            <v-card flat height= "150" color = "white"></v-card>

            <v-card flat class="mx-auto" max-width="1500" color = "white">

                <v-row justify = "center">
                <v-col cols = "6">
                    <v-card-text class=" display-1 font-weight-medium"> O seu porte, consoante o espaço disponível </v-card-text>
                </v-col>
                <v-col><v-img src='@/assets/alturacao.png' max-heigth = "180" max-width="180"></v-img></v-col>
                </v-row>

                <v-card flat height= "100" color = "white"></v-card>

                <v-row justify= "center">
                    <v-spacer></v-spacer>
                <v-col ><v-img src='@/assets/timeavailable.png' max-heigth = "190" max-width="190"></v-img></v-col>
                <v-col cols = "6">
                    <v-card-text class=" display-1 font-weight-medium"> O tempo disponível que pode dedicar ao cão </v-card-text>
                </v-col>
                </v-row>

                <v-card flat height= "100" color = "white"></v-card>

                <v-row justify = "center">
                <v-col cols = "6">
                    <v-card-text class=" display-1 font-weight-medium"> O temperamento da raça do cão </v-card-text>
                </v-col>
                <v-col><v-img src='@/assets/behaviour.png' max-heigth = "190" max-width="190"></v-img></v-col>
                </v-row>

                <v-card flat height= "100" color = "white"></v-card>

                <v-row justify= "center">
                    <v-spacer></v-spacer>
                <v-col ><v-img src='@/assets/pets.png' max-heigth = "190" max-width="190"></v-img></v-col>
                <v-col cols = "6">
                    <v-card-text class=" display-1 font-weight-medium"> A relação a estabelecer no caso de possuir outros animais de companhia </v-card-text>
                </v-col>
                </v-row>

                <v-card flat height= "100" color = "white"></v-card>

                <v-row justify= "center">
                <v-col cols = "6">
                    <v-card-text class=" display-1 font-weight-medium"> As necessidades requeridas consoante a idade do cão </v-card-text>
                </v-col>
                <v-col ><v-img src='@/assets/olddogcare.png' max-heigth = "200" max-width="200"></v-img></v-col>
                </v-row>
            </v-card>
            
            <v-card flat height= "150" color = "white"></v-card>
            <v-card flat class="mx-auto" max-width="1700" fluid>
                <v-card-text class=" display-1">Quando tiver a certeza de que pretende adotar um cão, vá ao separador 'Cães' e escolha o seu novo companheiro. </v-card-text> 
            </v-card>


        <Footer :id="$route.params.id"/>
    </div>
</template>

<script>
import Navbar from '@/components/NavbarFooter/Navbar.vue'
import Footer from '@/components/NavbarFooter/Footer.vue'
export default {
    components: { Navbar, 
                  Footer }
}
</script>