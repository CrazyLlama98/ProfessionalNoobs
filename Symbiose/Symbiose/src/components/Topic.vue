<template>
  <v-dialog v-model="dialog" fullscreen transition="dialog-bottom-transition" :overlay="false" scrollable>
      <v-card>
          <v-toolbar style="flex: 0 0 auto;" dark class="primary">
          <v-btn icon @click="close" dark>
            <v-icon>close</v-icon>
          </v-btn>
          <v-toolbar-title>Topic_Title</v-toolbar-title>
        </v-toolbar>
        <v-card-text>
          <v-layout mb-4>
            <v-flex xs3 sm2 md1 offset-lg1>
              <v-subheader>Description</v-subheader>
            </v-flex>
            <v-flex xs8 elevation-1 pa-2>
            <div
              name="topic_description"
              multi-line
              readonly
            >Topic_description</div>
          </v-flex>
        </v-layout>
        <v-layout>
          <v-flex offset-lg1>
        <v-subheader>Messages</v-subheader>
        </v-flex>
        </v-layout>
        <div v-if="messagesList.length > 0" v-for="message in messagesList" :key="message.author">
          <v-layout row mb-2>
            <v-flex xs3 sm2 md1 elevation-1 pa-2 offset-lg1>
              <v-layout row>
              <span>{{ message.author }}</span>
              </v-layout>
              <v-layout row>
              <span>{{ message.dateModified }}</span>
              </v-layout>
            </v-flex>
            <v-flex xs8 elevation-1 pa-2>
              <div
                  multi-line
                  readonly
                >{{ message.message }}</div>
              </v-flex>
            </v-layout>
          </div>
        <v-layout mt-2>
          <v-flex offset-xs3 xs8 offset-sm2 offset-md1 offset-lg2>
          <v-text-field label="Enter your message here" multi-line v-model="addedMessage"></v-text-field>
          </v-flex>
        </v-layout>
        <v-layout>
          <v-flex offset-xs8>
            <v-btn align-center @click="addMessage">Add Message</v-btn>
          </v-flex>
        </v-layout>
        </v-card-text>
          <div style="flex: 1 1 auto;"></div>
      </v-card>
    </v-dialog>
</template>
<script>
export default {
  data () {
    return {
      dialog: true,
      messagesList: [
        {
          author: 'gigi',
          message: 'salutasdf asdf asdf asdfasdf asdfasdf sd asdf asdf asdf asdf asdf asdf asdf asdf sad fsad fsad fsad fas dasdf adsf asdf asdf asdf asdf asdf asdf asd',
          dateModified: '1995-07-11'
        }
      ]
    }
  },
  methods: {
    close () {
      this.$router.replace('/project/topics')
    },
    addMessage () {

    }
  }
}
</script>
