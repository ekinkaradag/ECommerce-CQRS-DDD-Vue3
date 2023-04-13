import { createRouter, createWebHashHistory } from 'vue-router'
import HomeView from '../pages/HomePage.vue'

const routes = [
  {
    path: '/',
    name: 'Home',
    component: HomeView
  },
  {
    path: '/customer/:id/orders',
    name: 'Orders',
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () => import(/* webpackChunkName: "about" */ '../pages/OrdersPage.vue'),
    props(route) {
			return Object.freeze({
				id: route.params.id.toString(),
			});
		},
  },
  {
    path: '/customer/:customerId/orders/:id',
    name: 'Order Details',
    component: () => import(/* webpackChunkName: "about" */ '../pages/OrderDetailsPage.vue'),
    props(route) {
			return Object.freeze({
        id: route.params.id.toString(),
				customerId: route.params.customerId.toString(),
			});
		},
  }
]

const router = createRouter({
  history: createWebHashHistory(),
  routes
})

export default router
