import axios from 'axios'

axios.defaults.withCredentials = true

export default class TopicService {
  getMessagesByTopicId (topicId) {
    return new Promise((resolve, reject) => {
      axios.get('/api/TopicMessages/' + topicId)
        .then(result => {
          resolve(result)
        })
        .catch(error => {
          reject(error)
        })
    })
  }

  getTopics () {
    return new Promise((resolve, reject) => {
      axios.get('/api/topics')
        .then(result => {
          resolve(result)
        })
        .catch(error => {
          reject(error)
        })
    })
  }

  getTopicById (topicId) {
    return new Promise((resolve, reject) => {
      axios.get('/api/topics/' + topicId)
        .then(result => {
          resolve(result)
        })
        .catch(error => {
          reject(error)
        })
    })
  }
}
