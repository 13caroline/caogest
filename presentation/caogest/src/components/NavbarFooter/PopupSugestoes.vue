<template>
    <div>
    <v-row justify="center">
        <v-dialog v-model="dialog" persistent width="800px">
            <template v-slot:activator="{ on }">
                <v-row align = "end" justify= "end">
                    <v-col>
                        <v-btn class="ma-5" text v-on="on">Caixa de Sugestões e Comentários</v-btn>
                    </v-col>
                </v-row>
            </template>
            <v-card>
                <v-card-title>
                    <span class="display-1">Caixa de Sugestões e Comentários</span>
                </v-card-title>
                <v-card-text>
                    <v-form 
                        ref="form"
                        lazy-validation
                    >   
                        <v-container>
                                <v-col>
                                    <v-text-field 
                                        color = "grey" 
                                        flat  
                                        name="nome" 
                                        outlined 
                                        label="Nome *" 
                                        required 
                                        v-model="form.nome"
                                        :rules="regraNome"
                                        type="nome"
                                    ></v-text-field>
                                </v-col>
                                <v-spacer></v-spacer>
                                <v-col>
                                    <v-text-field 
                                        flat 
                                        color = "grey" 
                                        name="email" 
                                        outlined 
                                        label="Email *" 
                                        required
                                        v-model="form.user_email"
                                        :rules="regraEmail"
                                        type="email"
                                    ></v-text-field>
                                </v-col>
                                <v-spacer></v-spacer>
                                <v-col>
                                    <v-select        
                                        color = "grey"
                                        name="motivo"
                                        flat outlined 
                                        v-model="form.motivo"
                                        :items="items"
                                        label="Motivo do inquérito *"
                                        required
                                        :rules="regraMotivo"
                                        type="motivo"
                                    ></v-select>
                                </v-col>
                                <v-spacer></v-spacer>
                                <v-col>
                                    <v-textarea
                                        name="input-7-1"
                                        flat
                                        outlined
                                        auto-grow
                                        placeholder = "Mensagem *"
                                        color = "grey lighten-1" 
                                        rows = "5"
                                        v-model="form.sugestoes"
                                        :rules="regraMensagem"
                                        type="mensagem"
                                    ></v-textarea>
                                </v-col>
                        </v-container>
                        <small>*campos obrigatórios</small>
                        <v-card flat class="mx-auto" height = "30" color = "white"></v-card>
                        <small> Ao preencher este formulário, confirma que tem 16 anos ou mais.</small> 
                    </v-form>
                </v-card-text>
                <v-card-actions>
                    <v-spacer></v-spacer>
                    <v-btn class="ma-6" large color = "deep-orange lighten-4" @click="dialog = false">Cancelar</v-btn>
                    <v-btn class="ma-6" large type="button" color = "deep-orange lighten-4" @click="enviarSugestao">Submeter</v-btn>
                </v-card-actions>
            </v-card>
        </v-dialog>
    </v-row>
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
import moment from 'moment/moment';

  export default {
    data: () => ({
      select: null,
      dialog: false,
      items: [ 
        'Quero fazer um donativo',
        'Quero voluntariar-me para um canil',
        'Quero atualizar os meus dados pessoais',
        'Cuidados com o cão que adotei',
        'Quero registar um cão', 
        'Quero editar os dados de um cão', 
        'Quero editar um horário',
        'Outro',
      ],
      regraNome: [v => !!v || "Nome obrigatório."],
      regraEmail:[value => {
            const pattern = /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/
            return pattern.test(value) || 'Email inválido'
          },
      ], 
      regraMotivo: [v => !!v || "Motivo obrigatório."],
      regraMensagem: [v => !!v || "Mensagem obrigatória."],

      form: {
            nome: "",
            user_email: "", 
            motivo: "", 
            sugestoes: "", 
            data: moment().format(), 
            estado: "Não Lida", 
            estadoU: "Enviada",
        }, 
        snackbar: false, 
        color: "", 
        done: false, 
        timeout: 4000,
        text: "", 
    }),
    methods: {
        onScroll (e) {
            if (typeof window === 'undefined') return
            const top = window.pageYOffset ||   e.target.scrollTop || 0
            this.fab = top > 20
        },
        toTop () {
            this.$vuetify.goTo(0)
        },

        enviarSugestao: async function(){
     
            if (this.$refs.form.validate()) {
                try{ 
                var resposta = 
                    await axios.post(lhost + "/api/Sugestoes", 
                    {
                        user_email: this.form.user_email,
                        nome: this.form.nome,
                        motivo: this.form.motivo,
                        sugestoes: this.form.sugestoes,
                        data: this.form.data,
                        estado: this.form.estado, 
                        estadoU: this.form.estadoU
                    },
                    { headers: 
                        { "Authorization": 'Bearer ' + store.getters.token }
                    });
                    
                    console.log(JSON.stringify(resposta.data));
                    this.text = "Sugestão ou comentário enviada com sucesso";
                    this.color = "success"; 
                    this.dialog = false;
                    this.snackbar = true; 
                }
                catch(e){
                    if(e.message == "Request failed with status code 401"){
                        this.$store.commit("limpaStore");
                        this.$router.push("/");
                    }
                    this.text = "Ocorreu um erro, por favor tente mais tarde";
                    this.color = "warning"; 
                    this.dialog = false;
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
        },
    }, 
}
</script>