<template>
    <div id = "faqskennel" class = "FAQsKennel">
        <NavbarKennel/>
        <FAQs/>
        <Footer/>
    </div>
</template>


<script>
import NavbarKennel from '../components/NavbarKennel.vue'
import Footer from '../components/FooterKennel.vue'
import FAQs from '../components/FAQs.vue'
 
export default {
    components: {
                NavbarKennel, 
                Footer,
                FAQs
    }, 
    
}
</script>