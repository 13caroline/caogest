const lhost = require("@/config/global").host;
import axios from "axios";
import store from '@/store.js'

import { Line } from "vue-chartjs";

export default {
  extends: Line,
  data() {
    return {
      info: {
        labels: ["Janeiro","Fevereiro","Março","Abril","Maio","Junho","Julho","Agosto","Setembro","Outubro","Novembro","Dezembro"],
        datasets: [
          {
            label: "2020",
            borderColor: "#EF9A9A",
            data: [],
            fill:false,
            borderWidth: 5
          },
          {
            label: "2019",
            borderColor: "#C5E1A5",
            data: [],
            fill:false,
            borderWidth: 5
          },
          {
            label: "2018",
            borderColor: "#B3E5FC",
            data: [],
            fill:false,
            borderWidth: 5
          },

        ]
      },
      options: {
        responsive: true,
        maintainAspectRatio: false,
        legend: {
          display: true,
          labels: {
              fontSize:20,
          }
        }
      }
    };
  },
   async mounted() {
     try{
      let res = await axios.get(lhost + "/api/Stats/Donativos",
        { headers: 
          { "Authorization": 'Bearer ' + store.getters.token }
        });
  
          this.info.datasets[0].data = res.data[0];
          this.info.datasets[1].data = res.data[1];
          this.info.datasets[2].data = res.data[2];

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