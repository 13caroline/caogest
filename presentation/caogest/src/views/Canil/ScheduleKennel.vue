<template>
    <div id = "schedule" class = "schedule">
        <NavbarKennel :id="$route.params.id"/>
        <Schedule :id="$route.params.id" />
        <Footer :id="$route.params.id"/>
    </div>
</template>

<script>
import NavbarKennel from '@/components/NavbarFooter/NavbarKennel.vue'
import Footer from '@/components/NavbarFooter/FooterKennel.vue'
import Schedule from '@/components/ScheduleKennel.vue'

export default {

    components: { NavbarKennel, 
                  Footer, 
                  Schedule}
}
</script>