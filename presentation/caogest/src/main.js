import Vue from 'vue'
import App from './App.vue'
import router from './router'
import vuetify from './plugins/vuetify';
import store from './store';
import * as VueGoogleMaps from 'vue2-google-maps'
import VueGeolocation from 'vue-browser-geolocation'
import 'material-design-icons-iconfont/dist/material-design-icons.css'

var moment = require('moment');
Vue.config.productionTip = false;

Vue.use(VueGeolocation)

Vue.use(VueGoogleMaps, {
  load: {
    key: 'AIzaSyAxt5MfGNyDFT3fV3ec-HITeVRzQSO00L0',
    libraries: 'places', // This is required if you use the Autocomplete plugin
    // OR: libraries: 'places,drawing'
    // OR: libraries: 'places,drawing,visualization'
    // (as you require)
 
    //// If you want to set the version, you can do so:
    // v: '3.26',
  }
});

new Vue({
  router,
  store,
  vuetify,
  moment: moment,
  render: h => h(App)
}).$mount('#app')
