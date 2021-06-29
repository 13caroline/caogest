<template>
    <v-dialog v-model="dialog" persistent width="1000px">
        <template v-slot:activator="{ on }">
            <v-btn block color = "deep-orange lighten-5" light class="ma-5" v-on="on">Editar Horário</v-btn>
        </template>
        <v-card color = "white" fluid class = "mx-auto text-center" flat>
        <v-row align = "center" justify = "center">
            <v-col cols="8" sm="6">
            <v-menu
                ref="dataInicio"
                v-model="dataInicio"
                :close-on-content-click="false"
                :nudge-right="40"
                :return-value.sync="time"
                transition="scale-transition"
                offset-y
                max-width="290px"
                min-width="290px"
            >
                <template v-slot:activator="{ on }">
                <v-text-field
                    v-model="time"
                    label="Hora Início"
                    prepend-icon="access_time"
                    readonly
                    color = "grey"
                    v-on="on"
                ></v-text-field>
                </template>
                <v-time-picker
                v-if="dataInicio"
                v-model="time"
                full-width
                color = "brown lighten-2"
                @click:minute="$refs.menu.save(time)"
                ></v-time-picker>
            </v-menu>
            </v-col>
            <v-spacer></v-spacer>
            <v-col cols="8" sm="6">
            <v-menu
                ref="dataFim"
                v-model="dataFim"
                :close-on-content-click="false"
                :nudge-right="40"
                :return-value.sync="time"
                transition="scale-transition"
                offset-y
                max-width="290px"
                min-width="290px"
            >
                <template v-slot:activator="{ on }">
                <v-text-field
                    v-model="time"
                    label="Hora Fim"
                    prepend-icon="access_time"
                    readonly
                    color = "grey"
                    v-on="on"
                ></v-text-field>
                </template>
                <v-time-picker
                v-if="dataFim"
                v-model="time"
                full-width
                color = "brown lighten-2"
                @click:minute="$refs.menu.save(time)"
                ></v-time-picker>
            </v-menu>
            </v-col>
        </v-row>
        <v-row>
            <v-spacer></v-spacer>
            <v-btn class = "ma-2" color="brown lighten-1" text @click="dialog = false">Cancelar</v-btn>
            <v-btn class = "ma-2" color="brown lighten-1" text @click="dialog = false">Confirmar</v-btn>
        </v-row>
        </v-card>
    </v-dialog>
</template>

<script>
  export default {
    data () {
      return {
        dialog: false,
        time: null,
        dataInicio: false,
        dataFim: false,
      }
    },
  }
</script>