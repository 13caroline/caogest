<template>
    <v-row justify="center">
        <v-dialog v-model="dialog" persistent width="800px">
            <template v-slot:activator="{ on }">
                <v-row align = "end" justify= "end">
                    <v-col>
                        <v-btn class="ma-5" text v-on="on">Caixa de Sugestões e Comentários</v-btn>
                    </v-col>
                </v-row>
            </template>
            <v-card>
                <v-card-title>
                    <span class="display-1">Caixa de Sugestões e Comentários</span>
                </v-card-title>
                <v-card-text>
                    <v-container>
                            <v-col>
                                <v-text-field placeholder="Email *" required></v-text-field>
                            </v-col>
                            <v-spacer></v-spacer>
                            <v-col>
                                <v-text-field placeholder="Assunto" required></v-text-field>
                            </v-col>
                            <v-col>
                                <v-select 
                                color = "grey"
                                name="input-7-1"
                                flat 
                                :items="items"
                                label="Motivo do inquérito *"
                                required
                                ></v-select>
                            </v-col>
                            <v-spacer></v-spacer>
                            <v-col>
                                <v-textarea
                                    name="input-7-1"
                                    flat
                                    auto-grow
                                    placeholder = "Mensagem"
                                    color = "grey lighten-1" 
                                    rows = "5"
                                ></v-textarea>
                            </v-col>
                    </v-container>
                    <small>*campos obrigatórios</small>
                    <v-card flat class="mx-auto" height = "30" color = "white"></v-card>
                    <small> Ao preencher este formulário, confirma que tem 16 anos ou mais.</small> 
                </v-card-text>
                <v-card-actions>
                    <v-spacer></v-spacer>
                    <v-btn class="ma-6" large color = "deep-orange lighten-4" @click="dialog = false">Cancelar</v-btn>
                    <v-btn class="ma-6" large color = "deep-orange lighten-4" @click="dialog = false">Confirmar</v-btn>
                </v-card-actions>
            </v-card>
        </v-dialog>
    </v-row>
</template>
  
<script>
  export default {
    data: () => ({
      dialog: false,
      items: [ 
        'Quero fazer um donativo',
        'Quero voluntariar-me para um canil',
        'Quero atualizar os meus dados pessoais',
        'Cuidados com o cão que adotei',
        'Outro',
      ]
    }),
  }
</script>     