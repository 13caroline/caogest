const lhost = require("@/config/global").host;
import axios from "axios";
import store from '@/store.js'

import {Pie} from "vue-chartjs";

export default {
  extends: Pie,
  data() {
    return {
      info: {
        labels: [
          "Canil",
          "Utilizadores",
        ],
        datasets: [
          {
            backgroundColor: [
              "#FFE082",
              "#C5E1A5",

            ],
            data: [0, 0]
          }
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
      let res = await axios.get(lhost + "/api/Users",
        { headers: 
          { "Authorization": 'Bearer ' + store.getters.token }
        });

        for (var i = 0; i < res.data.length; i++) {
          if(res.data[i].tipo === 1)
          this.info.datasets[0].data[1] += 1;

          if(res.data[i].tipo === 2)
          this.info.datasets[0].data[0] += 1;
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
