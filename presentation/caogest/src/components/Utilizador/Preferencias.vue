<template>
    <div>
                <v-card flat class="mx-auto" max-width="1500" fluid>
                    <p class = "display-2 font-weight-regular text-center" color = "grey darken-4"> Informações Pessoais</p>
                </v-card>

                <v-card flat height= "100" color = "white"></v-card>    

                <v-card class = "mx-auto" max-width = "1500" fluid outlined rounded>
                    
                    <p class = " pa-8 display-1 font-weight-regular" color = "grey darken-4"> Perfil </p>
                    <v-card flat height= "80" color = "white"></v-card>    
                    
                    <v-row>
                        <v-flex xs8 md4>
                        <div class = " pa-8 headline font-weight-regular" color = "grey"> NOME </div> 
                        </v-flex>
                        <v-spacer></v-spacer>
                        <v-flex xs8 md4>
                        <div  class = " pa-8 headline font-weight-regular" color = "grey darken-4">
                                {{dados.nome}}
                            </div>
                        </v-flex>
                        <v-spacer></v-spacer>
                       <v-flex xs8 md4>
                            <NameChange :id="$route.params.id"/>  
                        </v-flex>
                    </v-row>
                    <v-divider></v-divider>

                    <v-row>
                        <v-flex xs8 md4>
                        <div  class = " pa-8 headline font-weight-regular" color = "grey"> ANIVERSÁRIO </div> 
                        </v-flex>
                        <v-spacer></v-spacer>
                        <v-flex xs8 md4>
                        <div  class = " pa-8 headline font-weight-regular" color = "grey darken-4">
                                {{date(dados.data_de_nascimento)}}
                            </div>
                        </v-flex>
                        <v-spacer></v-spacer>
                        <v-flex xs8 md4>
                            <!--<BirthChange :id="$route.params.id"/>  -->
                        </v-flex>
                    </v-row>
                    <v-divider></v-divider>

                    <v-row>
                       <v-flex xs8 md4>
                        <div  class = " pa-8 headline font-weight-regular" color = "grey"> PALAVRA-PASSE </div> 
                        </v-flex>
                        <v-spacer></v-spacer>
                        <v-flex xs8 md4>
                        <div class = " pa-8 headline font-weight-regular" color = "grey darken-4">**********</div>
                        </v-flex>
                        <v-spacer></v-spacer>
                        <v-flex xs8 md4>
                            <PassChange :id="$route.params.id"/>  
                        </v-flex>
                    </v-row>
                </v-card>    

                 <v-card flat height= "100" color = "white"></v-card>          

                 <v-card class = "mx-auto" max-width = "1500" fluid outlined rounded>
                    
                    <p class = " pa-8 display-1 font-weight-regular" color = "grey darken-4"> Informações de Contacto </p>
                    <v-card flat height= "20" color = "white"></v-card>    
                    
                    <v-row>
                        <v-flex xs8 md4>
                        <div  class = " pa-8 headline font-weight-regular" color = "grey"> EMAIL </div> 
                        </v-flex>
                        <v-spacer></v-spacer>
                        <v-flex xs8 md4>
                        <div  class = " pa-8 headline font-weight-regular" color = "grey darken-4">
                                {{dados.email}}
                            </div>
                        </v-flex>
                        <v-spacer></v-spacer>
                        <v-flex xs8 md4>
                            <v-btn class="ma-5" disabled text fab></v-btn>
                        </v-flex>
                        
                    </v-row>
                    <v-divider></v-divider>

                    <v-row>
                        <v-flex xs8 md4>
                        <div  class = " pa-8 headline font-weight-regular" color = "grey"> MORADA </div> 
                        </v-flex>
                        <v-spacer></v-spacer>
                        <v-flex xs8 md4>
                        <div class = " pa-8 headline font-weight-regular" color = "grey darken-4">
                                {{dados.rua}}
                            </div>
                        </v-flex>
                        <v-spacer></v-spacer>
                        <v-flex xs8 md4>
                            <AddressChange :id="$route.params.id"/>  
                        </v-flex>
                    </v-row>
                    <v-divider></v-divider>

                    <v-row>
                        <v-flex xs8 md4>
                        <div  class = " pa-8 headline font-weight-regular" color = "grey"> CONCELHO </div> 
                        </v-flex>
                        <v-spacer></v-spacer>
                        <v-flex xs8 md4>
                        <div class = " pa-8 headline font-weight-regular" color = "grey darken-4">
                                {{dados.localidade}}
                            </div>
                        </v-flex>
                        <v-spacer></v-spacer>
                        <v-flex xs8 md4>
                            <CityChange :id="$route.params.id"/>  
                        </v-flex>
                    </v-row>
                    <v-divider></v-divider>

                    <v-row>
                        <v-flex xs8 md4>
                        <div  class = " pa-8 headline font-weight-regular" color = "grey"> NÚMERO DE CARTÃO DE CIDADÃO </div> 
                        </v-flex>
                        <v-spacer></v-spacer>
                        <v-flex xs8 md4>
                        <div  class = " pa-8 headline font-weight-regular" color = "grey darken-4">
                                {{dados.cc}}
                            </div>
                        </v-flex>
                        <v-spacer></v-spacer>
                        <v-flex xs8 md4>
                            <NIFChange :id="$route.params.id"/>  
                        </v-flex>
                    </v-row>
                </v-card>     
                <v-card flat height= "100" color = "white"></v-card>          
                <v-card flat class = "mx-auto" max-width = "1500" fluid>
                <v-btn color = "red darken-3" dark x-large class = "headline" @click="alert = !alert"> Remover Conta</v-btn>
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
                            <v-col class="grow">Tem a certeza de que pretende remover a sua conta? Todos os dados serão perdidos, pelo que é uma ação irreversível.</v-col>
                            <v-col class="shrink">
                            <v-btn to='/'>Remover</v-btn>
                            </v-col>
                        </v-row>
                    </v-alert>
                </v-card>
            </div>
</template>

<script>
import NameChange from '@/components/EditarDados/NameChange.vue'
//import BirthChange from '@/components/EditarDados/BirthChange.vue'
import AddressChange from '@/components/EditarDados/AddressChange.vue'
import PassChange from '@/components/EditarDados/PassChange.vue'
import CityChange from '@/components/EditarDados/CityChange.vue'
import NIFChange from '@/components/EditarDados/NIFChange.vue'
import moment from 'moment/moment'
import store from '@/store.js'
import axios from 'axios'
const lhost = require("@/config/global").host;

export default {
    name: 'Preferencias',    
    props: ['id'], 
    data: () => ({             
        dialog:false,
        alert: false,
        dados: {},
    }),
    components: {  
        NameChange,
        //BirthChange,
        AddressChange,
        PassChange,
        CityChange,
        NIFChange
    },   
    methods:{
        date: function (date) {
            return moment(date).locale("pt").format('L');
        },
    },
   created: async function(){
    try {
      let response = await axios.get(lhost + "/api/Utilizadors/" + this.id,
            { headers: 
              { "Authorization": 'Bearer ' + store.getters.token }
            });
      this.dados = response.data;
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