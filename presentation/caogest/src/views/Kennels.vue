<template>
    <div id = "kennels" class = "kennels">
        <Navbar/>
        <v-card> 
            <v-img src='../assets/canis2.png'></v-img> 
        </v-card>
        <v-card flat height= "100" color = "white"></v-card>

        <div>
            <v-card flat class="mx-auto">
                <v-row>
                    <v-col class = "ma-12">
                        <Kennels/>
                    </v-col>
                   
                    <v-col cols = "3">
                        <v-row>
                            <v-card flat >
                                <v-card-text>
                                    <v-card-text class="display-2 font-weight-bold black--text">Pesquisar Canis</v-card-text>
                                    <v-card flat height= "50" color = "white"></v-card>
                                        <v-text-field flat color = "grey" name="input-7-1" outlined label="Nome" ></v-text-field>
                                        <v-text-field flat color = "grey" name="input-7-1" outlined label="Localidade" ></v-text-field>
                                </v-card-text>
                                <v-card-actions>
                                    <v-spacer></v-spacer>
                                    <v-btn class="ma-6" x-large color = "brown lighten-4" @click="dialog = false">Pesquisar</v-btn>
                                </v-card-actions>
                            </v-card>
                        </v-row>
                    </v-col>
                    
                </v-row>
            </v-card>
        </div>

        <Footer/>
    </div>
</template>

<script>
import Navbar from '../components/Navbar.vue'
import Footer from '../components/Footer.vue'
import Kennels from '../components/Kennels.vue'
export default {
    components: {   Navbar, 
                    Footer,
                    Kennels }, 
            
}
</script>