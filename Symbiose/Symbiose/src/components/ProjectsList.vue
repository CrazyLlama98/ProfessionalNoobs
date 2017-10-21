<template>
  <v-app toolbar>
    <v-toolbar fixed class="blue darken-3" dark app>
      <v-menu offset-y full-width>
          <v-avatar slot="activator">
            <v-icon>mdi-account</v-icon>
          </v-avatar>
        <v-list>
          <v-list-tile>
          <v-btn small flat color @click.native="logoff">Logout</v-btn>
          </v-list-tile>
        </v-list>
      </v-menu>
      <v-toolbar-title>Symbiose</v-toolbar-title>
    </v-toolbar>
      <v-container>
        <v-layout>
          <v-flex xs12 sm10 md8 lg8 offset-sm1 offset-md2 offset-lg2 pt-5 mt-5>
            <v-card>
              <v-card-text>
                <h3 v-if="projectsList.length > 0" class="text-xs-center">Projects</h3>
                <v-list two-line>
                  <div v-for="project in projectsList" :key="project.name">
                    <v-list-tile v-bind:key="project.name" ripple @click="goToProject">
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
    </main>
  </v-app>
</template>

<script>
export default {
  data () {
    return {
      right: null,
      drawer: false,
      projectsList: [
        {
          name: 'proiect1',
          description: 'desc1r'
        }
      ]
    }
  },
  methods: {
    goToProject (index) {}
  }
}

</script>
<style>

</style>
