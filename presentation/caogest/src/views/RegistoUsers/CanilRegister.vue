<template>
    <div id = "canilRegister">
        <v-toolbar flat color="white" height=150px>
        <v-img src="@/assets/logoA5.png" max-height=150px max-width=150px></v-img>
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
                    <v-card flat>
                        <v-form ref="form" lazy-validation>
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
                                            v-model="form.email"
                                            :rules="regraEmail"
                                            name="email"
                                            type="email"
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
                                        v-model="form.password"
                                        :rules="regraPassword"
                                        maxlength="32"
                                        :type="show1 ? 'text' : 'password'"
                                        name="password" 
                                        @click:append="show1 = !show1"
                                        :append-icon="show1 ? 'mdi-eye' : 'mdi-eye-off'"
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
                                        v-model="form.nome"
                                        :rules="regraNome"
                                        name="nome"
                                        type="nome"
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
                                        v-model="form.rua"
                                        :rules="regraRua"
                                        name="rua"
                                        type="rua"
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
                                            v-model="form.localidade"
                                            :rules="regraLocalidade"
                                            name="localidade"
                                            type="localidade"
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
                                        flat outlined 
                                        placeholder="Selecione o distrito onde reside"
                                        :items="distritos"
                                        rounded
                                        v-model="form.distrito"
                                        :rules="regraDistrito"
                                        name="distrito"
                                        type="distrito"
                                    ></v-select>
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
                                        v-model="form.capacidadeTotal"
                                        :rules="regraCapacidadeTotal"
                                        name="capacidadeTotal"
                                        type="number"
                                    ></v-text-field>
                                </v-col>
                            </v-row>
                            
                            <v-row>
                                <v-col cols="2">
                                    <div class="info-label headline">Ocupação Atual</div>
                                </v-col>
                                <v-col>
                                    <v-text-field 
                                        rounded 
                                        outlined 
                                        flat 
                                        color = "grey lighten-1"  
                                        required 
                                        placeholder="Introduza a capacidade total do canil"
                                        v-model="form.capacidadeOcupada"
                                        :rules="regraCapacidadeOcupada"
                                        name="capacidadeOcupada"
                                        type="number"
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
                                        v-model="form.nib"
                                        :rules="regraNIB"
                                        name="nib"
                                        type="number"
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
                                        placeholder="Introduza o seu contacto"
                                        v-model="form.contacto"
                                        :rules="regraContacto"
                                        name="contacto"
                                        type="number"
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
                                    <v-row>
                                        <v-col cols = "6">
                                            <v-menu
                                                ref="dataInicio1"
                                                v-model="menu1"
                                                :close-on-content-click="false"
                                                :nudge-right="40"
                                                :return-value.sync="dataInicio1"
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
                                                        readonly
                                                        color = "grey"
                                                        v-on="on"
                                                        v-model="form.dataInicio1"
                                                    ></v-text-field>
                                                </template>
                                                    <v-time-picker
                                                        format="24hr"
                                                        v-model="form.dataInicio1"
                                                        full-width
                                                        color = "brown lighten-2"
                                                        @click:minute="$refs.dataInicio1.save(dataInicio1)"
                                                    ></v-time-picker>
                                            </v-menu>
                                        </v-col>
                                     
                                        <v-col cols = "6">
                                            <v-menu
                                                ref="dataFim1"
                                                v-model="menu2"
                                                :close-on-content-click="false"
                                                :nudge-right="40"
                                                :return-value.sync="dataFim1"
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
                                                        readonly
                                                        color = "grey"
                                                        v-on="on"
                                                        v-model="form.dataFim1"
                                                    ></v-text-field>
                                                </template>
                                                    <v-time-picker
                                                        format="24hr"
                                                        v-model="form.dataFim1"
                                                        full-width
                                                        color = "brown lighten-2"
                                                        @click:minute="$refs.dataFim1.save(dataFim1)"
                                                    ></v-time-picker>
                                            </v-menu>
                                        </v-col>    
                                    </v-row>
                                </v-col>
                            </v-row>

                            <v-row>
                                <v-col cols="2">
                                    <div class="info-label">Número Voluntários</div>
                                </v-col>
                                <v-col>
                                    <v-text-field 
                                        rounded 
                                        outlined 
                                        flat 
                                        color = "grey lighten-1"  
                                        required 
                                        placeholder="Introduza o número máximo de voluntários para o horário de Segunda-feira"
                                        v-model="form.capacidade1"
                                        :rules="regraCapacidade"
                                        name="capacidade1"
                                        type="number"
                                    ></v-text-field>
                                </v-col>
                            </v-row>

                            <v-row>
                                <v-col cols = "2">
                                    <div class = "info-label"> Terça-feira</div>
                                </v-col>
                                <v-col>
                                    <v-row>
                                        <v-col cols = "6">
                                            <v-menu
                                                ref="dataInicio2"
                                                v-model="menu3"
                                                :close-on-content-click="false"
                                                :nudge-right="40"
                                                :return-value.sync="dataInicio2"
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
                                                        readonly
                                                        color = "grey"
                                                        v-on="on"
                                                        v-model="form.dataInicio2"
                                                    ></v-text-field>
                                                </template>
                                                    <v-time-picker
                                                        format="24hr"
                                                        v-model="form.dataInicio2"
                                                        full-width
                                                        color = "brown lighten-2"
                                                        @click:minute="$refs.dataInicio2.save(dataInicio2)"
                                                    ></v-time-picker>
                                            </v-menu>
                                        </v-col>
                                     
                                        <v-col cols = "6">
                                            <v-menu
                                                ref="dataFim2"
                                                v-model="menu4"
                                                :close-on-content-click="false"
                                                :nudge-right="40"
                                                :return-value.sync="dataFim2"
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
                                                        readonly
                                                        color = "grey"
                                                        v-on="on"
                                                        v-model="form.dataFim2"
                                                    ></v-text-field>
                                                </template>
                                                    <v-time-picker
                                                        format="24hr"
                                                        v-model="form.dataFim2"
                                                        full-width
                                                        color = "brown lighten-2"
                                                        @click:minute="$refs.dataFim2.save(dataFim2)"
                                                    ></v-time-picker>
                                            </v-menu>
                                        </v-col>    
                                    </v-row>
                                </v-col>
                            </v-row>

                             <v-row>
                                <v-col cols="2">
                                    <div class="info-label">Número Voluntários</div>
                                </v-col>
                                <v-col>
                                    <v-text-field 
                                        rounded 
                                        outlined 
                                        flat 
                                        color = "grey lighten-1"  
                                        required 
                                        placeholder="Introduza o número máximo de voluntários para o horário de Terça-feira"
                                        v-model="form.capacidade2"
                                        :rules="regraCapacidade"
                                        name="capacidade2"
                                        type="number"
                                    ></v-text-field>
                                </v-col>
                            </v-row>

                            <v-row>
                                <v-col cols = "2">
                                    <div class = "info-label"> Quarta-feira</div>
                                </v-col>
                                <v-col>
                                    <v-row>
                                        <v-col cols = "6">
                                            <v-menu
                                                ref="dataInicio3"
                                                v-model="menu5"
                                                :close-on-content-click="false"
                                                :nudge-right="40"
                                                :return-value.sync="dataInicio3"
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
                                                        readonly
                                                        color = "grey"
                                                        v-on="on"
                                                        v-model="form.dataInicio3"
                                                    ></v-text-field>
                                                </template>
                                                    <v-time-picker
                                                        format="24hr"
                                                        v-model="form.dataInicio3"
                                                        full-width
                                                        color = "brown lighten-2"
                                                        @click:minute="$refs.dataInicio3.save(dataInicio3)"
                                                    ></v-time-picker>
                                            </v-menu>
                                        </v-col>
                                     
                                        <v-col cols = "6">
                                            <v-menu
                                                ref="dataFim3"
                                                v-model="menu6"
                                                :close-on-content-click="false"
                                                :nudge-right="40"
                                                :return-value.sync="dataFim3"
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
                                                        readonly
                                                        color = "grey"
                                                        v-on="on"
                                                        v-model="form.dataFim3"
                                                    ></v-text-field>
                                                </template>
                                                    <v-time-picker
                                                        format="24hr"
                                                        v-model="form.dataFim3"
                                                        full-width
                                                        color = "brown lighten-2"
                                                        @click:minute="$refs.dataFim3.save(dataFim3)"
                                                    ></v-time-picker>
                                            </v-menu>
                                        </v-col>    
                                    </v-row>
                                </v-col>
                            </v-row>
                                
                             <v-row>
                                <v-col cols="2">
                                    <div class="info-label">Número Voluntários</div>
                                </v-col>
                                <v-col>
                                    <v-text-field 
                                        rounded 
                                        outlined 
                                        flat 
                                        color = "grey lighten-1"  
                                        required 
                                        placeholder="Introduza o número máximo de voluntários para o horário de Quarta-feira"
                                        v-model="form.capacidade3"
                                        :rules="regraCapacidade"
                                        name="capacidade3"
                                        type="number"
                                    ></v-text-field>
                                </v-col>
                            </v-row>

                            <v-row>
                                <v-col cols = "2">
                                    <div class = "info-label"> Quinta-feira</div>
                                </v-col>
                                <v-col>
                                    <v-row>
                                        <v-col cols = "6">
                                            <v-menu
                                                ref="dataInicio4"
                                                v-model="menu7"
                                                :close-on-content-click="false"
                                                :nudge-right="40"
                                                :return-value.sync="dataInicio4"
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
                                                        readonly
                                                        color = "grey"
                                                        v-on="on"
                                                        v-model="form.dataInicio4"
                                                    ></v-text-field>
                                                </template>
                                                    <v-time-picker
                                                        format="24hr"
                                                        v-model="form.dataInicio4"
                                                        full-width
                                                        color = "brown lighten-2"
                                                        @click:minute="$refs.dataInicio4.save(dataInicio4)"
                                                    ></v-time-picker>
                                            </v-menu>
                                        </v-col>
                                     
                                        <v-col cols = "6">
                                            <v-menu
                                                ref="dataFim4"
                                                v-model="menu8"
                                                :close-on-content-click="false"
                                                :nudge-right="40"
                                                :return-value.sync="dataFim4"
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
                                                        readonly
                                                        color = "grey"
                                                        v-on="on"
                                                        v-model="form.dataFim4"
                                                    ></v-text-field>
                                                </template>
                                                    <v-time-picker
                                                        format="24hr"
                                                        v-model="form.dataFim4"
                                                        full-width
                                                        color = "brown lighten-2"
                                                        @click:minute="$refs.dataFim4.save(dataFim4)"
                                                    ></v-time-picker>
                                            </v-menu>
                                        </v-col>    
                                    </v-row>
                                </v-col>
                            </v-row>

                             <v-row>
                                <v-col cols="2">
                                    <div class="info-label">Número Voluntários</div>
                                </v-col>
                                <v-col>
                                    <v-text-field 
                                        rounded 
                                        outlined 
                                        flat 
                                        color = "grey lighten-1"  
                                        required 
                                        placeholder="Introduza o número máximo de voluntários para o horário de Quinta-feira"
                                        v-model="form.capacidade4"
                                        :rules="regraCapacidade"
                                        name="capacidade4"
                                        type="number"
                                    ></v-text-field>
                                </v-col>
                            </v-row>
                            
                            <v-row>
                                <v-col cols = "2">
                                    <div class = "info-label"> Sexta-feira</div>
                                </v-col>
                                <v-col>
                                     <v-row>
                                        <v-col cols = "6">
                                            <v-menu
                                                ref="dataInicio5"
                                                v-model="menu9"
                                                :close-on-content-click="false"
                                                :nudge-right="40"
                                                :return-value.sync="dataInicio5"
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
                                                        readonly
                                                        color = "grey"
                                                        v-on="on"
                                                        v-model="form.dataInicio5"
                                                    ></v-text-field>
                                                </template>
                                                    <v-time-picker
                                                        format="24hr"
                                                        v-model="form.dataInicio5"
                                                        full-width
                                                        color = "brown lighten-2"
                                                        @click:minute="$refs.dataInicio5.save(dataInicio5)"
                                                    ></v-time-picker>
                                            </v-menu>
                                        </v-col>
                                     
                                        <v-col cols = "6">
                                            <v-menu
                                                ref="dataFim5"
                                                v-model="menu10"
                                                :close-on-content-click="false"
                                                :nudge-right="40"
                                                :return-value.sync="dataFim5"
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
                                                        readonly
                                                        color = "grey"
                                                        v-on="on"
                                                        v-model="form.dataFim5"
                                                    ></v-text-field>
                                                </template>
                                                    <v-time-picker  
                                                        format="24hr"
                                                        v-model="form.dataFim5"
                                                        full-width
                                                        color = "brown lighten-2"
                                                        @click:minute="$refs.dataFim5.save(dataFim5)"
                                                    ></v-time-picker>
                                            </v-menu>
                                        </v-col>    
                                    </v-row>
                                </v-col>
                            </v-row>

                            <v-row>
                                <v-col cols="2">
                                    <div class="info-label">Número Voluntários</div>
                                </v-col>
                                <v-col>
                                    <v-text-field 
                                        rounded 
                                        outlined 
                                        flat 
                                        color = "grey lighten-1"  
                                        required 
                                        placeholder="Introduza o número máximo de voluntários para o horário de Sexta-feira"
                                        v-model="form.capacidade5"
                                        :rules="regraCapacidade"
                                        name="capacidade5"
                                        type="number"
                                    ></v-text-field>
                                </v-col>
                            </v-row>

                           <v-row>
                                <v-col cols = "2">
                                    <div class = "info-label"> Sábado</div>
                                </v-col>
                                <v-col>
                                     <v-row>
                                        <v-col cols = "6">
                                            <v-menu
                                                ref="dataInicio6"
                                                v-model="menu11"
                                                :close-on-content-click="false"
                                                :nudge-right="40"
                                                :return-value.sync="dataInicio6"
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
                                                        readonly
                                                        color = "grey"
                                                        v-on="on"
                                                        v-model="form.dataInicio6"
                                                    ></v-text-field>
                                                </template>
                                                    <v-time-picker
                                                        format="24hr"
                                                        v-model="form.dataInicio6"
                                                        full-width
                                                        color = "brown lighten-2"
                                                        @click:minute="$refs.dataInicio6.save(dataInicio6)"
                                                    ></v-time-picker>
                                            </v-menu>
                                        </v-col>
                                     
                                        <v-col cols = "6">
                                            <v-menu
                                                ref="dataFim6"
                                                v-model="menu12"
                                                :close-on-content-click="false"
                                                :nudge-right="40"
                                                :return-value.sync="dataFim6"
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
                                                        readonly
                                                        color = "grey"
                                                        v-on="on"
                                                        v-model="form.dataFim6"
                                                    ></v-text-field>
                                                </template>
                                                    <v-time-picker  
                                                        format="24hr"
                                                        v-model="form.dataFim6"
                                                        full-width
                                                        color = "brown lighten-2"
                                                        @click:minute="$refs.dataFim6.save(dataFim6)"
                                                    ></v-time-picker>
                                            </v-menu>
                                        </v-col>    
                                    </v-row>
                                </v-col>
                            </v-row>

                             <v-row>
                                <v-col cols="2">
                                    <div class="info-label">Número Voluntários</div>
                                </v-col>
                                <v-col>
                                    <v-text-field 
                                        rounded 
                                        outlined 
                                        flat 
                                        color = "grey lighten-1"  
                                        required 
                                        placeholder="Introduza o número máximo de voluntários para o horário de Sábado"
                                        v-model="form.capacidade6"
                                        :rules="regraCapacidade"
                                        name="capacidade6"
                                        type="number"
                                    ></v-text-field>
                                </v-col>
                            </v-row>

                            <v-row>
                                <v-col cols = "2">
                                    <div class = "info-label"> Domingo</div>
                                </v-col>
                                <v-col>
                                    <v-row>
                                        <v-col cols = "6">
                                            <v-menu
                                                ref="dataInicio7"
                                                v-model="menu13"
                                                :close-on-content-click="false"
                                                :nudge-right="40"
                                                :return-value.sync="dataInicio7"
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
                                                        readonly
                                                        color = "grey"
                                                        v-on="on"
                                                        v-model="form.dataInicio7"
                                                    ></v-text-field>
                                                </template>
                                                    <v-time-picker
                                                        format="24hr"
                                                        v-model="form.dataInicio7"
                                                        full-width
                                                        color = "brown lighten-2"
                                                        @click:minute="$refs.dataInicio7.save(dataInicio7)"
                                                    ></v-time-picker>
                                            </v-menu>
                                        </v-col>
                                     
                                        <v-col cols = "6">
                                            <v-menu
                                                ref="dataFim7"
                                                v-model="menu14"
                                                :close-on-content-click="false"
                                                :nudge-right="40"
                                                :return-value.sync="dataFim7"
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
                                                        readonly
                                                        color = "grey"
                                                        v-on="on"
                                                        v-model="form.dataFim7"
                                                    ></v-text-field>
                                                </template>
                                                    <v-time-picker
                                                        format="24hr"
                                                        v-model="form.dataFim7"
                                                        full-width
                                                        color = "brown lighten-2"
                                                        @click:minute="$refs.dataFim7.save(dataFim7)"
                                                    ></v-time-picker>
                                            </v-menu>
                                        </v-col>    
                                    </v-row>
                                </v-col>
                            </v-row>

                             <v-row>
                                <v-col cols="2">
                                    <div class="info-label">Número Voluntários</div>
                                </v-col>
                                <v-col>
                                    <v-text-field 
                                        rounded 
                                        outlined 
                                        flat 
                                        color = "grey lighten-1"  
                                        required 
                                        placeholder="Introduza o número máximo de voluntários para o horário de Domingo"
                                        v-model="form.capacidade7"
                                        :rules="regraCapacidade"
                                        name="capacidade7"
                                        type="number"
                                    ></v-text-field>
                                </v-col>
                            </v-row>
                            
                            <v-card flat height= "20" color = "white"></v-card>
                            <v-row justify = "end">
                                <v-col cols = "12" md = "8">
                                    <v-row justify= "end">
                                        <v-btn class="ma-6 red--text" type="button" x-large color = "red" outlined @click="cancelar">Cancelar</v-btn>
                                        <v-btn class = "ma-6" type="button" x-large color = "deep-orange lighten-4" @click="registarCanil">Registar</v-btn>
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
                                    </v-row>
                                </v-col>
                            </v-row>
                        </v-card-text>
                        </v-form>
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
import axios from 'axios'
const lhost = require("@/config/global").host;
import store from '@/store.js'

