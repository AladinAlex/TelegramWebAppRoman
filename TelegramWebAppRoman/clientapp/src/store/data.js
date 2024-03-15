import { defineStore } from 'pinia'
import ApiCatalog from '../common/api/Catalog.js'
import { ref, reactive } from 'vue'

export const useCatalogStore = defineStore('catalogs', {
    state: () => ({
      Catalogs: []
    }),
    getters: {
      // getCatalogs: (state) => state.Catalogs
    },
    actions: {
      async setCatalogs() {
        await ApiCatalog.GetAll().then((r) => {
          if(r.status == 200 && r.data) {
            this.Catalogs = r.data;
          }
        })
        .catch((err) => console.log('Error: ' + err))
      },
      async getCatalog(id) {
        if(this.Catalogs.length == 0)
          await this.setCatalogs()
        return this.Catalogs.find(x => x.id == id)
      },
      async getCatalogs() {
        if(this.Catalogs.length == 0)
          await this.setCatalogs()
        return this.Catalogs
      }
    }
 });

export const useBasketStore = defineStore('basket', {
  state: () => ({
    // Basket: reactive([])
    Basket: []
  }),
  getters: {
    getBasket: (state) => state.Basket
  },
  actions: {
    addItem(value) {
      this.Basket.push(value)
    },
    removeItem(value) {
      this.Basket = this.Basket.filter(x => x !== value)
    },
    checkItem(value) {
      return this.Basket.includes(value)
    }
  }
});