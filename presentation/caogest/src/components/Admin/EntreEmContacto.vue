<template>
    <div>
        <v-container max-witdh="5000">
            <v-layout row class="mb-1"> 
                    <v-tooltip top>
                        <template v-slot:activator="{ on }">
                            <v-btn class = "ma-2" text @click="sortBy('data')" v-on="on">
                                <v-icon left small>schedule</v-icon>    
                                <span class = "caption text-lowercase">Por data</span>
                            </v-btn>  
                        </template>
                        <span>Ordenar mensagens por data</span> 
                    </v-tooltip>
            </v-layout>
            <v-tabs
                centered
                v-model="tab"
                background-color="brown lighten-5"
                color="brown darken-5"
                height="100"
                grow
            >
                <v-tab>
                Mensagens
                <v-badge
                    :content="this.numero"
                    :value="this.numero"
                    color="deep-orange darken-4"
                    overlap
                >
                    <v-icon right large>mdi-email</v-icon>
                </v-badge>
                </v-tab>
                <v-tab>
                Eliminadas
                    <v-icon right large>delete</v-icon>
                </v-tab>
                <v-tab>
                Enviadas
                <v-icon right large>send</v-icon>
                </v-tab>
            </v-tabs>
            <v-card max-witdh="5000" flat>
                <v-tabs-items v-model="tab">

                <v-tab-item>
                    <v-list two-line color="brown lighten-5">
                    <v-list-item-group
                        v-model="selected"
                        multiple
                        active-class="brown--text"
                    >
                        <v-list-item
                        color="dark lighten-4"
                        v-for="obj in recebidas"
                        :key="obj.identificacao"
                        @click="openDialog(obj)"
                        >
                        <v-list-item-content>
                            <v-list-item-title
                            class="display-1"
                            v-text="obj.nome"
                            ></v-list-item-title>
                            <v-list-item-subtitle
                            class=" headline text--primary"
                            v-text="obj.motivo"
                            ></v-list-item-subtitle>
                        </v-list-item-content>
                        <v-list-item-action>
                        <v-list-item-action-text> {{date(obj.data)}}
                        </v-list-item-action-text>
                        </v-list-item-action>
                        <v-list-item-icon>
                        <v-icon :color="obj.estado == 'Não Lida' ? 'brown lighten-1' : 'grey'">chat_bubble</v-icon>
                        </v-list-item-icon>
                        </v-list-item>
                    </v-list-item-group>
                    </v-list>
                </v-tab-item>

                <v-tab-item>
                    <v-list two-line color="brown lighten-5">
                    <v-list-item
                        color="dark lighten-4"
                        v-for="obj in apagadas"
                        :key="obj.identificacao"
                    >
                        <v-list-item-content>
                        <v-list-item-title
                            class="display-1"
                            v-text="obj.nome"
                        ></v-list-item-title>
                        <v-list-item-subtitle
                            class=" headline text--primary"
                            v-text="obj.motivo"
                        ></v-list-item-subtitle>
                        </v-list-item-content>

                        <v-list-item-action>
                        <v-list-item-action-text> {{date(obj.data)}}
                        </v-list-item-action-text>
                        <v-btn icon @click="recuperaMensagem(obj)">
                            <v-icon large color="grey">restore_from_trash</v-icon>
                        </v-btn>
                        </v-list-item-action>
                    </v-list-item>
                    </v-list>
                </v-tab-item>
                
                <v-tab-item>
                    <v-list two-line color="brown lighten-5">
                    <v-list-item
                        color="brown darken-4"
                        v-for="obj in enviadas"
                        :key="obj.identificacao"
                        @click="openEnviadas(obj)"
                    >
                        <v-list-item-content>
                        <v-list-item-title 
                            class="display-1" 
                            v-text="obj.nome"
                        ></v-list-item-title>

                        <v-list-item-subtitle
                            class=" headline text--primary"
                            v-text="obj.motivo"
                        ></v-list-item-subtitle>
                        </v-list-item-content>

                        <v-list-item-action>
                        <v-list-item-action-text> {{date(obj.data)}}
                        </v-list-item-action-text>
                        </v-list-item-action>
                    </v-list-item>
                    </v-list>
                </v-tab-item>
                </v-tabs-items>
            </v-card>
        </v-container>

        <v-dialog v-model="dialog" max-width="1500">
        <v-card>
            <v-card-title class="display-2 ma-2 pt-12">{{
            this.motivo
            }}</v-card-title>

            <v-card-subtitle 
            class = "display-1 ma-2 pb-12"> 
            {{ this.nome }} 
            <p 
                class = "headline"> 
                {{this.user_email}} 
            </p>
            </v-card-subtitle>

            <v-card-text class = "headline ma-2"> {{ this.sugestoes }} </v-card-text>

            <v-card-actions>

            <v-btn
                color="red"
                outlined
                x-large
                class = "ma-4 "
                @click="apagaMensagem(this)"
            >
                Apagar
            </v-btn>

            <v-btn
                color="red"
                outlined
                x-large
                class = "ma-4 "
                @click="marcaNaoLida(this)"
            >
                Marcar como Não Lida
            </v-btn>

            <v-spacer></v-spacer>
            
            <v-btn
                color="brown darken-4"
                outlined
                x-large
                class = "ma-4"
                @click="dialog = false"
            >
                Fechar
            </v-btn>

            <v-btn
                color="brown darken-4"
                dark
                x-large
                class = "ma-4"
                @click="openDialog1()"
            >
                Responder
            </v-btn>
            </v-card-actions>
        </v-card>
        </v-dialog>

        <v-dialog v-model="dialog1" max-width="1500">
        <v-card>
            <v-card flat color = "brown darken-4" dark>
            <v-card-title class="display-2 ma-2 pt-12">
            Enviar Resposta
            </v-card-title>
            </v-card>

            <v-text-field 
            readonly 
            class = "headline ma-12"
            color="brown darken-4"
            label="De"
            value="CãoGest"
            >
            </v-text-field>

            <v-text-field 
            label="Para"
            class = "headline ma-12"
            color="brown darken-4"
            readonly
            :value = "this.user_email"
            > 
            </v-text-field>
        
            <v-card flat class = "ma-8">
            <v-card-text
                class = "display-1"
                color="brown darken-4"
            > {{ this.sugestoes }}
            </v-card-text>
            </v-card>

            <v-textarea
            label="Mensagem"
            color="brown darken-4"
            class = "headline ma-12"
            rows="4"
            auto-grow
            v-model="form.sugestoes"
            >
            </v-textarea>

            <v-card-actions>
            <v-spacer></v-spacer>
            
            <v-btn
                color="brown darken-4"
                outlined
                x-large
                class = "ma-4"
                @click="dialog1 = false"
            >
                Cancelar
            </v-btn>

            <v-btn
                color="brown darken-4"
                dark
                x-large
                class = "ma-4"
                @click="enviaMensagem(this)"
            >
                Enviar
            </v-btn>
            </v-card-actions>
        </v-card>
        </v-dialog>

        <v-dialog v-model="dialog2" max-width="1500">
        <v-card>
            <v-card-title class="display-2 ma-2 pt-12">{{
            this.motivo
            }}</v-card-title>

            <v-card-subtitle 
            class = "display-1 ma-2 pb-12"> 
            {{ this.nome }} 
            <p 
                class = "headline"> 
                {{this.user_email}} 
            </p>
            </v-card-subtitle>

            <v-card-text class = "headline ma-2"> {{ this.sugestoes }} </v-card-text>

            <v-card-actions>
            <v-spacer></v-spacer>
            
            <v-btn
                color="brown darken-4"
                outlined
                x-large
                class = "ma-4"
                @click="dialog2 = false"
            >
                Fechar
            </v-btn>
            </v-card-actions>
        </v-card>
        </v-dialog>

        <v-dialog v-model="dialog3" max-width="1500">
        <v-card>
            <v-card-title class="display-2 ma-2 pt-12">{{
            this.motivo
            }}</v-card-title>

            <v-card-subtitle 
            class = "display-1 ma-2 pb-12"> 
            {{ this.nome }} 
            <p 
                class = "headline"> 
                {{this.user_email}} 
            </p>
            </v-card-subtitle>

            <v-card-text class = "headline ma-2 font-weight-bold"> Resposta </v-card-text>
            <v-card-text class = "headline ma-2"> {{ this.sugestoes }} </v-card-text>

            <v-card-actions>
            <v-spacer></v-spacer>
            
            <v-btn
                color="brown darken-4"
                outlined
                x-large
                class = "ma-4"
                @click="dialog3 = false"
            >
                Fechar
            </v-btn>
            </v-card-actions>
        </v-card>
        </v-dialog>
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
const lhost = require("@/config/global").host;
import moment from 'moment/moment';
import store from '@/store.js'

