<template>
    <div id = "donationskennel" class = "donationsKennel">
        <NavbarKennel :id="$route.params.id"/>
           <DonationsKennel :id="$route.params.id" />
        <Footer :id="$route.params.id"/>
    </div>
</template>

<script>
import NavbarKennel from '@/components/NavbarFooter/NavbarKennel.vue'
import Footer from '@/components/NavbarFooter/FooterKennel.vue'
import DonationsKennel from '@/components/DonationsKennel.vue'

export default {
     components: {
                NavbarKennel, 
                Footer,
                DonationsKennel
    }, 
};
</script>

<style>

</style>
