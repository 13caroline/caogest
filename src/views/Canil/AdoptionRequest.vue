<template>
    <div id = "adoptionRequest" class = "Adoption Request">
        <NavbarKennel :id="$route.params.id"/>
         <v-card> 
            <v-img src='@/assets/pedidosadocaocanil.png'>
                <v-row align = "end" justify = "end">
                    <v-btn text class = "white--text overline font-weight-thin text--secondary" href="https://alicjazmyslowska.pl/offer-for-business-and-breeders/">hiperligação para a imagem original</v-btn>
                </v-row> 
            </v-img>
         </v-card>
        <v-card flat height= "80" color = "white"></v-card>
        <v-container>
            <AdoptionRequest :id="$route.params.id"/>
        </v-container>
                <Footer :id="$route.params.id"/>
    </div>
</template>

<script>
import NavbarKennel from '@/components/NavbarFooter/NavbarKennel.vue'
import Footer from '@/components/NavbarFooter/FooterKennel.vue'
import AdoptionRequest from '@/components/AdoptionRequest.vue'
export default {
    components: { NavbarKennel, 
                  Footer,
                  AdoptionRequest}
}
</script>