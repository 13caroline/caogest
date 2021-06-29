<template>
    <div id = "kennel" class = "Kennel">
        <Navbar :id="$route.params.id"/>
        <div>
            <v-card flat height = "200"></v-card>
            <v-card flat height = "100" color = "brown lighten-5">
                <v-card-text class = "display-2 black--text text-center">{{canil.nome}}</v-card-text>
            </v-card>
            <v-card flat height = "80"></v-card>
            <v-card flat>
                <v-row>
                    <v-spacer></v-spacer>
                    <v-col>
                        <v-btn disabled class="ma-6 headline" x-large color = "brown lighten-4">Quero voluntariar-me!</v-btn>
                    </v-col>
                    <v-spacer></v-spacer>
                    <v-col>
                        <v-btn class="ma-6 headline" x-large color = "brown lighten-4" @click="horario(canil)">Horário Voluntários</v-btn>
                    </v-col>
                    <v-spacer></v-spacer>
                    <v-col>
                        <v-btn class="ma-6 headline" x-large color = "brown lighten-4" @click="informacoes(canil)">Informações</v-btn>
                    </v-col>
                    <v-spacer></v-spacer>
                    <v-col>
                        <v-btn class="ma-6 headline" x-large color = "brown lighten-4" @click="parcerias(canil)">Parcerias</v-btn>
                    </v-col>
                    <v-spacer></v-spacer>
                </v-row>
            </v-card>
             <v-card flat height = "200"></v-card>
            <v-row>
                <v-col cols="12" sm="6" offset-sm="2">
                    <v-container fluid>
                        <v-item-group
                            v-model="selected"
                            multiple
                        >
                            <v-card flat height = "100"></v-card>
                            <v-card class = " mx-auto" height = "80" width="2000" flat color = "brown lighten-5" v-if="this.disponiveis.length === 0"> 
                                <v-card-title class = "display-1 text-center justify-center"> Não existem cães registados neste canil </v-card-title>
                            </v-card>
                            <v-row>
                                <v-col
                                    v-for="obj in disponiveis"
                                    :key="obj.nome"
                                    class="d-flex child-flex"
                                    cols="4"
                                >
                                    <v-card flat tile>
                                        <v-item v-slot:default="{ active, toggle }">
                                            <v-img
                                                :src="require(`@/assets/${getPath(obj)}`)"
                                                aspect-ratio="1"
                                                class="grey lighten-2"
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
                                       <v-btn 
                                            text
                                            x-large
                                            class = "headline"
                                            @click="cao(obj)"
                                        > {{obj.nome}} 
                                        </v-btn>  
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
import store from '@/store.js'
import axios from 'axios'
const lhost = require("@/config/global").host;

export default {
    data: () => ({   
        fab:false,           
        itemssexo: [ 
            'Macho',
            'Fêmea',
            'Ambos',
        ],
        itemsporte: [ 
            'Pequeno',
            'Médio',
            'Grande',
            'Todos',
        ], 
        itemscor: [
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
            'Todas',
        ],
        items: [],
        canil: {},
        selected: [],  
        caes:[],
        disponivel:[], 
        fotos: [],
        dialog: false,
        alert: false, 
    }),
    name: 'KennelsAdmin',
    props: ['id', 'id2'], 
    components: {   Navbar, 
                    Footer
                }, 

    created: async function(){
        try {
            let response = await axios.get(lhost + "/api/Canis/" + this.id2,
            { headers: 
              { "Authorization": 'Bearer ' + store.getters.token }
            });
            this.canil = response.data;

            let resposta = await axios.get(lhost + "/api/CaesEmailCanil/" + this.id2,
            { headers: 
              { "Authorization": 'Bearer ' + store.getters.token }
            });
            this.caes = resposta.data;
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
        cao: function(obj){
            this.$router.push("/cao/admin/" + this.id + '/' + obj.idCao );
        },
        informacoes: function(canil){
            this.$router.push("/informacoes/admin/" + this.id + '/' + canil.email);
        }, 
        parcerias: function(canil){
            this.$router.push("/parcerias/admin/" + this.id + '/' + canil.email);
        },
        horario: function(canil){
            this.$router.push("/horario/admin/canil/" + this.id + '/' + canil.email);
        },
        onScroll (e) {
            if (typeof window === 'undefined') return
            const top = window.pageYOffset ||   e.target.scrollTop || 0
            this.fab = top > 20
        },
        toTop () {
            this.$vuetify.goTo(0)
        }, 
        getPath: function(e) {
           return e.fotos[0].path
        },
         openDialog: function(dados){
            this.idCao = dados.idCao;
            this.nome = dados.nome;
            this.raca = dados.raca;
            this.idade = dados.idade;
            this.sexo = dados.sexo;
            this.cor = dados.cor;
            this.porte = dados.porte;
            this.esterilizacao = dados.esterilizacao;
            this.descricao = dados.descricao;
            this.fotos = dados.fotos;
            this.dialog = true;
        },
    },
    computed: {
        disponiveis: function () {
        return this.caes.filter(function (disponivel) {
            return (disponivel.estado !== "Apagado" && disponivel.estado !== "Adotado")
        })
        }, 
    }                    
            
}
</script>