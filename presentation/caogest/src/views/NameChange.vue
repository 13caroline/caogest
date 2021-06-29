<template>
    <div id="namechange">  
        <v-row justify="center">
            <v-dialog v-model="dialog" fullscreen hide-overlay transition="dialog-bottom-transition">
            <v-card>
                <v-toolbar dark color="primary">
                <v-btn icon dark @click="dialog = false">
                    <v-icon>keyboard_backspace</v-icon>
                </v-btn>
                <v-toolbar-title>Nome</v-toolbar-title>
                <v-spacer></v-spacer>
                <v-toolbar-items>
                    <v-btn dark text @click="dialog = false">Guardar</v-btn>
                </v-toolbar-items>
                </v-toolbar>
                
                <v-card class = "mx-auto" max-width = "1500" fluid outlined rounded>
                    <v-text-field 
                        outlined 
                        placeholder="Carolina Cunha"
                        color = "grey">
                        <v-icon right>create</v-icon>
                    </v-text-field>
                </v-card>
            </v-card>
            </v-dialog>
        </v-row>
    </div>
</template>

<script>
  export default {
    data () {
      return {
        dialog: false,
        notifications: false,
        sound: false,
        widgets: false,
      }
    },
  }
</script>