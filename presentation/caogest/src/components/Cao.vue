<template>
    <div>           
        <v-card flat height = "200"></v-card>
        <v-container fluid>
            <v-row class = "align-center justify-center">
                <v-col cols = "4">
                    <v-card flat class = "mx-auto" height = "800" width = "900"> 
                         <v-img height = "800" width = "800" :src="require(`@/assets/${getPath(cao)}`)"></v-img> 
                    </v-card>
                </v-col>

                <v-col cols = "6">
                    <v-card color = "brown lighten-5" height = "800" width = "1200" tile>
                        <v-card flat color = "brown lighten-5" height = "40"></v-card>
                        <v-row class="ml-8">
                            <p 
                                class = " display-1 font-weight-bold" 
                                color = "grey"
                            > Nome: 
                                <span 
                                    class = "display-1 font-weight-regular "
                                >{{cao.nome}}</span>
                            </p> 
                            </v-row>
                            <v-card 
                                flat 
                                color = "brown lighten-5 "
                                height = "20"
                            ></v-card>
                            <v-row class="ml-8">
                                <p 
                                    class = " display-1 font-weight-bold" 
                                    color = "grey"
                                > Raça: 
                                    <span 
                                        class = "display-1 font-weight-regular "
                                    >{{cao.raca}}</span>
                                </p> 
                            </v-row>
                            <v-card 
                                flat 
                                color = "brown lighten-5" 
                                height = "20"
                            ></v-card>                                       
                            <v-row class="ml-8">
                                <p 
                                    class = " display-1 font-weight-bold" 
                                    color = "grey"
                                > Idade: 
                                    <span 
                                        class = "healine font-weight-regular "
                                    >{{cao.idade}}</span>
                                </p> 
                                <v-btn fab text>
                                    <v-icon color = "grey" @click="changeIdade(cao)">edit</v-icon>
                                </v-btn>
                            </v-row>
                            <v-card 
                                flat 
                                color = "brown lighten-5" 
                                height = "20"
                            ></v-card>
                            <v-row class="ml-8">
                                <p 
                                    class = " display-1 font-weight-bold" 
                                    color = "grey"
                                > Cor: 
                                    <span 
                                        class = "healine font-weight-regular "
                                    >{{cao.cor}}</span>
                                </p> 
                            </v-row>
                            <v-card 
                                flat 
                                color = "brown lighten-5" 
                                height = "20"
                            ></v-card>                                    
                            <v-row class="ml-8">
                                <p 
                                    class = " display-1 font-weight-bold" 
                                    color = "grey"
                                > Porte: 
                                    <span 
                                        class = "display-1 font-weight-regular "
                                    >{{cao.porte}}</span>
                                </p> 
                            </v-row>
                            <v-card 
                                flat 
                                color = "brown lighten-5" 
                                height = "20"
                            ></v-card>
                            <v-row class="ml-8">
                                <p 
                                    class = " display-1 font-weight-bold" 
                                    color = "grey"
                                > Sexo: 
                                    <span 
                                        class = "display-1 font-weight-regular "
                                    >{{cao.sexo}}</span>
                                </p> 
                            </v-row>
                            <v-card 
                                flat 
                                color = "brown lighten-5" 
                                height = "20"
                            ></v-card>                                        
                            <v-row class="ml-8">
                            <p 
                                class = " display-1 font-weight-bold" 
                                color = "grey"
                            > Esterilizado: 
                                <span 
                                    class = "display-1 font-weight-regular "
                                >{{cao.esterilizacao}}
                                </span>
                            </p> 
                            <v-btn fab text @click="changeEst(cao)">
                                    <v-icon color = "grey">edit</v-icon>
                                </v-btn>
                            </v-row>
                            <v-card 
                                flat   
                                color = "brown lighten-5" 
                                height = "20"
                            ></v-card>
                            <v-row class="ml-8">
                                <p 
                                    class = " display-1 font-weight-bold" 
                                    color = "grey"
                                > Descrição: 
                                    <span 
                                        class = "display-1 font-weight-regular "
                                    >{{cao.descricao}}</span>
                                </p> 
                            </v-row>
                            <v-card 
                                flat 
                                color = "brown lighten-5" 
                                height = "20"
                            ></v-card>   
                            <v-row class="ml-8">
                                <p class = " display-1 font-weight-bold" 
                                    color = "grey"
                                > Canil: 
                                    <span 
                                        class = "display-1 font-weight-regular "
                                    >{{cao.nome_canil}}</span>
                                </p> 
                            </v-row>
                        </v-card>
                    </v-col>
                </v-row>
                <v-row justify = "end">
                    <v-col cols = "12" md = "11">
                        <v-row justify= "start">
                             <v-btn color = "red darken-3" dark x-large class = "headline ma-3" @click="alert = !alert"> Remover Cão</v-btn>
                                    <v-alert
                                        :value="alert"
                                        color="red"
                                        prominent
                                        dark
                                        transition="scale-transition"
                                        type = "error"
                                        text
                                    >
                                    <v-row align="center">
                                        <v-col class="grow">Tem a certeza de que pretende remover este cão? Todos os dados serão perdidos, pelo que é uma ação irreversível.</v-col>
                                        <v-col class="shrink">
                                            <v-btn @click="removeCao(cao)">Remover</v-btn>
                                        </v-col>
                                    </v-row>
                                </v-alert>
                        </v-row>
                    </v-col>
                </v-row>
            </v-container>
            <v-dialog 
                v-model="dialog" 
                persistent 
                width="800px"
            >
                <v-form ref="form" lazy-validation>
                <v-card>
                <v-card flat color = "deep-orange lighten-4" class = "pa-6">
                    <span class="display-1" dark>Alterar Dados de Esterilização</span>
                </v-card>
                <v-card-text>
                    <v-container>
                    <v-col>
                        <v-text-field 
                        color = "grey" 
                        placeholder="Novos dados de esterilização" 
                        required
                        class = "ma-12"
                        v-model="form.esterilizacao"
                        :rules="regraEsterilizacao"
                        ></v-text-field>
                    </v-col>
                    </v-container>
                </v-card-text>
                <v-card-actions>
                    <v-spacer></v-spacer>
                    <v-btn class="ma-6" large color = "deep-orange lighten-4" @click="dialog = false">Cancelar</v-btn>
                    <v-btn class="ma-6" large color = "deep-orange lighten-4" @click="confirma()">Confirmar</v-btn>
                </v-card-actions>
                </v-card>
                </v-form>
        </v-dialog>
        <v-dialog 
                v-model="dialog2" 
                persistent 
                width="800px"
            >
                <v-form ref="form" lazy-validation>
                <v-card>
                <v-card flat color = "deep-orange lighten-4" class = "pa-6">
                    <span class="display-1" dark>Alterar Dados da Idade</span>
                </v-card>
                <v-card-text>
                    <v-container>
                    <v-col>
                        <v-text-field 
                        color = "grey" 
                        placeholder="Novos dados de Idade" 
                        required
                        class = "ma-12"
                        v-model="form.idade"
                        :rules="regraIdade"
                        type="number"
                        ></v-text-field>
                    </v-col>
                    </v-container>
                </v-card-text>
                <v-card-actions>
                    <v-spacer></v-spacer>
                    <v-btn class="ma-6" large color = "deep-orange lighten-4" @click="dialog2 = false">Cancelar</v-btn>
                    <v-btn class="ma-6" large color = "deep-orange lighten-4" @click="confirmaIdade">Confirmar</v-btn>
                </v-card-actions>
                </v-card>
                </v-form>
        </v-dialog>
    </div>
