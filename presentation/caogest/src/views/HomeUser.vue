<template>
    <div id = "mainpage" class = "Main Page">
        <Navbar/>
    
        <v-carousel
            cycle
            height="750"
            hide-delimiter-background
            show-arrows-on-hover
        >
            <v-carousel-item src= '../assets/sad2.jpg'>
                <v-row
                    class="fill-height"
                    align="center"
                    justify="center"
                >
                    <div class="display-3 white--text">Todos os anos são acolhidos em canis dispersos pelo país cerca de 35 393 animais</div>
                </v-row>
            </v-carousel-item>
            <v-carousel-item src= '../assets/sad.jpg'>
                <v-row
                    class="fill-height"
                    align="center"
                    justify="center"
                >
                    <div class="display-3 white--text"> Por ano, são adotados apenas 36,6% dos animais acolhidos</div>
                </v-row>
            </v-carousel-item>
            <v-carousel-item src= '../assets/happy.jpg'>
                <v-row
                    class="fill-height"
                    align="center"
                    justify="center"
                >
                    <div class="display-3 white--text">Os cães ajudam a diminuir o stress dos donos.</div>
                </v-row>
            </v-carousel-item>
            <v-carousel-item src= '../assets/happy2.jpg'>
                <v-row
                    class="fill-height"
                    align="center"
                    justify="center"
                >
                    <div class="display-3 white--text">Cães acolhidos são mais sociáveis e interativos</div>
                </v-row>
            </v-carousel-item>
        </v-carousel>

        <v-container fluid>

            <AdoptionRequest/>
    
            <v-card flat height="100" color="white"></v-card>
            <p class="my-5 display-2 font-weight-bold text-center">Os meus cães favoritos</p>
            <v-card flat height="40" color="white"></v-card>

            <div>
            <v-row align = "center" justify = "center">
                <v-col >
                    <v-container fluid>
                        <v-item-group
                            v-model="selected"
                            multiple
                        >
                            <v-row>
                                <v-col
                                    v-for="n in 9"
                                    :key="n"
                                    class="d-flex child-flex"
                                    cols="4"
                                >
                                    <v-card flat tile>
                                        <v-item v-slot:default="{ active, toggle }">
                                            <v-img
                                                :src="`https://picsum.photos/500/300?image=${n * 5 + 10}`"
                                                :lazy-src="`https://picsum.photos/10/6?image=${n * 5 + 10}`"
                                                aspect-ratio="1"
                                                class="grey lighten-2"
                                                @click="toggle"
                                            >
                                                <template v-slot:placeholder>
                                                    <v-row class="fill-height ma-0" align="center" justify="center">
                                                        <v-progress-circular indeterminate color="grey lighten-5"></v-progress-circular>
                                                    </v-row>
                                                </template>  
                                                <v-btn icon dark>
                                                    <v-icon large>
                                                        {{ active ? 'mdi-heart-outline' : 'mdi-heart' }}
                                                    </v-icon>
                                                </v-btn>

                                            </v-img>
                                        </v-item>
                                    <v-card-actions class="justify-center">
                                        <Dog/>
                                    </v-card-actions>
                                </v-card>
                            </v-col>
                        </v-row>
                    </v-item-group>
                </v-container>
                </v-col>
            </v-row>
            </div>
        </v-container>
        <Footer/>
    </div>
</template>

<script>
import Navbar from '../components/Navbar.vue'
import Footer from '../components/Footer.vue'
import AdoptionRequest from '../components/AdoptionRequestUser.vue'
import Dog from '../components/Dog.vue'
export default {
    data () {
      return {
        items: [
          {
            src: 'https://cdn.vuetifyjs.com/images/carousel/squirrel.jpg',
          },
          {
            src: 'https://cdn.vuetifyjs.com/images/carousel/sky.jpg',
          },
          {
            src: 'https://cdn.vuetifyjs.com/images/carousel/bird.jpg',
          },
          {
            src: 'https://cdn.vuetifyjs.com/images/carousel/planet.jpg',
          },
        ],
        slides: [
          'Todos os anos são acolhidos em canis dispersos pelo país aproximadamente 35393 animais',
          'Second',
          'Third',
          'Fourth',
          'Fifth',
        ],
        selected: []
      }
    },
    components: { Navbar, 
                  Footer,
                  AdoptionRequest, 
                  Dog}
}
</script>
