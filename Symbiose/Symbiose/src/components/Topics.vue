<template>
<v-content>
    <v-layout>
      <v-flex xs12 sm10 md8 lg8 offset-sm1 offset-md2 offset-lg2>
        <v-card>
          <v-card-text>
            <h4>Topics</h4>
            <h5 v-if="topicsList.length === 0">There are no topics for now!</h5>
            <v-list two-line>
              <div v-for="topic in topicsList" :key="topic.name">
                <v-list-tile v-bind:key="topic.name" ripple @click="goTotopic(topic.id)">
                  <v-list-tile-content>
                    <v-list-tile-title v-html="topic.name"></v-list-tile-title>
                    <v-list-tile-sub-title v-html="topic.description"></v-list-tile-sub-title>
                  </v-list-tile-content>
                </v-list-tile>
              </div>
            </v-list>
          </v-card-text>
        </v-card>
      </v-flex>
      <v-btn fab dark class="blue" right bottom fixed @click="addTopic">
              <v-icon>add</v-icon>
      </v-btn>
    </v-layout>
    <router-view></router-view>
  </v-content>
</template>
<script>
import {mapGetters} from 'vuex'
import * as types from '../store/types'
import TopicService from '../services/TopicService'

let topicService = new TopicService()
export default {
  data () {
    return {
      topicsList: []
    }
  },
  methods: {
    goTotopic (topicId) {
      this.$router.push('topics/topic/' + topicId)
    },
    addTopic () {
      this.$router.push('topics/addTopic')
    }
  },
  computed: {
    ...mapGetters({
      UserName: types.USER_NAME,
      UserId: types.USER_ID
    })
  },
  created () {
    topicService.getTopics()
      .then(response => {
        this.topicsList = response.data
      })
    .catch(error => console.log(error))
  }
}
</script>
<style>

</style>
