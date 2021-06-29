<template>
    <Kennel :id="$route.params.id" :id2="$route.params.id2"/>
</template>

<script>
// @ is an alias to /src
import Kennel from '@/components/Utilizador/Kennel.vue'
export default {
  name: 'Kennels',
  components: {
    Kennel
  }
}
</script>