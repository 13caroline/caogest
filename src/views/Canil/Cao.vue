<template>
    <div id = "dogs" class = "Dogs">
        <Navbar :id="$route.params.id"/>

        <Cao :id="$route.params.id" :id2="$route.params.id2"/>
    
        <Footer :id="$route.params.id"/>
    </div>
</template>

<script>


import Navbar from '@/components/NavbarFooter/NavbarKennel.vue'
import Footer from '@/components/NavbarFooter/FooterKennel.vue'
import Cao from '@/components/Cao.vue'

export default {
    components: {   Navbar, 
                    Footer,
                    Cao
                    },
           
}
</script>