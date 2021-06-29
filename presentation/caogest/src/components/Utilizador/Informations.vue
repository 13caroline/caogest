<template>
    <div id = "informations" class = "informations">
        <Navbar :id="$route.params.id"/>

            <v-card flat height= "60" color = "white"></v-card>

            <div>
                <v-card flat class="mx-auto" max-width="1500" fluid>
                    <p class = "display-2 font-weight-regular text-center" color = "grey darken-4"> Informações </p>
                </v-card>

                <v-card flat height= "100" color = "white"></v-card>    

                <v-card class = "mx-auto" max-width = "1500" fluid outlined rounded>
                    
                    <p class = " pa-8 display-1 font-weight-regular" color = "grey darken-4"> Morada </p>
                    <v-card flat height= "80" color = "white"></v-card>    
                    
                    <v-row>
                        <v-col>
                            <p class = " pa-8 headline font-weight-regular" color = "grey"> RUA </p> 
                        </v-col>
                        <v-spacer></v-spacer>
                        <v-col>
                            <p class = " pa-8 headline font-weight-regular" color = "grey darken-4">
                                {{canil.rua}}
                            </p>
                        </v-col>
                        <v-spacer></v-spacer>
                    </v-row>
                    <v-divider></v-divider>

                    <v-row>
                       <v-col>
                            <p class = " pa-8 headline font-weight-regular" color = "grey"> CONCELHO </p> 
                        </v-col>
                        <v-spacer></v-spacer>
                        <v-col>
                            <p class = " pa-8 headline font-weight-regular" color = "grey darken-4">
                                {{canil.localidade}}
                            </p>
                        </v-col>
                        <v-spacer></v-spacer>
                    </v-row>
                    <v-divider></v-divider>

                    <v-row>
                       <v-col>
                            <p class = " pa-8 headline font-weight-regular" color = "grey"> DISTRITO </p> 
                        </v-col>
                        <v-spacer></v-spacer>
                        <v-col>
                            <p class = " pa-8 headline font-weight-regular" color = "grey darken-4">
                                {{canil.distrito}}
                            </p>
                        </v-col>
                        <v-spacer></v-spacer>
                    </v-row>
                </v-card>    

                 <v-card flat height= "100" color = "white"></v-card>          

                 <v-card class = "mx-auto" max-width = "1500" fluid outlined rounded>
                    
                    <p class = " pa-8 display-1 font-weight-regular" color = "grey darken-4"> Contactos </p>
                    <v-card flat height= "20" color = "white"></v-card>    
                    
                    <v-row>
                        <v-col>
                            <p class = " pa-8 headline font-weight-regular" color = "grey"> EMAIL </p> 
                        </v-col>
                        <v-spacer></v-spacer>
                        <v-col>
                            <p class = " pa-8 headline font-weight-regular" color = "grey darken-4">
                                {{canil.email}}
                            </p>
                        </v-col>
                        <v-spacer></v-spacer>
                    </v-row>
                    <v-divider></v-divider>

                    <v-row>
                        <v-col>
                            <p class = " pa-8 headline font-weight-regular" color = "grey"> TELEFONE </p> 
                        </v-col>
                        <v-spacer></v-spacer>
                        <v-col>
                            <p class = " pa-8 headline font-weight-regular" color = "grey darken-4">
                                {{canil.contacto}}
                            </p>
                        </v-col>
                        <v-spacer></v-spacer>
                    </v-row>
                 </v-card>

                 <v-card flat height= "100" color = "white"></v-card>          

                 <v-card class = "mx-auto" max-width = "1500" fluid outlined rounded>
                    <p class = " pa-8 display-1 font-weight-regular" color = "grey darken-4"> Número de Identificação Bancária </p>
                    <v-card flat height= "20" color = "white"></v-card>    

                    <v-row>
                        <v-col>
                            <p class = " pa-8 headline font-weight-regular" color = "grey darken-4">
                               {{canil.nib}}
                            </p> 
                        </v-col>
                        <v-spacer></v-spacer>
                    </v-row>

                 </v-card>
                
                 <v-card flat height= "100" color = "white"></v-card>   

                <v-card class = "mx-auto" max-width = "1500" fluid outlined rounded>
                    
                    <p class = " pa-8 display-1 font-weight-regular" color = "grey darken-4"> Ocupação </p>
                    <v-card flat height= "20" color = "white"></v-card>    
                        
                    <v-row>
                        <v-col>
                            <p class = " pa-8 headline font-weight-regular" color = "grey"> VAGAS TOTAIS </p> 
                        </v-col>
                        <v-spacer></v-spacer>
                        <v-col>
                            <p class = " pa-8 headline font-weight-regular" color = "grey darken-4">
                                {{canil.capacidadeTotal}}
                            </p>
                        </v-col>
                    </v-row>
                    <v-spacer></v-spacer>
                    <v-row>
                        <v-col>
                            <p class = " pa-8 headline font-weight-regular" color = "grey"> VAGAS OCUPADAS </p> 
                        </v-col>
                        <v-spacer></v-spacer>
                        <v-col>
                            <p class = " pa-8 headline font-weight-regular" color = "grey darken-4">
                                {{canil.capacidadeOcupada}}
                            </p>
                        </v-col>
                    </v-row>
                </v-card>
    
            </div>
        <Footer :id="$route.params.id"/>
    </div>
</template>

<script>
import Navbar from '@/components/NavbarFooter/Navbar.vue'
import Footer from '@/components/NavbarFooter/Footer.vue'
import axios from 'axios'
import store from '@/store.js'
const lhost = require("@/config/global").host;

export default {
    props:['id','id2'],
    data: () => ({
        canil: {},
    }),
    name: 'Informacoes',
    components: { Navbar, 
                  Footer, 
    },
    created: async function(){
        try {
            let response = await axios.get(lhost + "/api/Canis/" + this.id2,
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
   
   
            
}
</script>