<template>
    <div id = "donationskennel" class = "donationsKennel">
            <v-card> 
                <v-img src='@/assets/donationskennel.png'>
                    <v-row align = "end" justify = "end">
                        <v-btn text class = "white--text overline font-weight-thin text--secondary" href="https://besthqwallpapers.com/de/download/original/67832">hiperligação para a imagem original</v-btn>
                    </v-row> 
                    <v-card flat height= "400" max-width="800" color = "transparent"></v-card>
                    <v-row class="fill-height"
                        align="center"
                        justify="center">
                        <v-col>
                            <v-row
                                class="fill-height"
                                align="center"
                                justify="center"
                            >
                                <div class="display-4 font-weight-bold white--text">Donativos</div>
                            </v-row>
                            <v-card flat height= "70" color = "transparent"></v-card>
                            <v-row class="fill-height"
                                align="center"
                                justify="center">
                                <div class="display-2 font-weight-bold white--text">Os donativos representam a principal e quase única fonte de receita dos canis para a </div>
                                <div class = "display-2 font-weight-bold white--text">prossecução das suas finalidades e dos programas e atividades que, diariamente,</div>
                                <div class = "display-2 font-weight-bold white--text"> desenvolve em prol do bem estar dos cães. </div>
                            </v-row>
                        </v-col>
                    </v-row>
                </v-img>
            </v-card>
            <v-card flat height= "150" color = "white"></v-card>
            
            <v-row justify = "center">
                <v-col cols = "9">
                <v-btn class="ma-3" x-large color = "brown lighten-4" @click="registarDonativos()">Registar Donativo</v-btn>
                </v-col>
            </v-row>

            <p class="my-5 display-2 font-weight-bold text-center">Donativos Monetários Realizados</p>
            <v-card flat height="40" color="white"></v-card>

                <v-container class="my-5">
                    <v-layout row class="mb-3"> 
                        <v-tooltip top>
                            <template v-slot:activator="{ on }">
                                <v-btn class = "ma-2" text @click="sortBy('valor')" v-on="on">
                                    <v-icon left small>euro</v-icon>    
                                    <span class = "caption text-lowercase">Por quantia</span>
                                </v-btn>  
                            </template>
                            <span>Ordenar pedidos por quantia doada</span> 
                        </v-tooltip>

                        <v-tooltip top>    
                            <template v-slot:activator="{ on }">
                                <v-btn class = "ma-2" text @click="sortBy('data')" v-on="on">
                                    <v-icon left small>today</v-icon>    
                                    <span class = "caption text-lowercase">Por data</span>
                                </v-btn> 
                            </template>
                            <span>Ordenar pedidos por data de submissão</span>
                        </v-tooltip>    
                    </v-layout>

                <v-card flat height = "100"></v-card>
                 <v-card class = " mx-auto" height = "80" width="2000" flat color = "brown lighten-5" v-if="this.donativos.length === 0"> 
                    <v-card-title class = "display-1 text-center justify-center"> Não foram realizados donativos monetários </v-card-title>
                </v-card>
                <v-card flat v-else v-for="donativo in donativos" :key="donativo.nome">
                    <v-layout row wrap class="pa-7 donativo">
                    <v-flex xs12 md4>
                        <div class="caption grey--text">Nome Donatário</div>
                        <div class="headline" >{{ donativo.utilizador_user_email }}</div>
                    </v-flex>
                    <v-flex xs6 sm4 md4>
                        <div class="caption grey--text">Valor do Donativo</div>
                        <div class="headline">{{ donativo.valor }}</div>
                    </v-flex>
                    <v-flex xs6 sm4 md4>
                        <div class="caption grey--text">Data do Donativo</div>
                        <div class="headline">{{date(donativo.data) }}</div>
                    </v-flex>
                    </v-layout>
                    <v-divider></v-divider>
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
            </v-container>
            <v-row justify="center">
                <v-dialog v-model="dialog" persistent max-height = "1000px" max-width="2000px">
                    <v-card height = "80" flat color = "brown darken-1" dark>
                        <v-card-title>
                            <span class="display-1">Registar Donativo</span>
                        </v-card-title>
                    </v-card>
                    <v-card flat height = "20"></v-card>
                    <v-card flat>    
                        <v-card-text>
                            <v-container>
                                <v-form ref="form" lazy-validation>
                                <v-card flat height = "10"></v-card>
                                <v-row>
                                <v-col cols="12" sm="6" md="4">
                                    <v-text-field 
                                        outlined
                                        label="Número de Contribuinte *" 
                                        class="headline" 
                                        color = "brown darken-1" 
                                        :rules ="regraContribuinte"
                                        v-model="form.nif"
                                        required
                                    ></v-text-field>
                                </v-col>
                                <v-col cols="12" sm="6" md="4">
                                    <v-text-field 
                                        readonly 
                                        outlined
                                        class = "headline"
                                        color="brown darken-4"
                                        label="Meio de Pagamento"
                                        value="Transferência Bancária"
                                        >
                                        </v-text-field>
                                </v-col>
                                <v-col cols="12">
                                    <v-text-field 
                                        outlined
                                        label="Nome *" 
                                        color = "brown darken-1" 
                                        required
                                        :rules ="regraNome"
                                    ></v-text-field>
                                </v-col>
                                <v-col cols="12">
                                    <v-text-field 
                                        outlined
                                        label="Donatário" 
                                        color = "brown darken-1" 
                                        required
                                        readonly
                                        :value="this.id"
                                    ></v-text-field>
                                </v-col>
                                <v-col cols="12" sm = "6" md="6">
                                    <v-text-field 
                                        outlined 
                                        label="Data" 
                                        :value="date2()"
                                        color = "brown darken-1" 
                                        required
                                        readonly
                                    ></v-text-field>
                                </v-col>
                                <v-col cols="12" sm="6" md="6">
                                    <v-text-field 
                                        suffix = "€" 
                                        label="Valor *" 
                                        color = "brown darken-1" 
                                        required
                                        outlined
                                        type="number"
                                        :rules ="regraValor"
                                        v-model="form.valor"
                                    ></v-text-field>
                                </v-col>
                                <v-col cols="12">
                                    <v-textarea
                                        outlined
                                        label="Descrição"
                                        color="brown darken-4"
                                        class = "headline "
                                        rows="4"
                                        auto-grow
                                        v-model="form.descricao"
                                    ></v-textarea>
                                </v-col>
                                </v-row>
                                </v-form>
                            </v-container>
                        <small>* campos obrigatórios</small>
                        </v-card-text>
                        <v-card-actions>
                            <v-spacer></v-spacer>
                            <v-btn color="red" class = "headline ma-2 red--text" outlined x-large @click="dialog = false">Cancelar</v-btn>
                            <v-btn color="brown lighten-4" class = "headline ma-2" x-large @click="emite">Emitir Recibo</v-btn>
                        </v-card-actions>
                    </v-card>
                </v-dialog>
            </v-row>
    </div>
