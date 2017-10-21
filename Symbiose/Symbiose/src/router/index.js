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
      path: '/project',
      name: 'Project',
      component: () => import('@/components/Project'),
      children: [
        {
          path: '/tasks',
          name: 'Tasks',
          component: () => import('@/components/Tasks')
        },
        {
          path: '/topics',
          name: 'Topics',
          component: () => import('@/components/Topics')
        }
      ]
    },
    {
      path: '/projectslist',
      name: 'ProjectsList',
      component: () => import('@/components/ProjectsList')
    }
  ]
})
