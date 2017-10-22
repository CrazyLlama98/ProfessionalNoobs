<template>
  <v-layout row justify-center>
    <v-dialog v-model="dialog" persistent max-width="500px">
      <v-card>
        <v-form>
          <v-card-title>
            <span class="headline">Add new Project</span>
          </v-card-title>
          <v-card-text>
            <v-container grid-list-md>
              <v-layout wrap>
                <v-flex xs12 sm10 md9>
                  <v-text-field :rules="rules.projectName" v-model.trim="project.Name" label="Project Name" required></v-text-field>
                </v-flex>
                <v-flex xs12 sm10 md9>
                  <v-text-field label="Description" v-model="project.Description"></v-text-field>
                </v-flex>
              </v-layout>
            </v-container>
            <small>*indicates required field</small>
          </v-card-text>
          <v-card-actions>
            <v-spacer></v-spacer>
            <v-btn color="blue darken-1" flat @click.native="dismiss">Close</v-btn>
            <v-btn color="blue darken-1" :disabled="!isValid" flat @click.native="postProject">Save</v-btn>
          </v-card-actions>
        </v-form>
      </v-card>
    </v-dialog>
  </v-layout>
</template>

<script>
import ProjectService from '../services/ProjectService'
import * as types from '../store/types'

let projectService = new ProjectService()

export default {
  data () {
    return {
      rules: {
        projectName: [
          (s) => !!s || 'Project Name is required!',
          (s) => (!!s && s.length > 5) || 'Project Name must have at least 5 characters'
        ]
      },
      project: {
        Name: '',
        Description: '',
        CreatorId: 0,
        DateCreated: null,
        ProjectStatus: 1
      }
    }
  },
  props: [ 'dialog' ],
  methods: {
    postProject () {
      if (this.isValid) {
        this.project.CreatorId = this.$store.getters[types.USER_ID]
        this.project.DateCreated = new Date()
        projectService.postNewProject(this.project)
          .then(response => {
            if (response.status === 200 && response.data.status === 1) {
              this.$router.push('/projectsList')
            }
          })
          .catch(error => console.log(error))
      }
    },
    dismiss () {
      this.$router.replace('/projectsList')
    }
  },
  computed: {
    isValid () {
      return this.rules.projectName.reduce((a, b) => a === true && b(this.project.Name) === true, true)
    }
  }
}
</script>

<style

</style>
