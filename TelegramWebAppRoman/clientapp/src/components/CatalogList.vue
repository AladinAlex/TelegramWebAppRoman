<template>

  <div v-for="(itm, index) in catalogList" :key="index" class="catalog-list">
    <CatalogItem :item="itm" />
  </div>


</template>

<script setup>
  import CatalogItem from './catalogItem.vue'
  import { reactive, ref } from 'vue'
  import { useCatalogStore } from '../store/data.js'

  const store = useCatalogStore()

  let catalogList = ref([])
  const setCatalogList = async() => {
    catalogList.value = await store.getCatalogs()
  }
  setCatalogList()

</script>

<style>
  .catalog-list {
    padding: 16px 0;
    margin: 0 16px;
    border-bottom: 1px solid #343434; 
  }
</style>