<template>
    <div id = "adoptionRequest" class = "Adoption Request">
        <NavbarKennel/>
         <v-card> 
            <v-img src='../assets/pedidosadocaocanil.png'></v-img>
         </v-card>
        <v-card flat height= "80" color = "white"></v-card>
        <v-container>
            <AdoptionRequest/>
        </v-container>
                <Footer/>
    </div>
</template>

<script>
import NavbarKennel from '../components/NavbarKennel.vue'
import Footer from '../components/FooterKennel.vue'
import AdoptionRequest from '../components/AdoptionRequest.vue'
export default {
    components: { NavbarKennel, 
                  Footer,
                  AdoptionRequest}
}
</script>