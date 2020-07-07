<template>
    <div>   
        <v-row align = "center" justify = "center">
            <v-col>
                    <v-container fluid>
                        <v-item-group
                            v-model="selected"
                            multiple
                        >
                            <v-card flat height = "100"></v-card>
                            <v-card class = " mx-auto" height = "150" width="1770" flat color = "brown lighten-5" v-if="this.disponiveis.length === 0"> 
                                <v-card-title class = "display-1 text-center justify-center"> Adotar um cão é um processo longo e cuidado. Adicione aqui os patudos que pretende conhecer e torná-los </v-card-title>
                                <v-card-title class = "display-1 justify-center">parte da sua família.</v-card-title>
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
                                            class = "display-1"
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
            </v-row>
    </div>
</template>

<script>
import axios from 'axios'
import store from '@/store'
const lhost = require("@/config/global").host;


export default {
    name: "Dog",
    props:['id', 'id2', 'id3'],

    data: () => ({   
        fab:false,  
        caes: [],   
        disponivel: [],     
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
        dialog: false, 
        alert: false, 
        selected: [], 
        idCao: "",
        nome: "",
        idade: "",
        esterilizacao: "", 
        raca: "", 
        sexo: "", 
        cor: "", 
        porte: "", 
        descricao: "", 
        email_canil: "",
        nome_canil:"", 
        estado: "", 
        fotos: [],
        path:"", 

    }),
    methods:{
        cao: function(obj){
            this.$router.push("/cao/utilizador/" + this.id + '/' + obj.idCao );
        },
        getPath: function(e) {
           return e.fotos[0].path;
        },
    },
    created: async function(){
        try {
        let response = await axios.get(lhost + "/api/Favoritos/" + this.id, 
            { headers: 
                { "Authorization": 'Bearer ' + store.getters.token }
            });
        this.caes = response.data;
        this.ready = true;
        } 
        catch (e) {
            if(e.message == "Request failed with status code 401"){
                this.$store.commit("limpaStore");
                this.$router.push("/");
            }
        }   
    },
    computed: {
        disponiveis: function () {
            return this.caes.filter(function (disponivel) {
                return (disponivel.estado !== "Apagado" && disponivel.estado != "Adotado")
            })
        }, 
    }    

}
</script>
