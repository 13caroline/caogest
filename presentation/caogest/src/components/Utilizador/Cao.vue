<template>
    <div>           
        <v-card flat height = "200"></v-card>
        <v-container fluid>
            <v-row class = "align-center justify-center">
                <v-col cols = "4">
                    <v-card flat class = "mx-auto" height = "800" width = "900"> 
                         <v-img height = "800" width = "900" :src="require(`@/assets/${getPath(cao)}`)">
                            <v-tooltip top v-if="reservado">
                                <template v-slot:activator="{ on }">
                                    <v-btn class = "ma-6" text fab x-large v-on="on">
                                        <v-icon style="font-size: 80px;"  color = "yellow" x-large>new_releases</v-icon>    
                                    </v-btn>  
                                </template>
                                <span class = "headline">Em processo de adoção</span> 
                            </v-tooltip>
                         </v-img> 
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
                <v-row justify = "center">
                    <v-col cols = "12" md = "9">
                            <v-btn 
                                x-large 
                                height = "100" 
                                class = "display-1 mr-8" 
                                color = "deep-orange lighten-5" 
                                @click="adotar(cao)"
                            > Quero Adotar! 
                            </v-btn>

                            <v-btn 
                                x-large 
                                tile
                                height = "100" 
                                text
                                class = "display-1 mx-2" 
                                v-if="lista"
                                @click="removeFavorito"
                            > 
                                <v-icon left color = "red">
                                    mdi-heart
                                </v-icon> 
                                Favoritos
                            </v-btn>
                            <v-btn 
                                x-large 
                                tile
                                height = "100" 
                                class = "display-1 mx-2" 
                                color = "deep-orange lighten-5" 
                                v-else
                                @click="addFavorito"
                            > 
                                <v-icon left>
                                    mdi-heart
                                </v-icon> 
                                Favoritos
                            </v-btn>
                    </v-col>
                </v-row>
        </v-container>
    </div>
</template>

<script>
import axios from 'axios'
import store from '@/store'
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
        favoritos:[],
        cao:[],

    }),
    methods:{
        getPath: function(e) {
           return e.fotos[0].path;
        },
        adotar: function(cao){
            this.email_canil = cao.email_canil; 
            this.$router.push("/formulario/adocao/" + this.id + '/' + this.email_canil + '/' + this.id2);
        },
        addFavorito: async function(){
            try{
                var resposta = 
                    await axios.post(lhost + "/api/Favoritos",
                    {
                        utilizador_user_email: this.id, 
                        cao_idCa: parseInt(this.id2), 
                    },
                    { headers: 
                        { "Authorization": 'Bearer ' + store.getters.token }
                    });
                console.log(JSON.stringify(resposta.data));
                this.$router.push("/pagina/utilizador/" + this.id);
            }
            catch(e){
                if(e.message == "Request failed with status code 401"){
                this.$store.commit("limpaStore");
                this.$router.push("/");
            }
            }
        },
        removeFavorito: async function(){
            try{
                var resposta = await axios.delete(lhost + "/api/Favoritos/" + this.id + '/' + this.id2, 
                { headers: 
                    { "Authorization": 'Bearer ' + store.getters.token }
                });
                console.log(JSON.stringify(resposta.data));
            }
            catch(e){
                if(e.message == "Request failed with status code 401"){
                this.$store.commit("limpaStore");
                this.$router.push("/");
            }
            }
            this.$router.push("/pagina/utilizador/" + this.id);
        }
    },
    created: async function(){
        try {
            let response = await axios.get(lhost + "/api/Caes/" + this.id2, 
            { headers: 
                { "Authorization": 'Bearer ' + store.getters.token }
            });
            this.cao = response.data;

            let resposta = await axios.get(lhost + "/api/Favoritos/" + this.id, 
            { headers: 
                { "Authorization": 'Bearer ' + store.getters.token }
            }); 
            this.favoritos = resposta.data; 

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
        favoritado: function(){
            let self=this;
            return this.favoritos.filter(function (fav){
                return (fav.idCao == self.id2)
            })
        }, 
        lista: function(){
            return (this.favoritado.length) ? true : false;
        }, 
        reservado: function () {
            return (this.cao.estado === "Reservado") ? true : false; 
        },   
    }  

}
</script>
