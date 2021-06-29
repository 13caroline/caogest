 <template>
    <div>
        <v-card> 
            <v-img src='../assets/contactos.png'></v-img> 
        </v-card>
        <v-card flat height= "100" color = "white"></v-card>

        <v-card flat class="mx-auto" max-width="1500" fluid>
            <p class = "display-1 font-weight-bold " color="grey"> Estas perguntas ajudarão a fornecer respostas às perguntas mais frequentes.</p>
        </v-card>

         <v-card flat height= "30" color = "white"></v-card>

        <v-divider inset></v-divider>

        <v-card flat height= "90" color = "white"></v-card>
        <v-card flat class = "mx-auto" max-width="1500">
            <v-card-text class="display-2 font-weight-bold black--text">Perguntas Mais Frequentes</v-card-text>
        </v-card>

        <v-card flat height= "40" color = "white"></v-card>

        <v-card flat class="mx-auto" max-width="1500" fluid>
            <v-row justify="center">
                <v-expansion-panels focusable flat accordion>
                    <v-expansion-panel>
                    <v-expansion-panel-header color = "deep-orange lighten-5" class="font-weight-bold display-1" >Quais são os requisitos para poder adotar um cão?</v-expansion-panel-header>
                    <v-expansion-panel-content>
                        <v-card flat color = "white" height="10"></v-card>
                        <v-card>
                             <v-card-text flat color = "white" class="display-1">Para adotar, deverá preencher um formulário, onde terá que apresentar o seu documento de identificação e comprovativo de morada (carta de condução, conta da água, luz ou telefone) e garantir as condições mínimas de conforto, higiene e qualidade de vida exigidas. Após preenchimento do formulário, deverá ler e aceitar o termo de responsabilidade. Será posteriormente enviado o pedido de adoção para o canil, pelo que terá um prazo de 10 dias para recolher o cão.	Outros requisitos exigidos por cada canil deve ser verificado na página do mesmo.</v-card-text>
                        </v-card>
                    </v-expansion-panel-content>
                </v-expansion-panel>

                <v-expansion-panel>
                    <v-expansion-panel-header color = "white" class="font-weight-bold display-1" >Como procuro um cão?</v-expansion-panel-header>
                    <v-expansion-panel-content>
                    <v-card flat color = "white" height="10"></v-card>
                        <v-card>
                             <v-card-text flat color = "white" class="display-1">CãoGest possui uma lista de cães a ser adotados que se encontram nos canis registados na plataforma. Dirija-se ao local onde diz "Cães", e poderá encontrar todos os cães disponíveis para adoção.</v-card-text>
                        </v-card>
                    </v-expansion-panel-content>
                </v-expansion-panel>

                <v-expansion-panel>
                    <v-expansion-panel-header color = "deep-orange lighten-5" class="font-weight-bold display-1" >Por que motivo não consigo efetuar donativos?</v-expansion-panel-header>
                    <v-expansion-panel-content>
                    <v-card flat color = "white" height="10"></v-card>
                        <v-card>
                             <v-card-text flat color = "white" class="display-1">Para ter a possibilidade de efetuar donativos, a idade mínima aceitável é 18 anos. Qualquer utilizador com idade inferior à referida, não poderá efetuar donativos.</v-card-text>
                        </v-card>
                    </v-expansion-panel-content>
                </v-expansion-panel>

                <v-expansion-panel>
                    <v-expansion-panel-header color = "white" class="font-weight-bold display-1" >Como consigo ter a certeza de que o canil ao qual vou adotar um cão é real?</v-expansion-panel-header>
                    <v-expansion-panel-content>
                    <v-card flat color = "white" height="10"></v-card>
                        <v-card>
                             <v-card-text flat color = "white" class="display-1">Todos os canis registados na plataforma são verificados antes de serem introduzidos na bases de dados as suas informações. Se tiver dúvidas face a algum canil listado na plataforma, por favor contacte-nos.</v-card-text>
                        </v-card>
                    </v-expansion-panel-content>
                </v-expansion-panel>
              
                <v-expansion-panel>
                    <v-expansion-panel-header color = "deep-orange lighten-5" class="font-weight-bold display-1" >O cão que eu vir na plataforma ainda é adotável?</v-expansion-panel-header>
                    <v-expansion-panel-content>
                    <v-card flat color = "white" height="10"></v-card>
                        <v-card>
                             <v-card-text flat color = "white" class="display-1">Cada canil é responsável por atualizar a sua lista de cães adotáveis. Se tiver alguma dúvida relativamente a um cão que pretenda adotar, contacte diretamente o canil.</v-card-text>
                        </v-card>
                    </v-expansion-panel-content>
                </v-expansion-panel>

                <v-expansion-panel>
                    <v-expansion-panel-header color = "white" class="font-weight-bold display-1" >Posso ser voluntário de um canil se tiver menos do que 18 anos?</v-expansion-panel-header>
                    <v-expansion-panel-content>
                     <v-card flat color = "white" height="10"></v-card>
                        <v-card>
                             <v-card-text flat color = "white" class="display-1">Não existe idade mínima para se poder voluntariar para ajudar um canil. No entanto, é aconselhável uma idade mínima de 16 anos. Qualquer política implementada por um canil deve ser consultada na página do mesmo.</v-card-text>
                        </v-card>
                    </v-expansion-panel-content>
                </v-expansion-panel>

                <v-expansion-panel>
                    <v-expansion-panel-header color = "deep-orange lighten-5" class="font-weight-bold display-1" >O que acontece se não for buscar o meu cão ao fim de 10 dias após submissão do formulário de adoção?</v-expansion-panel-header>
                    <v-expansion-panel-content>
                    <v-card flat color = "white" height="10"></v-card>
                        <v-card>
                             <v-card-text flat color = "white" class="display-1">Após um período de 10 dias da submissão do formulário de adoção, o cão volta a um estado de 'adotável', pelo que outros utilizadores o podem adotar.</v-card-text>
                        </v-card>
                    </v-expansion-panel-content>
                </v-expansion-panel>
                </v-expansion-panels>
            </v-row>
        </v-card>

         <v-card flat class="mx-auto" height = "150" color = "white"></v-card>

        <v-card> 
            <v-img src='../assets/Contacts.jpg'>
            </v-img> 
        </v-card>


        <v-card flat class="mx-auto" height = "80" color = "white"></v-card>
        
        <v-card flat class="mx-auto" max-width="1500" fluid>
            <v-card-text class="display-2 font-weight-bold black--text" >Entre em Contacto</v-card-text>
            <v-card flat height= "50" color = "white"></v-card>
            <v-card-text class = "display-1 font-weight-medium ">Se tiver alguma questão que não consiga encontrar no nosso site ou sugestão, escreva-nos usando o formulário abaixo. Faremos o possível para responder o quanto antes.</v-card-text>
        
            <v-card flat class="mx-auto" height = "80" color = "white"></v-card>
            <v-card outlined flat>
                <v-card outlined color = "brown darken-1" dark>
                <v-card-title >
                    <span class="font-weight-bold display-1">Entre em Contacto</span>
                </v-card-title>
                </v-card>
                <v-card-text>
                    <v-form 
                        ref="form"
                        v-model="valid"
                        lazy-validation
                    >   
                        <v-card flat class="mx-auto" height = "30" color = "white"></v-card>
                        <v-text-field color = "grey" flat  name="input-7-1" outlined label="Nome *" required ></v-text-field>

                        <v-text-field flat color = "grey" name="input-7-1" outlined label="Email *" required></v-text-field>

                        <v-select 
                            color = "grey"
                            name="input-7-1"
                            flat outlined 
                            :v-model="select"
                            :items="items"
                            label="Motivo do inquérito *"
                            required
                        ></v-select>

                        <v-textarea
                            name="input-7-1"
                            flat
                            outlined
                            auto-grow
                            placeholder = "Mensagem *"
                            color = "grey lighten-1" 
                            rows = "5"
                        ></v-textarea>

                    </v-form>
                    <small>*campos obrigatórios</small>
                    <v-card flat class="mx-auto" height = "30" color = "white"></v-card>
                    <p> Ao preencher este formulário, confirma que tem 16 anos ou mais.</p> 

                </v-card-text>
                <v-card-actions>
                    <v-spacer></v-spacer>
                    <v-btn class="ma-6" x-large color = "brown lighten-4" @click="dialog = false">Submeter</v-btn>
                </v-card-actions>
            </v-card>
        </v-card>
        <v-card flat class="mx-auto" height = "100" color = "white"></v-card>
        <v-divider inset></v-divider>

        <v-card flat class="mx-auto" height = "100" color = "white"></v-card>
        
        <v-card flat outlined class="mx-auto" max-width="1500" fluid color = "brown lighten-4">
            <v-card-text class="display-1 font-weight-medium black--text" >Se tiver uma questão, mas preferir falar conosco do que nos enviar um e-mail, ligue para </v-card-text> <v-card-text class="display-1 font-weight-bold black--text">911111111.</v-card-text>
        </v-card>

        <v-card flat class="mx-auto" height = "100" color = "white"></v-card>
        
        <v-card flat outlined class="mx-auto" max-width="1500" fluid color = "white">
            <v-card-text class="display-2 font-weight-bold"> Quer escrever-nos?</v-card-text>
            <v-card-text class="display-1 font-weight-medium black--text">Pode enviar-nos um e-mail para caogest@gmail.com.</v-card-text>
        </v-card>
    </div>
</template>

<script>
export default {
    data: () => ({
      dialog: false,
      select: null,
      valid: true,
      items: [ 
        'Quero fazer um donativo',
        'Quero voluntariar-me para um canil',
        'Quero atualizar os meus dados pessoais',
        'Cuidados com o cão que adotei',
        'Outro',
      ]
    })
}
</script>