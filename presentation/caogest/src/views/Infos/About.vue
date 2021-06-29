<template>
    <div id = "about" class = "About">
        <Navbar :id="$route.params.id"/>
        
        <About :id="$route.params.id"/>
          
        <Footer :id="$route.params.id"/>
    </div>
</template>

<script>
import Navbar from '@/components/NavbarFooter/Navbar.vue'
import Footer from '@/components/NavbarFooter/Footer.vue'
import About from '@/components/Infos/About.vue'
export default {
    components: {   Navbar, 
                    Footer,
                    About }
}
</script>