<template>
  <div id = "login" >
    <v-row align = "end" justify = "end">
      <v-btn text class = "white--text overline font-weight-thin text--secondary" href="https://apkpure.com/br/border-collie-wallpapers/com.sgm.bordercolliewallpapers">hiperligação para a imagem original</v-btn>
    </v-row>
      <div class = "section" >
      <v-col cols = "12">
      <v-card height = "250"  color = "transparent" flat></v-card>
      <v-row align = "center" justify = "center">
          <v-card color = "transparent" flat width = "600">
            <v-card-text class="justify-center">
               <v-form ref="form" lazy-validation>
                <v-text-field 
                  class = "headline"
                  dark 
                  color="white" 
                  rounded 
                  label="Email" 
                  type="email"
                  name="email"
                  v-model="form.email"
                  prepend-icon="email"
                  :rules="regraEmail"
                  outlined
                  required 
                />
                <v-text-field
                  class = "headline"
                  dark 
                  color="white" 
                  rounded 
                  prepend-icon="lock"
                  outlined   
                  v-model="form.password"
                  :rules="regraPassword"
                  name="password"
                  label="Password"
                  type="password"
                  required
                />
              </v-form>
              <v-btn depressed class="ma-2 headline" dark color = "transparent" type="submit" @click="loginUtilizador"> Entrar </v-btn>
              
              <v-dialog v-model="dialog" persistent max-width="350">
                <template v-slot:activator="{ on }">
                  <v-btn depressed class="ma-2 headline" v-on="on" dark color = "transparent"> Registar </v-btn>
                </template>

                <v-row align = "center" justify = "center">
                  <v-card flat color = "transparent">
                    <v-card-text>
                      <div>
                        <v-btn x-large depressed class="ma-4 headline" dark color = "transparent" to = "/registar/utilizador">Registar Utilizador</v-btn>
                      </div>

                      <div>
                        <v-btn x-large depressed class="ma-4 headline" dark color = "transparent" to = "/registar/canil">Registar Canil</v-btn>
                      </div>
                      
                      <div>
                        <v-btn x-large depressed class="ma-4 headline" dark color = "transparent" @click="dialog = false">Cancelar</v-btn>
                      </div>
                    </v-card-text>
                  </v-card>
                </v-row>
              </v-dialog>

            </v-card-text>
            <v-snackbar
            v-model="snackbar"
            :timeout="timeout"
            :color="color"
            :top="true"
            class = "headline"
          >
            {{ text }}
          </v-snackbar>
          </v-card>
        </v-row>

        <v-card flat color = "transparent" height = "200"></v-card>

        <v-row>
          <v-card flat color = "transparent" class = "mx-auto">
            <v-img 
              src="../assets/logoA3.png"
              max-width="600"
            >
            </v-img>
          </v-card>
      </v-row>
    </v-col> 

    <v-card flat color = "transparent" height="250"></v-card>
    <v-row align = "center">
      <v-card flat color = "transparent" class = "mx-auto"> 
        <v-btn fab x-large dark outlined @click="toNext">
          <v-icon dark x-large>keyboard_arrow_down</v-icon>
        </v-btn>
      </v-card>
    </v-row>
      </div>

       <div class = "section" id="sobre"> 
        <v-parallax
          dark
          src="../assets/sobrepage.jpg"
          height="600"
        >
          <v-row align = "start" justify = "end">
              <v-btn text class = "white--text overline font-weight-thin text--disabled" href="https://www.1zoom.ru/Животные/обои/521277/z1069.1/1366x768">hiperligação para a imagem original</v-btn>
          </v-row>
          <v-row
            align="center"
            justify="end"
          >
            <v-col cols="10">
              <h1 class="display-2 font-weight-light mb-4 black--text">Sobre</h1>
            </v-col>
          </v-row>
        </v-parallax>

        <v-card flat class="mx-auto" height = "20" color = "white"></v-card>

        <v-row align="center" justify="center">
          <v-col>
            <p class="display-2 font-weight-bold text-center">Missão</p>
            <v-card flat height= "30" color = "white"></v-card>
            <v-card flat class="mx-auto" max-width="1000" fluid>
                <v-card-text class="display-1"> A CãoGest tem como missão dar a cada animal um lar, e a cada dono um animal que corresponda às suas expectativas.
                </v-card-text>
            </v-card>
          </v-col>

          <v-col>
            <v-card flat height= "120" color = "white"></v-card>
            <p class="display-2 font-weight-bold text-center">Visão</p>
            <v-card flat height= "30" color = "white"></v-card>
            <v-card flat class="mx-auto" max-width="1000" fluid>
                <v-card-text class="display-1">Ambicionamos melhorar a gestão de movimento dos cães pelos canis, promovendo a entrada e saída mais célere dos animais, permitindo assim uma melhor qualidade de vida para os animais, bem como uma diminuição da sobrecarga laboral e insuficiência económica que enfrentam os canis. 
                </v-card-text>
            </v-card>
          </v-col>
        </v-row>

        <v-card flat height="120"></v-card>
        <v-row align = "center">
          <v-card flat color = "transparent" class = "mx-auto"> 
            <v-btn fab x-large outlined @click="toNext2">
              <v-icon x-large>keyboard_arrow_down</v-icon>
            </v-btn>
          </v-card>
        </v-row>
       </div>


      <div class = "section" id="contactos"> 
        <v-parallax
          dark
          src="../assets/contactopage.jpg"
          height="600"
        >
          <v-row align = "start" justify = "end">
              <v-btn text class = "white--text overline font-weight-thin text--disabled" href="https://www.wallpaperbetter.com/en/search?q=Handsome+Dog">hiperligação para a imagem original</v-btn>
          </v-row>
          <v-row
            align="center"
            justify="end"
          >
            <v-col cols="2">
              <h1 class="display-2 font-weight-light mb-4 black--text">Contactos</h1>
            </v-col>
          </v-row>
        </v-parallax>

        <v-card flat class="mx-auto" height = "100" color = "white"></v-card>
        
        <v-card flat outlined class="mx-auto" max-width="1500">

              <v-row>
                <v-card-text class="ml-8 mt-8 display-2 font-weight-bold"> Quer escrever-nos?</v-card-text>
              </v-row>

              <v-card flat height = "20"></v-card>

              <v-row align = "center" justify="center">
                <v-col cols = "2">
                  <v-icon x-large>mail</v-icon> 
                </v-col>

                <v-col cols = "8">
                  <v-card-text class="display-1 font-weight-normal black--text"> caogest@gmail.com </v-card-text>
                </v-col>
              </v-row>

              <v-card flat height = "50"></v-card>

              <v-row>
                  <v-card-text class=" ml-8 display-1 font-weight-normal black--text">Se tiver uma questão, mas preferir falar conosco do que nos enviar um e-mail, ligue para</v-card-text>
              </v-row>

              <v-card flat height = "50"></v-card>

              <v-row align = "center" justify="center">
                <v-col cols="2">
                  <v-icon x-large>call</v-icon>
                </v-col>
                <v-col cols = "8">
                  <v-card-text class="display-1 font-weight-normal black--text"> 9111111111 </v-card-text>
                </v-col>
              </v-row>
        </v-card>

        <v-card flat height = "10"></v-card>

        <v-footer absolute padless>
        <v-card class="flex" color = "grey lighten-1" flat tile height="50"> 
            <v-card-text class="py-2 black--text text-center title font-weight-thin">
            {{ new Date().getFullYear() }} — <strong>CaoGest</strong>
            </v-card-text>
        </v-card>
        </v-footer>
      </div>
    </div>
