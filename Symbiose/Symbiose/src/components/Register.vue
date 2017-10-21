<template>
  <div>
    <v-container id="form">
      <v-layout row justify-center>
        <v-flex lg3 md5 sm7 xs10>
          <v-card>
            <v-card-title primary-title>
              <v-flex offset-xs1>
                <h4>Register</h4>
              </v-flex>
            </v-card-title>
            <v-card-text row @keyup.enter="register">
              <v-flex xs10 offset-xs1>
                <v-text-field name="username" label="Username" id="username" :error-messages="errors" :rules="rules.username" v-model.trim="username" @keyup="removeErrors" required>
                </v-text-field>
              </v-flex>
              <v-flex xs10 offset-xs1>
                <v-text-field name="email" label="Email" id="email" :error-messages="errors" :rules="rules.email" v-model.trim="email" @keyup="removeErrors" required>
                </v-text-field>
              </v-flex>
              <v-flex xs10 offset-xs1>
                <v-text-field name="password" label="Password" id="password" type="password" :rules="rules.password" :error-messages="errors" @keyup="removeErrors" required v-model.trim="password" :append-icon="!visible ? 'visibility' : 'visibility_off'" :append-icon-cb="() => (visible = !visible)" :type="!visible ? 'password' : 'text'">
                </v-text-field>
              </v-flex>
              <v-flex xs10 offset-xs1>
                <v-text-field name="retypedPassword" label="Retype Password" id="retypedPassword" :rules="rules.retypedPassword" type="password" :error-messages="errors" @keyup="removeErrors" required v-model.trim="retypedPassword">
                </v-text-field>
              </v-flex>
            </v-card-text>
            <v-card-actions>
              <v-flex xs2 offset-xs7 class="mb-2">
                <v-btn light primary @click="register" :disabled="!isValid">Register</v-btn>
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
        username: [
          (u) => !!u || 'Username is required!',
          (u) => u.length >= 6 || 'Username must be at least 6 characters!'
        ],
        email: [
          (e) => !!e || 'E-mail is required!',
          (e) => {
            const pattern = /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/
            return pattern.test(e) || 'Invalid e-mail.'
          }
        ],
        password: [
          (p) => !!p || 'Password is required!',
          (p) => p.length >= 8 || 'Password must have at least 8 characters!'
        ],
        retypedPassword: [
          (r) => r === this.password || 'Password is not the same!'
        ]
      },
      username: '',
      password: '',
      retypedPassword: '',
      email: '',
      visible: false,
      errors: []
    }
  },
  methods: {
    register () {
      this.errors = []
      if (this.formCheck()) {
        loginService.registerUser(this.username, this.email, this.password).then((response) => {
          if (response.status === 200) {
            this.$router.push('/login')
          } else {
            this.errors.push('Server error')
          }
        }).catch(error => {
          console.log(error)
          this.errors.push('Server error')
        })
      }
    },
    removeErrors () {
      this.errors = []
    },
    formCheck () {
      return this.username !== '' && this.email !== '' && this.password !== '' && this.retypedPassword !== '' && this.password === this.retypedPassword
    }
  },
  computed: {
    isValid () {
      return this.username !== '' && this.email !== '' && this.password !== '' && this.retypedPassword !== '' && this.password === this.retypedPassword
    }

  }
}
</script>
<style>

</style>