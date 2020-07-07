<template>
    <div>
        <v-card flat class="mx-auto" max-width="1500" fluid>
            <p class = "display-2 font-weight-regular text-center" color = "grey darken-4"> Informações Pessoais</p>
        </v-card>

        <v-card flat height= "100" color = "white"></v-card>    

        <v-card class = "mx-auto" max-width = "1500" fluid outlined rounded>   
            <p 
                class = " pa-8 display-1 font-weight-regular" 
                color = "grey darken-4"
            > Perfil </p>

            <v-card flat height= "80" color = "white"></v-card>    
 
            <v-row>
                <v-flex xs8 md4>
                    <div 
                        class = " pa-12 headline font-weight-regular" 
                        color = "grey"
                    >NOME</div>            
                </v-flex>
                <v-flex xs8 md4>
                    <div 
                        class = " pa-12 headline font-weight-regular" 
                        color = "grey darken-4"
                    >{{canil.nome}}
                    </div>
                </v-flex>
                <v-flex xs8 md4>
                   <NameChange :id="$route.params.id"/>  
                </v-flex>
            </v-row>
   
            <v-divider></v-divider>

            <v-row>
                <v-flex xs8 md4>
                    <div 
                        class = " pa-12 headline font-weight-regular" 
                        color = "grey"
                    >CAPACIDADE TOTAL</div>            
                </v-flex>
                <v-flex xs8 md4>
                    <div 
                        class = " pa-12 headline font-weight-regular" 
                        color = "grey darken-4"
                    >{{canil.capacidadeTotal}}
                    </div>
                </v-flex>
                <v-flex xs8 md4>
                   <CapacityTotalChange :id="$route.params.id"/>  
                </v-flex>
            </v-row>

            <v-divider></v-divider>

            <v-row>
                <v-flex xs8 md4>
                    <div 
                        class = " pa-12 headline font-weight-regular" 
                        color = "grey"
                    >CAPACIDADE ATUAL</div>            
                </v-flex>
                <v-flex xs8 md4>
                    <div 
                        class = " pa-12 headline font-weight-regular" 
                        color = "grey darken-4"
                    >{{canil.capacidadeOcupada}}
                    </div>
                </v-flex>
                <v-flex xs8 md4>
                   <CapacityChange :id="$route.params.id"/>  
                </v-flex>
            </v-row>

            <v-divider></v-divider>
                
            <v-row>
                <v-flex xs8 md4>
                    <div 
                        class = " pa-12 headline font-weight-regular" 
                        color = "grey"
                    >PALAVRA-PASSE</div>            
                </v-flex>
                <v-flex xs8 md4>
                    <div 
                        class = " pa-12 headline font-weight-regular" 
                        color = "grey darken-4"
                    >**********
                    </div>
                </v-flex>
                <v-flex xs8 md4>
                   <PasswordChange :id="$route.params.id"/>  
                </v-flex>
            </v-row>    
  
            <v-divider></v-divider>

            <v-row>
                <v-flex xs8 md4>
                    <div 
                        class = " pa-12 headline font-weight-regular" 
                        color = "grey"
                    >CONTACTO</div>            
                </v-flex>
                <v-flex xs8 md4>
                    <div 
                        class = " pa-12 headline font-weight-regular" 
                        color = "grey darken-4"
                    >{{canil.contacto}}
                    </div>
                </v-flex>
                <v-flex xs8 md4>
                   <ContactChange :id="$route.params.id"/>   
                </v-flex>
            </v-row>  
        </v-card>

        <v-card flat height= "100" color = "white"></v-card>          

            <v-card class = "mx-auto" max-width = "1500" fluid outlined rounded>
                    
                <p class = " pa-8 display-1 font-weight-regular" color = "grey darken-4"> Informações de Contacto </p>
                <v-card flat height= "20" color = "white"></v-card>    
                <v-row>
                    <v-flex xs8 md4>
                        <div 
                            class = " pa-12 headline font-weight-regular" 
                            color = "grey"
                        >EMAIL</div>            
                    </v-flex>
                    <v-flex xs8 md4>
                        <div 
                            class = " pa-12 headline font-weight-regular" 
                            color = "grey darken-4"
                        >{{canil.email}}
                        </div>
                    </v-flex>
                    <v-flex xs8 md4>
                        <v-btn class="ma-5" disabled text fab></v-btn> 
                    </v-flex>
                </v-row>  

                <v-divider></v-divider>

                <v-row>
                    <v-flex xs8 md4>
                        <div 
                            class = " pa-12 headline font-weight-regular" 
                            color = "grey"
                        >MORADA</div>            
                    </v-flex>
                    <v-flex xs8 md4>
                        <div 
                            class = " pa-12 headline font-weight-regular" 
                            color = "grey darken-4"
                        >{{canil.rua}}
                        </div>
                    </v-flex>
                    <v-flex xs8 md4>
                    <AddressChange :id="$route.params.id"/>    
                    </v-flex>
                </v-row>  

                <v-divider></v-divider>

                <v-row>
                    <v-flex xs8 md4>
                        <div 
                            class = " pa-12 headline font-weight-regular" 
                            color = "grey"
                        >CONCELHO</div>            
                    </v-flex>
                    <v-flex xs8 md4>
                        <div 
                            class = " pa-12 headline font-weight-regular" 
                            color = "grey darken-4"
                        >{{canil.localidade}}
                        </div>
                    </v-flex>
                    <v-flex xs8 md4>
                    <CityChange :id="$route.params.id"/>  
                    </v-flex>
                </v-row>  

                <v-divider></v-divider>

                <v-row>
                    <v-flex xs8 md4>
                        <div 
                            class = " pa-12 headline font-weight-regular" 
                            color = "grey"
                        >DISTRITO</div>            
                    </v-flex>
                    <v-flex xs8 md4>
                        <div 
                            class = " pa-12 headline font-weight-regular" 
                            color = "grey darken-4"
                        >{{canil.distrito}}
                        </div>
                    </v-flex>
                    <v-flex xs8 md4>
                    <DistrictChange :id="$route.params.id"/>  
                    </v-flex>
                </v-row>  

                <v-divider></v-divider>

                <v-row>
                    <v-flex xs8 md4>
                        <div 
                            class = " pa-12 headline font-weight-regular" 
                            color = "grey"
                        >NIB</div>            
                    </v-flex>
                    <v-flex xs8 md4>
                        <div 
                            class = " pa-12 headline font-weight-regular" 
                            color = "grey darken-4"
                        >{{canil.nib}}
                        </div>
                    </v-flex>
                    <v-flex xs8 md4>
                        <NIBChange :id="$route.params.id"/>  
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
                                <v-btn @click="removeCanil()">Remover</v-btn>
                            </v-col>
                        </v-row>
                    </v-alert>
                </v-card>
                </div>
