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
                <v-btn text @click="logout">
                    <span>Terminar Sessão</span>
                    <v-icon right>exit_to_app</v-icon>
                </v-btn>
            </v-app-bar>
            <v-layout align-center justify-space-between column fill-height>
            <v-navigation-drawer app v-model="drawer" class = "white" width = "400">
            <v-list-item two-line>
                <v-list-item-avatar>
                <v-img src="@/assets/admin.png"></v-img>
                </v-list-item-avatar>

                <v-list-item-content>
                <v-list-item-title>Administrador</v-list-item-title>
                </v-list-item-content>
            </v-list-item>

        <v-divider></v-divider>

        <v-list nav > 
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
            <v-btn x-large class= "headline" text block @click="preferencias()">
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
const lhost = require("@/config/global").host;
import axios from "axios";
export default {
    props: ['id'], 
    data() {
        return {
            drawer: true,
            items: [
            { title: 'Pedidos de Registo', icon: 'archive', route: '/pagina/admin/' + this.id },
            { title: 'Pedidos de Adoção', icon: 'description', route: '/pedidos/adocao/admin/' + this.id },
            { title: 'Sobre', icon: 'info', route: '/sobre/admin/' + this.id  },
            { title: 'Donativos Realizados', icon: 'payment', route: '/donativos/admin/' + this.id },
            { title: 'Cães', icon: 'pets', route: '/caes/admin/' + this.id  },
            { title: 'Canis', icon: 'house', route: '/canis/admin/' + this.id },
            { title: 'Voluntários', icon:'accessibility_new', route: '/voluntarios/admin/' + this.id },
            { title: 'Documentos', icon: 'description', route: "/documentos/admin/" + this.id},
            { title: 'Entre em Contacto', icon:'question_answer', route: '/entre/contacto/' + this.id },
            { title: 'FAQs', icon: 'help', route: '/faqs/admin/' + this.id  }, 
            { title: 'Estatísticas', icon: 'equalizer', route: '/estatisticas/' + this.id }
            ],
        }
    }, 
    methods:{
        preferencias(){
            this.$router.push("/preferencias/admin/" + this.id);
        },
        async logout() {
            await axios.get(lhost + "/api/Login");
            this.$store.commit("limpaStore");
            this.$router.push("/");
        }, 
    }
}
</script>

<style>
</style>