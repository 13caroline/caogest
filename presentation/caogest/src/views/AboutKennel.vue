<template>
    <div id = "about" class = "About">
        <NavbarKennel/>
        
        <About/>
          
        <Footer/>
    </div>
</template>

<script>
import NavbarKennel from '../components/NavbarKennel.vue'
import Footer from '../components/FooterKennel.vue'
import About from '../components/About.vue'
export default {
    components: {   NavbarKennel, 
                    Footer,
                    About }
}
</script>