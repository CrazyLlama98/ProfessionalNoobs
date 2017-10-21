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
    </v-navigation-drawer>
    <v-toolbar fixed class="blue darken-3" dark app>
      <v-toolbar-side-icon @click.stop="drawer = !drawer"></v-toolbar-side-icon>
      <v-toolbar-title>Symbiose</v-toolbar-title>
    </v-toolbar>
    <main>
      <v-container fluid>
        <router-view></router-view>
      </v-container>
    </main>
  </v-app>
</template>

<script>
export default {
  data () {
    return {
      right: null,
      drawer: true
    }
  }
}
</script>
<style>

</style>
