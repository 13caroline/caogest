<template>
    <div>
        <v-img src="@/assets/adopt.png"></v-img>
        <v-card flat height = "100"></v-card>
        <v-card flat height = "100" color = "brown lighten-5">
            <v-card-text class = "display-2 black--text text-center">{{doc.titulo}}</v-card-text>
        </v-card>
        <v-card flat height = "200"></v-card>

         <v-row justify="center">
            <v-card flat width="1500" color = "white">
                <div class = "display-1" v-html="doc.texto"> </div>
            </v-card>
        </v-row>
    </div>
</template>

<script>
import store from '@/store.js'
import axios from 'axios'
const lhost = require("@/config/global").host;
 
export default {
    name: 'docsrand',    
    props: ['id','id2'], 
    data: () => ({  
        doc: {},
        fab:false, 
    }),

    created: async function(){
        try {
            let response = await axios.get(lhost + "/api/Documentos/" + this.id2,
            { headers: 
              { "Authorization": 'Bearer ' + store.getters.token }
            });
            this.doc = response.data;
            this.ready = true;
        } 
        catch (e) {
            return e;
        }
    },  
    
}
</script>