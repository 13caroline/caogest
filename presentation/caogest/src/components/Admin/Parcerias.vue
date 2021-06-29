<template>
    <div id = "partnerships" class = "Partnerships">
        <Navbar :id="$route.params.id"/>
        <v-card> 
            <v-img src='@/assets/parcerias.png'>
                <v-row align = "end" justify = "end">
                    <v-btn text class = "white--text overline font-weight-thin text--secondary" href="https://www.wallpaperflare.com/dogs-australian-shepherd-border-collie-pet-wallpaper-elke">hiperligação para a imagem original</v-btn>
                </v-row>
            </v-img> 
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
                        <v-card class = "display-1 mx-auto text-center"  flat color = "brown lighten-5" v-if="items.length == 0">Este canil não tem nenhum parceiro associado.</v-card>
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
        <v-btn
            v-scroll="onScroll"
            x-large
            v-show="fab"
            fab
            depressed
            fixed
            bottom
            right
            class = "ma-6"
            color="deep-orange lighten-4"
            @click="toTop"
        >
            <v-icon>keyboard_arrow_up</v-icon>
        </v-btn>
        <Footer :id="$route.params.id"/>
    </div>
</template>

<script>
import Navbar from '@/components/NavbarFooter/NavbarAdmin.vue'
import Footer from '@/components/NavbarFooter/FooterAdmin.vue'
import axios from 'axios'
const lhost = require("@/config/global").host;
import store from '@/store.js'
 
export default {
    data: () => ({ 
        fab:false,  
        items: [],
        selected: [],   
    }),
    components: {
                Navbar, 
                Footer
    }, 
    name: 'Parcerias',    
    props: ['id', 'id2'], 
    created: async function(){
        try {
            let response = await axios.get(lhost + "/api/CP/" + this.id2,
            { headers: 
              { "Authorization": 'Bearer ' + store.getters.token }
            });
            this.items = response.data;
            this.ready = true;
        } 
        catch (e) {
            if(e.message == "Request failed with status code 401"){
                this.$store.commit("limpaStore");
                this.$router.push("/");
            }
        }
    },
    methods: {
        onScroll (e) {
      if (typeof window === 'undefined') return
      const top = window.pageYOffset ||   e.target.scrollTop || 0
      this.fab = top > 20
    },
    toTop () {
      this.$vuetify.goTo(0)
    },
    }  
}
</script>