<template>
  <nav>
    <DisclaimerComponent />
    <router-link to="/">Home</router-link> |
    <router-link :to="{
					name: 'Orders',
					params: { id: '4667C05F-4162-4CCB-8FD6-B73B1B16EED7' },
				}">Orders</router-link>
  </nav>
  <router-view/>
</template>
<script>
import DisclaimerComponent from './components/DisclaimerComponent.vue';

export default {
  name: 'App',
  components: {
    DisclaimerComponent
  }
}
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
}

nav {
  padding: 30px;
}

nav a {
  font-weight: bold;
  color: #2c3e50;
}

nav a.router-link-exact-active {
  color: #4285b9;
}
</style>
