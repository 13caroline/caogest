<template>
  <div id="entreemcontacto" class="entreemcontacto">
    <NavbarAdmin :ident="$route.params.ident"/>
    <v-card>
      <v-img src="@/assets/entreemcontacto.png">
        <v-row align = "end" justify = "end">
          <v-btn text class = "white--text overline font-weight-thin text--secondary" href="https://besthqwallpapers.com/pt/download/original/76155">hiperligação para a imagem original</v-btn>
        </v-row>
      </v-img>
    </v-card>
    <v-card flat height="150" color="white"></v-card>

    <Contacto :ident="$route.params.ident" />
    <Footer :ident="$route.params.ident"/>

  </div>
</template>

<script>

import NavbarAdmin from "@/components/NavbarFooter/NavbarAdmin.vue";
import Footer from "@/components/NavbarFooter/FooterAdmin.vue";
import Contacto from "@/components/Admin/EntreEmContacto.vue";



export default {
  components: {
    NavbarAdmin,
    Footer, 
    Contacto,
  },

}
</script>

<style></style>