<template>
    <div id = "canilRegister">
        <v-toolbar flat color="white" height=150px>
        <v-img src="../assets/logoA5.png" max-height=150px max-width=150px></v-img>
        </v-toolbar>

  <v-row class="ma-2">
    <v-col>
      <v-card flat>
        <!-- Header -->
        <v-app-bar flat height=100px color="deep-orange lighten-4">
          <v-toolbar-title class="card-heading">Registar Canil</v-toolbar-title>
        </v-app-bar>
        <v-card flat height= "80" color = "white"></v-card>
        <!-- Content -->
        <v-container grid-list-md text-xl-left>
            <v-layout row wrap>
              <v-flex xs12>
                    <v-card ref="form" flat>
                        <v-card-text>
                            <v-row>
                                <v-col cols="2">
                                    <div class="info-label headline ">
                                        E-mail
                                    </div>
                                    
                                    </v-col>
                                    <v-col>
                                        <v-text-field 
                                            rounded 
                                            outlined 
                                            flat 
                                            color = "grey lighten-1" 
                                            required 
                                            placeholder="Introduza o e-mail do canil"
                                        ></v-text-field>
                                </v-col>
                            </v-row>
                            
                            <v-row>
                                <v-col cols="2">
                                <div class="info-label headline">
                                    Palavra-passe
                                </div>
                                </v-col>
                                <v-col>
                                    <v-text-field 
                                        rounded 
                                        outlined 
                                        flat  
                                        required
                                        placeholder="Introduza uma palavra-passe"
                                        color = "grey lighten-1" 
                                        v-model="password"
                                            :type="show1 ? 'text' : 'password'"
                                            name="input-10-1" 
                                    ></v-text-field>
                                </v-col>
                            </v-row>
                            
                            <v-row>
                                <v-col cols="2">
                                    <div class="info-label headline">Nome</div>
                                </v-col>
                                <v-col>
                                    <v-text-field 
                                        rounded 
                                        outlined  
                                        flat  
                                        color = "grey lighten-1"  
                                        required 
                                        placeholder="Introduza o nome do canil"
                                ></v-text-field>
                                </v-col>
                            </v-row>
                            
                            <v-row>
                                <v-col cols="2">
                                    <div class="info-label headline">Morada</div>
                                </v-col>
                                <v-col>
                                    <v-text-field 
                                        rounded 
                                        outlined 
                                        flat 
                                        color = "grey lighten-1"  
                                        required 
                                        placeholder="Introduza a morada do canil"
                                    ></v-text-field>
                                </v-col>
                            </v-row>
                            
                            <v-row>
                                <v-col cols="2">
                                    <div class="info-label headline">Concelho</div>
                                </v-col>
                                <v-col>
                                    <v-text-field 
                                        rounded 
                                        outlined 
                                        flat 
                                        color = "grey lighten-1"  
                                        required 
                                        placeholder="Introduza o concelho onde se localiza o canil"
                                    ></v-text-field>
                                </v-col>
                            </v-row>
                            
                            <v-row>
                                <v-col cols="2">
                                    <div class="info-label headline">Distrito</div>
                                </v-col>
                                <v-col>
                                    <v-select 
                                        color = "grey"
                                        name="input-7-1"
                                        flat outlined 
                                        placeholder="Selecione o distrito onde reside"
                                        :items="distritos"
                                        rounded
                                    ></v-select>
                                </v-col>
                            </v-row>
                           
                            <v-row>
                                <v-col cols="2">
                                    <div class="info-label headline">Código Postal</div>
                                </v-col>
                                <v-col>
                                    <v-text-field 
                                        rounded 
                                        outlined 
                                        flat 
                                        color = "grey lighten-1"  
                                        required 
                                        persistent-hint
                                        placeholder="0000-000"
                                    ></v-text-field>
                                </v-col>
                            </v-row>
                            
                            <v-row>
                                <v-col cols="2">
                                    <div class="info-label headline">Capacidade Total</div>
                                </v-col>
                                <v-col>
                                    <v-text-field 
                                        rounded 
                                        outlined 
                                        flat 
                                        color = "grey lighten-1"  
                                        required 
                                        placeholder="Introduza a capacidade total do canil"
                                    ></v-text-field>
                                </v-col>
                            </v-row>
                            
                            <v-row>
                                <v-col cols="2">
                                    <div class="info-label headline">Capacidade Atual</div>
                                </v-col>
                                <v-col>
                                    <v-text-field 
                                        rounded 
                                        outlined 
                                        flat 
                                        color = "grey lighten-1"  
                                        required 
                                        placeholder="Introduza a capacidade total do canil"
                                    ></v-text-field>
                                </v-col>
                            </v-row>
                            
                            <v-row>
                                <v-col cols="2">
                                    <div class="info-label headline">NIB</div>
                                </v-col>
                                <v-col>
                                    <v-text-field 
                                        rounded 
                                        outlined 
                                        flat 
                                        color = "grey lighten-1"  
                                        required 
                                        placeholder="Introduza o NIB do canil"
                                    ></v-text-field>
                                </v-col>
                            </v-row>
                            
                            <v-row>
                                <v-col cols="2">
                                    <div class="info-label headline">Contacto</div>
                                </v-col>
                                <v-col>
                                    <v-text-field 
                                        rounded 
                                        outlined 
                                        flat 
                                        color = "grey lighten-1"  
                                        required 
                                        placeholder="Introduza um contacto do canil"
                                    ></v-text-field>
                                </v-col>
                            </v-row>
                            
                            <v-row>
                                <v-col cols="6">
                                    <div class="info-label headline">Horário de Funcionamento</div>
                                </v-col>
                                
                            </v-row>
                                    
                            <v-row>
                                <v-col cols = "2">
                                    <div class = "info-label"> Segunda-feira</div>
                                </v-col>
                                <v-col>
                                    <AddHorario/>
                                </v-col>
                            </v-row>

                            <v-row>
                                <v-col cols = "2">
                                    <div class = "info-label"> Terça-feira</div>
                                </v-col>
                                <v-col>
                                    <AddHorario/>
                                </v-col>
                            </v-row>

                            <v-row>
                                <v-col cols = "2">
                                    <div class = "info-label"> Quarta-feira</div>
                                </v-col>
                                <v-col>
                                    <AddHorario/>
                                </v-col>
                            </v-row>
                                
                            <v-row>
                                <v-col cols = "2">
                                    <div class = "info-label"> Quinta-feira</div>
                                </v-col>
                                <v-col>
                                    <AddHorario/>
                                </v-col>
                            </v-row>
                            
                            <v-row>
                                <v-col cols = "2">
                                    <div class = "info-label"> Sexta-feira</div>
                                </v-col>
                                <v-col>
                                    <AddHorario/>
                                </v-col>
                            </v-row>

                            <v-row>
                                <v-col cols = "2">
                                    <div class = "info-label"> Sábado</div>
                                </v-col>
                                <v-col>
                                    <AddHorario/>
                                </v-col>
                            </v-row>

                            <v-row>
                                <v-col cols = "2">
                                    <div class = "info-label"> Domingo</div>
                                </v-col>
                                <v-col>
                                    <AddHorario/>
                                </v-col>
                            </v-row>
                            
                            <v-row>
                                <v-col cols="2">
                                    <div class="info-label headline"> Notas Adicionais </div>
                                </v-col>
                                <v-col>
                                    <v-textarea
                                        flat
                                        outlined
                                        rounded
                                        auto-grow
                                        placeholder = "Introduza informações que considere relevantes"
                                        color = "grey lighten-1" 
                                        rows = "5"
                                    ></v-textarea>
                                </v-col>
                            </v-row>
                            <v-card flat height= "20" color = "white"></v-card>
                            <v-row justify = "end">
                                <v-col cols = "12" md = "8">
                                    <v-row justify= "end">
                                        <v-btn class="ma-6" x-large color = "deep-orange lighten-4" to = "/">Cancelar</v-btn>
                                        <v-btn class = "ma-6" x-large color = "deep-orange lighten-4" @click="snackbar = true">Registar</v-btn>
                                            <v-snackbar
                                                v-model="snackbar"
                                                multi-line = "true"
                                                class = "bottom"
                                                color = "green"
                                                timeout = "10000"
                                            >
                                                Pedido de Registo enviado com sucesso
                                                <v-btn
                                                icon
                                                dark
                                                text
                                                @click="snackbar = false"
                                                to='/'
                                                >
                                                Sair
                                                <v-icon right>close</v-icon>
                                                
                                                </v-btn>
                                            </v-snackbar>
                                    </v-row>
                                </v-col>
                            </v-row>
                        </v-card-text>
                    </v-card>
                </v-flex>
                </v-layout>
            </v-container>
        </v-card>
        </v-col>
    </v-row>
  </div>
</template>

<script>
import AddHorario from '../components/AddHorario.vue'

export default {
    data () {
      return {
        show1: false, 
        password: 'Password',
        snackbar: false,
        distritos: [
            'Angra do Heroísmo',
            'Aveiro',
            'Beja',
            'Braga',
            'Bragança',
            'Castelo Branco',
            'Coimbra',
            'Évora',
            'Faro',
            'Funchal',
            'Guarda',
            'Horta',
            'Leiria',
            'Lisboa',
            'Ponta Delgada',
            'Portalegre',
            'Porto',
            'Santarém',
            'Setúbal',
            'Viana do Castelo',
            'Viseu',
        ] 
      }
    }, 
    components: {AddHorario}
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