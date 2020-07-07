<template>
    <div>
        <div>
            <v-row >
                <v-col 
                    cols="12" 
                    sm="6" 
                    offset-sm="2" 
                >
                    <v-container fluid>
                        <v-item-group
                            v-model="selected"
                            multiple
                        >
                            <v-row>
                                <v-col
                                    class="d-flex child-flex"
                                    cols="4"
                                    v-for="obj in filterList"
                                    :key="obj.nome"
                                    >
                                    <v-card flat tile>
                                        <v-item 
                                            v-slot:default="{ active, toggle }"
                                        >
                                            <v-img
                                                :src="require(`@/assets/${getPath(obj)}`)"
                                                aspect-ratio="1"
                                                class="grey lighten-2"
                                                @click="toggle"
                                            >
                                                <template v-slot:placeholder>
                                                    <v-row 
                                                        class="fill-height ma-0" 
                                                        align="center" 
                                                        justify="center"
                                                    >
                                                        <v-progress-circular 
                                                            indeterminate 
                                                            color="grey lighten-5"
                                                        ></v-progress-circular>
                                                    </v-row>
                                                </template>
                                            </v-img>
                                 
                                        </v-item>
                                        
                                        <v-row justify="center">
                                            <v-btn 
                                                text
                                                x-large
                                                class = "headline"
                                                @click="cao(obj)"
                                            > {{obj.nome}} 
                                            </v-btn>  
                                        </v-row>
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
                                    <v-text-field flat color = "grey" name="input-7-1" v-model="raca" outlined label="Raça" ></v-text-field>
                                    <v-select 
                                        color = "grey"
                                        name="input-7-1"
                                        flat outlined 
                                        :items="itemscor"
                                        v-model="cor"
                                        label="Cor"
                                    ></v-select>
                                    <v-select 
                                        color = "grey"
                                        name="input-7-1"
                                        flat outlined 
                                        :items="itemssexo"
                                        v-model="sexo"
                                        label="Género"
                                    ></v-select>
                                    <v-select 
                                        color = "grey"
                                        name="input-7-1"
                                        flat outlined 
                                        :items="itemsporte"
                                        v-model="porte"
                                        label="Porte"
                                    ></v-select>
                                    <v-text-field flat color = "grey" name="input-7-1" v-model="distrito" outlined label="Distrito" ></v-text-field>
                            </v-card-text>
                        </v-card>
                    </v-row>
                </v-col>  
            </v-row>        
        </div>
    </div>
</template>

<script>
import axios from 'axios'
import store from '@/store'
const lhost = require("@/config/global").host;

export default {
    props: ['item', 'id'],
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
        favoritos: [],
        selected: [],  
        disponivel: [],  
        fotos: [], 
        cor: "",
        sexo:"",
        porte:"",
        raca:"",
        distrito:"", 
    }), 
    created: async function(){
        try {
            let response = await axios.get(lhost + "/api/Caes", 
            { headers: 
                { "Authorization": 'Bearer ' + store.getters.token }
            });
            response.data.sort((a, b) => (a.nome > b.nome) ? 1 : -1);
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
    methods:{
        cao: function(obj){
            this.$router.push("/cao/utilizador/" + this.id + '/' + obj.idCao );
        },
        getPath: function(e) {
           return e.fotos[0].path
        },
        adotar: function(){
            this.$router.push("/formulario/adocao/" + this.id + '/' + this.email_canil + '/' + this.idCao);
        },
    },
    computed: {
        disponiveis: function () {
            return this.items.filter(function (disponivel) {
                return (disponivel.estado !== "Apagado" && disponivel.estado !== "Adotado")
            })
        }, 
        filterList(){
            return this.disponiveis.filter(item => {
                if (this.cor == "- Selecionar -") this.cor = ""; 
                if (this.sexo == "- Selecionar -") this.sexo = ""; 
                if (this.porte == "- Selecionar -") this.porte = "";
                if(this.cor == "" && this.sexo == "" && this.porte =="" && this.raca == "" && this.distrito == "") return this.disponiveis;
                var cor = this.cor ? (item.cor.includes(this.cor)) : true, 
                    sexo = this.sexo ? (this.sexo == item.sexo) : true, 
                    porte = this.porte ? (this.porte == item.porte) : true, 
                    raca = this.raca ? (this.raca == item.raca) : true, 
                    distrito = this.distrito ? (this.distrito == item.distrito) : true;

            if (cor && sexo && porte && raca && distrito) return item;
            })
        }
    }      
}
</script> 
