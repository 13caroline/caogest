<template>
    <div id = "canilRegister">
        <v-toolbar flat color="white" height=150px>
        <v-img src="@/assets/logoA5.png" max-height=150px max-width=150px></v-img>
        </v-toolbar>

        <!-- Header -->
        <v-card flat>
            <v-app-bar height=100px flat color="deep-orange lighten-4">
            <v-toolbar-title class="card-heading">Formulário de Adoção</v-toolbar-title>
            </v-app-bar>
        </v-card>
        <v-card flat height= "150" color = "white"></v-card>
        <v-card class = "mx-auto" max-width = "1500" flat>
            <p class="text-center display-1 font-weight-black">Por favor, leia com atenção os termos de responsabilidade antes de prosseguir com o pedido adoção. Após submetido, o pedido será avaliado pelo canil onde se encontra acolhido o cão. O estado do pedido poderá ser visualizado nos seus pedidos de adoção. </p>
        </v-card>
        <v-card flat height= "100" color = "white"></v-card>

        <div> 
            <v-form ref="form" lazy-validation>
            <v-card color = "grey lighten-2" class = "mx-auto" max-width = "1500" fluid outlined rounded>
                <v-row>
                    <v-col>
                        <v-card flat height= "30" color = "grey lighten-2"></v-card>  
                        <span class = " pa-8 headline font-weight-regular" color = "grey"> Nome Completo * </span> 
                    </v-col>
                </v-row>
                <v-row>
                    <v-col cols = "6">
                        <v-text-field
                            ref="name"
                            :rules="regraNome"
                            name="nome"
                            type="nome"
                            required
                            color = "deep-orange darken-4"
                            class = "pa-8"
                            placeholder="Introduza o seu nome"
                        ></v-text-field>
                    </v-col>
                </v-row>
            </v-card>
                
            <v-card flat height= "80" color = "white"></v-card>   

            <v-card class = "mx-auto" max-width = "1500" color = "grey lighten-2" fluid outlined rounded>
                <v-row>
                    <v-col>
                        <v-card flat height= "30" color = "grey lighten-2"></v-card>  
                        <span class = " pa-8 headline font-weight-regular" color = "grey"> Nome do Cão * </span> 
                    </v-col>
                </v-row>
                <v-row>
                    <v-col cols = "6">
                        <v-text-field
                            ref="name"
                            :rules="regraNomeCao"
                            name="nomeCao"
                            type="nomeCao"
                            required
                            color = "deep-orange darken-4"
                            class = "pa-8"
                            placeholder="Introduza o nome do cão que pretende adotar"
                        ></v-text-field>
                    </v-col>
                </v-row>
            </v-card>    

            <v-card flat height= "80" color = "white"></v-card>   

            <v-card class = "mx-auto" max-width = "1500" color = "grey lighten-2" fluid outlined rounded>
                <v-row>
                    <v-col>
                        <v-card flat height= "30" color = "grey lighten-2"></v-card>  
                        <span class = " pa-8 headline font-weight-regular" color = "grey"> Tipo de Moradia * </span> 
                    </v-col>
                </v-row>
                <v-row>
                    <v-container fluid>
                         <v-radio-group column v-model="form.tipoMoradia" :rules="regraTipoMoradia" :mandatory="false" class = "ma-12" >
                            <v-radio color = "deep-orange darken-4" label="Apartamento" value="Apartamento"></v-radio>
                            <v-radio color = "deep-orange darken-4" label="Vivenda" value="Vivenda"></v-radio>
                            <v-radio color = "deep-orange darken-4" label="Moradia" value="Moradia"></v-radio>
                            <v-radio color = "deep-orange darken-4" label="Terreno" value="Terreno"></v-radio>
                            <v-radio color = "deep-orange darken-4" label="Empresa/Fábrica" value="Empresa/Fábrica"></v-radio>
                            <v-radio color = "deep-orange darken-4" label="Outra" value="Outra"></v-radio>
                        </v-radio-group>
                    </v-container>
                </v-row>
            </v-card>    

            <v-card flat height= "80" color = "white"></v-card>   

            <v-card class = "mx-auto" max-width = "1500" color = "grey lighten-2" fluid outlined rounded>
                <v-row>
                    <v-col>
                        <v-card flat height= "30" color = "grey lighten-2"></v-card>  
                        <span class = " pa-8 headline font-weight-regular" color = "grey"> Espaço exterior ou equivalente * </span> 
                    </v-col>
                </v-row>
                <v-row>
                    <v-container fluid>
                         <v-radio-group column v-model="form.exterior" :rules="regraExterior" :mandatory="false" class = "ma-12" >
                            <v-radio color = "deep-orange darken-4" label="Varanda" value="Varanda"></v-radio>
                            <v-radio color = "deep-orange darken-4" label="Terraço" value="Terraço"></v-radio>
                            <v-radio color = "deep-orange darken-4" label="Marquise" value="Marquise"></v-radio>
                            <v-radio color = "deep-orange darken-4" label="Jardim" value="Jardim"></v-radio>
                            <v-radio color = "deep-orange darken-4" label="Nenhum" value="Nenhum"></v-radio>
                            <v-radio color = "deep-orange darken-4" label="Outra" value="Outra"></v-radio>
                        </v-radio-group>
                    </v-container>
                </v-row>
            </v-card>      

            <v-card flat height= "80" color = "white"></v-card>   

            <v-card class = "mx-auto" max-width = "1500" color = "grey lighten-2" fluid outlined rounded>
                <v-row>
                    <v-col>
                        <v-card flat height= "30" color = "grey lighten-2"></v-card>  
                        <span class = " pa-8 headline font-weight-regular" color = "grey"> A sua habitação é.. * </span> 
                    </v-col>
                </v-row>
                <v-row>
                    <v-container fluid>
                         <v-radio-group column v-model="form.habitacao" :rules="regraHabitacao" :mandatory="false" class = "ma-12" >
                            <v-radio color = "deep-orange darken-4" label="Própria" value="Própria"></v-radio>
                            <v-radio color = "deep-orange darken-4" label="Alugada" value="Alugada"></v-radio>
                            <v-radio color = "deep-orange darken-4" label="Condomínio" value="Condomínio"></v-radio>
                        </v-radio-group>
                    </v-container>
                </v-row>
            </v-card>      

            <v-card flat height= "80" color = "white"></v-card>   

            <v-card class = "mx-auto" max-width = "1500" color = "grey lighten-2" fluid outlined rounded>
                <v-row>
                    <v-col>
                        <v-card flat height= "30" color = "grey lighten-2"></v-card>  
                        <span class = " pa-8 headline font-weight-regular" color = "grey"> Caso seja alugada ou condomínio, tem permissão para ter animais? * </span> 
                    </v-col>
                </v-row>
                <v-row>
                    <v-container fluid>
                         <v-radio-group column v-model="form.permissao" :rules="regraPermissao" :mandatory="false" class = "ma-12" >
                            <v-radio color = "deep-orange darken-4" label="Sim" value="Sim"></v-radio>
                            <v-radio color = "deep-orange darken-4" label="Não" value="Não"></v-radio>
                            <v-radio color = "deep-orange darken-4" label="É própria" value="Própria"></v-radio>
                        </v-radio-group>
                    </v-container>
                </v-row>
            </v-card>      

            <v-card flat height= "80" color = "white"></v-card>   

            <v-card class = "mx-auto" max-width = "1500" color = "grey lighten-2" fluid outlined rounded>
                <v-row>
                    <v-col>
                        <v-card flat height= "30" color = "grey lighten-2"></v-card>  
                        <span class = " pa-8 headline font-weight-regular" color = "grey"> Pretende um cão para... </span> 
                    </v-col>
                </v-row>
                <v-row>
                    <v-container fluid>
                         <v-radio-group column v-model="form.motivo" :rules="regraMotivo" :mandatory="false" class = "ma-12" >
                            <v-radio color = "deep-orange darken-4" label="Companhia" value="Companhia"></v-radio>
                            <v-radio color = "deep-orange darken-4" label="Caça" value="Caça"></v-radio>
                            <v-radio color = "deep-orange darken-4" label="Guarda" value="Guarda"></v-radio>
                            <v-radio color = "deep-orange darken-4" label="Dar de presente" value="Presente"></v-radio>
                            <v-radio color = "deep-orange darken-4" label="Outra" value="Outra"></v-radio>
                        </v-radio-group>
                    </v-container>
                </v-row>
            </v-card>      

            <v-card flat height= "80" color = "white"></v-card>   

            <v-card class = "mx-auto" max-width = "1500" color = "grey lighten-2" fluid outlined rounded>
                <v-row>
                    <v-col>
                        <v-card flat height= "30" color = "grey lighten-2"></v-card>  
                        <span class = " pa-8 headline font-weight-regular" color = "grey"> Em caso de ausência para férias, trabalho ou outra, o seu cão: </span> 
                    </v-col>
                </v-row>
                <v-row>
                    <v-container fluid>
                         <v-radio-group column v-model="form.ausencia" :rules="regraAusencia" :mandatory="false" class = "ma-12" >
                            <v-radio color = "deep-orange darken-4" label="Acompanhará a família" value="Acompanhará a família"></v-radio>
                            <v-radio color = "deep-orange darken-4" label="Ficará com familiares/amigos" value="Ficará com familiares/amigos"></v-radio>
                            <v-radio color = "deep-orange darken-4" label="Ficará num hotel" value="Ficará num hotel"></v-radio>
                            <v-radio color = "deep-orange darken-4" label="Ficará sozinho em casa" value="Ficará sozinho em casa"></v-radio>
                            <v-radio color = "deep-orange darken-4" label="Outro" value="Outro"></v-radio>
                        </v-radio-group>
                    </v-container>
                </v-row>
            </v-card>      

            <v-card flat height= "80" color = "white"></v-card>   

            <v-card class = "mx-auto" max-width = "1500" color = "grey lighten-2" fluid outlined rounded>
                <v-row>
                    <v-col>
                        <v-card flat height= "30" color = "grey lighten-2"></v-card>  
                        <span class = " pa-8 headline font-weight-regular" color = "grey"> Tem alguém alérgico a cães na família? * </span> 
                    </v-col>
                </v-row>
                <v-row>
                    <v-container fluid>
                         <v-radio-group column v-model="form.alergia" :rules="regraAlergia" :mandatory="false" class = "ma-12" >
                            <v-radio color = "deep-orange darken-4" label="Sim" value="Sim"></v-radio>
                            <v-radio color = "deep-orange darken-4" label="Não" value="Não"></v-radio>
                        </v-radio-group>
                    </v-container>
                </v-row>
            </v-card>      

            <v-card flat height= "80" color = "white"></v-card>   

            <v-card class = "mx-auto" max-width = "1500" color = "grey lighten-2" fluid outlined rounded>
                <v-row>
                    <v-col>
                        <v-card flat height= "30" color = "grey lighten-2"></v-card>  
                        <span class = " pa-8 headline font-weight-regular" color = "grey"> É dono de mais algum animal? * </span> 
                    </v-col>
                </v-row>
                <v-row>
                    <v-container fluid>
                         <v-radio-group column v-model="form.donoAnimal" :rules="regraDonoAnimal" :mandatory="false" class = "ma-12" >
                            <v-radio color = "deep-orange darken-4" label="Sim" value="Sim"></v-radio>
                            <v-radio color = "deep-orange darken-4" label="Não" value="Não"></v-radio>
                        </v-radio-group>
                    </v-container>
                </v-row>
            </v-card>      

            <v-card flat height= "80" color = "white"></v-card>   

            <v-card class = "mx-auto" max-width = "1500" color = "grey lighten-2" fluid outlined rounded>
                <v-row>
                    <v-col>
                        <v-card flat height= "30" color = "grey lighten-2"></v-card>  
                        <span class = " pa-8 headline font-weight-regular" color = "grey"> Se sim, quais?  </span> 
                    </v-col>
                </v-row>
                <v-row>
                    <v-col cols = "6">
                        <v-textarea
                            flat
                            auto-grow
                            v-model="form.descAnimais"
                            placeholder = "Indique de que outros animais é dono"
                            color = "grey lighten-1" 
                            class = "pa-8"
                            rows = "2"
                        ></v-textarea>
                    </v-col>
                </v-row>
            </v-card>      

            <v-card flat height= "80" color = "white"></v-card>  

            <v-card class = "mx-auto" max-width = "1500" color = "grey lighten-2" fluid outlined rounded>
                <v-row>
                    <v-col>
                        <v-card flat height= "30" color = "grey lighten-2"></v-card>  
                        <span class = " pa-8 headline font-weight-regular" color = "grey"> Comprovativo de Morada * </span> 
                    </v-col>
                </v-row>
                <v-row>
                    <v-col cols = "6">
                        <input class = "ma-12" type="file" id="file" ref="file" v-on:change="handleFileUpload()"/>
                    </v-col>
                </v-row>
            </v-card>      

            <v-card flat height= "50" color = "white"></v-card>
            <v-card class = "mx-auto" max-width = "1500" flat>
                <v-row>
                    <v-col cols="12">
                        <v-checkbox color="deep-orange darken-4" v-model="terms" id="terms" :rules="regraTermos" >
                            <template v-slot:label>
                                <div>
                                    <Termos/>
                                </div>
                            </template>
                        </v-checkbox>
                    </v-col>
                </v-row>
                <v-card-actions>
                    <v-spacer></v-spacer>
                    <v-btn class="ma-6 headline red--text" x-large color = "red" outlined @click="cancelar()">Cancelar</v-btn>
                    <v-btn
                        class="ma-6 headline"
                        x-large
                        color="deep-orange lighten-4"
                        :disabled="isDisabled"
                        @click="submeterPedido()" 
                    >Submeter Pedido</v-btn>
                </v-card-actions>  
            </v-card>    
            </v-form>  
        </div>

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
import axios from 'axios'
import store from '@/store.js'
const lhost = require("@/config/global").host;
import Termos from '@/components/Infos/TermosECondicoes.vue'
export default {
    props:['id','id2','id3'],
    data () {
      return {
        terms:false, 
        snackbar: false, 
        color: "", 
        done: false, 
        timeout: 0,
        text: "",
        form:{
            tipoMoradia:"",
            exterior:"", 
            ausencia:"", 
            alergia:"", 
            donoAnimal:"", 
            descAnimais:"", 
            motivo:"", 
            permissao:"", 
            habitacao:"",  
        }, 
        regraNome: [v => !!v || "Nome obrigatório."],
        regraNomeCao: [v => !!v || "Nome de cão obrigatório."],
        regraTipoMoradia: [v => !!v || "Indicaçaõ obrigatória."],
        regraExterior: [v => !!v || "Indicação obrigatória."],
        regraAlergia: [v => !!v || "Indicação obrigatória."],
        regraDonoAnimal: [v => !!v || "Indicação obrigatória."],
        regraAusencia: [v => !!v || "Indicação obrigatória."],
        regraMotivo: [v => !!v || "Indicação obrigatória."],
        regraPermissao: [v => !!v || "Indicação obrigatória."],
        regraHabitacao: [v => !!v || "Indicação obrigatória."],
        regraComprovativo: [v => !!v || "Comprovativo de Morada obrigatório."],
        regraTermos: [v => !!v || "Por favor aceite os termos de condição"],
        file: '',
      }
    },
    components: {
                Termos
    },
    computed:{
        isDisabled: function(){
            return !this.terms;
        }
    }, 
    methods:{
      submeterPedido: async function(){
        if (this.$refs.form.validate()) {
            try{ 
            var resposta = 
                await axios.post(lhost + "/api/Adocoes", 
                {
                    estado: "Pendente", 
                    cao_idCao: this.id3, 
                    permissao: this.form.permissao, 
                    alergia: this.form.alergia, 
                    descAnimais: this.form.descAnimais, 
                    ausencia: this.form.ausencia, 
                    habitacao: this.form.habitacao, 
                    exterior: this.form.exterior, 
                    tipoMoradia: this.form.tipoMoradia, 
                    motivo: this.form.motivo, 
                    utilizador_user_email: this.id, 
                    comprovativo: "Por Validar", 
                    donoAnimal: this.form.donoAnimal
                },
                { headers: 
                    { "Authorization": 'Bearer ' + store.getters.token }
                }); 
                console.log(JSON.stringify(resposta.data));

                let formData = new FormData();

                /*
                    Add the form data we need to submit
                */
                formData.append('file', this.file);
                formData.append('name', this.file.name);

                var res =  
                    await axios.post(lhost + '/api/Comprovativos/' + this.id ,
                        formData,
                    {
                        headers: {
                            'Content-Type': 'multipart/form-data'
                        }
                    });
                console.log(JSON.stringify(res.data));
                this.text = "Pedido de Adoção submetido criado com sucesso!";
                this.color = "success"; 
                this.snackbar = true; 
            }
            catch(e){
                if(e.message == "Request failed with status code 401"){
                    this.$store.commit("limpaStore");
                    this.$router.push("/");
                }
                this.text = "Ocorreu um erro na submissão do pedido, por favor tente mais tarde!";
                this.color = "warning"; 
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
                if(this.color == 'success')
                    this.$router.push("/pagina/utilizador/" + this.id);
            },
        cancelar() {
            this.$router.push("/pagina/utilizador/" + this.id);
        },
        handleFileUpload(){
            this.file = this.$refs.file.files[0];
        }
    } 

}
</script>

<style scoped>
.parallax {
  min-height: 100vh;
  align-items: center;
}

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