<template>
    <div>
        <v-toolbar flat color="white" height=150px>
            <v-img src="@/assets/logoA5.png" max-height=150px max-width=150px></v-img>
        </v-toolbar>
        <v-row class="ma-2">
            <v-col>
                <v-card flat>
                    <v-app-bar height=100px flat color="deep-orange lighten-4">
                        <v-toolbar-title class="card-heading">Adicionar Novo Documento</v-toolbar-title>
                    </v-app-bar>
                </v-card>
                <v-card flat height= "150" color = "white"></v-card>
                <v-container grid-list-md text-xl-left>
                    <v-layout row wrap>
                    <v-flex xs12>
                        <v-form ref="form" lazy-validation>
                            <v-card  flat>
                                <v-card-text>
                                    <v-row>
                                        <v-col cols="2">
                                            <div class="info-label headline">Título</div>
                                        </v-col>
                                        <v-col cols = "8">
                                        <v-text-field  
                                            outlined  
                                            flat  
                                            color = "grey lighten-1"  
                                            required 
                                            placeholder="Introduza o título do documento"
                                            v-model="form.titulo"
                                            name="titulo"
                                            type="titulo"
                                        ></v-text-field>
                                        </v-col>
                                    </v-row>
                                    
                                    <v-row>
                                        <v-col cols="2">
                                            <div class="info-label headline">
                                                Subtítulo <p class="caption">(opcional)</p>
                                            </div>
                                            
                                            </v-col>
                                            <v-col cols = "8">
                                                <v-text-field  
                                                    outlined 
                                                    flat 
                                                    color = "grey lighten-1" 
                                                    required 
                                                    placeholder="Introduza um subtítulo"
                                                    v-model="form.nota1"
                                                    name="nota1"
                                                    type="nota1"
                                                ></v-text-field>
                                            </v-col>
                                    </v-row>

                                    <v-row>
                                        <v-col cols="2">
                                            <div class="info-label headline">
                                                Informações Adicionais <p class = "caption">(opcional)</p>
                                            </div>
                                            
                                            </v-col>
                                            <v-col cols = "8">
                                                <v-text-field  
                                                    outlined 
                                                    flat 
                                                    color = "grey lighten-1" 
                                                    required 
                                                    placeholder="Introduza informações adicionais sobre o texto"
                                                    v-model="form.nota2"
                                                    name="nota2"
                                                    type="nota2"
                                                ></v-text-field>
                                            </v-col>
                                    </v-row>


                                    <v-row>
                                        <v-col cols="2">
                                            <div class="info-label headline">
                                                URL Imagem
                                            </div>
                                            
                                            </v-col>
                                            <v-col cols = "8">
                                                <v-text-field  
                                                    outlined 
                                                    flat 
                                                    color = "grey lighten-1" 
                                                    required 
                                                    placeholder="Introduza o URL da imagem"
                                                    v-model="form.url"
                                                    name="url"
                                                    type="url"
                                                ></v-text-field>
                                            </v-col>
                                    </v-row>

                                <v-row>
                                    <v-col cols = "2">
                                        <div class="info-label headline">
                                            Texto
                                        </div>
                                    </v-col>
                                    <v-col cols = "8">
                                        <vue-editor id="texto" :editorToolbar="customToolbar" v-model="form.texto"></vue-editor>
                                    </v-col>
                                </v-row>
                                    <v-card flat height= "20" color = "white"></v-card>
                                <v-row justify = "end">
                                    <v-col cols = "12" md = "5">
                                        <v-row >
                                            <v-btn class="ma-4" type="button" right bottom x-large color = "deep-orange lighten-4" @click="cancelar">Cancelar</v-btn>
                                            <v-btn class = "ma-4" type="button" right bottom x-large color = "deep-orange lighten-4" @click="adicionarDoc">Adicionar</v-btn>
                                        </v-row>
                                    </v-col>
                                </v-row>
                                </v-card-text>
                            </v-card>
                        </v-form>
                    </v-flex>
                </v-layout>
            </v-container>    
            <div class="text-center ma-2">
            <v-snackbar
            v-model="snackbar"
            :color="color"
            :timeout="timeout"
            bottom
            multi-line
            class = "headline"
            >
            {{ text }}
            <v-btn class = "headline" text @click="fecharSnackbar">Fechar</v-btn>
            </v-snackbar>
            </div>
            </v-col>
        </v-row>
    </div>
</template>

<script>
import axios from 'axios'
import store from '@/store.js'
const lhost = require("@/config/global").host;
import { VueEditor } from "vue2-editor";

export default {
    name: "addDocument",
    props:['id'],
    data: () => ({  
        form: {
            titulo: "",
            texto: "", 
            url:"",
            user_email:"admincaogest@caogest.pt",
            nota1:"", 
            nota2:"", 
        },  
        snackbar: false, 
        color: "", 
        done: false, 
        timeout: 0,
        text: "", 
        customToolbar: [
                        [
                            { 'header': 
                                [false, 1, 2, 3, 4, 5, 6, ] 
                            }
                        ],
                        [
                            { size: 
                                ['small', false, 'large', 'huge'] 
                            }
                        ],
                        ["bold", "italic", "underline","strike"], 
                        [{ color: [] }, { background: [] }], // dropdown with defaults from theme
                        [
                            { list: "ordered" },
                            { list: "bullet" },
                            { list: "check" }
                        ],
                        [
                           { align: "left" }, 
                           { align: "center" }, 
                           { align: "right"}, 
                           { align: "justify"}
                        ],
                        ["blockquote", "code-block"],
                        [{ indent: "-1" }, { indent: "+1" }], // outdent/indent
        ]
    }), 
    components:{
        VueEditor
    },
    methods: {
        adicionarDoc: async function(){
     
            if (this.$refs.form.validate()) {
                try{ 
                var resposta = 
                    await axios.post(lhost + "/api/Documentos/", 
                    {
                        titulo: this.form.titulo,
                        texto: this.form.texto, 
                        user_email:this.id,
                        pathImagem:this.form.url, 
                        nota1: this.form.nota1, 
                        nota2: this.form.nota2, 
                    },
                    {
                        headers: { "Authorization": 'Bearer ' + store.getters.token }
                    }); 
                    console.log(JSON.stringify(resposta.data));
                    this.text = "Documento adicionado com sucesso!";
                    this.color = "success"; 
                    this.snackbar = true; 
                }
            catch(e){
                if(e.message == "Request failed with status code 401"){
                    this.$store.commit("limpaStore");
                    this.$router.push("/");
                }
                this.text = "Ocorreu um erro na criação do documento, por favor tente mais tarde!";
                this.color = "warning"; 
                this.snackbar = true; 
            }
            } else {
                this.text = "Por favor preencha todos os campos!";
                this.color = "error";
                this.snackbar = true;
                this.done = false;
            }
        },
        fecharSnackbar() {
        this.snackbar = false;
        if(this.color == 'success')
            this.$router.push("/documentos/admin/" + this.id);
        },
        cancelar() {
        this.$router.push("/documentos/admin/" + this.id);
        },
    },
}
</script>

<style>

.card-heading {
  font-size: x-large;
  font-weight: bold;
}
.info-label {
  color: "grey lighten-1"; 
  padding: 2px;
  font-weight: 500;
  width: 100%;
  background-color: "transparent";
  font-weight: bold;
  margin: 20px;
  border-radius: 50x;
}

#texto{
    height: 500px;
    font-size: x-large;
}
</style>