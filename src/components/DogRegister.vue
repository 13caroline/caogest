<template>
    <div>
        <v-toolbar flat color="white" height=150px>
            <v-img src="@/assets/logoA5.png" max-height=150px max-width=150px></v-img>
        </v-toolbar>
        <v-card width="2000" class = "mx-auto" flat color = "brown lighten-5">
        <v-stepper 
            v-model="e1"
            :vertical="vertical"
            :alt-labels="altLabels"
        >
            <v-stepper-header>
                <v-stepper-step :complete="e1 > 1" color = "brown darken-2" class = "headline" step="1">Registar dados</v-stepper-step>
                <v-divider></v-divider>
                <v-stepper-step :complete="e1 > 2" color = "brown darken-2" class = "headline" step="2">Inserir Fotografia</v-stepper-step>
            </v-stepper-header>

            <v-stepper-items>
                <v-stepper-content step="1">
                       <v-row>
                            <v-col>
                            <v-card flat color="brown lighten-5">
                                <!-- Content -->
                                <v-container grid-list-md text-xl-left color="brown lighten-5">
                                    <v-layout row wrap>
                                    <v-flex xs12>
                                        <v-form ref="form" lazy-validation>
                                            <v-card  flat color = "brown lighten-5">
                                                <v-card-text>
                                                    <v-row>
                                                        <v-col cols="2">
                                                            <div class="info-label display-1">
                                                                Nome
                                                            </div>
                                                            
                                                            </v-col>
                                                            <v-col>
                                                                <v-text-field 
                                                                    rounded 
                                                                    outlined 
                                                                    placeholder="Introduza o nome"
                                                                    flat 
                                                                    color = "grey lighten-1" 
                                                                    required 
                                                                    v-model="form.nome"
                                                                    :rules="regraNome"
                                                                    name="nome"
                                                                    type="nome"
                                                                ></v-text-field>
                                                        </v-col>
                                                    </v-row>
                                                    <v-card flat height= "10" color = "brown lighten-5"></v-card>
                                                    <v-row>
                                                        <v-col cols="2">
                                                            <div class="info-label display-1">
                                                                Raça
                                                            </div>
                                                        </v-col>
                                                        <v-col>
                                                            <v-text-field 
                                                                    rounded 
                                                                    outlined 
                                                                    placeholder="Introduza a raça"
                                                                    flat 
                                                                    color = "grey lighten-1" 
                                                                    required 
                                                                    v-model="form.raca"
                                                                    :rules="regraRaça"
                                                                    name="raca"
                                                                    type="raca"
                                                                ></v-text-field>
                                                        </v-col>
                                                    </v-row>
                                                    <v-card flat height= "10" color = "brown lighten-5"></v-card>
                                                    <v-row>
                                                        <v-col cols="2">
                                                            <div class="info-label display-1">Idade</div>
                                                        </v-col>
                                                        <v-col>
                                                            <v-text-field 
                                                                rounded 
                                                                outlined  
                                                                placeholder="Introduza a idade"
                                                                flat  
                                                                color = "grey lighten-1"  
                                                                required 
                                                                v-model="form.idade"
                                                                :rules="regraIdade"
                                                                name="idade"
                                                                type="number"
                                                                suffix="anos"
                                                        ></v-text-field>
                                                        </v-col>
                                                    </v-row>
                                                    <v-card flat height= "10" color = "brown lighten-5"></v-card>
                                                    <v-row>
                                                        <v-col cols="2">
                                                            <div class="info-label display-1">Cor</div>
                                                        </v-col>
                                
                                                        <v-col>
                                                            <v-select 
                                                                color = "grey"
                                                                flat outlined 
                                                                placeholder="Selecione a cor"
                                                                :items="itemscor"
                                                                multiple
                                                                rounded
                                                                v-model="form.cor"
                                                                :rules="regraCor"
                                                                name="cor"
                                                                type="cor"
                                                            ></v-select>
                                                        </v-col>
                                                    </v-row>
                                                    <v-card flat height= "10" color = "brown lighten-5"></v-card>
                                                    <v-row>
                                                        <v-col cols="2">
                                                            <div class="info-label display-1">Porte</div>
                                                        </v-col>
                                
                                                        <v-col>
                                                            <v-select 
                                                                color = "grey"
                                                                flat outlined 
                                                                placeholder="Selecione o porte"
                                                                :items="itemsporte"
                                                                rounded
                                                                v-model="form.porte"
                                                                :rules="regraPorte"
                                                                name="porte"
                                                                type="porte"
                                                            ></v-select>
                                                        </v-col>
                                                    </v-row>
                                                    <v-card flat height= "10" color = "brown lighten-5"></v-card>
                                                    <v-row>
                                                        <v-col cols="2">
                                                            <div class="info-label display-1">Sexo</div>
                                                        </v-col>
                                                        <v-col>
                                                            <v-radio-group v-model="form.sexo" :rules="regraSexo" name="sexo" type="sexo" row>
                                                                <v-radio label="Macho" value="Macho"></v-radio>
                                                                <v-radio label="Fêmea" value="Fêmea"></v-radio>
                                                            </v-radio-group>
                                                        </v-col>
                                                    </v-row>
                                                    <v-card flat height= "10" color = "brown lighten-5"></v-card>
                                                    <v-row>
                                                        <v-col cols="2">
                                                            <div class="info-label display-1">Esterilizado</div>
                                                        </v-col>
                                                        <v-col>
                                                            <v-radio-group v-model="form.esterilizacao" :rules="regraEsterilizacao" name="esterilizacao" type="esterilizacao" row>
                                                                <v-radio label="Sim" value="Sim"></v-radio>
                                                                <v-radio label="Não" value="Não"></v-radio>
                                                            </v-radio-group>
                                                        </v-col>
                                                    </v-row>    
                                                    <v-card flat height= "10" color = "brown lighten-5"></v-card>
                                                    <v-row>
                                                        <v-col cols="2">
                                                            <div class="info-label display-1"> Notas </div>
                                                        </v-col>
                                                        <v-col>
                                                            <v-textarea
                                                                v-model="form.descricao"
                                                                name="descricao"
                                                                type="descricao"
                                                                flat
                                                                outlined
                                                                rounded
                                                                auto-grow
                                                                :rules="rules"
                                                                placeholder = "Introduza informações que considere relevantes"
                                                                color = "grey lighten-1" 
                                                                rows = "5"
                                                                counter
                                                            ></v-textarea>
                                                        </v-col>
                                                    </v-row>
                                                    
                                                <v-row justify = "end">
                                                    <v-col cols = "12" md = "8">
                                                        <v-row justify= "end">
                                                            <v-btn class="ma-6 red--text" x-large color = "red" outlined  @click ="cancelar()" >Cancelar</v-btn>
                                                            <v-btn class = "ma-6" :disabled="isDisable" x-large color = "deep-orange lighten-4" @click ="nextStep(1)"> Continuar </v-btn>
                                                        </v-row>
                                                    </v-col>
                                                </v-row>
                                            </v-card-text>
                                        </v-card>
                                        </v-form>
                                    </v-flex>
                                    </v-layout>
                                </v-container>
                            </v-card>
                        </v-col>
                  </v-row>
                </v-stepper-content>
        
                <v-stepper-content step="2">
                    <v-row>
                        <v-col>
                            <v-card flat color = "brown lighten-4">
                                <v-card-text>
                                    <input type="file" id="file" ref="file" v-on:change="handleFileUpload()"/>
                                    <v-card flat height="20" color = "brown lighten-4"></v-card>
                                    <v-row justify="center" align="center">
                                    <v-card id="preview" flat color = "brown lighten-4">
                                        <img v-if="url" :src="url" />
                                    </v-card>
                                    </v-row>
                                    <v-row justify = "end">
                                        <v-col cols = "12" md = "8">
                                            <v-row justify= "end">
                                                <v-btn class="ma-6 red--text" x-large color = "red" outlined @click ="cancelar()" >Cancelar</v-btn>
                                                <v-btn class="ma-6" x-large color = "brown lighten-5" @click="submitFile()"> Registar </v-btn>
                                            </v-row>
                                        </v-col>
                                    </v-row>
                                </v-card-text>
                            </v-card>
                        </v-col>
                     </v-row>
                </v-stepper-content>
            </v-stepper-items>
        </v-stepper>
        </v-card>
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
    </div>
