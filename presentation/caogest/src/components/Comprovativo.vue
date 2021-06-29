<template>
  <div>
    <v-card flat height = "100"></v-card>
    <div class="invoice-box" ref="document">
      <table cellpadding="0" cellspacing="0">
        <tr class="top">
          <td colspan="4">
            <table>
              <tr>
                <img src="@/assets/invoicelogo.png" style=" max-width:200px;">
                <td>
                  <col>
                    Recibo Eletrónico<br> 
                  <col>  
                    Data Emissão: {{date2(donativo.data)}}<br> 
                </td>
              </tr>
            </table>
          </td>
        </tr>
        <tr class="information">
          <td colspan="4">
            <table>
              <tr>
                <td>
                  <col> {{donativo.canil_nome}}<br>  
                  <col> {{donativo.canil_user_email}}<br>
                  <col> {{donativo.canil_rua}}, {{donativo.canil_localidade}}<br>
                  <col> {{donativo.canil_distrito}} <br>
                  <col> {{donativo.canil_contacto}}  
                </td>
                <td>
                  <col> {{donativo.utilizador_nome}}<br> 
                  <col> {{donativo.utilizador_nif}}
                </td>
              </tr>
            </table>
          </td>
        </tr>

        <tr class="heading">
          <td colspan="3">Método de Pagamento</td>
          <td></td>
        </tr>

        <tr class="details">
          <td colspan="3">Transferência Bancária</td>
        </tr>

        <tr class="heading">
          <td>Emolumento</td>
          <td>Descrição</td>
          <td></td>
          <td>Valor</td>
        </tr>

        <tr class="item">
          <td>Donativo monetário</td>
          <td> {{donativo.descricao}}</td>
          <td></td>
          <td>€ {{donativo.valor}}</td>
        </tr>

        <tr class="total">
          <td colspan="3"></td>
          <td>Total: € {{donativo.valor}} </td>
        </tr>
      </table>
    </div>
    <v-card flat height="100"></v-card>
    <v-card flat class="mx-auto" width="750">
      <v-text-field 
          outlined
          class = "headline"
          color="brown darken-4"
          label="Nome do recibo a emitir"
          v-model="form.nome"
          :rules ="regraNome"
        >
      </v-text-field>
    </v-card>
    <v-card flat height = "100"></v-card>
    <v-card flat class="mx-auto">
      <v-row justify="center" align="center">
        <v-btn color="red" bottom class = "headline ma-2 red--text" outlined x-large @click="dialog = false">Cancelar</v-btn>
        <v-btn color="brown lighten-4" bottom class = "headline mr-12" x-large @click="send(donativo.utilizador_user_email)">Emitir Recibo</v-btn>
      </v-row>
    </v-card>
    <v-snackbar
          v-model="snackbar"
          :color="color"
          :timeout="timeout"
          bottom
          multi-line
          class = "headline"
        >
          {{ text }}
          <v-btn class = "headline" text @click="fecharSnackbar">Fechar</v-btn>
        </v-snackbar>
  </div>
</template>

<script>
import html2pdf from 'html2pdf.js'
import moment from 'moment/moment';
import axios from 'axios'
import store from '@/store.js'
const lhost = require("@/config/global").host;

export default {
  props:['id','id2'],
  data: () => ({
    donativo:[],
    form:{
      nome:"",
    },
    snackbar: false, 
    color: "", 
    done: false, 
    timeout: 0,
    text: "", 
    regraNome: [v => !!v || "Nome de ficheiro obrigatório."],
  }),
  methods: {
    exportToPDF() {
      let imagenes = document.getElementsByTagName("img");
        for (let i = 0; i < imagenes.length; i++) 
        imagenes[i].setAttribute("crossorigin", "*"); 

				html2pdf(this.$refs.document, {
					margin: 2,
          filename: this.form.nome + '.pdf',
					image: { type: 'jpeg', quality: 1 },
					html2canvas: { dpi: 192, letterRendering: true },
					jsPDF: { format: 'letter', orientation: 'portrait' }
        })
      },
      date2: function (date) {
            return moment(date).locale("pt").format('L');
      },
      send: async function(email){
        this.exportToPDF();
        const delay = ms => new Promise(res => setTimeout(res, ms));
        await delay(5000);
        try{
            await axios.post(lhost + "/api/Canis/Mail",
            {
                mail: email,
                nome: this.form.nome + '.pdf',
            },
            {
              headers:
                { "Authorization": 'Bearer' + store.getters.token}
            });
            this.text = "Recibo emitido com sucesso!";
            this.color = "success"; 
            this.snackbar = true; 
        } catch(e){
          console.log(e);
          this.text = "Ocorreu um erro na emissão do recibo, por favor tente mais tarde!";
          this.color = "warning"; 
          this.snackbar = true; 
        }
      }, 
      fecharSnackbar() {
        this.snackbar = false;
        if(this.color == 'success')
          this.$router.push("/donativos/canil/" + this.id);
      },
      cancelar() {
        this.$router.push("/donativos/canil/" + this.id);
      },
  },
  created: async function(){
     
        try {
            let response = await axios.get(lhost + "/api/Donativos/Info/" + this.id2,
            { headers: 
              { "Authorization": 'Bearer ' + store.getters.token }
            });
            this.donativo = response.data;
           
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

<style scoped>
  .invoice-box {
  max-width: 800px;
  margin: auto;
  padding: 20px;
  font-size: 16px;
  line-height: 50px;
  font-family: "Helvetica Neue", "Helvetica", Helvetica, Arial, sans-serif;
  color: #555;
}

.invoice-box table {
  width: 100%;
  line-height: inherit;
  text-align: left;
}

.invoice-box table td {
  padding: 5px;
  vertical-align: top;
}

.invoice-box table tr td:nth-child(n + 2) {
  text-align: right;
}

.invoice-box table tr.top table td {
  padding-bottom: 20px;
}

.invoice-box table tr.top table td.title {
  font-size: 45px;
  line-height: 45px;
  color: #333;
}

.invoice-box table tr.information table td {
  padding-bottom: 40px;
}

.invoice-box table tr.heading td {
  background: #eee;
  border-bottom: 1px solid #ddd;
  font-weight: bold;
}

.invoice-box table tr.details td {
  padding-bottom: 20px;
}

.invoice-box table tr.item td {
  border-bottom: 1px solid #eee;
}

.invoice-box table tr.item.last td {
  border-bottom: none;
}

.invoice-box table tr.item input {
  padding-left: 5px;
}

.invoice-box table tr.item td:first-child input {
  margin-left: -5px;
  width: 100%;
}

.invoice-box table tr.total td:nth-child(2) {
  border-top: 2px solid #eee;
  font-weight: bold;
}

.invoice-box input[type="number"] {
  width: 60px;
}

@media only screen and (max-width: 600px) {
  .invoice-box table tr.top table td {
    width: 100%;
    display: block;
    text-align: center;
  }

  .invoice-box table tr.information table td {
    width: 100%;
    display: block;
    text-align: center;
  }
}

/** RTL **/
.rtl {
  direction: rtl;
  font-family: Tahoma, "Helvetica Neue", "Helvetica", Helvetica, Arial,
    sans-serif;
}

.rtl table {
  text-align: right;
}

.rtl table tr td:nth-child(2) {
  text-align: left;
}


</style>