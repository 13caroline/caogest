<template>
    <div id = "treinar" class = "treinar">
        <Navbar :id="$route.params.id" />
        <Treinar :id="$route.params.id" />
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
import Treinar from '@/components/Docs/Treinar.vue'
export default {
    name:"treinar", 
    props:['id'],
    data() {
        return {
            fab:false,
        }
    },
    components: {   Navbar, 
                    Footer,
                    Treinar },
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