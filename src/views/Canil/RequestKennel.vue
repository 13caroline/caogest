<template>
    <RequestKennel :id="$route.params.id" :id2="$route.params.id2"/>
</template>

<script>
// @ is an alias to /src
import RequestKennel from '@/components/Admin/RequestKennel.vue'
export default {
  name: 'PedidoRegisto',
  components: {
    RequestKennel
  }
}
</script>