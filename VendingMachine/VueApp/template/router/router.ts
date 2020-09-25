import VueRouter from 'vue-router'

// Pages
import VendingMachine from '@/template/components/VendingMachine/VendingMachine.vue'


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
	// {
	// 	name: 'vuex',
	// 	path: `/vuex`,
	// 	component: Vuex
	// },
	// {
	// 	name: 'thirdpartylibraries',
	// 	path: `/thirdpartylibraries`,
	// 	component: ThirdPartyLibraries
	// }
]

export const router = new VueRouter({
	mode: 'history',
	routes,
	linkActiveClass: 'is-active'
})
