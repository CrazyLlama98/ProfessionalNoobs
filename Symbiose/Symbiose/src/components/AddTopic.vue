<template>
  <v-layout row justify-center>
    <v-dialog v-model="dialog" persistent max-width="500px">
      <v-card>
        <v-form>
          <v-card-title>
            <span class="headline">Add new Topic</span>
          </v-card-title>
          <v-card-text>
            <v-container grid-list-md>
              <v-layout wrap>
                <v-flex xs12 sm10 md9>
                  <v-text-field :rules="rules.topicName" v-model.trim="topic.Name" label="Topic Title" required></v-text-field>
                </v-flex>
                <v-flex xs12 sm10 md9>
                  <v-text-field label="Description" v-model="topic.Description"></v-text-field>
                </v-flex>
              </v-layout>
            </v-container>
            <small>*indicates required field</small>
          </v-card-text>
          <v-card-actions>
            <v-spacer></v-spacer>
            <v-btn color="blue darken-1" flat @click.native="dismiss">Close</v-btn>
            <v-btn color="blue darken-1" :disabled="!isValid" flat @click.native="postTopic">Save</v-btn>
          </v-card-actions>
        </v-form>
      </v-card>
    </v-dialog>
  </v-layout>
</template>

<script>
import TopicService from '../services/TopicService'

let topicService = new TopicService()

export default {
  data () {
    return {
      rules: {
        topicName: [
          (s) => !!s || 'Topic Title is required!',
          (s) => (!!s && s.length > 5) || 'Topic Title must have at least 5 characters'
        ]
      },
      topic: {
        ProjectId: this.$route.params.id,
        Name: '',
        Description: ''

      }
    }
  },
  props: [ 'dialog' ],
  methods: {
    postTopic () {
      if (this.isValid) {
        topicService.postNewTopic(this.topic)
          .then(response => {
            if (response.status === 200 && response.data.status === 1) {
              this.$router.push('/project/' + this.$route.params.id)
            }
          })
          .catch(error => console.log(error))
      }
    },
    dismiss () {
      this.$router.replace('/project/' + this.$route.params.id)
    }
  },
  computed: {
    isValid () {
      return this.rules.topicName.reduce((a, b) => a === true && b(this.topic.Name) === true, true)
    }
  }
}
</script>

<style

</style>
