<template>
    <div id = "preferences" class = "preferences">
        <NavbarKennel :id="$route.params.id"/>
        <v-card flat height= "60" color = "white"></v-card>     
        <Preferencias :id="$route.params.id"/>        
        <Footer :id="$route.params.id"/>
    </div>
</template>

<script>
import NavbarKennel from '@/components/NavbarFooter/NavbarKennel.vue'
import Footer from '@/components/NavbarFooter/FooterKennel.vue'
import Preferencias from '@/components/PreferencesKennel.vue'

export default {
    components: {   NavbarKennel, 
                    Footer, 
                    Preferencias
                    },   
   
   
            
}
</script>