
<template>

    <div class="container-items">
        <div class="catalog-name">{{ catalog?.name }}</div>
        <div class="item-container">
            <div class="row">
                <Card v-for="(itm, index) in items" :key="index"  :item="itm"/>
            </div>
        </div>
    </div>

</template>

<script setup>
import Card from './Card.vue';
import { useRoute } from "vue-router";
import { useCatalogStore } from '../store/data.js'
import { ref } from 'vue'
import ApiItem from '../common/api/Item.js'


const router = useRoute()
const store = useCatalogStore()
let catalog = ref()

const setCatalog = async () => {
    catalog.value = await store.getCatalog(router.params.catalogItem)
}
setCatalog()

let items = ref([])

const getItems = async() => {
    await ApiItem.GetAll(router.params.catalogItem).then((r) => {
        if(r.status == 200 && r.data) {
            items.value = r.data
        }
    })
    .catch(err => {})
}
getItems()

</script>

<style lang="scss">
    .container-items {
        padding: 12px 0;
        margin: 0 16px;
        text-align: center;

        .catalog-name {
            color: #FFFFFF;
            font-weight: 760;
            font-size: 20px;
        }

        .item-container {
            margin-top: 16px;

            .row {
                display: grid;
                gap: 16px;
                grid-template-columns: repeat(2, 1fr)
            }
        }
        
    }
</style>