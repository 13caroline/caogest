<template>
    <div id = "adoptionRequestAdmin" class = "Adoption Request Admin">
        <NavbarAdmin :id="$route.params.id"/>
        <v-card> 
            <v-img src='@/assets/pedidosadocao.png'></v-img> 
        </v-card>
       
        <v-container>
            <AdoptionRequestAdmin :id="$route.params.id"/>
        </v-container>
        <Footer :id="$route.params.id"/>
    </div>
</template>

<script>
import NavbarAdmin from '@/components/NavbarFooter/NavbarAdmin.vue'
import Footer from '@/components/NavbarFooter/Footer.vue'
import AdoptionRequestAdmin from '@/components/Admin/AdoptionRequestAdmin.vue'
export default {
    components: { NavbarAdmin, 
                  Footer,
                  AdoptionRequestAdmin,
    }
}
</script>