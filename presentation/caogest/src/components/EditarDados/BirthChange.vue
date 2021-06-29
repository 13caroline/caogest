<template>
  <div>
        <v-dialog v-model="dialog" persistent width="800px">
            <template v-slot:activator="{ on }">
                
                        <v-btn class="pa-12 ma-2" text fab v-on="on">
                          <v-icon x-large color = "grey"> keyboard_arrow_right</v-icon>
                        </v-btn>
                    
            </template>
            <v-form ref="form" lazy-validation>
            <v-card>
                <v-card flat color = "deep-orange lighten-4" class = "pa-6">
                    <span class="display-1" dark>Alterar Data de Nascimento</span>
                </v-card>
                <v-card-text>
                    <v-container>
                      <v-row>
                            <v-col cols="12" sm="6" md="4">
                               <v-menu
                                        ref="menu2"
                                        v-model="menu2"
                                        :close-on-content-click="false"
                                        transition="scale-transition"
                                        offset-y
                                        max-width="290px"
                                        min-width="290px"
                                    >
                                        <template v-slot:activator="{ on }">
                                        <v-text-field
                                            outlined 
                                            rounded
                                            placeholder="YYYY/MM/DD"
                                            flat
                                            color = "grey lighten-1" 
                                            v-model="form.data_de_nascimento"
                                            readonly=""
                                            v-on="on"
                                        ></v-text-field>
                                        </template>
                                        <v-date-picker v-model="date" no-title @input="menu2 = false" :max="dateCurrent"></v-date-picker>
                                    </v-menu>
                            </v-col>
                      </v-row>
                    </v-container>
                </v-card-text>
                <v-card-actions>
                    <v-spacer></v-spacer>
                    <v-btn class="ma-6 red--text" large color = "red" outlined  @click="cancelar()">Cancelar</v-btn>
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
const lhost = require("@/config/global").host;
import store from '@/store.js'

  export default {
    name:"BirthChange",
    props:['id'],
    data: ur => ({
        date: new Date().toISOString().substr(0, 10),
        dateCurrent: new Date().toISOString().substr(0, 10),
        dateFormatted: ur.formatDate(new Date().toISOString().substr(0, 10)),
        menu2: false,
        form: {
            data_de_nascimento:"", 
        }, 
        snackbar: false, 
        color: "", 
        done: false, 
        timeout: 0,
        text: "", 
        dialog:false,
    }),
    methods:{
      confirma: async function(){
        if (this.$refs.form.validate()) {
          try{ 
            var resposta = 
            await axios.put(lhost + "/api/Utilizadors/" + this.id , 
            {
              email:this.utilizador.email, 
              nome:this.utilizador.nome,
              data_de_nascimento:this.form.data_de_nascimento,
              distrito:this.utilizador.distrito,
              rua: this.utilizador.rua,
              localidade:this.localidade,
              cc:this.utilizador.cc,
              sexo:this.utilizador.sexo,
              contacto: this.utilizador.contacto,
              encriptado: this.utilizador.encriptado,
              nif: this.utilizador.nif,
            },
            {
              headers: { "Authorization": 'Bearer ' + store.getters.token }
            });
            console.log(JSON.stringify(resposta.data));
            this.dialog = false; 
            this.text = "Data de Nascimento alterada com sucesso!";
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
        this.dialog=false;
      },
      cancelar() {
        this.dialog=false;
      },
      formatDate(date) {
        if (!date) return null;
        const [year, month, day] = date.split("-");
        return `${year}-${month}-${day}`;
      },
    },
    computed: {
      computedDateFormatted() {
        return this.formatDate(this.date);
      }
    },
    watch: {
      date() {
        this.form.data_de_nascimento = this.formatDate(this.date);
      }
    },

    created: async function(){
      try {
        let response = await axios.get(lhost + "/api/Utilizadors/" + this.id,
            { headers: 
              { "Authorization": 'Bearer ' + store.getters.token }
            });
        this.utilizador = response.data;
        this.form.data_de_nascimento = this.dateFormatted;
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