<template>
    <div>
        <v-card flat width="2000" class="mx-auto" color = "white">
            <v-row class = "ml-12">
                <v-col cols = "2">
                    <v-img max-height = "200" max-width = "200" src="@/assets/direitos.png"></v-img>
                </v-col>
                <v-col>
                    <p class = "display-1 font-weight-medium">Direitos dos Animais</p>
                    <p class = "headline"> Artigo 1º </p>
                    <span class = "headline"> 1. Todos os animais nascem iguais perante a vida e têm os mesmos direitos à existência... </span>
                </v-col>
                <v-col>     
                    <v-btn absolute right bottom x-large color ="brown darken-2" dark class = "ma-2 headline" @click="direitosAnimais()">Ler</v-btn>
                </v-col>
            </v-row>
            <v-divider inset ></v-divider>
        </v-card>

        <v-card flat height = "40"></v-card>
        <v-card flat width="2000" class="mx-auto" color = "white">
            <v-row class = "ml-12">
                <v-col cols = "2">
                    <v-img max-height = "180" max-width = "180" src="@/assets/spay.png"></v-img>
                </v-col>
                <v-col>
                    <p class = "display-1 font-weight-medium">Porquê Esterilizar?</p>
                    <p class="headline">Porquê Esterilizar?</p>
                    <span class = "headline"> A reprodução indesejada de animais na Região Autónoma da Madeira é um incómodo problema que carece de solução... </span>
                </v-col>
                <v-col>     
                    <v-btn absolute right bottom x-large color ="brown darken-2" dark class = "ma-2 headline" @click="esterilizar()">Ler</v-btn>
                </v-col>
            </v-row>
            <v-divider inset></v-divider>
        </v-card>
        
        <v-card flat height = "40"></v-card>
        <v-card flat width="2000" class="mx-auto" color = "white">
            <v-row class = "ml-12">
                <v-col cols = "2">
                    <v-img max-height = "190" max-width = "190" src="@/assets/adoptme.png"></v-img>
                </v-col>
                <v-col >
                    <p class = "display-1 font-weight-medium">Motivos para Adotar Animais Errantes</p>
                     <p class="headline">Excesso de população animal </p> 
                    <span class = "headline"> Anualmente milhares de animais de companhia entram em canis e abrigos em todo o país... </span>
                </v-col>
                <v-col>     
                    <v-btn absolute right bottom x-large color ="brown darken-2" dark class = "ma-2 headline" @click="motivosparaadotar()">Ler</v-btn>
                </v-col>
            </v-row>
            <v-divider inset></v-divider>
        </v-card>

        <v-card flat height = "40"></v-card>
        <v-card flat width="2000" class="mx-auto" color = "white">
            <v-row class = "ml-12">
                <v-col cols = "2">
                    <v-img max-height = "200" max-width = "200" src="@/assets/treino.png"></v-img>
                </v-col>
                <v-col >
                    <p class = "display-1 font-weight-medium">Conselhos para a adoção e treino de hábitos</p>
                     <p class="headline">Treino de hábitos </p> 
                    <span class = "headline"> A nossa principal tendência é exagerar nos cuidados dados ao cão, de forma que ele vive mais no nosso colo do que no chão... </span>
                </v-col>
                <v-col>     
                    <v-btn absolute right bottom x-large color ="brown darken-2" dark class = "ma-2 headline" @click="treino()">Ler</v-btn>
                </v-col>
            </v-row>
            <v-divider inset></v-divider>
        </v-card>

        <v-card flat height = "40"></v-card>
        <v-card flat width="2000" class="mx-auto" color = "white">
            <v-row class = "ml-12">
                <v-col cols = "2">
                    <v-img max-height = "200" max-width = "200" src="@/assets/doente.png"></v-img>
                </v-col>
                <v-col >
                    <p class = "display-1 font-weight-medium">Doenças e Tratamentos</p>
                     <p class="headline">Anemia </p> 
                    <span class = "headline"> Consiste numa diminuição do seu número de glóbulos vermelhos ou do seu constituinte, a hemoglobina... </span>
                </v-col>
                <v-col>     
                    <v-btn absolute right bottom x-large color ="brown darken-2" dark class = "ma-2 headline" @click="doencas()">Ler</v-btn>
                </v-col>
            </v-row>
            <v-divider inset></v-divider>
        </v-card>

        <v-card 
            flat 
            width="2000" 
            class="mx-auto" 
            color = "white" 
            v-for="obj in documentos"
            :key="obj.identificacao"
        >
        <v-card flat height = "40"></v-card>
            <v-row class = "ml-12">
                <v-col cols = "2">
                    <v-img height = "200" width = "200" :src="obj.pathImagem"></v-img>
                </v-col>
                <v-col >
                    <p class = "display-1 font-weight-medium">{{obj.titulo}}</p>
                     <p class="headline">{{obj.nota1}} </p> 
                    <span class = "headline"> {{obj.nota2}}... </span>
                </v-col>
                <v-col>     
                    <v-btn absolute right bottom x-large color ="brown darken-2" dark class = "ma-2 headline" @click="readDoc(obj)">Ler</v-btn>
                </v-col>
            </v-row>
            <v-divider inset></v-divider>

        </v-card>
    </div>
</template>

<script>
import axios from 'axios'
import store from '@/store.js'
const lhost = require("@/config/global").host;

export default {
    name: "textos", 
    props:['id'],

    data: () => ({   
        documentos:[],
        titulo: "", 
        texto: "", 
    }),

    methods:{
        direitosAnimais(){
            this.$router.push("/documentos/direitosanimais/" + this.id);
        },
        esterilizar(){
            this.$router.push("/documentos/esterilizar/" + this.id);
        },
        motivosparaadotar(){
            this.$router.push("/documentos/motivos/adotar/" + this.id);
        },
        treino(){
            this.$router.push("/documentos/treino/" + this.id);
        },
        doencas(){
            this.$router.push("/documentos/doencas/" + this.id);
        },
        readDoc: function(dados){
            this.identificacao = dados.identificacao;
            this.titulo = dados.titulo; 
            this.texto = dados.texto; 
            this.$router.push("/documentos/utilizador/" + this.id + '/' + this.identificacao);
        }, 
    },
    created: async function(){
            try {
                let response = await axios.get(lhost + "/api/Documentos",
                { headers: 
                { "Authorization": 'Bearer ' + store.getters.token }
                });
                this.documentos = response.data;
                this.ready = true;
            } 
            catch (e) {
                return e;
            }   
        },
}
</script>