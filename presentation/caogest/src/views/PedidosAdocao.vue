<template>
    <PedidosAdocao :id="$route.params.id"/>
</template>

<script>
// @ is an alias to /src
import PedidosAdocao from '@/components/PedidosAdocao.vue'
export default {
  name: 'PedidoAdocaoAdmin',
  components: {
    PedidosAdocao
  }
}
</script>