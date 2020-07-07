<template>
    <div>
        <v-card> 
            <v-img src='@/assets/horários.png'>
                <v-row align = "end" justify = "end">
                    <v-btn text class = "white--text overline font-weight-thin text--secondary" href="https://www.fanpop.com/clubs/border-collie/images/41564797/title/border-collies-autumn-photo">hiperligação para a imagem original</v-btn>
                </v-row> 
            </v-img>
        </v-card>
        <v-card flat height= "100" color = "white"></v-card>

        <v-container>

            <v-card flat height= "100" color = "white"></v-card>

            <v-row>
                <v-col v-for="hor in sortedArray" :key = "hor.dia" cols="12" md="4" >
                    <v-card
                        color="white"
                        class="d-flex align-center"
                        dark
                        
                        height="400"
                    >
                        <v-col>
                            <v-row>
                                <v-flex xs12 text-xs-center>
                                    <div class = "text-center display-1 font-weight-bold black--text">{{dia(hor.dia)}}</div>
                                </v-flex>
                            </v-row>
                            
                            <v-card flat height= "30" color = "white"></v-card>
                            
                            <v-row>
                                <v-flex xs12 text-xs-center>
                                    <div class = "text-center headline black--text">{{date(hor.dataInicio)}} - {{date(hor.dataFim)}}</div>
                                </v-flex>    
                            </v-row>

                            <v-card flat height= "30" color = "white"></v-card>

                            <v-row align = "center" justify = "center">
                                    <v-chip color = "deep-orange lighten-4" class = "black--text">
                                        {{hor.registados}} Voluntários
                                    </v-chip>
                            </v-row>
                            <v-card flat color = "white" height = "40"></v-card>
                            <v-row align = "center" justify = "center">
                                <v-btn v-if="hor.registados !== 0" bottom absolute disabled class = "headline" light block>Editar Horário</v-btn>
                                <v-btn v-else class = "headline" bottom absolute color = "brown lighten-4" light block @click="editaHorario(hor)">Editar Horário</v-btn>
                            </v-row>
                        </v-col>
                    </v-card>
                </v-col>
            </v-row>
        </v-container>
        <v-dialog v-model="dialog" persistent width="1000px">
        <v-card class = "mx-auto" >
            <v-card color = "brown darken-4" flat dark class="pa-6" height="80">
                <span class="display-1" dark>Alterar Horário</span>
            </v-card>
            <v-card color = "white" fluid class = "mx-auto text-center px-12" flat>
            <v-card height = "30" flat ></v-card>
            <v-row>
                <v-col cols = "4">
                    <v-menu
                        ref="dataInicio"
                        v-model="menu13"
                        :close-on-content-click="false"
                        :nudge-right="40"
                        :return-value.sync="dataInicio"
                        transition="scale-transition"
                        offset-y
                        max-width="290px"
                        min-width="290px"
                    >
                        <template v-slot:activator="{ on }">
                            <v-text-field
                                :rules="regraHorario"
                                label="Hora Início"
                                prepend-icon="access_time"
                                color = "grey"
                                v-on="on"
                                v-model="form.dataInicio"
                            ></v-text-field>
                        </template>
                        <v-time-picker
                            format="24hr"
                            v-model="form.dataInicio"
                            full-width
                            color = "brown lighten-2"
                            @click:minute="$refs.dataInicio.save(dataInicio)"
                        ></v-time-picker>
                    </v-menu>
                </v-col>
                                     
                <v-col cols = "4">
                    <v-menu
                        ref="dataFim"
                        v-model="menu14"
                        :close-on-content-click="false"
                        :nudge-right="40"
                        :return-value.sync="dataFim"
                        transition="scale-transition"
                        offset-y
                        max-width="290px"
                        min-width="290px"
                    >
                        <template v-slot:activator="{ on }">
                            <v-text-field
                                :rules="regraHorario"
                                label="Hora Fim"
                                prepend-icon="access_time"
                                color = "grey"
                                v-on="on"
                                v-model="form.dataFim"
                            ></v-text-field>
                        </template>
                        <v-time-picker
                            format="24hr"
                            v-model="form.dataFim"
                            full-width
                            color = "brown lighten-2"
                            @click:minute="$refs.dataFim.save(dataFim)"
                        ></v-time-picker>
                    </v-menu>
                </v-col>    
            </v-row>
            <v-card flat height = "10"></v-card>
            <v-card flat>
                <v-row>
                    <v-col cols = "5">
                        <v-text-field
                            :rules="regraVoluntarios"
                            prepend-icon="accessibility_new"
                            label="Número Máximo de Voluntários"
                            color="grey"
                            v-model="form.capacidade"
                            type="number"
                        >
                        </v-text-field>
                    </v-col>
                </v-row>
            </v-card>
            <v-card height = "80" flat></v-card>
            <v-row>
                <v-spacer></v-spacer>
                <v-btn class = "ma-4 mb-12 headline red--text" color="red" outlined text @click="dialog = false">Cancelar</v-btn>
                <v-btn class = "ma-4 mb-12 headline" color="brown lighten-1" text @click="confirma()">Confirmar</v-btn>
            </v-row>
            </v-card>
        </v-card>
    </v-dialog>
    </div>
