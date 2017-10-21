<template>
  <v-dialog v-model="dialog" fullscreen transition="dialog-bottom-transition" :overlay="false" scrollable>
      <v-card>
          <v-toolbar style="flex: 0 0 auto;" dark class="primary">
          <v-btn icon @click="close" dark>
            <v-icon>close</v-icon>
          </v-btn>
        </v-toolbar>
        <v-card-text>

        </v-card-text>

          <div style="flex: 1 1 auto;"></div>
      </v-card>

    </v-dialog>
</template>
<script>
export default {
  data () {
    return {
      dialog: true
    }
  },
  methods: {
    close () {
      this.$router.replace('/project/topics')
    }
  }
}
</script>
