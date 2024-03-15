<template>

<div class="content">
  <div class="inner">
    <router-view />
  </div>
</div>

</template>
  
<script>
  
  export default {
  
    components: {
        
    },
    setup() {

    }
  }
</script>

<style lang="scss">

.content {
    background-color: #151515;
    // max-width: 480px;
    min-height: 100vh;
    // display: flex;
    // justify-content: flex-start;
    align-items: start;
}

</style>