</template>

<script>
import NameChange from '@/components/EditarDadosKennel/NameChange.vue'
import AddressChange from '@/components/EditarDadosKennel/AddressChange.vue'
import PasswordChange from '@/components/EditarDadosKennel/PassChange.vue'
import CityChange from '@/components/EditarDadosKennel/CityChange.vue'
import DistrictChange from '@/components/EditarDadosKennel/DistrictChange.vue'
import NIBChange from '@/components/EditarDadosKennel/NIBChange.vue'
import ContactChange from '@/components/EditarDadosKennel/ContactChange.vue'
import CapacityChange from '@/components/EditarDadosKennel/CapacityChange.vue'
import CapacityTotalChange from '@/components/EditarDadosKennel/CapacityTotalChange.vue'
import axios from 'axios'
import store from '@/store.js'
const lhost = require("@/config/global").host;

export default {
    data: () => ({  
        canil: {},           
        dialog:false,
        alert: false,
    }),
    name: 'Informacoes',
    props: ['id'], 
    components: {  
                    NameChange,
                    ContactChange,
                    AddressChange,
                    PasswordChange,
                    CityChange,
                    DistrictChange,
                    NIBChange, 
                    CapacityChange,
                    CapacityTotalChange
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
    }, 
    methods:{
        removeCanil: async function() {
            this.$router.push("/"); 
        }
    } 
}
</script>