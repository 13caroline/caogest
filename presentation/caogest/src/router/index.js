import Vue from 'vue'
import VueRouter from 'vue-router'
import store from '../store'

Vue.use(VueRouter)

const routes = [
  {
    path: '/',
    name: 'Home',
    component: () => import(/* webpackChunkName: "about" */ '../views/Home.vue')
  },
  {
    path: '/sobre/:id',
    name: 'About',
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () => import('../views/Infos/About.vue'),
    beforeEnter(to,from,next){
      if(!store.getters.isAuthenticated) {
        next('/');
      }
     
      else next();
    }
  },
  {
    path: '/sobre/canil/:id',
    name: 'AboutKennel',
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () => import('../views/Infos/AboutKennel.vue'),
    beforeEnter(to,from,next){
      if(!store.getters.isAuthenticated) {
        next('/');
      }
      
      else next();
    }
  },
  {
    path: '/sobre/admin/:id',
    name: 'AboutAdmin',
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () => import('../views/Infos/AboutAdmin.vue'),
    beforeEnter(to,from,next){
      if(!store.getters.isAuthenticated) {
        next('/');
      }
      
      else next();
    }
  },
  {
    path: '/faqs/:id',
    name: 'FAQs',
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () => import('../views/Infos/FAQs.vue'),
    beforeEnter(to,from,next){
      if(!store.getters.isAuthenticated) {
        next('/');
      }
      
      else next();
    }
  },
  {
    path: '/faqs/canil/:id',
    name: 'FAQsKennel',
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () => import('../views/Infos/FAQsKennel.vue'),
    beforeEnter(to,from,next){
      if(!store.getters.isAuthenticated) {
        next('/');
      }
      
      else next();
    }
  },
  {
    path: '/faqs/admin/:id',
    name: 'FAQsAdmin',
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () => import('../views/Infos/FAQsAdmin.vue'),
    beforeEnter(to,from,next){
      if(!store.getters.isAuthenticated) {
        next('/');
      }
     
      else next();
    }
  },
  {
    path: '/antesdeadotar/:id',
    name: 'Antes De Adotar',
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () => import('../views/Infos/BeforeAdopting.vue'),
    beforeEnter(to,from,next){
      if(!store.getters.isAuthenticated) {
        next('/');
      }
      
      else next();
    }
  },
  {
    path: '/donativos/:id',
    name: 'Donativos',
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () => import('../views/Infos/Donations.vue'),
    beforeEnter(to,from,next){
      if(!store.getters.isAuthenticated) {
        next('/');
      }
      
      else next();
    }
  },
  {
    path: '/donativos/canil/:id',
    name: 'DonativosKennel',
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () => import('../views/Canil/DonationsKennel.vue'),   
    beforeEnter(to,from,next){
      if(!store.getters.isAuthenticated) {
        next('/');
      }
      
      else next();
    }
  },
  {
    path: '/donativos/admin/:id',
    name: 'Donativosrealizados',
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () => import('../views/Admin/DonationsAdmin.vue'),
    beforeEnter(to,from,next){
      if(!store.getters.isAuthenticated) {
        next('/');
      }
      
      else next();
    }
  },
  {
    path: '/pedidos/adocao/canil/:id',
    name: 'AdoptionRequest',
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () => import('../views/Canil/AdoptionRequest.vue'),
    beforeEnter(to,from,next){
      if(!store.getters.isAuthenticated) {
        next('/');
      }
      
      else next();
    }
  },
  {
    path: '/pedidos/adocao/admin/:id',
    name: 'AdoptionRequestAdmin',
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () => import('../views/Admin/AdoptionRequestAdmin.vue'),
    beforeEnter(to,from,next){
      if(!store.getters.isAuthenticated) {
        next('/');
      }
     
      else next();
    }
  },
  {
    path: '/horario/canil/:id',
    name: 'Schedule',
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () => import('../views/Canil/ScheduleKennel.vue'),
    beforeEnter(to,from,next){
      if(!store.getters.isAuthenticated) {
        next('/');
      }
      
      else next();
    }
  },
  {
    path: '/horario/admin/canil/:id/:id2',
    name: 'HorarioCanil',
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () => import('../views/Admin/HorarioCanil.vue'),
    beforeEnter(to,from,next){
      if(!store.getters.isAuthenticated) {
        next('/');
      }
      
      else next();
    }
  },
  {
    path: '/pagina/utilizador/:id',
    name: 'Main Page',
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () => import('../views/Utilizador/HomeUser.vue'),
    beforeEnter(to,from,next){
      if(!store.getters.isAuthenticated) {
        next('/');
      }
    
      else next();
    }
  },
  {
    path: '/pagina/canil/:id',
    name: 'MainPageKennel',
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () => import('../views/Canil/HomeKennel.vue'),
    beforeEnter(to,from,next){
      if(!store.getters.isAuthenticated) {
        next('/');
      }
      else next();
    }
  },
  {
    path: '/pagina/admin/:id',
    name: 'Main Page Admin',
    component: () => import('../views/Admin/HomeAdmin.vue'),
    beforeEnter(to,from,next){
      if(!store.getters.isAuthenticated) {
        next('/');
      }
      else next();
    }
  },
  {
    path: '/registar/utilizador',
    name: 'User Register',
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () => import('../views/RegistoUsers/UserRegister.vue'),
  },
  {
    path: '/registar/canil',
    name: 'Kennel Register',
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () => import('../views/RegistoUsers/CanilRegister.vue'),
  },
  {
    path: '/registar/cao/:id',
    name: 'Dog Register',
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () => import('../views/Canil/DogRegister.vue'),
    beforeEnter(to,from,next){
      if(!store.getters.isAuthenticated) {
        next('/');
      }
      else next();
    }
  },
  {
    path: '/formulario/adocao/:id/:id2/:id3',
    name: 'Adoption Form',
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () => import('../views/AdoptionForm.vue'),
    beforeEnter(to,from,next){
      if(!store.getters.isAuthenticated) {
        next('/');
      }
      else next();
    }
  },
  {
    path: '/caes/:id',
    name: 'Dogs',
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () => import('../views/Utilizador/Dogs.vue'),
    beforeEnter(to,from,next){
      if(!store.getters.isAuthenticated) {
        next('/');
      }
      else next();
    }
  },
  {
    path: '/caes/admin/:id',
    name: 'DogsAdmin',
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () => import('../views/Admin/DogsAdmin.vue'),
    beforeEnter(to,from,next){
      if(!store.getters.isAuthenticated) {
        next('/');
      }
      else next();
    }
  },
  {
    path: '/canis/:id',
    name: 'Kennels',
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () => import('../views/Utilizador/Kennels.vue'),
    beforeEnter(to,from,next){
      if(!store.getters.isAuthenticated) {
        next('/');
      }
      else next();
    }
  },
  {
    path: '/canis/admin/:id',
    name: 'KennelsAdmin',
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () => import('../views/Admin/KennelsAdmin.vue'),
    beforeEnter(to,from,next){
      if(!store.getters.isAuthenticated) {
        next('/');
      }
      else next();
    }
  },
  {
    path: '/canil/:id/:id2',
    name: 'Kennel',
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () => import('../views/Utilizador/Kennel.vue'),
    beforeEnter(to,from,next){
      if(!store.getters.isAuthenticated) {
        next('/');
      }
      else next();
    }
  },
  {
    path: '/canil/admin/:id/:id2',
    name: 'KennelAdmin',
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () => import('../views/Admin/KennelAdmin.vue'),
    beforeEnter(to,from,next){
      if(!store.getters.isAuthenticated) {
        next('/');
      }
       
      else next();
    }
  },
  {
    path: '/preferencias/:id',
    name: 'Preferences',
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () => import('../views/Utilizador/Preferences.vue'),
    beforeEnter(to,from,next){
      if(!store.getters.isAuthenticated) {
        next('/');
      }
       
      else next();
    }
  },
  {
    path: '/preferencias/canil/:id',
    name: 'PreferencesKennel',
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () => import('../views/Canil/PreferencesKennel.vue'),
    beforeEnter(to,from,next){
      if(!store.getters.isAuthenticated) {
        next('/');
      }
       
      else next();
    }
  },
  {
    path: '/preferencias/admin/:id',
    name: 'PreferencesAdmin',
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () => import('../views/Admin/Preferencias.vue'),
    beforeEnter(to,from,next){
      if(!store.getters.isAuthenticated) {
        next('/');
      }
       
      else next();
    }
  },
  {
    path: '/parcerias/canil/:id',
    name: 'Parcerias',
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () => import('../views/Canil/Partnerships.vue'),
    beforeEnter(to,from,next){
      if(!store.getters.isAuthenticated) {
        next('/');
      }
       
      else next();
    }
  },
  {
    path: '/parcerias/admin/:id/:id2',
    name: 'Partnerships',
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () => import('../views/Admin/Parcerias.vue'),
    beforeEnter(to,from,next){
      if(!store.getters.isAuthenticated) {
        next('/');
      }
       
      else next();
    }
  },
  {
    path: '/parcerias/utilizador/:id/:id2',
    name: 'Parceria',
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () => import('../views/Utilizador/Parcerias.vue'),
    beforeEnter(to,from,next){
      if(!store.getters.isAuthenticated) {
        next('/');
      }
       
      else next();
    }
  },
  {
    path: '/voluntarios/canil/:id',
    name: 'VoluntariosCanil',
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () => import('../views/Canil/Volunteers.vue'),
    beforeEnter(to,from,next){
      if(!store.getters.isAuthenticated) {
        next('/');
      }
       
      else next();
    }
  },
  {
    path: '/voluntarios/admin/:id',
    name: 'Voluntarios',
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () => import('../views/Admin/Voluntarios.vue'),
    beforeEnter(to,from,next){
      if(!store.getters.isAuthenticated) {
        next('/');
      }
       
      else next();
    }
  },
  {
    path: '/voluntariado/:id',
    name: 'Voluntariado',
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () => import('../views/Utilizador/Voluntariado.vue'),
    beforeEnter(to,from,next){
      if(!store.getters.isAuthenticated) {
        next('/');
      }
       
      else next();
    }
  },
  {
    path: '/regista/horario/:id/:id2',
    name: 'RegistaHorario',
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () => import('../views/Utilizador/RegistaHorario.vue'),
    beforeEnter(to,from,next){
      if(!store.getters.isAuthenticated) {
        next('/');
      }
       
      else next();
    }
  },
  {
    path: '/informacoes/:id',
    name: 'Informacoes',
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () => import('../views/Canil/Informations.vue'),
    beforeEnter(to,from,next){
      if(!store.getters.isAuthenticated) {
        next('/');
      }
       
      else next();
    }
  },
  {
    path: '/informacoes/admin/:id/:id2',
    name: 'Informations',
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () => import('../views/Admin/Informacoes.vue'),
    beforeEnter(to,from,next){
      if(!store.getters.isAuthenticated) {
        next('/');
      }
       
      else next();
    }
  },
  {
    path: '/informacoes/utilizador/:id/:id2',
    name: 'Informações',
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () => import('../views/Utilizador/Informacoes.vue'),
    beforeEnter(to,from,next){
      if(!store.getters.isAuthenticated) {
        next('/');
      }
       
      else next();
    }
  },
  {
    path: '/pedido/registo/:id/:id2',
    name: 'PedidoRegisto',
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () => import('../views/Canil/RequestKennel.vue'),
    beforeEnter(to,from,next){
      if(!store.getters.isAuthenticated) {
        next('/');
      }
       
      else next();
    }
  },
  {
    path: '/pedido/adocao/admin/:id/:id2',
    name: 'PedidoAdocaoAdmin',
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () => import('../views/Admin/PedidosAdocao.vue'),
    beforeEnter(to,from,next){
      if(!store.getters.isAuthenticated) {
        next('/');
      }
       
      else next();
    }
  },
  {
    path: '/pedido/adocao/:id/:id2',
    name: 'PedidoAdocao',
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () => import('../views/Utilizador/PedidosAdocaoUser.vue'),
    beforeEnter(to,from,next){
      if(!store.getters.isAuthenticated) {
        next('/');
      }
       
      else next();
    }
  },
  {
    path: '/pedido/adocao/canil/:id/:id2',
    name: 'PedidoAdocaoCanil',
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () => import('../views/Canil/PedidosAdocaoCanil.vue'),
    beforeEnter(to,from,next){
      if(!store.getters.isAuthenticated) {
        next('/');
      }
       
      else next();
    }
  },
  {
    path: '/entre/contacto/:id',
    name: 'EntreEmContacto',
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () => import('../views/Admin/EntreEmContacto.vue'),
    beforeEnter(to,from,next){
      if(!store.getters.isAuthenticated) {
        next('/');
      }
       
      else next();
    }
  },
  {
    path: '/entre/contacto/canil/:id',
    name: 'EntreEmContactoCanil',
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () => import('../views/Canil/EntreEmContacto.vue'),
    beforeEnter(to,from,next){
      if(!store.getters.isAuthenticated) {
        next('/');
      }
       
      else next();
    }
  },

  {
    path: '/entre/contacto/utilizador/:id',
    name: 'EntreEmContactoUtilizador',
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () => import('../views/Utilizador/EntreEmContacto.vue'),
    beforeEnter(to,from,next){
      if(!store.getters.isAuthenticated) {
        next('/');
      }
       
      else next();
    }
  },
  {
    path: '/estatisticas/:id',
    name: 'Estatisticas',
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () => import('../views/Admin/Estatisticas.vue'),
    beforeEnter(to,from,next){
      if(!store.getters.isAuthenticated) {
        next('/');
      }
       
      else next();
    }
  },
  {
    path: '/documentos/:id',
    name: 'Documentos',
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () => import('../views/Utilizador/Textos.vue'),
    beforeEnter(to,from,next){
      if(!store.getters.isAuthenticated) {
        next('/');
      }
       
      else next();
    }
  },
  {
    path: '/documentos/admin/:id',
    name: 'DocumentosAdmin',
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () => import('../views/Admin/Textos.vue'),
    beforeEnter(to,from,next){
      if(!store.getters.isAuthenticated) {
        next('/');
      }
       
      else next();
    }
  },
  {
    path: '/documentos/direitosanimais/:id',
    name: 'DireitosAnimais',
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () => import('../views/Docs/DireitosUser.vue'),
    beforeEnter(to,from,next){
      if(!store.getters.isAuthenticated) {
        next('/');
      }
      else next();
    }
  },
  {
    path: '/documentos/esterilizar/:id',
    name: 'PorquêEsterilizar',
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () => import('../views/Docs/Esterilizar.vue'),
    beforeEnter(to,from,next){
      if(!store.getters.isAuthenticated) {
        next('/');
      }
      else next();
    }
  },
  {
    path: '/documentos/motivos/adotar/:id',
    name: 'MotivosAdotar',
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () => import('../views/Docs/Adotar.vue'),
    beforeEnter(to,from,next){
      if(!store.getters.isAuthenticated) {
        next('/');
      }
      else next();
    }
  },
  {
    path: '/documentos/treino/:id',
    name: 'TreinarCao',
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () => import('../views/Docs/Treinar.vue'),
    beforeEnter(to,from,next){
      if(!store.getters.isAuthenticated) {
        next('/');
      }
      else next();
    }
  },
  {
    path: '/documentos/doencas/:id',
    name: 'DoencasETratamentos',
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () => import('../views/Docs/Doencas.vue'),
    beforeEnter(to,from,next){
      if(!store.getters.isAuthenticated) {
        next('/');
      }
      else next();
    }
  },
  {
    path: '/documentos/admin/direitosanimais/:id',
    name: 'DireitosAnimaisAdmin',
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () => import('../views/Docs/DireitosUserAdmin.vue'),
    beforeEnter(to,from,next){
      if(!store.getters.isAuthenticated) {
        next('/');
      }
       
      else next();
    }
  },
  {
    path: '/documentos/admin/esterilizar/:id',
    name: 'PorquêEsterilizarAdmin',
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () => import('../views/Docs/EsterilizarAdmin.vue'),
    beforeEnter(to,from,next){
      if(!store.getters.isAuthenticated) {
        next('/');
      }
       
      else next();
    }
  },
  {
    path: '/documentos/admin/motivos/adotar/:id',
    name: 'MotivosAdotarAdmin',
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () => import('../views/Docs/AdotarAdmin.vue'),
    beforeEnter(to,from,next){
      if(!store.getters.isAuthenticated) {
        next('/');
      }
       
      else next();
    }
  },
  {
    path: '/documentos/admin/treino/:id',
    name: 'TreinarCaoAdmin',
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () => import('../views/Docs/TreinarAdmin.vue'),
    beforeEnter(to,from,next){
      if(!store.getters.isAuthenticated) {
        next('/');
      }
       
      else next();
    }
  },
  {
    path: '/documentos/admin/doencas/:id',
    name: 'DoencasETratamentosAdmin',
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () => import('../views/Docs/DoencasAdmin.vue'),
    beforeEnter(to,from,next){
      if(!store.getters.isAuthenticated) {
        next('/');
      }
       
      else next();
    }
  },
  {
    path: '/documentos/admin/adiciona/:id',
    name: 'AddDocumentos',
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () => import('../views/Admin/AdicionarDocumentos.vue'),
    beforeEnter(to,from,next){
      if(!store.getters.isAuthenticated) {
        next('/');
      }
       
      else next();
    }
  },
  {
    path: '/documentos/admin/:id/:id2',
    name: 'documentosRand',
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () => import('../views/Docs/DocumentosRand.vue'),
    beforeEnter(to,from,next){
      if(!store.getters.isAuthenticated) {
        next('/');
      }
       
      else next();
    }
  },
  {
    path: '/documentos/utilizador/:id/:id2',
    name: 'documentosRandUser',
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () => import('../views/Docs/DocumentosRandUser.vue'),
    beforeEnter(to,from,next){
      if(!store.getters.isAuthenticated) {
        next('/');
      }
      else next();
    }
  },
  {
    path: '/cao/utilizador/:id/:id2',
    name: 'caoUtilizador',
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () => import('../views/Utilizador/Cao.vue'),
    beforeEnter(to,from,next){
      if(!store.getters.isAuthenticated) {
        next('/');
      }
       
      else next();
    }
  },
  {
    path: '/cao/canil/:id/:id2',
    name: 'caoCanil',
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () => import('../views/Canil/Cao.vue'),
    beforeEnter(to,from,next){
      if(!store.getters.isAuthenticated) {
        next('/');
      }
       
      else next();
    }
  },
  {
    path: '/cao/admin/:id/:id2',
    name: 'caoAdmin',
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () => import('../views/Admin/Cao.vue'),
    beforeEnter(to,from,next){
      if(!store.getters.isAuthenticated) {
        next('/');
      }
       
      else next();
    }
  },
  {
    path: '/emissao/recibo/:id/:id2',
    name: 'Recibo',
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () => import('../views/Canil/Recibo.vue'),
    beforeEnter(to,from,next){
      if(!store.getters.isAuthenticated) {
        next('/');
      }
       
      else next();
    }
  },
  {
    path: '/teste',
    name: 'Teste',
    component: () => import('../views/teste.vue'),
  }
  
]

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes, 
  scrollBehavior (to, from, savedPosition) {
    if (savedPosition) {
      return savedPosition
    } else {
      return { x: 0, y: 0 }
    }
  }
})

export default router