</template>

<script>
const lhost = require("@/config/global").host;
import axios from "axios";
import store from '@/store.js'
import moment from 'moment/moment';

export default {
    name:"Donations", 
    props:['id'],
    data() {
        return {
            fab:false,
            dialog: false, 
            donativos: [], 
            regraNome: [v => !!v || "Nome obrigatório."],
            regraValor: [v => !!v || "Introduza um valor de donativo"],
            regraContribuinte: [v => !!v || "Contribuinte obrigatório."],
            
            form:{
                valor:"", 
                descricao:"", 
                nif:"", 
               
            }, 
            idDonativo: "",
        };
    },
    methods: {
        sortBy(prop){
            this.donativos.sort((a,b) => a[prop] < b[prop] ? 1 : -1)
        },
        onScroll (e) {
                if (typeof window === 'undefined') return
                const top = window.pageYOffset ||   e.target.scrollTop || 0
                this.fab = top > 20
            },
        toTop () {
            this.$vuetify.goTo(0)
        },
        date: function (date) {
            return moment(date).locale("pt").format('LL');
        },
        date2: function (date) {
            return moment(date).locale("pt").format('L');
        },
        registarDonativos: function(){
            this.dialog = true; 
        }, 
        emite: async function(){
            if (this.$refs.form.validate()) {
                try{ 
                    await axios.post(lhost + "/api/Donativos/", 
                    {
                        nif: this.form.nif,
                        valor: this.form.valor, 
                        descricao: this.form.descricao,
                        canil_user_email: this.id,
                    },
                    { headers: 
                        { "Authorization": 'Bearer ' + store.getters.token }
                    }); 
                    this.dialog = false;
                }
                catch(e){
                    console.log(e);
                }       
                
                try{
                    let response = await axios.post(lhost + "/api/Donativos/Id", 
                        {
                            nif: this.form.nif, 
                            valor: this.form.valor, 
                            descricao: this.form.descricao, 
                            canil_user_email: this.id, 
                            data: moment().format(),
                        },
                        { headers: 
                            { "Authorization": 'Bearer ' + store.getters.token }
                        }); 
                        this.idDonativo = response.data;
                        this.$router.push("/emissao/recibo/" + this.id + '/' + this.idDonativo); 
                } catch(e){   
                    console.log(e);
                }
            }
        }, 
        atualiza: async function(){
            try {
                let response = await axios.get(lhost + "/api/Donativos/" + this.id,
                { headers: 
                    { "Authorization": 'Bearer ' + store.getters.token }
                });
                this.donativos = response.data;
                this.ready = true;
            } 
            catch (e) {
                if(e.message == "Request failed with status code 401"){
                    this.$store.commit("limpaStore");
                    this.$router.push("/");
                }
            }
        }
    }, 
    created: async function(){
        try {
            let response = await axios.get(lhost + "/api/Donativos/" + this.id,
            { headers: 
              { "Authorization": 'Bearer ' + store.getters.token }
            });
            this.donativos = response.data;
            this.ready = true;
        } 
        catch (e) {
            if(e.message == "Request failed with status code 401"){
                this.$store.commit("limpaStore");
                this.$router.push("/");
            }
        }
    },        
};
</script>

<style>

</style>
