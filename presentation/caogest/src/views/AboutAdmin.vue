<template>
    <div id = "about" class = "About">
        <NavbarKennel/>
        
        <About/>
          
        <Footer/>
    </div>
</template>

<script>
import NavbarKennel from '../components/NavbarAdmin.vue'
import Footer from '../components/FooterAdmin.vue'
import About from '../components/About.vue'
export default {
    components: {   NavbarKennel, 
                    Footer,
                    About }
}
</script>