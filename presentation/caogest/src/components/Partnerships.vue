<template>
    <div id = "partnerships" class = "Partnerships">
        <Navbar :id="$route.params.id"/>
        <v-card> 
            <v-img src='@/assets/parcerias.png'>
                <v-row align = "end" justify = "end">
                    <v-btn text class = "white--text overline font-weight-thin text--secondary" href="https://www.wallpaperflare.com/dogs-australian-shepherd-border-collie-pet-wallpaper-elke">hiperligação para a imagem original</v-btn>
                </v-row>
            </v-img> 
        </v-card>
        <v-card flat height= "100" color = "white"></v-card>
        
        <v-card flat class="mx-auto" max-width="1700" fluid>
            <v-card-text class=" display-1"> A CãoGest pretende expressar o seu agradecimento a todos os voluntários e empresas que se predispõem para auxiliar os canis registados nesta plataforma, tanto em trabalho como financeiramente.</v-card-text> 
        </v-card>

        <v-card flat class = "mx-auto" height= "200" color = "white"></v-card>

        <Parcerias :id="$route.params.id" />

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
        <Footer :id="$route.params.id"/>
    </div>
</template>

<script>
import Navbar from '@/components/NavbarFooter/NavbarKennel.vue'
import Footer from '@/components/NavbarFooter/FooterKennel.vue'
import Parcerias from '@/components/ParceriasCanil.vue'

export default {
    data: () => ({  
        fab:false, 
    }),
    components: {
                Navbar, 
                Footer, 
                Parcerias
    }, 
    methods:{
        onScroll (e) {
            if (typeof window === 'undefined') return
            const top = window.pageYOffset ||   e.target.scrollTop || 0
            this.fab = top > 20
        },
        toTop () {
            this.$vuetify.goTo(0)
        },
    },
    
}
</script>