<template>
        <v-dialog v-model="dialog" persistent width="800px">
            <template v-slot:activator="{ on }">
                
                        <v-btn class="ma-5" text fab v-on="on">
                          <v-icon x-large color = "grey"> keyboard_arrow_right</v-icon>
                        </v-btn>
                    
            </template>
            <v-card>
               <v-card flat color = "deep-orange lighten-4" class = "pa-6">
                    <span class="display-1" dark>Alterar Capacidade</span>
                </v-card>
                <v-card-text>
                    <v-container>
                            <v-col>
                                <v-text-field color = "grey" placeholder="Nova Capacidade Total" required></v-text-field>
                            </v-col>

                            <v-col>
                                <v-text-field color = "grey" placeholder="Nova Capacidade Atual" required></v-text-field>
                            </v-col>
                    </v-container>
                </v-card-text>
                <v-card-actions>
                    <v-spacer></v-spacer>
                    <v-btn class="ma-6" large color = "deep-orange lighten-4" @click="dialog = false">Cancelar</v-btn>
                    <v-btn class="ma-6" large color = "deep-orange lighten-4" @click="dialog = false">Confirmar</v-btn>
                </v-card-actions>
            </v-card>
        </v-dialog>
</template>
  
<script>
  export default {
    data: () => ({
      dialog: false,
    }),
  }
</script>     