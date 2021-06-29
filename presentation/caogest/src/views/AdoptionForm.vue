<template>
    <div id = "canilRegister">
        <AdoptionForm :id="$route.params.id" :id2="$route.params.id2" :id3="$route.params.id3"/>
    </div>
</template>

<script>
import AdoptionForm from '@/components/Utilizador/AdoptionForm.vue'
export default {
    components: {
                AdoptionForm
                }
}
</script>