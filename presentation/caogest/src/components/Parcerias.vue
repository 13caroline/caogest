<template>
    <div id = "partnerships" class = "Partnerships">
        <Navbar/>
        <v-card> 
            <v-img src='../assets/parcerias.png'></v-img> 
        </v-card>
        <v-card flat height= "100" color = "white"></v-card>
        
        <v-card flat class="mx-auto" max-width="1700" fluid>
            <v-card-text class=" display-1"> A CãoGest pretende expressar o seu agradecimento a todos os voluntários e empresas que se predispõem para auxiliar os canis registados nesta plataforma, tanto em trabalho como financeiramente.</v-card-text> 
        </v-card>

        <v-card flat class = "mx-auto" height= "200" color = "white"></v-card>

        <div>
            <v-row>
                <v-col cols="12" sm="8" offset-sm="2" >
                    <v-container fluid>
                        <v-item-group
                            v-model="selected"
                            multiple
                        >
                            <v-row>
                                <v-col
                                    class="d-flex child-flex"
                                    cols="4"
                                    v-for="item in items"
                                    :key="item.nome">
                                    <v-card flat tile>
                                        <v-item v-slot:default="{ active, toggle }">
                                            <v-img
                                                :src="item.pathLogo"
                                                aspect-ratio="1"
                                                class="white"
                                                contain
                                                @click="toggle"
                                            >
                                                <template v-slot:placeholder>
                                                    <v-row class="fill-height ma-0" align="center" justify="center">
                                                        <v-progress-circular indeterminate color="grey lighten-5"></v-progress-circular>
                                                    </v-row>
                                                </template>
                                            </v-img>
                                        </v-item>
                                        <v-card-actions class="justify-center">
                                                    <v-btn text light :href="item.url"> {{item.nome}} </v-btn>  
                                        </v-card-actions>
                                    </v-card>
                                </v-col>
                            </v-row>
                        </v-item-group>
                    </v-container>      
                </v-col>
            </v-row>
        </div>
        <Footer/>
    </div>
</template>

<script>
import Navbar from '../components/NavbarAdmin.vue'
import Footer from '../components/FooterAdmin.vue'
import axios from 'axios'
const lhost = require("@/config/global").host;
 
export default {
    data: () => ({  
        items: [],
        selected: [],   
    }),
    components: {
                Navbar, 
                Footer
    }, 
    name: 'Parcerias',    
    props: ['id'], 
    created: async function(){
        try {
            let response = await axios.get(lhost + "/api/CP/" + this.id);
            this.items = response.data;
            this.ready = true;
        } 
        catch (e) {
            return e;
        }
    },  
    
}
</script>