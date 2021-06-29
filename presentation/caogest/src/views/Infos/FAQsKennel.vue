<template>
    <div id = "faqskennel" class = "FAQsKennel">
        <NavbarKennel :id="$route.params.id"/>
        <FAQs :id="$route.params.id"/>
        <Footer :id="$route.params.id"/>
    </div>
</template>


<script>
import NavbarKennel from '@/components/NavbarFooter/NavbarKennel.vue'
import Footer from '@/components/NavbarFooter/FooterKennel.vue'
import FAQs from '@/components/Infos/FAQs.vue'
 
export default {
    components: {
                NavbarKennel, 
                Footer,
                FAQs
    }, 
    
}
</script>