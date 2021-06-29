<template>
    <Kennel :id="$route.params.id"/>
</template>

<script>
// @ is an alias to /src
import Kennel from '@/components/Kennel.vue'
export default {
  name: 'Kennels',
  components: {
    Kennel
  }
}
</script>