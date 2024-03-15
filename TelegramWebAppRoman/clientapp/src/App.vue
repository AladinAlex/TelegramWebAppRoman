
<template>
  <component :is="layout" />
</template>

<script>
import { defineAsyncComponent, markRaw } from 'vue';

export default {
  data() {
    return {
      layout: null,
    };
  },
  watch: {
    $route(to, from) {
      document.title = to.meta?.title || "V I N Y L  D E A L E R";
      if (this.layout === null || to.meta?.layout !== from.meta?.layout) {
        this.layout = markRaw(
          defineAsyncComponent(() =>
            import(`./components/${to.meta?.layout || "Layout"}.vue`)
          )
        );
      }
    },
  },
};
</script>
<style>

</style>

