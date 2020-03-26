import Vue from 'vue'
import Router from 'vue-router'

import Default from '@/components/Default'
import ExampleIndex from '@/components/example/Index'
import ExampleView from '@/components/example/View'
import InventarioIndex from '@/components/inventario/Index'
import InventarioCreateOrUpdate from '@/components/inventario/CreateOrUpdate'

Vue.use(Router)

const routes = [
  { path: '/', name: 'Default', component: Default },
  { path: '/example', name: 'ExampleIndex', component: ExampleIndex },
  { path: '/example/:id', name: 'ExampleView', component: ExampleView },
  { path: '/inventario/', name: 'InventarioIndex', component: InventarioIndex },
  { path: '/inventario/add', name: 'InventarioCreate', component: InventarioCreateOrUpdate },
  { path: '/inventario/:id/edit', name: 'InventarioEdit', component: InventarioCreateOrUpdate },
]

export default new Router({
  routes
})
