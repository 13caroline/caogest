<template>
    <div>
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
                    <v-card flat color = "white" class = "mx-auto" height = "800" width = "900"> 
                         <v-img height = "800" width = "800" :src="require(`@/assets/${getPath()}`)"></v-img> 
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
                            <p class = " headline font-weight-bold" color = "grey"> Tem alguém alérgico a cães na família: 
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
                        <v-row class="ml-8" v-if="validacao">
                            <p class = " headline font-weight-bold" color = "grey"> Comprovativo de Morada: 
                                <v-btn color = "red darken-4" dark class = "headline" @click="valida()">Validar</v-btn>
                            </p> 
                        </v-row>
                         <v-row class="ml-8" v-else>
                            <p class = " headline font-weight-bold" color = "grey"> Comprovativo de Morada: 
                                <span class = "headline font-weight-regular ">{{pedido.comprovativo}}</span>
                            </p> 
                        </v-row>

                    </v-card>
                </v-col>
            </v-row>
        </v-container>
         <v-card flat class = "mx-auto" width="1900">
            <v-row justify = "end" >
                <v-btn v-if="pedido.estado === 'Pendente'" class="ma-4 red--text" x-large color = "red" outlined @click="rejeitarRegisto()">
                    Recusar Pedido
                </v-btn>
                <v-btn v-else class="ma-4 red--text" color = "red" outlined  x-large disabled>
                    Recusar Pedido
                </v-btn>
                <v-btn v-if="pedido.estado === 'Pendente'" type="button" class="ma-4 mr-12" x-large color = "deep-orange lighten-4" @click="aceitarRegisto()">
                    Aceitar Pedido
                </v-btn>
                <v-btn v-else class="ma-4 mr-12" x-large disabled>
                    Aceitar Pedido
                </v-btn>
            </v-row>
        </v-card>
        <v-row justify="center">
                <v-dialog v-model="dialog" persistent max-height = "1000px" max-width="2000px">
                    <v-card>
                    <v-card height = "80" flat color = "brown darken-1" dark>
                        <v-card-title>
                            <span class="display-1">Comprovativo de Morada</span>
                        </v-card-title>
                    </v-card>

                    <v-card flat>
                        <v-card color = "white" flat class = "mx-auto" > 
                            <v-img class = "ma-12" :src="`${publicPath}images/${getComprovativo()}`"></v-img>
                            <v-row justify = "end">
                                <v-btn type="button" class="ma-4" large color = "red lighten-2" @click="invalidado()">Não válido</v-btn>
                                <v-btn type="button" class="ma-4 mr-12" large color = "light-green lighten-2" @click="validado()">Válido</v-btn>
                            </v-row>
                        </v-card>
                    </v-card>
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
        comprovativo: {},
        pedido: {},
        dialog: false, 
        publicPath: process.env.BASE_URL
    }),
    name: 'EstadoPedidos',
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
    methods: {
        getComprovativo: function(){
            return this.comprovativo.path
        },
        getPath: function() {
           return this.pedido.fotos[0].path
        },
        aceitarRegisto: async function(){
           try{ 
                let vm = this;
                var resposta = 
                await axios.put(lhost + "/api/Adocoes/" + this.id2 , 
                {
                    nPedido: vm.pedido.nPedido, 
                    data: vm.pedido.data, 
                    estado: "Aceite", 
                    cao_idCao: vm.pedido.cao_idCao, 
                    identificacao: vm.pedido.identificacao,
                    permissao: vm.pedido.permissao, 
                    alergia: vm.pedido.alergia, 
                    descAnimais: vm.pedido.descAnimais, 
                    ausencia: vm.pedido.ausencia,
                    habitacao: vm.pedido.habitacao, 
                    exterior: vm.pedido.exterior, 
                    tipoMoradia: vm.pedido.tipoMoradia, 
                    motivo: vm.pedido.motivo, 
                    comprovativo: vm.pedido.comprovativo, 
                    donoAnimal: vm.pedido.donoAnimal,
                },
                { headers: 
                    { "Authorization": 'Bearer ' + store.getters.token }
                });

                var res = 
                await axios.put(lhost + "/api/Caes/Adocao/" + vm.pedido.identificacao,
                {
                    estado: "Reservado"
                }, 
                { headers: 
                    { "Authorization": 'Bearer ' + store.getters.token }
                });

                this.$router.push("/pedidos/adocao/canil/" + this.id); 
                console.log(JSON.stringify(resposta.data));
                console.log(JSON.stringify(res.data));
           }
           catch(e){
            if(e.message == "Request failed with status code 401"){
                this.$store.commit("limpaStore");
                this.$router.push("/");
            }
          }
        },
        rejeitarRegisto: async function(){
           try{ 
                let vm = this;
                var resposta = 
                await axios.put(lhost + "/api/Adocoes/" + this.id2 , 
                {
                    nPedido: vm.pedido.nPedido, 
                    data: vm.pedido.data, 
                    estado: "Recusado", 
                    cao_idCao: vm.pedido.cao_idCao, 
                    identificacao: vm.pedido.identificacao,
                    permissao: vm.pedido.permissao, 
                    alergia: vm.pedido.alergia, 
                    descAnimais: vm.pedido.descAnimais, 
                    ausencia: vm.pedido.ausencia,
                    habitacao: vm.pedido.habitacao, 
                    exterior: vm.pedido.exterior, 
                    tipoMoradia: vm.pedido.tipoMoradia, 
                    motivo: vm.pedido.motivo, 
                    comprovativo: vm.pedido.comprovativo, 
                    donoAnimal: vm.pedido.donoAnimal,
                },
                { headers: 
                    { "Authorization": 'Bearer ' + store.getters.token }
                });
                this.$router.push("/pedidos/adocao/canil/" + this.id); 
                console.log(JSON.stringify(resposta.data));
           }
           catch(e){
           if(e.message == "Request failed with status code 401"){
                this.$store.commit("limpaStore");
                this.$router.push("/");
            }
          }
        },
        validado: async function(){
            try{ 
                let vm = this;
                await axios.put(lhost + "/api/Adocoes/" + this.id2 , 
                {
                    nPedido: vm.pedido.nPedido, 
                    data: vm.pedido.data, 
                    estado: vm.pedido.estado,  
                    cao_idCao: vm.pedido.cao_idCao, 
                    identificacao: vm.pedido.identificacao,
                    permissao: vm.pedido.permissao, 
                    alergia: vm.pedido.alergia, 
                    descAnimais: vm.pedido.descAnimais, 
                    ausencia: vm.pedido.ausencia,
                    habitacao: vm.pedido.habitacao, 
                    exterior: vm.pedido.exterior, 
                    tipoMoradia: vm.pedido.tipoMoradia, 
                    motivo: vm.pedido.motivo, 
                    comprovativo: "Sim", 
                    donoAnimal: vm.pedido.donoAnimal,
                },
                { headers: 
                    { "Authorization": 'Bearer ' + store.getters.token }
                });
           }
           catch(e){
            if(e.message == "Request failed with status code 401"){
                this.$store.commit("limpaStore");
                this.$router.push("/");
            }
          }
          this.atualiza();
          this.dialog = false; 
        },
        invalidado: async function(){
            try{ 
                let vm = this;
                await axios.put(lhost + "/api/Adocoes/" + this.id2 , 
                {
                    nPedido: vm.pedido.nPedido, 
                    data: vm.pedido.data, 
                    estado: vm.pedido.estado,  
                    cao_idCao: vm.pedido.cao_idCao, 
                    identificacao: vm.pedido.identificacao,
                    permissao: vm.pedido.permissao, 
                    alergia: vm.pedido.alergia, 
                    descAnimais: vm.pedido.descAnimais, 
                    ausencia: vm.pedido.ausencia,
                    habitacao: vm.pedido.habitacao, 
                    exterior: vm.pedido.exterior, 
                    tipoMoradia: vm.pedido.tipoMoradia, 
                    motivo: vm.pedido.motivo, 
                    comprovativo: "Não", 
                    donoAnimal: vm.pedido.donoAnimal,
                },
                { headers: 
                    { "Authorization": 'Bearer ' + store.getters.token }
                });
           }
           catch(e){
            if(e.message == "Request failed with status code 401"){
                this.$store.commit("limpaStore");
                this.$router.push("/");
            }
          }
          this.atualiza();
          this.dialog = false; 
        },
        atualiza: async function(){
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
        valida: async function(){
            try {
                let response = await axios.get(lhost + "/api/Comprovativos/" + this.id2,
                { headers: 
                    { "Authorization": 'Bearer ' + store.getters.token }
                });
                this.comprovativo = response.data;
                this.ready = true;
            } 
            catch (e) {
                if(e.message == "Request failed with status code 401"){
                    this.$store.commit("limpaStore");
                    this.$router.push("/");
                }
            }
            this.dialog = true; 
        }
    }, 
    computed:{
        validacao: function () {
            return (this.pedido.comprovativo === "Por Validar") ? true : false; 
        }, 
    }
}
</script>     