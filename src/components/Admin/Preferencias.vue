<template>
    <div>
                <v-card flat class="mx-auto" max-width="1500" fluid>
                    <p class = " pa-8 display-1 font-weight-regular" color = "grey darken-4"> Informações de Contacto </p>
                </v-card>
                <v-card flat height= "100" color = "white"></v-card>    

                <v-card class = "mx-auto" max-width = "1500" fluid outlined rounded>    
                    <v-row>
                        <v-col>
                            <p
                                class = " pa-8 headline font-weight-regular" 
                                color = "grey"
                            > EMAIL 
                            </p> 
                        </v-col>
                        <v-spacer></v-spacer>
                        <v-col>
                            <p 
                                class = " pa-8 headline font-weight-regular" 
                                color = "grey darken-4">
                                admincaogest@caogest.pt
                            </p>
                        </v-col>
                        <v-spacer></v-spacer>
                        <v-col>
                            <v-btn class="ma-5" disabled text fab></v-btn>
                        </v-col>
                    </v-row>

                    <v-row>
                       <v-col>
                            <p 
                                class = " pa-8 headline font-weight-regular" 
                                color = "grey"
                            > PALAVRA-PASSE 
                        </p> 
                        </v-col>
                        <v-spacer></v-spacer>
                        <v-col>
                            <p 
                                class = " pa-8 headline font-weight-regular" 
                                color = "grey darken-4">
                                **********
                            </p>
                        </v-col>
                        <v-spacer></v-spacer>
                        <v-col>
                            <PasswordChange :id="$route.params.id"/>  
                        </v-col>
                    </v-row>
                </v-card>    
            </div>      
</template>

<script>

import PasswordChange from '@/components/Admin/EditPassword.vue'
export default {
    components:{
        PasswordChange
    }

}
</script>