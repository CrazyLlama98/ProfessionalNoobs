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
            <v-card v-if="projectsList.length > 0">
              <v-card-text>
                <h4>Projects</h4>
                <v-list two-line>
                  <div v-for="project in projectsList" :key="project.name">
                    <v-list-tile avatar v-bind:key="project.name" ripple @click="goToProject">
                      <v-list-tile-avatar>
                        <v-icon>mdi-projector-screen</v-icon>
                      </v-list-tile-avatar>
                      <v-list-tile-content>
                        <v-list-tile-title v-html="project.name"></v-list-tile-title>
                        <v-list-tile-sub-title v-html="project.description"></v-list-tile-sub-title>
                      </v-list-tile-content>
                    </v-list-tile>
                  </div>
                </v-list>
              </v-card-text>
            </v-card>
          </v-flex>
        </v-layout>
      </v-container>
    </v-content>
  </v-app>
</template>

<script>
import {mapGetters} from 'vuex'
import * as types from '../store/types'

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
      console.log(this.$store)
    }
  },
  computed: {
    ...mapGetters({
      UserName: types.USER_NAME
    })
  }
}

</script>
<style>

</style>
