<template>
    <div id="kennels">
        <v-app id="inspire">
            <v-container fluid>
                <v-data-iterator
                    :items="items"
                    :items-per-page.sync="itemsPerPage"
                    :page="page"
                    :search="search"
                    :sort-by="sortBy.toLowerCase()"
                    :sort-desc="sortDesc"
                    hide-default-footer
                >
            
                    <template v-slot:default="props">
                    <v-row v-for="item in props.items"
                        :key="item.nome">
                        <v-col>
                        <v-card flat>
                            <v-row>
                                <v-btn icon @click="canil(item)">
                                    <v-icon>pets</v-icon>
                                </v-btn>
                                <v-card-title class="headline font-weight-regular">{{ item.nome }}</v-card-title>
                            </v-row>
                            <v-divider></v-divider>
                        </v-card>
                        </v-col>
                    </v-row>
                    </template>
            
                    <template v-slot:footer>
                    <v-row class="mt-2" align="center" justify="center">
                        <span class="grey--text">Canis por página</span>
                        <v-menu offset-y>
                        <template v-slot:activator="{ on }">
                            <v-btn
                            dark
                            text
                            color="black"
                            class="ml-2"
                            v-on="on"
                            >
                            {{ itemsPerPage }}
                            <v-icon>mdi-chevron-down</v-icon>
                            </v-btn>
                        </template>
                        <v-list>
                            <v-list-item
                            v-for="(number, index) in itemsPerPageArray"
                            :key="index"
                            @click="updateItemsPerPage(number)"
                            >
                            <v-list-item-title>{{ number }}</v-list-item-title>
                            </v-list-item>
                        </v-list>
                        </v-menu>
            
                        <v-spacer></v-spacer>
            
                        <span
                        class="mr-4
                        grey--text"
                        >
                        Page {{ page }} of {{ numberOfPages }}
                        </span>
                        <v-btn
                        fab
                        dark
                        color="brown darken-1"
                        class="mr-1"
                        @click="formerPage"
                        >
                        <v-icon>mdi-chevron-left</v-icon>
                        </v-btn>
                        <v-btn
                        fab
                        dark
                        color="brown darken-1"
                        class="ml-1"
                        @click="nextPage"
                        >
                        <v-icon>mdi-chevron-right</v-icon>
                        </v-btn>
                    </v-row>
                    </template>
                </v-data-iterator>
                <v-btn
                    v-scroll="onScroll"
                    x-large
                    v-show="fab"
                    fab
                    depressed
                    fixed
                    bottom
                    right
                    class = "ma-6"
                    color="deep-orange lighten-4"
                    @click="toTop"
                >
                    <v-icon>keyboard_arrow_up</v-icon>
                </v-btn>
            </v-container>
        </v-app>
    </div>
</template>

<script>

import axios from 'axios'
const lhost = require("@/config/global").host;

export default {
    data () {
        return {
            fab:false,
            itemsPerPageArray: [10, 15, 20],
            search: '',
            filter: {},
            sortDesc: false,
            page: 1,
            itemsPerPage: 10,
            sortBy: 'nome',
            items: [],
            ready: false
        }
    },
    computed: {
        numberOfPages () {
        return Math.ceil(this.items.length / this.itemsPerPage)
        },
        filteredKeys () {
        return this.keys.filter(key => key !== `Nome`)
        },
    },
    methods: {
        nextPage () {
            if (this.page + 1 <= this.numberOfPages) this.page += 1
        },
        formerPage () {
            if (this.page - 1 >= 1) this.page -= 1
        },
        updateItemsPerPage (number) {
            this.itemsPerPage = number
        },
        canil: function(item){
            this.$router.push("/canil/" + item.email);
        },
        onScroll (e) {
            if (typeof window === 'undefined') return
            const top = window.pageYOffset ||   e.target.scrollTop || 0
            this.fab = top > 20
        },
        toTop () {
            this.$vuetify.goTo(0)
        },
    },
    created: async function(){
    try {
      let response = await axios.get(lhost + "/api/Canis");
      this.items = response.data;
      this.ready = true;
    } 
    catch (e) {
      return e;
    }
  },
}
</script>