export default {
    name: "CanilRegister",
    data () {
      return {
        show1: false, 
        password: 'Password',
        dataInicio1: null,
        dataFim1: null,
        dataInicio2: null, 
        dataFim2: null, 
        dataInicio3: null, 
        dataFim3: null, 
        dataInicio4:null, 
        dataFim4:null, 
        dataInicio5:null, 
        dataFim5:null, 
        dataInicio6:null, 
        dataFim6:null,
        dataInicio7:null, 
        dataFim7:null, 
        menu1:false, 
        menu2:false, 
        menu3:false, 
        menu4:false, 
        menu5:false, 
        menu6:false, 
        menu7:false, 
        menu8:false, 
        menu9:false, 
        menu10:false, 
        menu11:false, 
        menu12:false, 
        menu13:false, 
        menu14:false, 
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
        ],
        dialog: false,
        regraNome: [v => !!v || "Nome obrigatório."],
        regraEmail:[value => {
            const pattern = /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/
            return pattern.test(value) || 'Email inválido'
          },
        ], 
        regraPassword: [v => !!v || "Palavra-passe obrigatória."],
        regraRua: [v => !!v || "Morada obrigatória."],
        regraDistrito: [v => !!v || "Distrito obrigatório."],
        regraNIB: [v => !!v || "Introduza um número de identificação bancária válido."],
        regraLocalidade: [v => !!v || "Concelho obrigatório."],
        regraCapacidadeTotal: [v => !!v || "Introduza uma capacidade total válida."], 
        regraCapacidadeOcupada: [v => !!v || "Introduza uma ocupação atual válida."], 
        regraContacto: [v => !!v || "Introduza um contacto válido."],
        regraHorario: [v => !!v || "Horários obrigatórios."],
        regraCapacidade: [v => !!v || "Introduza um número de voluntários válido."],
        form: {
            nome: "",
            email: "", 
            password: "", 
            rua: "", 
            localidade: "", 
            nib: "", 
            distrito: "",
            capacidadeTotal: "",  
            capcidadeOcupada: "", 
            contacto:"",
            dataInicio1:"", 
            dataFim1:"", 
            dataInicio2:"", 
            dataFim2:"", 
            dataInicio3:"", 
            dataFim3:"", 
            dataInicio4:"", 
            dataFim4:"",
            dataInicio5:"", 
            dataFim5:"",
            dataInicio6:"", 
            dataFim6:"",
            dataInicio7:"", 
            dataFim7:"",
            capacidade1:"", 
            capacidade2:"", 
            capacidade3:"", 
            capacidade4:"", 
            capacidade5:"", 
            capacidade6:"",
            capacidade7:"", 
            tipo: 2,
            estado: "Pendente",
        }, 
     
        snackbar: false, 
        color: "", 
        done: false, 
        timeout: 0,
        text: "",  
      }
    }, 
    methods: {
      registarCanil: async function(){
      if (this.$refs.form.validate()) {
         try{ 
          var resposta = 
            await axios.post(lhost + "/api/Canis", 
            {
              email: this.form.email,
              password: this.form.password,
              tipo: this.form.tipo,
              nome: this.form.nome,
              distrito: this.form.distrito,
              rua: this.form.rua,
              localidade: this.form.localidade,
              nib: this.form.nib,
              contacto: this.form.contacto, 
              capacidadeTotal: parseInt(this.form.capacidadeTotal,10), 
              capacidadeOcupada: parseInt(this.form.capacidadeOcupada,10),
              dataInicio1: this.form.dataInicio1,
              dataFim1: this.form.dataFim1, 
              dataInicio2: this.form.dataInicio2,
              dataFim2: this.form.dataFim2, 
              dataInicio3: this.form.dataInicio3,
              dataFim3: this.form.dataFim3, 
              dataInicio4: this.form.dataInicio4,
              dataFim4: this.form.dataFim4, 
              dataInicio5: this.form.dataInicio5,
              dataFim5: this.form.dataFim5, 
              dataInicio6: this.form.dataInicio6,
              dataFim6: this.form.dataFim6, 
              dataInicio7: this.form.dataInicio7,
              dataFim7: this.form.dataFim7, 
              capacidade1:this.form.capacidade1, 
              capacidade2:this.form.capacidade2, 
              capacidade3:this.form.capacidade3,  
              capacidade4:this.form.capacidade4, 
              capacidade5:this.form.capacidade5, 
              capacidade6:this.form.capacidade6,
              capacidade7:this.form.capacidade7, 
              estado:this.form.estado,
            },
            { headers: 
                { "Authorization": 'Bearer ' + store.getters.token }
            }); 
            console.log(JSON.stringify(resposta.data));
            this.text = "Canil criado com sucesso!";
            this.color = "success"; 
            this.snackbar = true; 
          }
          catch(e){
            console.log("erro: " + e);
            this.text = "Ocorreu um erro no registo, por favor tente mais tarde!";
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
        this.$router.push("/");
    },
    cancelar() {
      this.$router.push("/");
    },
  },
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