</template>

<script>
import store from '@/store.js'
import axios from 'axios'
const lhost = require("@/config/global").host;

export default {
    name: "signupdog",
    props:['id'],
    data: () => ({  
        itemsporte: [ 
            'Pequeno',
            'Médio',
            'Grande',
        ], 
        itemscor: [
            'Amarelo',
            'Azul',
            'Branco',
            'Castanho',
            'Cinzento',
            'Creme',
            'Dourado',
            'Fulvo',
            'Malhado',
            'Preto',
            'Vermelho',
        ],
        regraNome: [v => !!v || "Nome obrigatório."],
        regraRaça:[v => !!v || "Raça obrigatória."], 
        regraIdade: [v => !!v || "Idade obrigatória."],
        regraSexo: [v => !!v || "Género obrigatório."],
        regraEsterilizacao: [v => !!v || "Esterilização obrigatória."],
        regraCor: [v => !!v || "Cor obrigatória."],
        regraPorte: [v => !!v || "Porte obrigatório."],
        regraFicheiro: [v => !!v || "Selecione um ficheiro."],
        rules: [v => v.length <= 100 || 'Máx 100 caracteres'],
        form: {
            nome: "",
            raca: "", 
            idade: "", 
            sexo: "", 
            esterilizacao: "", 
            cor: "", 
            porte: "", 
            descricao:"",
            estado: "Por Adotar",
            canil_user_email:"", 
        },  
        snackbar: false, 
        color: "", 
        done: false, 
        timeout: 0,
        text: "", 
        file:'',
        e1: 1,
        steps: 2,
        altLabels: false,
        editable: false,
        vertical: false, 
        url:null,
    }), 
    watch: {
    steps (val) {
      if (this.e1 > val) {
        this.e1 = val
      }
    },
    vertical () {
      this.e1 = 2
      requestAnimationFrame(() => this.e1 = 1) // Workarounds
    },
  },
    methods: {
        onInput (val) {
            this.steps = parseInt(val)
        },
        nextStep (n) {
            if (n === this.steps) {
                this.e1 = 1
            } else {
                this.e1 = n + 1
            }
            this.registarCao();
        },
      registarCao: async function(){
     
        if (this.$refs.form.validate()) {
            try{ 
                    await axios.post(lhost + "/api/Caes/", 
                    {
                        nome: this.form.nome,
                        sexo: this.form.sexo, 
                        descricao: this.form.descricao,
                        estado: "Por Adotar",
                        raca: this.form.raca, 
                        cor: this.form.cor, 
                        idade: this.form.idade, 
                        esterilizacao: this.form.esterilizacao, 
                        porte: this.form.porte, 
                        canil_user_email: this.id,
                    },
                    { headers: 
                        { "Authorization": 'Bearer ' + store.getters.token }
                    }); 
            }
            catch(e){
                console.log(e);
            }         
        }   
    },
    submitFile (){
            let formData = new FormData();

            formData.append('file', this.file);
            formData.append('name', this.file.name);

            try {
                let resposta = axios.post(lhost + '/api/Teste',
                    formData,
                    {
                        headers: {
                            'Content-Type': 'multipart/form-data'
                    }
                });
                console.log(JSON.stringify(resposta.data));

                let res = axios.post(lhost + '/api/Fotografias',
                    {   
                    path: this.file.name,
                    },
                    {
                        headers: {
                            "Authorization": 'Bearer ' + store.getters.token
                    }
                });
                console.log(JSON.stringify(res.data));
                this.text = "Cão registado com sucesso!";
                this.color = "success"; 
                this.snackbar = true; 
            }
            catch(e){
               if(e.message == "Request failed with status code 401"){
                this.$store.commit("limpaStore");
                this.$router.push("/");
            }
                this.text = "Ocorreu um erro no registo, por favor tente mais tarde!";
                this.color = "warning"; 
                this.snackbar = true; 
            }
      },
    fecharSnackbar() {
      this.snackbar = false;
      if(this.color == 'success')
        this.$router.push("/pagina/canil/" + this.id);
    },
    cancelar() {
      this.$router.push("/pagina/canil/" + this.id);
    },
    handleFileUpload(){
        this.file = this.$refs.file.files[0];
        this.url = URL.createObjectURL(this.file);
    }

    }, 
    computed:{
        isDisable() {
            return this.form.nome.length === 0 || 
                   this.form.raca.length === 0 ||  
                   this.form.idade.length === 0 ||  
                   this.form.sexo.length === 0 || 
                   this.form.esterilizacao.length === 0 || 
                   this.form.cor.length === 0 || 
                   this.form.porte.length === 0;
        }
    }
 
}
</script>

<style scoped>

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
</style>