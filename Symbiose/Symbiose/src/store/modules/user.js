import * as types from '../types'
import LoginService from '../../services/LoginService'

let loginService = new LoginService()

const state = {
  Userdata: {}
}

const getters = {
  [types.USER_DATA]: (state) => {
    return state.Userdata
  },
  [types.USER_NAME]: (state) => {
    return state.Userdata.userName
  },
  [types.USER_ID]: (state) => {
    return state.Userdata.id
  },
  [types.USER_ROLES]: (state) => {
    return state.Userdata.roles
  }
}

const mutations = {
  [types.MUTATE_USER]: (state, payload) => {
    state.Userdata = payload
  }
}

const actions = {
  [types.FETCH_USER]: ({ commit }) => {
    return new Promise((resolve, reject) => {
      loginService.isLoggedIn()
        .then(response => {
          commit(types.MUTATE_USER, response.data)
          resolve(response)
        })
        .catch(e => {
          reject(e)
        })
    })
  }
}

export default {
  state,
  getters,
  mutations,
  actions
}
