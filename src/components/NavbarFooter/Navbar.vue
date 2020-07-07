<template>
    <div id="app">
        <nav>
            <v-app-bar flat app height = "100" color="deep-orange lighten-4">
                <v-app-bar-nav-icon class = "black--text" @click="drawer = !drawer"></v-app-bar-nav-icon>
                <v-app-bar flat color = "deep-orange lighten-4" class = "text-uppercase black--text">
                    <span class= "font-weight-light">Cao</span>
                    <span>Gest</span>
                </v-app-bar>
                <v-spacer></v-spacer>
                <v-btn text  @click="logout">
                    <span>Terminar Sessão</span>
                    <v-icon right>exit_to_app</v-icon>
                </v-btn>
            </v-app-bar>
            <v-layout align-center justify-space-between column fill-height>
            <v-navigation-drawer app v-model="drawer" class = "white" width = "400">
            <v-list-item two-line>
                <v-list-item-avatar>
                    <v-img v-if="this.utilizador.sexo === 'Feminino'" src="@/assets/woman.png"></v-img>
                    <v-img v-else src="@/assets/man.png"></v-img>
                </v-list-item-avatar>

                <v-list-item-content>
                <v-list-item-title class= "headline">{{this.utilizador.nome}}</v-list-item-title>
                </v-list-item-content>
            </v-list-item>

        <v-divider></v-divider>

        <v-list nav> 
            <v-list-item 
                v-for="item in items"
                :key="item.title"
                router :to="item.route"
                link
            >
                <v-list-item-icon>
                    <v-icon class = "ma-2">{{ item.icon }}</v-icon>
                </v-list-item-icon>

                <v-list-item-content>
                    <v-list-item-title class= "headline">{{ item.title }}</v-list-item-title>
                </v-list-item-content>
                <v-card height = "20" flat></v-card>
            </v-list-item>
        </v-list>
        <template v-slot:append>
        <div class="pa-2">
            <v-btn x-large text class= "headline" block @click="preferencias()">
                <v-icon left>settings</v-icon>Preferências
            </v-btn>
        </div>
      </template>

        </v-navigation-drawer>
        </v-layout>
    </nav>
</div>

</template>

<script>
import store from '@/store.js'
const lhost = require("@/config/global").host;
import axios from "axios";

export default {
    data() {
        return {
            drawer: true,
            utilizador: {},
            items: [
            { title: 'Página Inicial', icon: 'dashboard', route: "/pagina/utilizador/" + this.id },
            { title: 'Sobre', icon: 'info', route: "/sobre/" + this.id },
            { title: 'Antes de Adotar', icon: 'announcement', route: "/antesdeadotar/" + this.id},
            { title: 'Donativos', icon: 'payment', route: "/donativos/" + this.id},
            { title: 'Documentos', icon: 'description', route: "/documentos/" + this.id},
            { title: 'Cães', icon: 'pets', route: "/caes/" + this.id },
            { title: 'Canis', icon: 'house', route: "/canis/" + this.id },
            { title: 'Voluntariado', icon: 'accessibility_new', route: "/voluntariado/" + this.id},
            { title: 'FAQs', icon: 'help', route: "/faqs/" + this.id },
            { title: 'Entre em Contacto', icon:'question_answer', route: "/entre/contacto/utilizador/" + this.id},
            ],
        }
    },
    name: 'Navbar',    
    props: ['id'], 
    methods: {
        async logout() {
            await axios.get(lhost + "/api/Login");
            this.$store.commit("limpaStore");
            this.$router.push("/");
        }, 
        preferencias(){
            this.$router.push("/preferencias/" + this.id);
        }
    },
    created: async function(){
        try {
            let response = await axios.get(lhost + "/api/Utilizadors/" + this.id,
            { headers: 
              { "Authorization": 'Bearer ' + store.getters.token }
            });
            this.utilizador = response.data;
            this.ready = true;
        } 
        catch (e) {
            if(e.message == "Request failed with status code 401"){
                this.$store.commit("limpaStore");
                this.$router.push("/");
            }
        }
    }, 
}
</script>

<style>
</style>