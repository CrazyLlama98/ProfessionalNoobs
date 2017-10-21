import axios from 'axios'

axios.defaults.withCredentials = true

export default class ProjectService {
  getAll () {
    return new Promise((resolve, reject) => {
      axios.get('/api/projects')
        .then(result => {
          resolve(result)
        })
        .catch(error => {
          reject(error)
        })
    })
  }
}
