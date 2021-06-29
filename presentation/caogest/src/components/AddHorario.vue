<template>
    <div>
        <v-row>
        <v-col cols = "6">
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
        
            
        <v-col cols = "6">
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
    </div>
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