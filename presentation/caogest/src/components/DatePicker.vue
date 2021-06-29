<template>
    <div id="data">
        <v-app id="inspire">
            <v-container>
            <v-row>
                <v-col cols="12" lg="6">
                <v-menu
                    v-model="menu2"
                    :close-on-content-click="false"
                    transition="scale-transition"
                    offset-y
                    max-width="290px"
                    min-width="290px"
                >
                    <template v-slot:activator="{ on }">
                    <v-text-field
                        v-model="computedDateFormatted"
                        hint="MM/DD/YYYY"
                        persistent-hint
                        prepend-icon="event"
                        readonly
                        v-on="on"
                    ></v-text-field>
                    </template>
                    <v-date-picker v-model="dataValor" no-title scrollable locale="pt">
                        <v-spacer></v-spacer>
                        <v-btn text color="primary" @click="menu1 = false">Fechar</v-btn>
                        <v-btn text color="primary" @click="dataSelecionada">Selecionar</v-btn>
                    </v-date-picker>
                </v-menu>
                </v-col>
            </v-row>
            </v-container>
        </v-app>
    </div>
</template>