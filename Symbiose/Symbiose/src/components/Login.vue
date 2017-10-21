<template>
  <div>
    <!-- <h3 class="center">Welcome to Symbiose</h3> -->
    <v-container id="form">
      <v-layout row justify-center>
        <v-flex lg3 md5 sm7 xs10>
          <v-card>
            <v-card-title primary-title>
              <v-flex offset-xs1>
                <h4>Login</h4>
              </v-flex>
            </v-card-title>
            <v-card-text row @keyup.enter="login">
              <v-flex xs10 offset-xs1>
                <v-text-field name="email" label="Email" id="email" :error-messages="errors" @keyup="removeErrors" :rules="rules.email" v-model.trim="email" required>
                </v-text-field>
              </v-flex>
              <v-flex xs10 offset-xs1>
                <v-text-field name="password" label="Password" id="password" type="password" :error-messages="errors" :rules="rules.password" @keyup="removeErrors" required v-model.trim="password" :append-icon="!visible ? 'visibility' : 'visibility_off'" :append-icon-cb="() => (visible = !visible)" :type="!visible ? 'password' : 'text'">
                </v-text-field>
              </v-flex>
            </v-card-text>
            <v-card-actions>
              <v-flex xs4 offset-xs3 class="mb-2">
                <v-btn light primary @click="login" :disabled="!isValid">Login</v-btn>
              </v-flex>
              <v-flex xs3 class="mb-2">
                <v-btn light primary @click="register">Register</v-btn>
              </v-flex>
            </v-card-actions>
          </v-card>
        </v-flex>
      </v-layout>
    </v-container>
  </div>
</template>
<script>
import LoginService from '../services/LoginService'

let loginService = new LoginService()

export default {
  data () {
    return {
      rules: {
        email: [
          (e) => !!e || 'E-mail is required!',
          (e) => {
            const pattern = /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/
            return pattern.test(e) || 'Invalid e-mail.'
          }
        ],
        password: [
          (p) => p.length >= 8 || 'Password must have at least 8 characters!'
        ]
      },
      password: '',
      email: '',
      visible: false,
      errors: []
    }
  },
  methods: {
    login () {
      this.errors = []
      if (this.email !== '' && this.password !== '') {
        loginService.logInUser(this.email, this.password).then((response) => {
          if (response.status === 200) {
            loginService.isLoggedIn().then(() => {
              if (response.data.status === 1) {
                if (this.$route.query === {} || this.$route.query.redirect === undefined) {
                  this.$router.push('/')
                } else {
                  this.$router.push(this.$route.query.redirect)
                }
              } else {
                this.errors.push(response.data.text)
              }
            }).catch(error => console.log(error))
          } else {
            this.errors.push('Wrong Credentials')
          }
        }).catch(error => {
          console.log(error)
          this.errors.push('Wrong Credentials')
        })
      }
    },
    register () {
      this.$router.push('/register')
    },
    removeErrors () {
      this.errors = []
    }
  },
  computed: {
    isValid () {
      return this.rules.email.reduce((a, b) => a === true && b(this.email) === true, true) &&
        this.rules.password.reduce((a, b) => a === true && b(this.password) === true, true)
    }
  }
}
</script>
<style>

</style>
