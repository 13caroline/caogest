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
          "Recusados",
          "Aceites",
          "Expirados",
          "Pendentes",
          "Concluídos"
        ],
        datasets: [
          {
            backgroundColor: [
              "#EF9A9A",
              "#C5E1A5",
              "#B39DDB",
              "#FFE082",
              "#B2EBF2",
            ],
            data: [0, 0, 0, 0, 0],
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
      let res = await axios.get(lhost + "/api/Adocoes",
      { headers: 
        { "Authorization": 'Bearer ' + store.getters.token }
      });
      for (var i = 0; i < res.data.length; i++) {
          if(res.data[i].estado === 'Recusado')
          this.info.datasets[0].data[0] += 1;

          if(res.data[i].estado === 'Aceite')
          this.info.datasets[0].data[1] += 1;

          if(res.data[i].estado === 'Expirado')
          this.info.datasets[0].data[2] += 1;

          if(res.data[i].estado === 'Pendente')
          this.info.datasets[0].data[3] += 1;

          if(res.data[i].estado === 'Concluído')
          this.info.datasets[0].data[4] += 1;
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
