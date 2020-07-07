<template>
    <div id = "dogs" class = "Dogs">
        <Navbar :id="$route.params.id"/>
        <v-card> 
            <v-img src='@/assets/caes2.png'>
                <v-row align = "end" justify = "end">
                        <v-btn text class = "white--text overline font-weight-thin text--secondary" href="https://www.goodfon.com/wallpaper/avstraliiskaia-ovcharka-aussi-sobaka-shchenok-beg-progulka-o.html">hiperligação para a imagem original</v-btn>
                </v-row>    
            </v-img> 
        </v-card>
        <v-card flat height= "100" color = "white"></v-card>

        <Dogs :id="$route.params.id"/>
        
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


import Navbar from '@/components/NavbarFooter/Navbar.vue'
import Footer from '@/components/NavbarFooter/Footer.vue'
import Dogs from '@/components/Utilizador/Dogs.vue'

export default {
    data: () => ({   
        fab: false,  
    }),
    components: {   Navbar, 
                    Footer,
                    Dogs
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