export default {
    props: ['sugestao', 'id'],
  data() {
    return {
      fab:false,
      selected: [],
      dialog: false,
      dialog1: false,
      dialog2:false, 
      dialog3:false, 
      sugestoesl: [],
      tab: null,
      deleted: 0,
      motivo: "",
      sugestoes: "",
      nome: "",
      estado: "",
      data: "",
      user_email: "",
      identificacao:"", 
      estadoU:"", 
      form:{
        sugestoes: "",
        data: moment().format(),
      }
    };
  },
  methods: {
    openDialog: function(dados){
      this.motivo = dados.motivo;
      this.sugestoes = dados.sugestoes;
      this.nome = dados.nome;
      this.estado = dados.estado;
      this.estadoU = dados.estadoU;
      this.data = dados.data;
      this.user_email = dados.user_email;
      this.identificacao = dados.identificacao;
      this.dialog = true;
      if(this.estado === 'Não Lida'){
        this.marcaLida();
        this.getMensagem();
      }
    },
    openDialog1: function(){
      this.dialog = false;
      this.dialog1 = true;
    },
    openEnviadas: function(dados){
      this.motivo = dados.motivo;
      this.sugestoes = dados.sugestoes;
      this.nome = dados.nome;
      this.estado = dados.estado;
      this.estadoU = dados.estadoU;
      this.data = dados.data;
      this.user_email = dados.user_email;
      this.identificacao = dados.identificacao;
      this.dialog3 = true;
    },
    date: function (date) {
      return moment(date).locale("pt").fromNow();
    },
    sortBy(prop){
          this.sugestoesl.sort((a,b) => a[prop] < b[prop] ? 1 : -1)
    },
    onScroll (e) {
      if (typeof window === 'undefined') return
      const top = window.pageYOffset ||   e.target.scrollTop || 0
      this.fab = top > 20
    },
    toTop () {
      this.$vuetify.goTo(0)
    },
    marcaLida: async function(){
      try{ 
        var resposta = 
        await axios.put(lhost + "/api/Sugestoes/" + this.identificacao , 
        {
          identificacao:this.identificacao, 
          motivo:this.motivo,
          sugestoes:this.sugestoes,
          nome:this.nome,
          estado:"Lida",
          data:this.data,
          estadoU:this.estadoU, 
          user_email: this.user_email,
        },
        {
          headers: { "Authorization": 'Bearer ' + store.getters.token }
        });
        console.log(JSON.stringify(resposta.data));
        this.numero--;
        this.getMensagem();
      }
      catch(e){
          if(e.message == "Request failed with status code 401"){
         this.$store.commit("limpaStore");
         this.$router.push("/");
      }
      }
    },
    marcaNaoLida: async function(){
      try{ 
        var resposta = 
        await axios.put(lhost + "/api/Sugestoes/" + this.identificacao , 
        {
          identificacao:this.identificacao, 
          motivo:this.motivo,
          sugestoes:this.sugestoes,
          nome:this.nome,
          estado:"Não Lida",
          data:this.data,
          user_email: this.user_email,
          estadoU:this.estadoU,
        },
        {
          headers: { "Authorization": 'Bearer ' + store.getters.token }
        });
        console.log(JSON.stringify(resposta.data));
        this.numero++;
        this.getMensagem();
        this.dialog=false;
      }
      catch(e){
          if(e.message == "Request failed with status code 401"){
         this.$store.commit("limpaStore");
         this.$router.push("/");
      }
      }
    },
    apagaMensagem: async function(){
       try{ 
        if(this.estado === 'Não Lida') this.numero--;
        var resposta = 
        await axios.put(lhost + "/api/Sugestoes/" + this.identificacao , 
        {
          identificacao:this.identificacao, 
          motivo:this.motivo,
          sugestoes:this.sugestoes,
          nome:this.nome,
          estado:"Apagada",
          data:this.data,
          user_email: this.user_email,
          estadoU:this.estadoU,
        },
        {
          headers: { "Authorization": 'Bearer ' + store.getters.token }
        });
        console.log(JSON.stringify(resposta.data));
        this.dialog = false;
        this.getMensagem();
        this.dialog3 = false;
      }
      catch(e){
          if(e.message == "Request failed with status code 401"){
            this.$store.commit("limpaStore");
            this.$router.push("/");
          }
      }
    },
    recuperaMensagem: async function(dados){
        this.motivo = dados.motivo;
        this.sugestoes = dados.sugestoes;
        this.nome = dados.nome;
        this.estado = dados.estado;
        this.data = dados.data;
        this.user_email = dados.user_email;
        this.identificacao = dados.identificacao;
        this.estadoU = dados.estadoU;
       try{ 
        var resposta = 
        await axios.put(lhost + "/api/Sugestoes/" + this.identificacao , 
        {
          identificacao:this.identificacao, 
          motivo:this.motivo,
          sugestoes:this.sugestoes,
          nome:this.nome,
          estado:"Lida",
          data:this.data,
          user_email: this.user_email,
          estadoU:this.estadoU,
        },
        {
          headers: { "Authorization": 'Bearer ' + store.getters.token }
        });
        console.log(JSON.stringify(resposta.data));
        this.getMensagem();
      }
      catch(e){
          if(e.message == "Request failed with status code 401"){
            this.$store.commit("limpaStore");
            this.$router.push("/");
          }
      }
    },
    enviaMensagem: async function(){
      try{
        var resposta = 
          await axios.post(lhost + "/api/Sugestoes", 
          {
            user_email: this.user_email,
            nome: this.nome,
            motivo: this.motivo,
            sugestoes: this.form.sugestoes,
            data: this.form.data,
            estado: "Enviada",
            estadoU:"Não Lida",
          },
          {
            headers: { "Authorization": 'Bearer ' + store.getters.token }
          });
        console.log(JSON.stringify(resposta.data));
        this.dialog1 = false;
        this.getMensagem();
      }
      catch(e){
          if(e.message == "Request failed with status code 401"){
            this.$store.commit("limpaStore");
            this.$router.push("/");
          }
      }
    },
    async getMensagem(){
      try {
        let response = await axios.get(lhost + "/api/Sugestoes",
            { headers: 
              { "Authorization": 'Bearer ' + store.getters.token }
            });
        this.sugestoesl = response.data;
        this.ready = true;
      } 
      catch (e) {
          if(e.message == "Request failed with status code 401"){
            this.$store.commit("limpaStore");
            this.$router.push("/");
          }
      }
    },   
  },
  computed: {
    recebidas: function () {
      return this.sugestoesl.filter(function (sugestao) {
          return (sugestao.estado === "Não Lida" | sugestao.estado === "Lida")
      })
    }, 
    apagadas: function () {
      return this.sugestoesl.filter(function (sugestao) {
          return (sugestao.estado === "Apagada")
      })
    }, 
    enviadas: function () {
      return this.sugestoesl.filter(function (sugestao) {
          return (sugestao.estado === "Enviada")
      })
    }, 
    numero:{
      get(){
        return this.sugestoesl.filter(function(sugestao){
          return (sugestao.estado === "Não Lida")
        }).length;
      },
      set(value)
      {
        this.value = value
      }
    }, 
  },
  created: async function(){
        try {
            let response = await axios.get(lhost + "/api/Sugestoes",
            { headers: 
              { "Authorization": 'Bearer ' + store.getters.token }
            });
            this.sugestoesl = response.data;
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