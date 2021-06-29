<template>
    <div id = "faqsadmin" class = "FAQsAdmin">
        <NavbarKennel/>
        <FAQs/>
        <Footer/>
    </div>
</template>


<script>
import NavbarKennel from '../components/NavbarAdmin.vue'
import Footer from '../components/FooterAdmin.vue'
import FAQs from '../components/FAQs.vue'
 
export default {
    components: {
                NavbarKennel, 
                Footer,
                FAQs
    }, 
    
}
</script>