</template>

<script>
import axios from 'axios'
import store from '@/store.js'
const lhost = require("@/config/global").host;


export default {
    name: "Dog",
    props:['id', 'id2'],

    data: () => ({   
        alert: false, 
        fab:false,  
        fotos: [],
        cao:[],
        dialog: false, 
        dialog2: false,
        esterilizacao:"", 
        idade:"", 
        form:{
            esterilizacao:"",
            idade:"",
        },
        regraEsterilizacao: [v => !!v || "Campo obrigatório."],
        regraIdade: [v => !!v || "Campo obrigatório."],
    }),
    methods:{
        getPath: function(e) {
           return e.fotos[0].path;
        },
        atualiza: async function(){
            try {
                let response = await axios.get(lhost + "/api/Caes/" + this.id2,
                { headers: 
                    { "Authorization": 'Bearer ' + store.getters.token }
                });
                this.cao = response.data;
                this.ready = true;
            } 
            catch (e) {
                if(e.message == "Request failed with status code 401"){
                    this.$store.commit("limpaStore");
                    this.$router.push("/");
                }
            }
        },
        confirma: async function(){
                try{
                    let response = 
                         axios.put(lhost + "/api/Caes/Update/" + this.id2, 
                        {
                            idade: this.idade.toString(),
                            esterilizacao: this.form.esterilizacao, 
                        },
                        { headers: 
                            { "Authorization": 'Bearer ' + store.getters.token }
                        });
  
                    console.log(JSON.stringify(response.data));
                    this.atualiza();
                    this.dialog = false;
                    }
                catch(e){
                    console.log(e); 
                    if(e.message == "Request failed with status code 401"){
                        this.$store.commit("limpaStore");
                        this.$router.push("/");
                    }
                }  
        },
        confirmaIdade: async function(){
                try{
                    let response = 
                         axios.put(lhost + "/api/Caes/Update/" + this.id2, 
                        {
                            idade: this.form.idade,
                            esterilizacao: this.esterilizacao, 
                        },
                        { headers: 
                            { "Authorization": 'Bearer ' + store.getters.token }
                        });
                    console.log(JSON.stringify(response.data));
                   
                    this.dialog2 = false;
                    this.atualiza();
                }
                catch(e){
                    if(e.message == "Request failed with status code 401"){
                        this.$store.commit("limpaStore");
                        this.$router.push("/");
                    }
                }  
        },
        changeEst: function(cao){
            this.esterilizacao = cao.esterilizacao; 
            this.idade = cao.idade; 
            this.dialog = true; 
        },
        changeIdade: function(cao){
            this.esterilizacao = cao.esterilizacao; 
            this.idade = cao.idade; 
            this.dialog2 = true; 
        },
        removeCao: async function(cao) {
            try{ 
                var resposta = 
                await axios.put(lhost + "/api/Caes/" + this.id2 , 
                {
                    idCao:parseInt(this.id2),
                    nome:cao.nome,
                    raca:cao.raca,
                    idade:cao.idade,
                    sexo:cao.sexo,
                    cor:cao.cor,
                    porte:cao.porte,
                    esterilizacao:cao.esterilizacao,
                    descricao:cao.descricao,
                    estado:"Apagado",
                    canil_user_email:this.id,
                    fotos: cao.fotos,
                },
                { headers: 
                    { "Authorization": 'Bearer ' + store.getters.token }
                });
                console.log(JSON.stringify(resposta.data));
                this.$router.push("/pagina/canil/" + this.id);
                this.dialog=false;
            }
            catch(e){
                if(e.message == "Request failed with status code 401"){
                this.$store.commit("limpaStore");
                this.$router.push("/");
            }
            }
        },
    },
    created: async function(){
        try {
            let response = await axios.get(lhost + "/api/Caes/" + this.id2,
            { headers: 
              { "Authorization": 'Bearer ' + store.getters.token }
            });
            this.cao = response.data;

            this.ready = true;
        } 
        catch (e) {
            if(e.message == "Request failed with status code 401"){
                this.$store.commit("limpaStore");
                this.$router.push("/");
            }
        }
    },

}
</script>

                
                           