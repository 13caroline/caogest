<template>
    <div id = "about" class = "About">
        <Navbar/>
        
        <About/>
          
        <Footer/>
    </div>
</template>

<script>
import Navbar from '../components/Navbar.vue'
import Footer from '../components/Footer.vue'
import About from '../components/About.vue'
export default {
    components: {   Navbar, 
                    Footer,
                    About }
}
</script>