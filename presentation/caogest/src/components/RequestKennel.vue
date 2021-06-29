<template>
    <div id = "requestkennel" class = "Request Kennel" >
        <NavbarAdmin/>
        <v-card flat height = "100"></v-card>
        <v-card flat height = "100" color = "brown lighten-5">
                <v-card-text class = "display-2 black--text text-center">{{canil.nome}}</v-card-text>
            </v-card>
        <v-card flat class="ma-12" max-width="1500" fluid>
            <v-row>
                <v-col>
                    <v-card flat>
                        <v-row>
                            <p class = " display-1 font-weight-bold" color = "grey"> E-mail: 
                                <span class = "display-1 font-weight-regular ">{{canil.user_email}}</span>
                            </p> 
                        </v-row>
                        <v-card flat color = "white" height = "40"></v-card>
                        <v-row>
                            <p class = " display-1 font-weight-bold" color = "grey"> Nome: 
                                <span class = "display-1 font-weight-regular ">{{canil.nome}}</span>
                            </p> 
                        </v-row>
                        <v-card flat color = "white" height = "40"></v-card>
                        <v-row>
                            <p class = " display-1 font-weight-bold" color = "grey"> Morada: 
                                <span class = "display-1 font-weight-regular ">{{canil.rua}}</span>
                            </p> 
                        </v-row>
                        <v-card flat color = "white" height = "40"></v-card>
                        <v-row>
                            <p class = " display-1 font-weight-bold" color = "grey"> Localidade: 
                                <span class = "display-1 font-weight-regular ">{{canil.localidade}}</span>
                            </p> 
                        </v-row>
                        <v-card flat color = "white" height = "40"></v-card>
                        <v-row>
                            <p class = " display-1 font-weight-bold" color = "grey"> Distrito: 
                                <span class = "display-1 font-weight-regular ">{{canil.distrito}}</span>
                            </p> 
                        </v-row>
                        <v-card flat color = "white" height = "40"></v-card>
                        <v-row>
                            <p class = " display-1 font-weight-bold" color = "grey"> Capacidade Total: 
                                <span class = "display-1 font-weight-regular ">{{canil.capacidadeTotal}}</span>
                            </p> 
                        </v-row>
                        <v-card flat color = "white" height = "40"></v-card>
                        <v-row>
                            <p class = " display-1 font-weight-bold" color = "grey"> Vagas Ocupadas: 
                                <span class = "display-1 font-weight-regular ">{{canil.capacidadeOcupada}}</span>
                            </p> 
                        </v-row>
                        <v-card flat color = "white" height = "40"></v-card>
                        <v-row>
                            <p class = " display-1 font-weight-bold" color = "grey"> NIB: 
                                <span class = "display-1 font-weight-regular ">{{canil.nib}}</span>
                            </p> 
                        </v-row>
                        <v-card flat color = "white" height = "40"></v-card>
                        <v-row>
                            <p class = " display-1 font-weight-bold" color = "grey"> Contacto: 
                                <span class = "display-1 font-weight-regular ">{{canil.contacto}}</span>
                            </p> 
                        </v-row>
                        <v-card flat color = "white" height = "40"></v-card>
                        <v-row>
                            <p class = " display-1 font-weight-bold" color = "grey"> Horário de Funcionamento: </p>
                        </v-row>
                        <v-row>
                            <v-card class = "mx-auto" flat>
                                <v-row>
                                    <p class = "display-1 font-weight-bold ">Segunda-feira
                                        <span class = "display-1 font-weight-regular ">14h - 16h</span>    
                                    </p>  
                                </v-row>  
                                <v-row>
                                    <p class = "display-1 font-weight-bold ">Terça-feira
                                        <span class = "display-1 font-weight-regular ">14h - 16h</span>    
                                    </p>  
                                </v-row>  
                                <v-row>
                                    <p class = "display-1 font-weight-bold ">Quarta-feira
                                        <span class = "display-1 font-weight-regular ">14h - 16h</span>    
                                    </p>  
                                </v-row>  
                                <v-row>
                                    <p class = "display-1 font-weight-bold ">Quinta-feira
                                        <span class = "display-1 font-weight-regular ">14h - 16h</span>    
                                    </p>  
                                </v-row>  
                                <v-row>
                                    <p class = "display-1 font-weight-bold ">Sexta-feira
                                        <span class = "display-1 font-weight-regular ">14h - 16h</span>    
                                    </p>  
                                </v-row> 
                                <v-row>
                                    <p class = "display-1 font-weight-bold ">Sábado
                                        <span class = "display-1 font-weight-regular ">11h - 15h</span>    
                                    </p>  
                                </v-row> 
                                <v-row>
                                    <p class = "display-1 font-weight-bold ">Domingo
                                        <span class = "display-1 font-weight-regular ">10h - 13h</span>    
                                    </p>  
                                </v-row>    
                            </v-card>   
                        </v-row>
                    </v-card>
                </v-col>
            </v-row>
        </v-card>
        <v-card flat class = "ma-12">
            <v-row align = "end">
            <v-spacer></v-spacer>
            <v-btn v-if="canil.estado === 'Pendente'" class="ma-4" x-large color = "deep-orange lighten-4" to="/mainpageadmin">
                Recusar Registo
            </v-btn>
            <v-btn v-else class="ma-4" x-large disabled>
                Recusar Registo
            </v-btn>
             <v-btn v-if="canil.estado === 'Pendente'" class="ma-4" x-large color = "deep-orange lighten-4" to="/mainpageadmin">
                Aceitar Registo
            </v-btn>
            <v-btn v-else class="ma-4" x-large disabled>
                Aceitar Registo
            </v-btn>
           
            </v-row>
        </v-card>
        <Footer/>
    </div>
</template> 

<script>
import NavbarAdmin from '../components/NavbarAdmin.vue'
import Footer from '../components/Footer.vue'

import axios from 'axios'
const lhost = require("@/config/global").host;

export default {
    data: () => ({
        canil: {},
    }),
    name: 'PedidoRegisto',
    props: ['id'], 
    components: { NavbarAdmin, 
                  Footer, 
    },
    created: async function(){
        try {
            let response = await axios.get(lhost + "/api/Canis/" + this.id);
            this.canil = response.data;
            this.ready = true;
        } 
        catch (e) {
            return e;
        }
    },  
    methods: {
        aceitarRegisto(){

        },
    }
}
</script>     