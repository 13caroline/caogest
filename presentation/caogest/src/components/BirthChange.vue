<template>
        <v-dialog v-model="dialog" persistent width="800px">
            <template v-slot:activator="{ on }">
                
                        <v-btn class="ma-5" text fab v-on="on">
                          <v-icon x-large color = "grey"> keyboard_arrow_right</v-icon>
                        </v-btn>
                    
            </template>
            <v-card>
                <v-card-title>
                    <span class="display-1">Alterar Data de Nascimento</span>
                </v-card-title>
                <v-card-text>
                    <v-container>
                      <v-row>
                            <v-col cols="12" sm="6" md="4">
                                <v-select
                                :items="dia"
                                label="Dia"
                                required 
                                color = "grey"
                              ></v-select>
                            </v-col>
                            <v-spacer></v-spacer>
                            
                            <v-col cols="12" sm="6" md="4">
                              <v-select
                                :items="mes"
                                label="Mês"
                                required
                                color = "grey"
                              ></v-select>
                            </v-col>
                            <v-spacer></v-spacer>
                            
                            <v-col cols="12" sm="6" md="4">
                              <v-text-field color = "grey" placeholder="Ano" required></v-text-field>
                            </v-col>
                      </v-row>
                    </v-container>
                </v-card-text>
                <v-card-actions>
                    <v-spacer></v-spacer>
                    <v-btn class="ma-6" large rounded color = "deep-orange lighten-4" @click="dialog = false">Cancelar</v-btn>
                    <v-btn class="ma-6" large rounded color = "deep-orange lighten-4" @click="dialog = false">Confirmar</v-btn>
                </v-card-actions>
            </v-card>
        </v-dialog>
</template>
  
<script>
  export default {
    data: () => ({
      dialog: false,
      mes: [ 'janeiro',
             'fevereiro',
             'março',
             'abril',
             'maio',
             'junho',
             'agosto',
             'setembro',
             'outubro',
             'novembro',
             'dezembro',
      ],
      dia: ['01','02','03','04','05','06','07','08','09','10','11','12','13','14','15','16','17','18','19','20','21','22','23','24','25','26','27','28','29','30','31']
    }),
  }
</script>     