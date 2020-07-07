<template>
    <div id = "preferencias" class = "preferencias">
        <Navbar :id="$route.params.id" />
        <v-card flat height= "60" color = "white"></v-card>
        <Preferencias :id="$route.params.id" />
        <Footer :id="$route.params.id" />
    </div>
</template>

<script>
import Navbar from '@/components/NavbarFooter/Navbar.vue'
import Footer from '@/components/NavbarFooter/Footer.vue'
import Preferencias from '@/components/Utilizador/Preferencias.vue'

export default {
    components: {  
        Navbar, 
        Footer, 
        Preferencias,
    },   
}
</script>