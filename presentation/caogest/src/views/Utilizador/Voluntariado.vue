<template>
    <div id = "dogs" class = "Dogs">
        <Navbar :id="$route.params.id"/>

        <Voluntariado :id="$route.params.id"/>
    
        <Footer :id="$route.params.id"/>
    </div>
</template>

<script>


import Navbar from '@/components/NavbarFooter/Navbar.vue'
import Footer from '@/components/NavbarFooter/Footer.vue'
import Voluntariado from '@/components/Utilizador/Voluntariado.vue'


export default {
    data: () => ({   
    }),
    components: {   Navbar, 
                    Footer, 
                    Voluntariado
                },
           
}
</script>