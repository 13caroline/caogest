<template>
    <div>
        <v-row>
            <v-col cols="12" sm="8" offset-sm="2" >
                <v-btn class="ma-3" x-large color = "brown lighten-4" @click="registar">Registar Parceria</v-btn>
                <v-container fluid>
                    <v-card class = " mx-auto" height = "80" width="2000" flat color = "brown lighten-5" v-if="this.items.length === 0"> 
                        <v-card-title class = "display-1 text-center justify-center"> Não existem parcerias associadas. </v-card-title>
                    </v-card>
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
        <v-row justify="center">
                <v-dialog v-model="dialog" persistent max-height = "1000px" max-width="1500px">
                    <v-card height = "80" flat color = "brown darken-1" dark>
                        <v-card-title>
                            <span class="display-1">Registar Parceria</span>
                        </v-card-title>
                    </v-card>
                    <v-card flat height = "20"></v-card>
                    <v-card flat>    
                        <v-card-text>
                            <v-container>
                                <v-form ref="form" lazy-validation>
                                <v-card flat height = "10"></v-card>
                                <v-row align="center" justify="center">
                                <v-col cols="10" >
                                    <v-text-field 
                                        outlined
                                        label="Nome da Parceria *" 
                                        class="headline" 
                                        color = "brown darken-1" 
                                        :rules ="regraNome"
                                        v-model="form.nome"
                                        required
                                    ></v-text-field>
                                </v-col>
                                <v-col cols="10" >
                                    <v-text-field 
                                        outlined
                                        class = "headline"
                                        color="brown darken-4"
                                        label="URL da página da parceria *"
                                        :rules ="regraURL"
                                        v-model="form.url"
                                        >
                                        </v-text-field>
                                </v-col>
                                <v-col cols="10">
                                    <v-text-field 
                                        outlined
                                        label="URL da imagem da parceria *" 
                                        color = "brown darken-1" 
                                        required
                                        :rules ="regraPath"
                                        v-model="form.path"
                                    ></v-text-field>
                                </v-col>
                                </v-row>
                                </v-form>
                            </v-container>
                        <small>* campos obrigatórios</small>
                        </v-card-text>
                        <v-card-actions>
                            <v-spacer></v-spacer>
                            <v-btn color="brown lighten-4" class = "headline ma-2" x-large @click="dialog = false">Cancelar</v-btn>
                            <v-btn color="brown lighten-4" class = "headline ma-2" x-large @click="registarParceria">Registar Parceria</v-btn>
                        </v-card-actions>
                    </v-card>
                </v-dialog>
            </v-row>
    </div>
</template>

<script>
import axios from 'axios'
import store from '@/store.js'
const lhost = require("@/config/global").host;
 
export default {
    data: () => ({  
        items: [],
        selected: [],  
        dialog: false,
        fab:false, 
        regraNome: [v => !!v || "Nome obrigatório."],
        regraURL: [v => !!v || "Introduza um URL da página da parceria."],
        regraPath: [v => !!v || "URL da imagem obrigatório."],
        form:{
            path:"", 
            url:"", 
            nome:"",
        }
    }),
    name: 'Parcerias',    
    props: ['id'], 
    methods:{
        registar: function(){
            this.dialog = true; 
        },
        atualiza: async function(){
            try {
                let response = await axios.get(lhost + "/api/CP/" + this.id,
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
        registarParceria: async function(){
            try{
                var resposta = 
                    await axios.post(lhost + "/api/Parcerias", 
                    {
                        canil_user_email: this.id,
                        nome: this.form.nome,
                        url: this.form.url,
                        pathLogo: this.form.path,
                    },
                    { headers: 
                        { "Authorization": 'Bearer ' + store.getters.token }
                    },
                    ); 
            console.log(JSON.stringify(resposta.data));
            this.atualiza();
            this.dialog = false;
          }
          catch(e){
            if(e.message == "Request failed with status code 401"){
                this.$store.commit("limpaStore");
                this.$router.push("/");
            }
          }
        }
    },
    created: async function(){
        try {
            let response = await axios.get(lhost + "/api/CP/" + this.id,
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
    
}
</script>