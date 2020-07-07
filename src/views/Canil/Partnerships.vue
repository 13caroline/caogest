<template>
    <Partnerships :id="$route.params.id"/>
</template>

<script>
// @ is an alias to /src
import Partnerships from '@/components/Partnerships.vue'
export default {
  name: 'Parcerias',
  components: {
    Partnerships
  }
}
</script>