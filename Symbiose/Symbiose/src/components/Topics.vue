<template>
<v-content>
    <v-layout>
      <v-flex xs12 sm10 md8 lg8 offset-sm1 offset-md2 offset-lg2>
        <v-card>
          <v-card-text>
            <h3 v-if="topicsList.length > 0" class="text-xs-center">Topics</h3>
            <v-list two-line>
              <div v-for="topic in topicsList" :key="topic.name">
                <v-list-tile v-bind:key="topic.name" ripple @click="goTotopic">
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
export default {
  data () {
    return {
      topicsList: [
        {
          name: 'topic1',
          description: 'desc_topic1'
        }
      ]
    }
  },
  methods: {
    goTotopic () {
      this.$router.push('topics/topic')
    },
    addTopic () {
      this.$router.push('topics/addTopic')
    }
  }
}
</script>
<style>

</style>
