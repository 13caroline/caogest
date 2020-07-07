<template>
    <div>
        <v-btn class = "ma-4 headline" x-large color="brown lighten-4" @click="adicionaDoc()">Adicionar Documento</v-btn> 
        <v-card flat height = "50"></v-card>
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
                        <v-btn x-large color = "grey" text fab right absolute class = "ma-2 headline"> 
                            <v-icon>delete</v-icon>
                        </v-btn>
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
                    <v-btn x-large color = "grey" text fab right absolute class = "ma-2 headline"> 
                        <v-icon>delete</v-icon>
                    </v-btn>
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
                    <v-btn x-large color = "grey" text fab right absolute class = "ma-2 headline"> 
                        <v-icon>delete</v-icon>
                    </v-btn>
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
                    <v-btn x-large color = "grey" text fab right absolute class = "ma-2 headline"> 
                        <v-icon>delete</v-icon>
                    </v-btn>
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
                    <v-btn x-large color = "grey" text fab right absolute class = "ma-2 headline"> 
                        <v-icon>delete</v-icon>
                    </v-btn>
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
                    <v-btn x-large color = "grey" text fab right absolute class = "ma-2 headline" @click="deleteDoc(obj)"> 
                        <v-icon>delete</v-icon>
                    </v-btn>
                </v-col>
            </v-row>
            <v-divider inset></v-divider>

        </v-card>


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
        fab:false,   
        documentos:[],
        titulo: "", 
        texto: "", 
    }),

    methods:{
        direitosAnimais(){
            this.$router.push("/documentos/admin/direitosanimais/" + this.id);
        },
        esterilizar(){
            this.$router.push("/documentos/admin/esterilizar/" + this.id);
        },
        motivosparaadotar(){ 
            this.$router.push("/documentos/admin/motivos/adotar/" + this.id);
        },
        treino(){
            this.$router.push("/documentos/admin/treino/" + this.id);
        },
        doencas(){
            this.$router.push("/documentos/admin/doencas/" + this.id);
        },
        adicionaDoc(){
            this.$router.push("/documentos/admin/adiciona/" + this.id);
        },
        onScroll (e) {
            if (typeof window === 'undefined') return
                const top = window.pageYOffset ||   e.target.scrollTop || 0
                this.fab = top > 20
        },
        toTop () {
            this.$vuetify.goTo(0)
        },
        readDoc: function(dados){
            this.identificacao = dados.identificacao;
            this.titulo = dados.titulo; 
            this.texto = dados.texto; 
            this.$router.push("/documentos/admin/" + this.id + '/' + this.identificacao);
        }, 
        deleteDoc: async function(dados){
            this.identificacao = dados.identificacao; 
            try{
                await axios.delete(lhost + "/api/Documentos/" + this.identificacao,
                { headers: 
                    { "Authorization": 'Bearer ' + store.getters.token }
                });
                this.atualiza();
            }
            catch(e){
                return e;
            }
        },  
        atualiza: async function(){
            try {
                let response = await axios.get(lhost + "/api/Documentos/",
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