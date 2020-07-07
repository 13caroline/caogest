<template>
    <div id = "mainpage" class = "Main Page">
        <Navbar :id="$route.params.id"/>
    
        <v-carousel
            cycle
            height="750"
            hide-delimiter-background
            show-arrows-on-hover
        >
            <v-carousel-item src= '@/assets/sad2.jpg'>
                <v-row align = "end" justify = "end">
                    <v-card flat height= "400" max-width="800" color = "transparent">
                        <v-btn text class = "white--text overline font-weight-thin text--secondary" href="https://www.zastavki.com/eng/Animals/Dogs/wallpaper-114760.htm">hiperligação para a imagem original</v-btn>
                    </v-card>
                </v-row>
                <v-row
                    class="fill-height"
                    align="center"
                    justify="center"
                >
                    <div class="display-3 white--text">Todos os anos são acolhidos em canis dispersos pelo país cerca de 35 393 animais</div>
                </v-row>
            </v-carousel-item>
            <v-carousel-item src= '@/assets/sad.jpg'>
                <v-row align = "end" justify = "end">
                    <v-card flat height= "400" max-width="800" color = "transparent">
                        <v-btn text class = "white--text overline font-weight-thin text--secondary" href="http://hddesktopwallpapers.in/dogs-and-cats-wallpapers/">hiperligação para a imagem original</v-btn>
                    </v-card>
                </v-row>
                <v-row
                    class="fill-height"
                    align="center"
                    justify="center"
                >
                    <div class="display-3 white--text"> Por ano, são adotados apenas 36,6% dos animais acolhidos</div>
                </v-row>
            </v-carousel-item>
            <v-carousel-item src= '@/assets/happy.jpg'>
                <v-row align = "end" justify = "end">
                    <v-card flat height= "400" max-width="800" color = "transparent">
                        <v-btn text class = "white--text overline font-weight-thin text--secondary" href="https://www.tapeciarnia.pl/tapeta-dwa-psy-border-collie-na-pniu-i-spadajace-liscie">hiperligação para a imagem original</v-btn>
                    </v-card>
                </v-row>
                <v-row
                    class="fill-height"
                    align="center"
                    justify="center"
                >
                    <div class="display-3 white--text">Os cães ajudam a diminuir o stress dos donos.</div>
                </v-row>
            </v-carousel-item>
            <v-carousel-item src= '@/assets/happy2.jpg'>
                <v-row align = "end" justify = "end">
                    <v-card flat height= "400" max-width="800" color = "transparent">
                        <v-btn text class = "white--text overline font-weight-thin text--secondary" href="https://www.wallpaperflare.com/two-adult-orange-black-and-white-border-collie-dog-animals-wallpaper-btb">hiperligação para a imagem original</v-btn>
                    </v-card>
                </v-row>
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

            <AdoptionRequest :id="$route.params.id"/>
    
            <v-card flat height="100" color="white"></v-card>
            <p class="my-5 display-2 font-weight-bold text-center">As minhas almas gémeas</p>
            <v-card flat height="40" color="white"></v-card>

            <Dog :id="$route.params.id"/>
        </v-container>
        <Footer :id="$route.params.id"/>
    </div>
</template>

<script>
import Navbar from '@/components/NavbarFooter/Navbar.vue'
import Footer from '@/components/NavbarFooter/Footer.vue'
import AdoptionRequest from '@/components/Utilizador/AdoptionRequestUser.vue'
import Dog from '@/components/Utilizador/Dog.vue'
export default {
    data () {
      return {
        items: [],
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
