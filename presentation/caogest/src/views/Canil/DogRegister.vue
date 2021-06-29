<template>
    <Dog :id="$route.params.id" />
</template>

<script>
import Dog from '@/components/DogRegister.vue'
export default {
    components:{
        Dog,
    }
}
</script>