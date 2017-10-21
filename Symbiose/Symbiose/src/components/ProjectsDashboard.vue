<template>
<div>
  <v-app toolbar>
    <v-navigation-drawer persistent enable-resize-watcher disable-route-watcher v-model="drawer" overflow app>
      <v-menu offset-y full-width>
        <v-list class="pa-1" slot="activator">
          <v-list-tile avatar>
            <v-list-tile-avatar>
              <v-icon>mdi-account</v-icon>
            </v-list-tile-avatar>
            <v-list-tile-content>
              <v-list-tile-title v-text="Username"></v-list-tile-title>
            </v-list-tile-content>
          </v-list-tile>
        </v-list>
        <v-list>
          <v-btn small flat primary class="mx-5" @click.native="logoff">Logout</v-btn>
        </v-list>
      </v-menu>
      <v-list class="pt-0" dense>
        <v-divider></v-divider>
        <v-list-tile to="discountSimulator">
          <v-list-tile-action>
            <v-icon>mdi-ticket-percent</v-icon>
          </v-list-tile-action>
          <v-list-tile-content>
            <v-list-tile-title>Discount Simulator</v-list-tile-title>
          </v-list-tile-content>
        </v-list-tile>
        <v-list-tile to="asd">
          <v-list-tile-action>
            <v-icon>mdi-store</v-icon>
          </v-list-tile-action>
          <v-list-tile-content>
            <v-list-tile-title>Change the store</v-list-tile-title>
          </v-list-tile-content>
        </v-list-tile>
      </v-list>
    </v-navigation-drawer>
    <v-toolbar fixed class="blue darken-3" dark app>
      <v-toolbar-side-icon @click.stop="drawer = !drawer"></v-toolbar-side-icon>
      <v-toolbar-title>Discount Simulator</v-toolbar-title>
    </v-toolbar>
    <main>
      <v-container fluid>
        <router-view></router-view>
      </v-container>
    </main>
  </v-app>
</div>
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

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
h1, h2 {
  font-weight: normal;
}

ul {
  list-style-type: none;
  padding: 0;
}

li {
  display: inline-block;
  margin: 0 10px;
}

a {
  color: #42b983;
}
</style>