</template>


<script>

const lhost = require("@/config/global").host;
import axios from "axios";

export default {
  name: "login",
  data (){
    return {
      canil:{},
      form:{
        email: "",
        password: "",
      },
      regraEmail: [ v => !!v || "Email obrigatório."],
      regraPassword: [v => !!v || "Palavra-passe obrigatória."],
      dialog: false,
      snackbar: false,
      color: "",
      timeout: 4000,
      text: "",
      done: false, 
    }
  }, 
  methods: {
    toNext () {
      this.$vuetify.goTo(1447)
    },
    toNext2 () {
      this.$vuetify.goTo(3000)
    },
    async loginUtilizador() {
      if (this.$refs.form.validate()) {
        try{
          var res = await axios.post(lhost + "/api/Login", {
            email: this.$data.form.email,
            password: this.$data.form.password 
          })
            if (res.data.token != undefined && res.data.nome != undefined ){
              this.$store.commit("guardaTokenUtilizador", res.data.token); 
              this.$store.commit("guardaNomeUtilizador", res.data.nome); 
              this.$store.commit("guardaTipoUtilizador", res.data.tipo); 
              if(res.data.tipo == 0)
                this.$router.push("/pagina/admin/" + this.$data.form.email);
              if(res.data.tipo == 1)
                this.$router.push("/pagina/utilizador/" + this.$data.form.email);
              if(res.data.tipo == 2){
                try {
                  let response = await axios.get(lhost + "/api/Canis/" + this.form.email);
                  this.canil = response.data;
                  this.ready = true;

                  if (this.canil.estado !== "Aceite") {
                    this.text = "Esta conta não se encontra válida."; 
                    this.color = "error"; 
                    this.snackbar = true; 
                    this.done = false; 
                    this.$store.commit("limpaStore");
                  }
                  else this.$router.push("/pagina/canil/" + this.$data.form.email);
                }
                catch(e){
                  console.log(e);
                }   
              }
            }
            else{
              this.text = "Email ou Palavra-Passe incorretos!"; 
              this.color = "error"; 
              this.snackbar = true; 
              this.done = false; 
            }
          }
          catch(e) {
            this.text = "Email ou Palavra-Passe incorretos!";
            this.color = "error";
            this.snackbar = true;
            this.done = false;
            console.log(JSON.stringify(e));
          }
        } else {
          this.text = "Por favor preencha todos os campos!";
          this.color = "error";
          this.snackbar = true;
          this.done = false;
        }
      }
  }, 
}
</script>

<style scoped>
#login{
    width: 100%;
    height: 100%;
    position: absolute;
    top: 0;
    left: 0;
    background-image: url('../assets/image-2.jpg');
    background-size: cover;
  }

  #sobre{
    width: 100%;
    height: 100%;
    position: absolute;
    top: 100%;
    left: 0;
    background-size: cover;
  }

  #contactos{
    width: 100%;
    height: 100%;
    position: absolute;
    top: 200%;
    left: 0;
    background-size: cover;
  }

</style>
