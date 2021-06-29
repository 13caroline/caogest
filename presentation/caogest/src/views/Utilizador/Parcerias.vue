<template>
    <Partnerships :id="$route.params.id" :id2="$route.params.id2"/>
</template>

<script>
// @ is an alias to /src
import Partnerships from '@/components/Utilizador/Parcerias.vue'
export default {
  name: 'Parcerias',
  components: {
    Partnerships
  }
}
</script>