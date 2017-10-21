import Vue from 'vue'
import Router from 'vue-router'

Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/login',
      name: 'Login',
      component: () => import('@/components/Login')
    },
    {
      path: '/register',
      name: 'Register',
      component: () => import('@/components/Register')
    },
    {
      path: '/',
      name: 'ProjectsDashboard',
      component: () => import('@/components/ProjectsDashboard')
    }
  ]
})
