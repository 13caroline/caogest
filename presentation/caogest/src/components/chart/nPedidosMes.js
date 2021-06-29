const lhost = require("@/config/global").host;
import axios from "axios";
import store from '@/store.js'

import { Bar } from "vue-chartjs";

export default {
  extends: Bar,
  data() {
    return {
      info: {
        datasets: [
          {
            label: "Janeiro",
            backgroundColor: "#EF9A9A",
            data: []
          },
          {
            label: "Fevereiro",
            backgroundColor: "#C5E1A5",
            data: []
          },
          {
            label: "Março",
            backgroundColor: "#B39DDB",
            data: []
          },
          {
            label: "Abril",
            backgroundColor: "#FFE082",
            data: []
          },
          {
            label: "Maio",
            backgroundColor: "#B3E5FC",
            data: []
          },
          {
            label: "Junho",
            backgroundColor: "#EF9A9A",
            data: []
          },
          {
            label: "Junho",
            backgroundColor: "#C5E1A5",
            data: []
          },
          {
            label: "Agosto",
            backgroundColor: "#B39DDB",
            data: []
          },
          {
            label: "Setembro",
            backgroundColor: "#FFE082",
            data: []
          },
          {
            label: "Outubro",
            backgroundColor: "#B3E5FC",
            data: []
          },
          {
            label: "Novembro",
            backgroundColor: "#EF9A9A",
            data: []
          },
          {
            label: "Dezembro",
            backgroundColor: "#C5E1A5",
            data: []
          }
        ]
      },
      options: {
        responsive: true,
        maintainAspectRatio: false
      }
    };
  },
   async mounted() {
     try{
      let res = await axios.get(lhost + "/api/Stats/Pedidos/Mes",
      { headers: 
        { "Authorization": 'Bearer ' + store.getters.token }
      });  
      
      for (var i = 0; i < res.data.length; i++) {  
          this.info.datasets[i].data[0] = res.data[i];
      }
      
      this.renderChart(this.info, this.options);
      }
      catch(error){ 
        if(error.message == "Request failed with status code 401"){
          this.$store.commit("limpaStore");
          this.$router.push("/");
      }
      }
  }
};