<template>
    <div id = "faqsadmin" class = "FAQsAdmin">
        <NavbarKennel :id="$route.params.id"/>
        <FAQs :id="$route.params.id"/>
        <Footer :id="$route.params.id"/>
    </div>
</template>


<script>
import NavbarKennel from '@/components/NavbarFooter/NavbarAdmin.vue'
import Footer from '@/components/NavbarFooter/FooterAdmin.vue'
import FAQs from '@/components/Infos/FAQs.vue'
 
export default {
    components: {
                NavbarKennel, 
                Footer,
                FAQs
    }, 
    
}
</script>