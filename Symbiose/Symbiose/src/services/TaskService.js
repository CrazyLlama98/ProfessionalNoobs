import axios from 'axios'

axios.defaults.withCredentials = true

export default class TaskService {
  getTasksByUser (userId) {
    return new Promise((resolve, reject) => {
      axios.get('/api/tasks/user/' + userId)
        .then(result => {
          resolve(result)
        })
        .catch(error => {
          reject(error)
        })
    })
  }

  getTasksByProject (projectId) {
    return new Promise((resolve, reject) => {
      axios.get('/api/tasks/project/' + projectId)
        .then(result => {
          resolve(result)
        })
        .catch(error => {
          reject(error)
        })
    })
  }

  getTasksById (taskId) {
    return new Promise((resolve, reject) => {
      axios.get('/api/tasks/' + taskId)
        .then(result => {
          resolve(result)
        })
        .catch(error => {
          reject(error)
        })
    })
  }
}
