import axios from 'axios'

axios.defaults.withCredentials = true

export default class ProjectService {
  getProjectsByUser (userId) {
    return new Promise((resolve, reject) => {
      axios.get('/api/projects/user/' + userId)
        .then(result => {
          resolve(result)
        })
        .catch(error => {
          reject(error)
        })
    })
  }

  postNewProject (newProject) {
    return new Promise((resolve, reject) => {
      axios.post('/api/Projects/addNewProject', newProject)
        .then(response => {
          resolve(response)
        })
        .catch(error => {
          reject(error)
        })
    })
  }

  getProjectById (id) {
    return new Promise((resolve, reject) => {
      axios.get('/api/projects/' + id)
        .then(result => {
          resolve(result)
        })
        .catch(error => {
          reject(error)
        })
    })
  }
}
