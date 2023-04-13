import { createApp } from 'vue'
import 'devextreme/dist/css/dx.light.css';
import App from './App.vue'
import router from './router'

createApp(App).use(router).mount('#app')
