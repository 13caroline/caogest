<template>
    <div id = "dogs" class = "Dogs">
        <Navbar/>
        <v-card> 
            <v-img src='../assets/caes2.png'></v-img> 
        </v-card>
        <v-card flat height= "100" color = "white"></v-card>
        
        <div>
            <v-row>
                <v-col cols="12" sm="6" offset-sm="2">
                    <v-container fluid>
                        <v-item-group
                            v-model="selected"
                            multiple
                        >
                            <v-row>
                                <v-col
                                    v-for="item in items"
                                    :key="item.nome"
                                    class="d-flex child-flex"
                                    cols="4"
                                >
                                    <v-card flat tile>
                                        <v-item v-slot:default="{ active, toggle }">
                                            <v-img
                                                src='../assets/example.jpg'
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
                                            <v-dialog v-model="dialog" fullscreen hide-overlay transition="dialog-bottom-transition">
                                                <template v-slot:activator="{on}">
                                                    <v-btn text v-on="on"> {{item.nome}} </v-btn>  
                                                </template>
                                                <v-card class = "ma-2" flat>
                                                    <v-toolbar height = "100" color="deep-orange lighten-4">
                                                        <v-btn icon @click="dialog = false">
                                                            <v-icon>mdi-close</v-icon>
                                                        </v-btn>
                                                    <v-toolbar-title >Fechar</v-toolbar-title>
                                                    </v-toolbar>
                                                        
                                                    <v-card color = "white" height = "150" flat></v-card>
                                        
                                                    <v-row>
                                                        <v-col>
                                                            <v-card flat color = "white" class = "mx-auto" height = "800" width = "900"> 
                                                                <v-img height = "800" width = "800" src='../assets/example.jpg'></v-img> 
                                                                <v-card flat color = "white" height = "100"></v-card>
                                                            </v-card>
                                                        </v-col>

                                                        <v-col>
                                                            <v-card flat>
                                                                <v-row>
                                                                    <p class = " display-2 font-weight-bold" color = "grey"> Nome: 
                                                                        <span class = "display-2 font-weight-regular ">{{item.nome}}</span>
                                                                    </p> 
                                                                </v-row>
                                                                <v-card flat color = "white" height = "40"></v-card>
                                                                <v-row>
                                                                    <p class = " display-2 font-weight-bold" color = "grey"> Raça: 
                                                                        <span class = "display-2 font-weight-regular ">{{item.raca}}</span>
                                                                    </p> 
                                                                </v-row>
                                                                    <v-card flat color = "white" height = "40"></v-card>
                                                                <v-row>
                                                                    <p class = " display-2 font-weight-bold" color = "grey"> Idade: 
                                                                        <span class = "display-2 font-weight-regular ">{{item.idade}}</span>
                                                                    </p> 
                                                                </v-row>
                                                                <v-card flat color = "white" height = "40"></v-card>
                                                                <v-row>
                                                                    <p class = " display-2 font-weight-bold" color = "grey"> Cor: 
                                                                        <span class = "display-2 font-weight-regular ">{{item.cor}}</span>
                                                                    </p> 
                                                                </v-row>
                                                                <v-card flat color = "white" height = "40"></v-card>
                                                                <v-row>
                                                                    <p class = " display-2 font-weight-bold" color = "grey"> Porte: 
                                                                        <span class = "display-2 font-weight-regular ">{{item.porte}}</span>
                                                                    </p> 
                                                                </v-row>
                                                                <v-card flat color = "white" height = "40"></v-card>
                                                                <v-row>
                                                                    <p class = " display-2 font-weight-bold" color = "grey"> Sexo: 
                                                                        <span class = "display-2 font-weight-regular ">{{item.sexo}}</span>
                                                                    </p> 
                                                                </v-row>
                                                                    <v-card flat color = "white" height = "40"></v-card>
                                                                <v-row>
                                                                    <p class = " display-2 font-weight-bold" color = "grey"> Esterilizado: 
                                                                        <span class = "display-2 font-weight-regular ">{{item.esterilizacao}}</span>
                                                                    </p> 
                                                                </v-row>
                                                                <v-card flat color = "white" height = "40"></v-card>
                                                                <v-row>
                                                                    <p class = " display-2 font-weight-bold" color = "grey"> Descrição: 
                                                                        <span class = "display-2 font-weight-regular ">{{item.descricao}}</span>
                                                                    </p> 
                                                                </v-row>
                                                            </v-card>
                                                        </v-col>
                                                    </v-row>
                                                </v-card>
                                            </v-dialog>
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
import axios from 'axios'
const lhost = require("@/config/global").host;

import Navbar from '../components/NavbarAdmin.vue'
import Footer from '../components/Footer.vue'

export default {
    data: () => ({    
        dialog:false,         
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
        items: [],
      selected: [],   
    }),
    components: {   Navbar, 
                    Footer,
                    }, 
    created: async function(){
        try {
        let response = await axios.get(lhost + "/api/Caes");
        this.items = response.data;
        this.ready = true;
        } 
        catch (e) {
        return e;
        }
    },         
}
</script>