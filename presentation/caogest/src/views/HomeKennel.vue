<template>
    <div id = "mainpage" class = "Main Page">
        <NavbarKennel/>
        <v-card flat height= "80" color = "white"></v-card>
         <div>
            <v-row>

                <v-col cols="12" sm="6" offset-sm="2">
                    <v-btn v-btn class="ma-6" x-large color = "brown lighten-4" to="/dogregister">Registar Cão</v-btn>
                    <v-container fluid>
                        <v-item-group
                            v-model="selected"
                            multiple
                        >
                            <v-row>
                                <v-col
                                    v-for="n in 9"
                                    :key="n"
                                    class="d-flex child-flex"
                                    cols="4"
                                >
                                    <v-card flat tile>
                                        <v-item v-slot:default="{ active, toggle }">
                                            <v-img
                                                :src="`https://picsum.photos/500/300?image=${n * 5 + 10}`"
                                                :lazy-src="`https://picsum.photos/10/6?image=${n * 5 + 10}`"
                                                aspect-ratio="1"
                                                class="grey lighten-2"
                                                @click="toggle"
                                            >
                                                <template v-slot:placeholder>
                                                    <v-row class="fill-height ma-0" align="center" justify="center">
                                                        <v-progress-circular indeterminate color="grey lighten-5"></v-progress-circular>
                                                    </v-row>
                                                </template>  
                                                <v-btn icon dark>
                                                    <v-icon large>
                                                        {{ active ? 'mdi-heart' : 'mdi-heart-outline' }}
                                                    </v-icon>
                                                </v-btn>

                                            </v-img>
                                        </v-item>
                                    <v-card-actions class="justify-center">
                                        <DogKennel/>
                                    </v-card-actions>
                                </v-card>
                            </v-col>
                        </v-row>
                    </v-item-group>
                </v-container>      
                </v-col>
                <v-spacer></v-spacer>

                <v-col cols = "3">
                    <v-row>
                        <v-card flat>
                            <v-card-text align = "start" justify= "end" >
                                <v-card-text class="display-2 font-weight-bold black--text">Pesquisar Cães</v-card-text>
                                <v-card flat height= "50" color = "white"></v-card>
                                    <v-text-field flat color = "grey" name="input-7-1" outlined label="Raça" ></v-text-field>
                                    <v-select 
                                        color = "grey"
                                        name="input-7-1"
                                        flat outlined 
                                        :items="itemscor"
                                        label="Cor"
                                    ></v-select>
                                    <v-select 
                                        color = "grey"
                                        name="input-7-1"
                                        flat outlined 
                                        :items="itemssexo"
                                        label="Género"
                                    ></v-select>
                                    <v-text-field flat color = "grey" name="input-7-1" outlined label="Idade" ></v-text-field>
                                    <v-select 
                                        color = "grey"
                                        name="input-7-1"
                                        flat outlined 
                                        :items="itemsporte"
                                        label="Porte"
                                    ></v-select>
                                    <v-text-field flat color = "grey" name="input-7-1" outlined label="Distrito" ></v-text-field>
                            </v-card-text>
                            <v-card-actions>
                                <v-spacer></v-spacer>
                                <v-btn class="ma-6" x-large color = "brown lighten-4" @click="dialog = false">Pesquisar</v-btn>
                            </v-card-actions>
                        </v-card>
                    </v-row>
                </v-col>
            </v-row>
        </div>
        <Footer/>
    </div>
</template>

<script>
import NavbarKennel from '../components/NavbarKennel.vue'
import Footer from '../components/FooterKennel.vue'
import DogKennel from '../components/DogKennel.vue'
export default {
    data: () => ({             
        itemssexo: [ 
            '- Selecionar -',
            'Macho',
            'Fêmea',
        ],
        itemsporte: [ 
            '- Selecionar -',
            'Pequeno',
            'Médio',
            'Grande',
        ], 
        itemscor: [
            '- Selecionar -',
            'Amarelo',
            'Azul',
            'Branco',
            'Castanho',
            'Cinzento',
            'Creme',
            'Dourado',
            'Fulvo',
            'Malhado',
            'Preto',
            'Vermelho',
        ],
      selected: [],   
    }),
    components: { NavbarKennel, 
                  Footer,
                  DogKennel}
}
</script>