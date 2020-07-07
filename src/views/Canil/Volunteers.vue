<template>
    <div id = "volunteers" class = "Volunteers">
        <NavbarKennel :id="$route.params.id"/>
         <v-card> 
            <v-img src='@/assets/voluntarios.png'>
                <v-row align = "end" justify = "end">
                    <v-btn text class = "white--text overline font-weight-thin text--secondary" href="https://stopcambioclimatico.es/2018/04/26/cuidar-los-animales-cuidar-del-medioambiente/">hiperligação para a imagem original</v-btn>
                </v-row>
            </v-img>
         </v-card>
        <Volunteers :id="$route.params.id"/>
        <Footer :id="$route.params.id"/>    
    </div>
</template>

<script>
import NavbarKennel from '@/components/NavbarFooter/NavbarKennel.vue'
import Footer from '@/components/NavbarFooter/FooterKennel.vue'
import Volunteers from '@/components/Volunteers.vue'
export default {
    components: {
        NavbarKennel, 
        Footer, 
        Volunteers
    }
};
</script>

<style>

</style>