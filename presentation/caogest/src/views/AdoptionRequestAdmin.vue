<template>
    <div id = "adoptionRequestAdmin" class = "Adoption Request Admin">
        <NavbarAdmin/>
        <v-card> 
            <v-img src='../assets/pedidosadocao.png'></v-img> 
        </v-card>
       
        <v-container>
            <AdoptionRequestAdmin/>
        </v-container>
        <Footer/>
    </div>
</template>

<script>
import NavbarAdmin from '../components/NavbarAdmin.vue'
import Footer from '../components/Footer.vue'
import AdoptionRequestAdmin from '../components/AdoptionRequestAdmin.vue'
export default {
    components: { NavbarAdmin, 
                  Footer,
                  AdoptionRequestAdmin,
    }
}
</script>