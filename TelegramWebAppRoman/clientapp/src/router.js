import { createRouter, createWebHistory } from 'vue-router'

const routes = [
    {
        path: "/",  
        name: "Index",
        component: () => import("./components/CatalogList.vue"),
        meta: {
            title: 'V I N Y L  D E A L E R',
            layout: 'Layout',
            name: ''
        }
    },
    {
        path: "/catalog/:catalogItem",
        name: "Каталог",
        component: () => import("./components/Items.vue"),
        meta: {
            title: 'V I N Y L  D E A L E R',
            layout: 'Layout',
            name: ''
        }
    }   
]

const router = createRouter({
    history: createWebHistory(),
    routes: routes,
})

export default router;