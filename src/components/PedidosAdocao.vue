<template>
    <div>
         <v-card flat height = "100"></v-card>
        <v-card flat height = "100" color = "brown lighten-5">
            <v-row>
                <v-card-text class = "display-2 black--text text-center">
                    {{pedido.nome_Utilizador}} 
                    <v-icon>pets</v-icon> 
                    {{pedido.cao_idCao}}
                </v-card-text>
            </v-row>
        </v-card>
        <v-card flat height = "100"></v-card>
        <v-container fluid>
            <v-row class = "align-center justify-center">
                <v-col cols = "4">
                    <v-card flat class = "mx-auto" height = "800" width = "900"> 
                         <v-img height = "800" width = "800" :src="require(`@/assets/${getPath(pedido)}`)"></v-img> 
                    </v-card>
                </v-col>

                <v-col cols = "5"> 
                    <v-card color = "brown lighten-5" height = "800" width = "1000" tile>
                        <v-card flat color = "brown lighten-5" height = "40"></v-card>
                        <v-row class="ml-8">
                            <p class = " headline font-weight-bold" color = "grey"> Nome Cão: 
                                <span class = "headline font-weight-regular ">{{pedido.cao_idCao}}</span>
                            </p> 
                        </v-row>
                        <v-card flat color = "brown lighten-5" height = "5"></v-card>
                        <v-row class="ml-8">
                            <p class = " headline font-weight-bold" color = "grey"> Nome Completo: 
                                <span class = "headline font-weight-regular ">{{pedido.nome_Utilizador}}</span>
                            </p> 
                        </v-row>
                        <v-card flat color = "brown lighten-5" height = "5"></v-card>
                        <v-row class="ml-8">
                            <p class = " headline font-weight-bold" color = "grey"> Número do Cartão de Cidadão: 
                                <span class = "headline font-weight-regular ">{{pedido.cc}}</span>
                            </p> 
                        </v-row>
                        <v-card flat color = "brown lighten-5" height = "5"></v-card>
                        <v-row class="ml-8">
                            <p class = " headline font-weight-bold" color = "grey"> Tipo de Moradia: 
                                <span class = "headline font-weight-regular ">{{pedido.tipoMoradia}}</span>
                            </p> 
                        </v-row>
                        <v-card flat color = "brown lighten-5" height = "5"></v-card>
                        <v-row class="ml-8">
                            <p class = " headline font-weight-bold" color = "grey"> Espaço exterior ou equivalente: 
                                <span class = "headline font-weight-regular ">{{pedido.exterior}}</span>
                            </p> 
                        </v-row>
                        <v-card flat color = "brown lighten-5" height = "5"></v-card>
                        <v-row class="ml-8">
                            <p class = " headline font-weight-bold" color = "grey"> A sua habitação é: 
                                <span class = "headline font-weight-regular ">{{pedido.habitacao}}</span>
                            </p> 
                        </v-row>
                        <v-card flat color = "brown lighten-5" height = "5"></v-card>
                        <v-row class="ml-8">
                            <p class = " headline font-weight-bold" color = "grey"> Em caso de alugada ou condomínio, tem permissão para ter animais: 
                                <span class = "headline font-weight-regular ">{{pedido.permissao}}</span>
                            </p> 
                        </v-row>
                        <v-card flat color = "brown lighten-5" height = "5"></v-card>
                        <v-row class="ml-8">
                            <p class = " headline font-weight-bold" color = "grey"> Pretende um cão para: 
                                <span class = "headline font-weight-regular ">{{pedido.motivo}}</span>
                            </p> 
                        </v-row>
                        <v-card flat color = "brown lighten-5" height = "5"></v-card>
                        <v-row class="ml-8">
                            <p class = " headline font-weight-bold" color = "grey"> Em caso de ausência para férias, trabalho ou outra, o seu cão:
                                <span class = "headline font-weight-regular ">{{pedido.ausencia}}</span>
                            </p> 
                        </v-row>
                        <v-card flat color = "brown lighten-5" height = "5"></v-card>
                        <v-row class="ml-8">
                            <p class = "headline font-weight-bold" color = "grey"> Tem alguém alérgico a cães na família: 
                                <span class = "headline font-weight-regular ">{{pedido.alergia}}</span>
                            </p> 
                        </v-row>
                        <v-card flat color = "brown lighten-5" height = "5"></v-card>
                        <v-row class="ml-8">
                            <p class = " headline font-weight-bold" color = "grey"> É dono de mais algum animal: 
                                <span class = "headline font-weight-regular ">{{pedido.donoAnimal}}</span>
                            </p> 
                        </v-row>
                        <v-card flat color = "brown lighten-5" height = "5"></v-card>
                        <v-row class="ml-8">
                            <p class = " headline font-weight-bold" color = "grey"> Se sim, quais: 
                                <span class = "headline font-weight-regular ">{{pedido.descAnimais}}</span>
                            </p> 
                        </v-row>
                        <v-card flat color = "brown lighten-5" height = "5"></v-card>
                        <v-row class="ml-8">
                            <p class = " headline font-weight-bold" color = "grey"> Comprovativo de Morada: 
                                <span class = "headline font-weight-regular ">{{pedido.comprovativo}}</span>
                            </p> 
                        </v-row>
                    </v-card>
                </v-col>
            </v-row>
        </v-container>
    </div>
</template>

<script>

import axios from 'axios'
import store from '@/store.js'
const lhost = require("@/config/global").host;

export default {
    data: () => ({
        pedido: {},
    }),
    name: 'PedidoAdocao',
    props: ['id', 'id2'], 
    created: async function(){
        try {
            let response = await axios.get(lhost + "/api/Adocoes/" + this.id2,
            { headers: 
              { "Authorization": 'Bearer ' + store.getters.token }
            });
            this.pedido = response.data;
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
        getPath: function(e) {
           return e.fotos[0].path;
        },
    } 
}
</script>     