<template>
  <v-layout row justify-center>
    <v-dialog v-model="dialog" persistent max-width="500px">
      <v-card>
        <v-form>
          <v-card-title>
            <span class="headline">Add new Task</span>
          </v-card-title>
          <v-card-text>
            <v-container grid-list-md>
              <v-layout wrap>
                <v-flex xs12 sm10 md9>
                  <v-text-field :rules="rules.taskName" v-model.trim="task.Name" label="Task Name" required></v-text-field>
                </v-flex>
                <v-flex xs12 sm10 md9>
                  <v-text-field label="Description" v-model="task.Description"></v-text-field>
                </v-flex>
                <v-flex xs12 sm10 md9>
                  <v-date-picker v-model="task.Deadline" ></v-date-picker>
                </v-flex>
              </v-layout>
            </v-container>
            <small>*indicates required field</small>
          </v-card-text>
          <v-card-actions>
            <v-spacer></v-spacer>
            <v-btn color="blue darken-1" flat @click.native="dismiss">Close</v-btn>
            <v-btn color="blue darken-1" :disabled="!isValid" flat @click.native="postTask">Save</v-btn>
          </v-card-actions>
        </v-form>
      </v-card>
    </v-dialog>
  </v-layout>
</template>

<script>
import TaskService from '../services/TaskService'
import * as types from '../store/types'

let taskService = new TaskService()

export default {
  data () {
    return {
      rules: {
        taskName: [
          (s) => !!s || 'Task Name is required!',
          (s) => (!!s && s.length > 5) || 'Task Name must have at least 5 characters'
        ]
      },
      task: {
        Name: '',
        Description: '',
        CreatorId: 0,
        DateCreated: new Date(),
        Deadline: new Date(),
        TaskStatus: 1,
        ProjectId: this.$route.params.id,
        DateEnded: new Date(),
        AssigneeId: this.$store.getters[types.USER_ID]
      }
    }
  },
  props: [ 'dialog' ],
  methods: {
    postTask () {
      if (this.isValid) {
        taskService.postNewTask(this.task)
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
      return this.rules.taskName.reduce((a, b) => a === true && b(this.task.Name) === true, true)
    }
  }
}
</script>

<style

</style>
