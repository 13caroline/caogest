<template>
    <div id = "termos" class = "termos">
        
        <v-dialog v-model="dialog" width="800px">
        <template v-slot:activator="{ on }">
            <span>
            Li e aceito os 
            <a v-on="on">termos</a>
            e
            <a v-on="on">condições</a>
            de responsabilidade 
            </span>
        </template>
    
            <v-card>
            <v-card-title>
                <span class="display-1">Termos e Condições de responsabilidade</span>
            </v-card-title>
            <v-card-text class = "headline"> 
                <v-row>
                Declaro-me integralmente responsável pelo animal previamente escolhido, eximindo o doador de qualquer responsabilidade a partir desta data para o animal adotado. 
                </v-row>

                <v-row>
                    <span>
                        <v-icon> done </v-icon> Comprometo-me a prestar todos os cuidados necessários de que o anime precise, no que diz respeito à sua saúde, alimentação, abrigo, convívio com demais animais e pessoas.
                    </span>
                </v-row>

                <v-row>
                    <span>
                        <v-icon> done </v-icon> Comprometo-me a comunicar com o centro de adoção no caso de o animal precisar de cuidados veterinários cujas despesas eu nao possa suportar.
                    </span>
                </v-row>

                <v-row>
                    <span>
                        <v-icon> done </v-icon> Comprometo-me a não vender, trocar ou abandonar o animal que estou a adotar.
                        </span>
                </v-row>

                <v-row>
                    <span>
                        <v-icon> done </v-icon> Comprometo-me a comunicar ao centro de adoção caso deseje doá-lo a terceiros. 
                    </span>
                </v-row>

                <v-row>
                    <span>
                        <v-icon> done </v-icon> Tenho conhecimento e permito a visita do centro de doação para exercer o seu direito de fiscalizzar o cumprimento das obrigações por mim assumidas, reservando-lhe o direito de procurar a aplicação das penas previstas na lei, caso sejam, por mim, desrespeitadas.
                    </span>
                </v-row>

                <v-row>
                    <span>
                        <v-icon> done </v-icon> Comprometo-me a obedecer a toda a legislação municipal, e nacional vigente em relação à posse responsável de animais. 
                    </span>
                </v-row>

                <v-card height = "40" flat color = "white"></v-card>
                <v-row>
                    O presente termo tem prazo de validade indeterminado. 
                </v-row>

                <v-row>
                    Ao clicar "li e aceito os termos e condições de responsabilidade", assumo plenamente os deveres que nele costam.
                </v-row>
            </v-card-text>
            <v-card-actions>
                <v-spacer></v-spacer>
                <v-btn color="deep-orange darken-4" text @click="dialog = false">Fechar</v-btn>
            </v-card-actions>
            </v-card>
    </v-dialog>

    </div>
</template>

<script>
  export default {
    data () {
      return {
        dialog: false,
      }
    },
  }
</script>