<template>
    <div id = "requestkennel" class = "Request Kennel">
        <Navbar/>
        <v-card flat height = "100"></v-card>
        <PedidosAdocao/>
        <v-card flat class = "mx-auto">
            <v-row justify = "end">
                <v-btn class="ma-12 headline" x-large color = "deep-orange lighten-4"> Rejeitar Pedido</v-btn>
                <v-btn class="ma-12 headline" x-large color = "deep-orange lighten-4"> Aceitar Pedido</v-btn>
            </v-row>
        </v-card>
        <Footer/>
    </div>
</template> 

<script>
import Navbar from '../components/NavbarKennel.vue'
import Footer from '../components/FooterKennel.vue'
import PedidosAdocao from '../components/PedidosAdocao.vue'
  export default {
        components: { Navbar, 
                      Footer, 
                      PedidosAdocao, 
        }
  }
</script>     