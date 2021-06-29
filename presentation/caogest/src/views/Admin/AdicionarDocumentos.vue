<template>
    <div>
        <AdicionarDocumentos :id="$route.params.id"/>
    </div>
</template>

<script>
import AdicionarDocumentos from '@/components/Docs/AdicionarDocumentos.vue'

export default {
    components: {
        AdicionarDocumentos
    }
}
</script>