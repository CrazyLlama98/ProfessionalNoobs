<template>
  <v-content>
    <v-layout>
      <v-flex xs12 sm10 md8 lg8 offset-sm1 offset-md2 offset-lg2>
        <v-card>
          <v-card-text>
            <h4>My Projects</h4>
            <h5 v-if="tasksList.length === 0">You have no tasks for now!</h5>
            <v-list two-line>
              <div v-for="task in tasksList" :key="task.name">
                <v-list-tile v-bind:key="task.name" ripple @click="goToTask(task.id)">
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
import {mapGetters} from 'vuex'
import * as types from '../store/types'
import TaskService from '../services/TaskService'

let taskService = new TaskService()

export default {
  data () {
    return {
      tasksList: []
    }
  },
  methods: {
    goToTask (taskId) {
      this.$router.push('tasks/task/' + taskId)
    },
    addTask () {
      this.$router.push('tasks/addtask')
    }
  },
  computed: {
    ...mapGetters({
      UserName: types.USER_NAME,
      UserId: types.USER_ID
    })
  },
  created () {
    taskService.getTasksByUser(this.UserId)
      .then(response => {
        this.tasksList = response.data
      })
      .catch(error => console.log(error))
  }
}
</script>
<style>

</style>

