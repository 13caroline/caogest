<template>
  <div>
    <Navbar :id="$route.params.id"/>
    <PedidosAdocao :id="$route.params.id" :id2="$route.params.id2"/>
    <Footer :id="$route.params.id"/>
  </div>
</template>

<script>
// @ is an alias to /src
import PedidosAdocao from '@/components/PedidosAdocao.vue'
import Navbar from '@/components/NavbarFooter/NavbarAdmin.vue'
import Footer from '@/components/NavbarFooter/FooterAdmin.vue'
export default {
  name: 'PedidoAdocaoAdmin',
  components: {
    PedidosAdocao,
    Navbar, 
    Footer
  }
} 
</script>