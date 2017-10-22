<template>
  <v-app toolbar>
    <v-toolbar fixed class="blue darken-3" dark app>
      <v-toolbar-title>Symbiose</v-toolbar-title>
      <v-spacer></v-spacer>
      <span>Hello, {{UserName}}</span>
      <v-btn flat color @click.native="logoff" icon>
        <v-icon>
          mdi-logout
        </v-icon>
      </v-btn>
    </v-toolbar>
    <v-content>
      <v-container>
        <v-layout>
          <v-flex xs12 sm10 md8 lg8 offset-sm1 offset-md2 offset-lg2 pt-5 mt-5>
            <v-card>
              <v-card-text>
                <h4>My Projects</h4>
                <h5 v-if="projectsList.length === 0">You have no projects for now!</h5>
                <v-list three-line>
                  <div v-for="project in projectsList" :key="project.name">
                    <v-list-tile avatar v-bind:key="project.name" ripple @click="goToProject(project.id)">
                      <v-list-tile-avatar>
                        <v-icon>mdi-projector-screen</v-icon>
                      </v-list-tile-avatar>
                      <v-list-tile-content>
                        <v-list-tile-title v-html="project.name"></v-list-tile-title>
                        <v-list-tile-sub-title v-html="project.description"></v-list-tile-sub-title>
                        <v-list-tile-sub-title>You are {{project.projectRole}}</v-list-tile-sub-title>
                      </v-list-tile-content>
                    </v-list-tile>
                  </div>
                </v-list>
              </v-card-text>
            </v-card>
          </v-flex>
        </v-layout>
        <v-btn class="blue darken-3" dark fixed bottom right fab to="/projectsList/addNewProject">
          <v-icon>add</v-icon>
        </v-btn>
        <router-view></router-view>
      </v-container>
    </v-content>
  </v-app>
</template>

<script>
import {mapGetters} from 'vuex'
import * as types from '../store/types'

import ProjectService from '../services/ProjectService'

let projectService = new ProjectService()

export default {
  data () {
    return {
      right: null,
      drawer: false,
      projectsList: []
    }
  },
  methods: {
    goToProject (index) {
      this.$router.push('/project/' + index)
    },
    getProjects () {
      projectService.getProjectsByUser(this.UserId)
      .then(response => {
        this.projectsList = response.data
        for (var i in this.projectsList) {
          this.projectsList[i].projectRole = this.Roles.find(item => item.projectId === this.projectsList[i].id).roleName
        }
      })
      .catch(error => console.log(error))
    }
  },
  computed: {
    ...mapGetters({
      UserName: types.USER_NAME,
      UserId: types.USER_ID,
      Roles: types.USER_ROLES
    })
  },
  beforeRouteUpdate (to, from, next) {
    this.getProjects()
    next()
  },
  mounted () {
    this.getProjects()
  }
}

</script>
<style>

</style>
