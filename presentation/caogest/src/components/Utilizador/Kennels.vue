<template>
  <div> 
    <v-card flat class="mx-auto ml-12">
      <v-row>
        <v-col class = "ma-12">
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
                    :key="item.nome"
                    cols="12"
                    sm="6"
                    md="4"
                    lg="3">
                  <v-col>
                    <v-card flat>
                      <v-row>
                        <v-btn icon @click="canil(item)">
                          <v-icon large>pets</v-icon>
                        </v-btn>
                        <v-card-title class="display-1 font-weight-regular">{{ item.nome }}</v-card-title>
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
                    <template v-slot:activator="{ on, attrs }">
                      <v-btn
                        dark
                        text
                        color="black"
                        class="ml-2"
                        v-bind="attrs"
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
                    Página {{ page }} de {{ numberOfPages }}
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
        </v-col>
        <v-col cols = "3">
          <v-row>
            <v-card flat >
              <v-card-text>
                <v-card-text class="display-2 font-weight-bold black--text">Pesquisar Canis</v-card-text>
                <v-card flat height= "50" color = "white"></v-card>
                <v-text-field append-icon="search" flat color = "grey" v-model="search" outlined class="title font-weight-regular" placeholder="Pesquisa por nome ou localidade" ></v-text-field>
              </v-card-text>
            </v-card>
           </v-row>
        </v-col>
      </v-row>  
    </v-card>
    <div>
      <GmapMap
        :center="myCoordinates"
        ref="mapRef"
        @dragend="handleDrag"
        :zoom="10"
        map-type-id="roadmap"
        style="width: 2470px; height: 1000px"
      >

      <GmapMarker
            icon="http://maps.google.com/mapfiles/ms/icons/orange-dot.png"
            :position="myCoordinates"
            :clickable="true"
            :draggable="true"
            @click="center=myCoordinates"
        />

        <GmapMarker
            :key="index"
            v-for="(m, index) in sets1"
            :position="m.position"
            :clickable="true"
            :draggable="false"
            @click="toggleInfoWindow(m,index)"
        />
        <GmapInfoWindow
            :options="infoOptions"
            :position="infoWindowPos"
            :opened="infoWinOpen"
            @closeclick="infoWinOpen=false">
            <div v-html="infoContent"></div>
        </GmapInfoWindow>

      </GmapMap>
    </div>
  </div>
</template>

<script>
const lhost = require("@/config/global").host;
import axios from 'axios'
import store from '@/store.js'


  export default {
    props:['id'],
    data () {
      return {
        sets: [], 
        sets1: [],
        markers: [],
        fab:false,
        itemsPerPageArray: [10, 15, 20],
        search: '',
        filter: {},
        sortDesc: false,
        page: 1,
        itemsPerPage: 10,
        sortBy: 'nome',
        items: [],
        ready: false,
        map: null,
        gettingLocation: false,
        location:null,
        myCoordinates:{
          lat: 0, 
          lng: 0,
        },
        infoContent: '',
        infoWindowPos: {
          lat: 0,
          lng: 0
        },
        infoWinOpen: false,
        currentMidx: null,
        infoOptions: {
          pixelOffset: {
            width: 0,
            height: -35
          }
        },
      }
    },
    computed: {
      numberOfPages () {
        return Math.ceil(this.items.length / this.itemsPerPage)
      },
      filteredKeys () {
        return this.items.filter(item => {
          return item.nome.toLowerCase().includes(this.search.toLowerCase()) || item.distrito.toLowerCase().includes(this.search.toLowerCase()) || item.localidade.toLowerCase().includes(this.search.toLowerCase()) 
        })
      },
      mapCoordinates() {
        if(!this.map) {
          return {
            lat: 0,
            lng: 0
          };
        }
        return {
          lat: this.map.getCenter().lat().toFixed(4),
          lng: this.map.getCenter().lng().toFixed(4)
        }
      }
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
            this.$router.push("/canil/" + this.id + '/' + item.email);
      },
      onScroll (e) {
          if (typeof window === 'undefined') return
          const top = window.pageYOffset ||   e.target.scrollTop || 0
          this.fab = top > 20
      },
      toTop () {
          this.$vuetify.goTo(0)
      },
      handleDrag() {
                // get center and zoom level, store in localstorage
                let center = {
                    lat: this.map.getCenter().lat(),
                    lng: this.map.getCenter().lng()
                };
                let zoom = this.map.getZoom();
                localStorage.center = JSON.stringify(center);
                localStorage.zoom = zoom;
            },
      toggleInfoWindow: function (marker, idx) {
        this.infoWindowPos = marker.position;
        this.infoContent = this.getInfoWindowContent(marker);

        //check if its the same marker that was selected if yes toggle
        if (this.currentMidx == idx) {
          this.infoWinOpen = !this.infoWinOpen;
        }
        //if different marker set infowindow to open and reset current marker index
        else {
          this.infoWinOpen = true;
          this.currentMidx = idx;
        }
      },
      getInfoWindowContent: function (marker) {
          return (`<p class="title is-4">${marker.name}</p>`);
      },
      
    },
     created: async function(){
    try {
        let response = await axios.get(lhost + "/api/Canis",
            { headers: 
              { "Authorization": 'Bearer ' + store.getters.token }
            });
        this.items = response.data.filter(function(item){
          return (item.estado === "Aceite")
        }) 
        this.ready = true;

        for (var i = 0; i < this.items.length; i++){
            let response1 = await axios.post(lhost + "/api/Canis/String",{
              rua: this.items[i].rua
            },
            { headers: 
              { "Authorization": 'Bearer ' + store.getters.token }
            });
            this.sets.push({ b:response1.data })
          }
          for (i = 0; i < this.sets.length; i++){
                let response2 = await axios.post("https://maps.googleapis.com/maps/api/geocode/json?address="+ this.sets[i].b +"&key=AIzaSyDo30UCma5RRXnpbvwvovMpOJiCQO8yTRY")
                const marker = {
                    lat: response2.data.results[0].geometry.location.lat,
                    lng: response2.data.results[0].geometry.location.lng
                };
                this.sets1.push({ position:marker, name: this.items[i].nome })
          }

        if(localStorage.center) {
                this.myCoordinates = JSON.parse(localStorage.center);
            } else {
                // get user's coordinates from browser request
                this.gettingLocation = true;
    // get position
                    navigator.geolocation.getCurrentPosition(pos => {
                      this.gettingLocation = false;
                      this.location = pos;
                      this.myCoordinates.lat = this.location.coords.latitude; 
                      this.myCoordinates.lng = this.location.coords.longitude;
                    }, err => {
                      this.gettingLocation = false;
                      this.errorStr = err.message;
                    })
                
            }
            // does the user have a saved zoom? use it instead of the default
            if(localStorage.zoom) {
                this.zoom = parseInt(localStorage.zoom);
            }
    } 
    catch (e) {
       if(e.message == "Request failed with status code 401"){
            this.$store.commit("limpaStore");
            this.$router.push("/");
        }
    }
  },
  mounted() {
            // add the map to a data object
            this.$refs.mapRef.$mapPromise.then(map => this.map = map);
        },
  }
</script>
<style lang="css">
.vue-map-container {
  position: relative;
}
.vue-map-container .vue-map {
  left: 0; right: 0; top: 0; bottom: 0;
  position: absolute;
}
.vue-map-hidden {
  display: none;
}
</style>