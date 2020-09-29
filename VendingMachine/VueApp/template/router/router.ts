import VueRouter from 'vue-router'

// Pages
import VendingMachine from '../components/VendingMachine/VendingMachine.vue'
import AdminPanel from '../components/AdminPanel/AdminPanel.vue'

const routes = [
	{
		path: '*',
		redirect: { name: 'home' }
	},
	{
		name: 'home',
		path: `/`,
		component: VendingMachine
	},
	{
		name: 'admin',
		path: `/admin`,
		component: AdminPanel
	},
]

export const router = new VueRouter({
	mode: 'history',
	routes,
	linkActiveClass: 'is-active'
})
