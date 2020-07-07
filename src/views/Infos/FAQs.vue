<template>
    <div id = "faqs" class = "FAQs">
        <Navbar :id="$route.params.id"/>

        <FAQs :id="$route.params.id"/>
        
        <Footer :id="$route.params.id"/>
    </div>
</template>


<script>
import Navbar from '@/components/NavbarFooter/Navbar.vue'
import Footer from '@/components/NavbarFooter/Footer.vue'
import FAQs from '@/components/Infos/FAQs.vue'
 
export default {
    components: {
                Navbar, 
                Footer,
                FAQs 
    }, 
    
}
</script>