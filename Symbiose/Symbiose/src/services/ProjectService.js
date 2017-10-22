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
}
