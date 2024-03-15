import { createApp } from 'vue'
import './style.scss'
import App from './App.vue'
import VueTelegram from 'vue-tg'
import router from './router'
import axios from 'axios'
import VueAxios from 'vue-axios'
import config from './common/config'
import { createPinia } from 'pinia'

const pinia = createPinia()
const app = createApp(App)

app.use(VueAxios, axios)
app.use(router)
app.use(pinia)
app.use(VueTelegram)

app.mount('#app')

axios.defaults.baseURL = config.API_URL