</template>

<script>
import axios from 'axios'
import store from '@/store.js'
import moment from 'moment/moment';
const lhost = require("@/config/global").host;


export default {
    name: 'Horarios',
    props:['id'],
    data: () => ({             
        items: [],
        dialog: false,
        regraHorario: [v => !!v || "Horários obrigatórios."],
        regraVoluntarios: [v => !!v || "Número de Voluntários obrigatório."],
        dataInicio:null, 
        dataFim:null, 
        menu13:false, 
        menu14:false, 
        diaS:"",
        canil_user_email:"", 
        form:{
            dataInicio:"", 
            dataFim:"",
            capacidade:"",
        }
    }),
    components: { },
    created: async function(){
        try {
            let response = await axios.get(lhost + "/api/Horarios/" + this.id,
            { headers: 
              { "Authorization": 'Bearer ' + store.getters.token }
            });
            this.items = response.data;
            this.ready = true;
        } 
        catch (e) {
            return e;
        } 
    },  
    methods: {
        date: function (date) {
            return moment(date).locale("pt").format('LT');
        },
        dia: function (num) {
            if(num === 1) return "Segunda-feira"
            else if (num === 2) return "Terça-feira";
            else if (num === 3) return "Quarta-feira"; 
            else if (num === 4) return "Quinta-feira"; 
            else if (num === 5) return "Sexta-feira"; 
            else if (num === 6) return "Sábado";
            return "Domingo";
        },
        editaHorario: function(dados){
            this.dataInicio = dados.dataInicio;
            this.dataFim = dados.dataFim;
            this.capacidade = dados.capacidade;
            this.diaS = dados.dia;
            this.canil_user_email = dados.canil_user_email;
            this.dialog = true;
        },
        atualiza: async function(){
            try {
                let response = await axios.get(lhost + "/api/Horarios/" + this.id,
                { headers: 
                    { "Authorization": 'Bearer ' + store.getters.token }
                });
                this.items = response.data;
                this.ready = true;
            } 
            catch (e) {
                if(e.message == "Request failed with status code 401"){
                this.$store.commit("limpaStore");
                this.$router.push("/");
            }
            } 
        },
        confirma:  async function() {
            try{ 
                var resposta = 
                await axios.put(lhost + "/api/Horarios/" + this.id + "/" + this.diaS , 
                {
                    dataInicio: this.form.dataInicio, 
                    dataFim: this.form.dataFim, 
                    capacidade: this.form.capacidade, 
                    registados: 0,
                    dia: this.diaS,
                    canil_user_email: this.id
                },
                { headers: 
                    { "Authorization": 'Bearer ' + store.getters.token }
                });
                console.log(JSON.stringify(resposta.data));
                this.dialog=false;
                this.atualiza();
            }
            catch(e){
               if(e.message == "Request failed with status code 401"){
                this.$store.commit("limpaStore");
                this.$router.push("/");
            }
            }
        },
    },
    computed: {
        sortedArray: function() {
            function compare(a, b) {
            if (a.dia < b.dia)
                return -1;
            if (a.dia > b.dia)
                return 1;
            return 0;
            }

            return this.items.slice(0).sort(compare);
        }
    },     
}
</script>

