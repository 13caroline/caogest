<template>
    <div>
        <Navbar :id="$route.params.id" />
        <v-card>
            <v-img src="@/assets/informacoesdiversas.png">
                <v-row align = "end" justify = "end">
                    <v-btn text class = "white--text overline font-weight-thin text--secondary" href="https://ja.best-wallpaper.net/Blue-eyes-dog-rest-bench_wallpapers.html">hiperligação para a imagem original</v-btn>
                </v-row>
            </v-img>
        </v-card>

        <v-card flat height = "60"></v-card>

        <Textos :id="$route.params.id" />
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
        <Footer :id="$route.params.id" />
    </div>
</template>

<script>
import Navbar from '@/components/NavbarFooter/NavbarAdmin.vue'
import Footer from '@/components/NavbarFooter/FooterAdmin.vue'
import Textos from '@/components/Docs/TextosAdmin.vue'
  export default {
      name: "textos", 
      props:['id'],

        data() {
            return {
                fab:false,
            }
        },
        components: { Navbar, 
                      Footer, 
                      Textos,
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
    }
  }
</script>     