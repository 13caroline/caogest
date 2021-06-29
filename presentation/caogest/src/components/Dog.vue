<template>
    <div id = "dog" class = "dog">
        <v-dialog v-model="dialog" fullscreen hide-overlay transition="dialog-bottom-transition">
            <template v-slot:activator="{ on }">
                <v-btn text v-on="on"> hello </v-btn>  
            </template>
            <v-card class = "ma-2" flat>
                <v-toolbar height = "100" color="deep-orange lighten-4">
                    <v-btn icon @click="dialog = false">
                        <v-icon>mdi-close</v-icon>
                    </v-btn>
                <v-toolbar-title >Fechar</v-toolbar-title>
                </v-toolbar>
                    
                <v-card color = "white" height = "150" flat></v-card>
    
                <v-row>
                    <v-col>
                        <v-card flat color = "white" class = "mx-auto" height = "800" width = "900"> 
                            <v-img height = "800" width = "800" src='../assets/example.jpg'></v-img> 
                            <v-card flat color = "white" height = "100"></v-card>
                            <v-row>
                                <v-btn x-large height = "100" class = "display-2" color = "deep-orange lighten-5" to='/formulario/adocao'> Quero Adotar! </v-btn>
                            </v-row>
                        </v-card>
                    </v-col>

                    <v-col>
                        <v-card flat>
                            <v-row>
                                <p class = " display-2 font-weight-bold" color = "grey"> Nome: 
                                    <span class = "display-2 font-weight-regular ">Balto</span>
                                </p> 
                            </v-row>
                            <v-card flat color = "white" height = "40"></v-card>
                            <v-row>
                                <p class = " display-2 font-weight-bold" color = "grey"> Raça: 
                                    <span class = "display-2 font-weight-regular ">Labrador</span>
                                </p> 
                            </v-row>
                                <v-card flat color = "white" height = "40"></v-card>
                            <v-row>
                                <p class = " display-2 font-weight-bold" color = "grey"> Idade: 
                                    <span class = "display-2 font-weight-regular ">4</span>
                                </p> 
                            </v-row>
                            <v-card flat color = "white" height = "40"></v-card>
                            <v-row>
                                <p class = " display-2 font-weight-bold" color = "grey"> Cor: 
                                    <span class = "display-2 font-weight-regular ">Preto</span>
                                </p> 
                            </v-row>
                            <v-card flat color = "white" height = "40"></v-card>
                            <v-row>
                                <p class = " display-2 font-weight-bold" color = "grey"> Porte: 
                                    <span class = "display-2 font-weight-regular ">Grande</span>
                                </p> 
                            </v-row>
                            <v-card flat color = "white" height = "40"></v-card>
                            <v-row>
                                <p class = " display-2 font-weight-bold" color = "grey"> Sexo: 
                                    <span class = "display-2 font-weight-regular ">Masculino</span>
                                </p> 
                            </v-row>
                                <v-card flat color = "white" height = "40"></v-card>
                            <v-row>
                                <p class = " display-2 font-weight-bold" color = "grey"> Esterilizado: 
                                    <span class = "display-2 font-weight-regular ">Sim</span>
                                </p> 
                            </v-row>
                            <v-card flat color = "white" height = "40"></v-card>
                            <v-row>
                                <p class = " display-2 font-weight-bold" color = "grey"> Descrição: 
                                    <span class = "display-2 font-weight-regular ">O Bolt é um cão tímido mas muito dócil.</span>
                                </p> 
                            </v-row>
                        </v-card>
                    </v-col>
                </v-row>
            </v-card>
        </v-dialog>
    </div>
</template>

<script>
  export default {
    data: () => ({
      dialog: false
    }),
  }
</script>     