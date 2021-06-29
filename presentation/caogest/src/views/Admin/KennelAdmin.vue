<template>
    <Kennel :id="$route.params.id" :id2="$route.params.id2"/>
</template>

<script>
// @ is an alias to /src
import Kennel from '@/components/Admin/KennelAdmin.vue'
export default {
  name: 'KennelsAdmin',
  components: {
    Kennel
  }
}
</script>