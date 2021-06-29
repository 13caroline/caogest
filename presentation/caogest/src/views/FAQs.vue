<template>
    <div id = "faqs" class = "FAQs">
        <Navbar/>

        <FAQs/>
        
        <Footer/>
    </div>
</template>


<script>
import Navbar from '../components/Navbar.vue'
import Footer from '../components/Footer.vue'
import FAQs from '../components/FAQs.vue'
 
export default {
    components: {
                Navbar, 
                Footer,
                FAQs 
    }, 
    
}
</script>