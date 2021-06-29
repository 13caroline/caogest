<template>
    <Informations :id="$route.params.id"/>
</template>

<script>
// @ is an alias to /src
import Informations from '@/components/Informacoes.vue'
export default {
  name: 'Informacoes',
  components: {
    Informations
  }
}
</script>