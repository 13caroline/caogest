<template>
    <div id = "dogs" class = "Dogs">
        <Navbar :id="$route.params.id"/>

        <Cao :id="$route.params.id" :id2="$route.params.id2"/>
    
        <Footer :id="$route.params.id"/>
    </div>
</template>

<script>


import Navbar from '@/components/NavbarFooter/NavbarAdmin.vue'
import Footer from '@/components/NavbarFooter/FooterAdmin.vue'
import Cao from '@/components/Admin/Cao.vue'

export default {
    data: () => ({   
        fab: false,  
    }),
    components: {   Navbar, 
                    Footer,
                    Cao
                    },
           
}
</script>