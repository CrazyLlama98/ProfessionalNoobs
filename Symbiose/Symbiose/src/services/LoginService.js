import axios from 'axios'

axios.defaults.withCredentials = true

export default class LoginService {

  registerUser (username, email, password) {
    return new Promise((resolve, reject) => {
      axios.post('api/accounts/register', { username, email, password })
      .then(response => {
        resolve(response)
      })
      .catch(error => {
        reject(error)
      })
    })
  }

  logInUser (email, password) {
    return new Promise((resolve, reject) => {
      axios.post('/api/accounts/login', { email, password })
      .then(response => {
        resolve(response)
      })
      .catch(error => {
        reject(error)
      })
    })
  }

  logOffUser () {
    return new Promise((resolve, reject) => {
      axios.post('/api/accounts/logoff')
      .then(response => {
        resolve(response)
      })
      .catch(error => {
        reject(error)
      })
    })
  }

  isLoggedIn () {
    return new Promise((resolve, reject) => {
      axios.post('/api/accounts/identity')
      .then(response => {
        resolve(response)
      })
      .catch(error => {
        reject(error)
      })
    })
  }
}
