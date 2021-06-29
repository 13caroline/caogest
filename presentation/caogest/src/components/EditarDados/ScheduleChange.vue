<template>
    <div id = "dog" class = "dog">
        <v-dialog v-model="dialog" fullscreen hide-overlay transition="dialog-bottom-transition">
            <template v-slot:activator="{ on }">
                <v-btn text v-on="on"> Editar Horários </v-btn>  
            </template>
            <v-card class = "ma-2" flat>
                <v-toolbar height = "100" color="deep-orange lighten-4">
                    <v-btn icon @click="dialog = false">
                        <v-icon>mdi-close</v-icon>
                    </v-btn>
                <v-toolbar-title >Fechar</v-toolbar-title>
                </v-toolbar>
                    
                <v-card color = "white" height = "150" flat></v-card>
            </v-card>    
        </v-dialog>
    </div>
</template>