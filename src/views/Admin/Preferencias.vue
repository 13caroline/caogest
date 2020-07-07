<template>
    <div id = "preferences" class = "preferences">
        <Navbar :id="$route.params.id"/>
        <v-card flat height= "60" color = "white"></v-card>
        <Preferencias :id="$route.params.id"/>
        <Footer :id="$route.params.id"/>
    </div>
</template>

<script>
import Navbar from '@/components/NavbarFooter/NavbarAdmin.vue'
import Footer from '@/components/NavbarFooter/FooterAdmin.vue'
import Preferencias from '@/components/Admin/Preferencias.vue'

export default {
    components: {   
        Navbar, 
        Footer,
        Preferencias 
    },   
            
}
</script>