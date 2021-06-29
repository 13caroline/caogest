<template>
  <div>
  <v-dialog 
    v-model="dialog" 
    persistent 
    width="800px"
  >
    <template v-slot:activator="{ on }">
      <v-btn 
        class="pa-12 ma-2" 
        text 
        fab
        v-on="on"
      >
        <v-icon 
          x-large 
          color = "grey"
        > keyboard_arrow_right
        </v-icon>
      </v-btn>
                    
    </template>
    <v-form ref="form" lazy-validation>
    <v-card>
      <v-card flat color = "deep-orange lighten-4" class = "pa-6">
        <span class="display-1" dark>Alterar Distrito</span>
      </v-card>
      <v-card-text>
        <v-container>
          <v-col>
            <v-text-field 
              color = "grey" 
              placeholder="Novo Distrito" 
              required
              class = "ma-12"
              v-model="form.distrito"
              :rules="regradistrito"
            ></v-text-field>
          </v-col>
        </v-container>
      </v-card-text>
      <v-card-actions>
        <v-spacer></v-spacer>
        <v-btn class="ma-6 red--text" large color = "red" outlined @click="dialog = false">Cancelar</v-btn>
        <v-btn class="ma-6" large color = "deep-orange lighten-4" @click="confirma()">Confirmar</v-btn>
      </v-card-actions>
    </v-card>
    </v-form>
    </v-dialog>
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
</template>
  
<script>
import axios from 'axios'
import store from '@/store.js'
const lhost = require("@/config/global").host;

  export default {
    name:"distritoChange",
    props:['id'],
    data: () => ({
      canil:{},
      dialog: false,
      form:{
        distrito: "", 
      },
      snackbar: false, 
      color: "", 
      done: false, 
      timeout: 4000,
      text: "", 
      regradistrito: [v => !!v || "Introdução de distrito obrigatória."],
    }),
    methods:{
      confirma: async function(){
        if (this.$refs.form.validate()) {
          try{ 
            var resposta = 
            await axios.put(lhost + "/api/Canis/" + this.id , 
            {
              email:this.canil.email, 
              nib:this.canil.nib,
              nome:this.canil.nome,
              capacidadeOcupada:this.canil.capacidadeOcupada,
              capacidadeTotal:this.canil.capacidadeTotal,
              distrito:this.form.distrito,
              rua: this.canil.rua,
              localidade:this.canil.localidade,
              contacto: this.canil.contacto,
              estado: this.canil.estado, 
              encriptado: this.canil.encriptado,
            },
            { headers: 
              { "Authorization": 'Bearer ' + store.getters.token }
            });
            console.log(JSON.stringify(resposta.data));
            this.dialog = false; 
            this.text = "Distrito alterado com sucesso!";
            this.color = "success"; 
            this.snackbar = true; 
          }
          catch(e){
            if(e.message == "Request failed with status code 401"){
                this.$store.commit("limpaStore");
                this.$router.push("/");
            }
            this.text = "Ocorreu um erro, por favor tente mais tarde!";
            this.color = "warning"; 
            this.snackbar = true; 
          }
        } 
      },
      fecharSnackbar() {
        this.snackbar = false;
      },
    },
    created: async function(){
      try {
        let response = await axios.get(lhost + "/api/Canis/" + this.id,
            { headers: 
              { "Authorization": 'Bearer ' + store.getters.token }
            });
        this.canil = response.data;
        this.ready = true;
      } 
      catch (e) {
        if(e.message == "Request failed with status code 401"){
                this.$store.commit("limpaStore");
                this.$router.push("/");
            }
      }
    }
  }
</script>     