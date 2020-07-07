<template>
    <div id = "recibo" class = "recibo">
        <NavbarKennel :id="$route.params.id"/>
           <Recibo :id="$route.params.id" :id2="$route.params.id2" />
        <Footer :id="$route.params.id"/>
    </div>
</template>

<script>
import NavbarKennel from '@/components/NavbarFooter/NavbarKennel.vue'
import Footer from '@/components/NavbarFooter/FooterKennel.vue'
import Recibo from '@/components/Comprovativo.vue'

export default {
     components: {
                NavbarKennel, 
                Footer,
                Recibo
    }, 
};
</script>
