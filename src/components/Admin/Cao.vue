<template>
    <div>           
        <v-card flat height = "200"></v-card>
        <v-container fluid>
            <v-row class = "align-center justify-center">
                <v-col cols = "4">
                    <v-card flat class = "mx-auto" height = "800" width = "900"> 
                         <v-img height = "800" width = "900" :src="require(`@/assets/${getPath(cao)}`)"></v-img> 
                    </v-card>
                </v-col>

                <v-col cols = "6">
                    <v-card color = "brown lighten-5" height = "800" width = "1200" tile>
                        <v-card flat color = "brown lighten-5" height = "40"></v-card>
                        <v-row class="ml-8">
                            <p 
                                class = " display-1 font-weight-bold" 
                                color = "grey"
                            > Nome: 
                                <span 
                                    class = "display-1 font-weight-regular "
                                >{{cao.nome}}</span>
                            </p> 
                            </v-row>
                            <v-card 
                                flat 
                                color = "brown lighten-5 "
                                height = "20"
                            ></v-card>
                            <v-row class="ml-8">
                                <p 
                                    class = " display-1 font-weight-bold" 
                                    color = "grey"
                                > Raça: 
                                    <span 
                                        class = "display-1 font-weight-regular "
                                    >{{cao.raca}}</span>
                                </p> 
                            </v-row>
                            <v-card 
                                flat 
                                color = "brown lighten-5" 
                                height = "20"
                            ></v-card>                                       
                            <v-row class="ml-8">
                                <p 
                                    class = " display-1 font-weight-bold" 
                                    color = "grey"
                                > Idade: 
                                    <span 
                                        class = "healine font-weight-regular "
                                    >{{cao.idade}}</span>
                                </p> 
                            </v-row>
                            <v-card 
                                flat 
                                color = "brown lighten-5" 
                                height = "20"
                            ></v-card>
                            <v-row class="ml-8">
                                <p 
                                    class = " display-1 font-weight-bold" 
                                    color = "grey"
                                > Cor: 
                                    <span 
                                        class = "healine font-weight-regular "
                                    >{{cao.cor}}</span>
                                </p> 
                            </v-row>
                            <v-card 
                                flat 
                                color = "brown lighten-5" 
                                height = "20"
                            ></v-card>                                    
                            <v-row class="ml-8">
                                <p 
                                    class = " display-1 font-weight-bold" 
                                    color = "grey"
                                > Porte: 
                                    <span 
                                        class = "display-1 font-weight-regular "
                                    >{{cao.porte}}</span>
                                </p> 
                            </v-row>
                            <v-card 
                                flat 
                                color = "brown lighten-5" 
                                height = "20"
                            ></v-card>
                            <v-row class="ml-8">
                                <p 
                                    class = " display-1 font-weight-bold" 
                                    color = "grey"
                                > Sexo: 
                                    <span 
                                        class = "display-1 font-weight-regular "
                                    >{{cao.sexo}}</span>
                                </p> 
                            </v-row>
                            <v-card 
                                flat 
                                color = "brown lighten-5" 
                                height = "20"
                            ></v-card>                                        
                            <v-row class="ml-8">
                            <p 
                                class = " display-1 font-weight-bold" 
                                color = "grey"
                            > Esterilizado: 
                                <span 
                                    class = "display-1 font-weight-regular "
                                >{{cao.esterilizacao}}
                                </span>
                            </p> 
                            </v-row>
                            <v-card 
                                flat   
                                color = "brown lighten-5" 
                                height = "20"
                            ></v-card>
                            <v-row class="ml-8">
                                <p 
                                    class = " display-1 font-weight-bold" 
                                    color = "grey"
                                > Descrição: 
                                    <span 
                                        class = "display-1 font-weight-regular "
                                    >{{cao.descricao}}</span>
                                </p> 
                            </v-row>
                            <v-card 
                                flat 
                                color = "brown lighten-5" 
                                height = "20"
                            ></v-card>   
                            <v-row class="ml-8">
                                <p class = " display-1 font-weight-bold" 
                                    color = "grey"
                                > Canil: 
                                    <span 
                                        class = "display-1 font-weight-regular "
                                    >{{cao.nome_canil}}</span>
                                </p> 
                            </v-row>
                        </v-card>
                    </v-col>
                </v-row>
            </v-container>
    </div>
</template>

<script>
import store from '@/store.js'
import axios from 'axios'
const lhost = require("@/config/global").host;


export default {
    name: "Dog",
    props:['id', 'id2'],

    data: () => ({   
        fab:false,  
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
        cao:[],

    }),
    methods:{
        getPath: function(e) {
           return e.fotos[0].path;
        },
    },
    created: async function(){
        try {
            let response = await axios.get(lhost + "/api/Caes/" + this.id2,
            { headers: 
              { "Authorization": 'Bearer ' + store.getters.token }
            });
            this.cao = response.data;
            this.ready = true;
        } 
        catch (e) {
            if(e.message == "Request failed with status code 401"){
            this.$store.commit("limpaStore");
            this.$router.push("/");
      }
        }
    }, 
}
</script>
