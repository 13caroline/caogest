<template>
    <Informations :id="$route.params.id" :id2="$route.params.id2"/>
</template>

<script>
// @ is an alias to /src
import Informations from '@/components/Admin/Informacoes.vue'
export default {
  name: 'Informacoes',
  components: {
    Informations
  }
}
</script>