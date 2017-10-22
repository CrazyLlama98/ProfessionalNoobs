import Vue from 'vue'
import Router from 'vue-router'

Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/',
      name: 'Home',
      meta: {
        requireAuth: true
      },
      redirect: '/projectsList'
    },
    {
      path: '/login',
      name: 'Login',
      component: () => import('@/components/Login'),
      meta: {
        requireAuth: false
      }
    },
    {
      path: '/register',
      name: 'Register',
      component: () => import('@/components/Register'),
      meta: {
        requireAuth: true
      }
    },
    {
      path: '/project',
      name: 'Project',
      component: () => import('@/components/Project'),
      children: [
        {
          path: 'tasks',
          name: 'Tasks',
          component: () => import('@/components/Tasks'),
          meta: {
            requireAuth: true
          },
          children: [
            {
              path: 'task/:id',
              name: 'Task',
              component: () => import('@/components/Task'),
              meta: {
                requireAuth: true
              }
            }
          ]

        },
        {
          path: 'topics',
          name: 'Topics',
          component: () => import('@/components/Topics'),
          meta: {
            requireAuth: true
          },
          children: [
            {
              path: 'topic/:id',
              name: 'Topic',
              component: () => import('@/components/Topic'),
              meta: {
                requireAuth: true
              }
            }
          ]
        }
      ]
    },
    {
      path: '/projectslist',
      name: 'ProjectsList',
      component: () => import('@/components/ProjectsList'),
      meta: {
        requireAuth: true
      }
    }
  ]
})
