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
        requireAuth: false
      }
    },
    {
      path: '/project/:id',
      name: 'Project',
      component: () => import('@/components/Project'),
      redirect: '/project/:id/tasks',
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
            },
            {
              path: 'addTask',
              name: 'addTask',
              component: () => import('@/components/addTask'),
              meta: {
                requireAuth: true
              },
              props: {
                dialog: true
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
            },
            {
              path: 'addTopic',
              name: 'addTopic',
              component: () => import('@/components/addTopic'),
              meta: {
                requireAuth: true
              },
              props: {
                dialog: true
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
      },
      children: [
        {
          path: 'addNewProject',
          name: 'addNewProject',
          component: () => import('@/components/NewProjectForm'),
          meta: {
            requireAuth: true
          },
          props: {
            dialog: true
          }
        }
      ]
    }
  ]
})
