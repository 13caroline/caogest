<template>
    <div id="app">
    <v-app id="inspire">
        <v-footer absolute padless>
        <v-card class="flex" color = "grey" flat tile >
            <v-card-title black--text class="grey lighten-2">
                <v-row>
                <v-spacer></v-spacer>
                <v-col>
                    <strong class="subheading">Cães</strong>
                    <v-card-actions>
                    <v-btn class="ma-1" text small to="/dogs">Encontrar um Cão</v-btn>
                    </v-card-actions>
                </v-col>

                <v-col>
                    <strong class="subheading">Envolva-se</strong>
                    <v-card-actions>
                        <v-btn text-lowercase class="ma-1" text small>Adotar</v-btn>
                    </v-card-actions>
                    <v-card-actions>
                        <v-btn class="ma-1" text small to= "/donativos">Donativos</v-btn>
                    </v-card-actions>
                </v-col>

                <v-col>
                    <strong class="subheading">A Nossa Organização</strong>
                    <v-card-actions>
                    <v-btn class="ma-1" text small to= "/sobre">Sobre</v-btn>
                    </v-card-actions>
                    <v-card-actions>
                    <v-btn class="ma-1" text small to="/faqs">Contactos</v-btn>
                    </v-card-actions>
                </v-col>

                <v-spacer></v-spacer>
                <v-img src="../assets/image.png" max-height="150" max-width="150"></v-img>

                </v-row>

                <v-card-text>
                    <v-divider inset></v-divider>
                    <v-card flat height= "2" color = "transparent" class="ma-5"></v-card>
                    <div class="headline text-center"> CãoGest é uma instituição sem fins lucrativos. A nossa missão é promover e facilitar a adoção de cães que se encontram ao abrigo de canis por todo o país.</div>
                    <div class="headline text-center"> Diga-nos o que pensa! <PopupSugestoes/> </div>
                </v-card-text>
            </v-card-title>
    
            <v-card-text class="py-2 white--text text-center">
            {{ new Date().getFullYear() }} — <strong>Caogest</strong>
            </v-card-text>
        </v-card>
        </v-footer>
    </v-app>
    </div>
</template>

<style> *{ text-transform: none !important; } </style>

<script>
import PopupSugestoes from '../components/PopupSugestões.vue'
export default {
    components: {PopupSugestoes 
    }
    
}
</script>