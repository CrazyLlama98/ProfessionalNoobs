<template>
  <v-app toolbar>
    <v-navigation-drawer persistent enable-resize-watcher disable-route-watcher v-model="drawer" overflow app>
      <v-menu offset-y full-width>
        <v-list class="pa-1" slot="activator">
          <v-list-tile avatar>
            <v-list-tile-avatar>
              <v-icon>mdi-account</v-icon>
            </v-list-tile-avatar>
            <v-list-tile-content>
              <v-list-tile-title></v-list-tile-title>
            </v-list-tile-content>
          </v-list-tile>
        </v-list>
        <v-list>
          <v-btn small flat color class="mx-5" @click.native="logoff">Logout</v-btn>
        </v-list>
      </v-menu>
      <v-list class="pt-0" dense>
        <v-divider></v-divider>
        <v-list-tile to="tasks">
          <v-list-tile-action>
            <v-icon>mdi-format-list-checks</v-icon>
          </v-list-tile-action>
          <v-list-tile-content>
            <v-list-tile-title>Tasks</v-list-tile-title>
          </v-list-tile-content>
        </v-list-tile>
        <v-list-tile to="topics">
          <v-list-tile-action>
            <v-icon>mdi-wechat</v-icon>
          </v-list-tile-action>
          <v-list-tile-content>
            <v-list-tile-title>Topics</v-list-tile-title>
          </v-list-tile-content>
        </v-list-tile>
        <v-list-tile to="/projectslist">
          <v-list-tile-action>
            <v-icon>mdi-folder-open</v-icon>
          </v-list-tile-action>
          <v-list-tile-content>
            <v-list-tile-title>Projects List</v-list-tile-title>
          </v-list-tile-content>
        </v-list-tile>
      </v-list>
    </v-navigation-drawer>
    <v-toolbar fixed class="blue darken-3" dark app>
      <v-toolbar-side-icon @click.stop="drawer = !drawer"></v-toolbar-side-icon>
      <v-toolbar-title>Symbiose</v-toolbar-title>
    </v-toolbar>
      <v-container fluid>
        <router-view></router-view>
      </v-container>
  </v-app>
</template>

<script>
import ProjectService from '../services/ProjectService'

let projectService = new ProjectService()

export default {
  data () {
    return {
      right: null,
      drawer: true,
      currentProject: {}
    }
  },
  methods: {
    getProjectById () {
      projectService.getProjectById(this.$route.params.id)
      .then(response => {
        this.currentProject = response.data
      })
      .catch(error => console.log(error))
    }
  },
  mounted () {
    this.getProjectById()
  },
  beforeRouteUpdate (to, from, next) {
    this.getProjectById()
    next()
  }
}
</script>
<style>

</style>
