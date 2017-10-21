<template>
  <v-content>
    <v-layout>
      <v-flex xs12 sm10 md8 lg8 offset-sm1 offset-md2 offset-lg2>
        <v-card>
          <v-card-text>
            <h3 v-if="tasksList.length > 0" class="text-xs-center">Tasks</h3>
            <v-list two-line>
              <div v-for="task in tasksList" :key="task.name">
                <v-list-tile v-bind:key="task.name" ripple @click="goToTask">
                  <v-list-tile-content>
                    <v-list-tile-title v-html="task.name"></v-list-tile-title>
                    <v-list-tile-sub-title v-html="task.description"></v-list-tile-sub-title>
                  </v-list-tile-content>
                </v-list-tile>
              </div>
            </v-list>
          </v-card-text>
        </v-card>
      </v-flex>
      <v-btn fab dark class="blue" right bottom fixed @click="addTask">
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
      tasksList: [
        {
          name: 'task1',
          description: 'desc_task1'
        }
      ]
    }
  },
  methods: {
    goToTask () {
      this.$router.push('tasks/task')
    },
    addTask () {
      this.$router.push('tasks/addtask')
    }
  }
}
</script>
<style>

</style>

