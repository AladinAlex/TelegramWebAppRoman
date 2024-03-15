<template>

<div class="catalog-item" @click="catalogHandler(item.id)">
    <div class="item-start">
        <div class="catalog-item__name">
            <span>{{ item.name }}</span>
        </div>
        <div class="catalog-item__count">
            <span>{{ item.itemCount }}</span>
        </div>
    </div>
    <div class="item-end">
        <div class="icon">
            <svg width="9" height="16" viewBox="0 0 9 16" fill="none" xmlns="http://www.w3.org/2000/svg">
                <path fill-rule="evenodd" clip-rule="evenodd" d="M0.46967 15.5303C0.176777 15.2374 0.176777 14.7626 0.46967 14.4697L6.93934 8L0.46967 1.53033C0.176777 1.23744 0.176777 0.762563 0.46967 0.46967C0.762564 0.176777 1.23744 0.176777 1.53033 0.46967L8.53033 7.46967C8.82322 7.76256 8.82322 8.23744 8.53033 8.53033L1.53033 15.5303C1.23744 15.8232 0.762564 15.8232 0.46967 15.5303Z" fill="white"/>
            </svg>
        </div>
    </div>
</div>

</template>
    
<script>
import { useRouter } from "vue-router"

export default {

    components: {
        
    },
    props: {
        item: {
            type: Object,
            required: true,
        }
    },
    setup(props) {
        const router = useRouter()

        const catalogHandler = (id) => {
            // console.log(id)
            // Telegram.WebApp.onEvent("mainButtonClicked", function() {
            //     tg.sendData(id)
            // })
            // if(tg.MainButton.isVisible) {
            //     tg.MainButton.hide()
            // }
            // else {
            //     tg.MainButton.setText(props.item.name)
            //     tg.MainButton.show()
            // }
            router.push({ path: '/catalog/' + id, replace: true })
        }

        return {
            catalogHandler
        }
    }
}
</script>
  
<style lang="scss">
.catalog-item {
    width: 100%;
    display: grid;
    align-items: center;
    grid-template-columns: auto max-content;
    cursor: pointer;
    
    .item-start {

        display: flex;
        justify-content: flex-start;

        .catalog-item__name {
            color: #FFFFFF;
            font-weight: 760;
            font-size: 20px;
            margin-right: 5px;
        }
        
        .catalog-item__count {
            color: #FFFFFF;
            font-weight: 540;
            font-size: 10px;
            width: 23px;
            height: 23px;
            border: 1px solid #343434; 
            border-radius: 50%;
            display: block;
            span {
                // text-align: center;
                // width: 100%;
                // display: inline-block;
                
                height: 100%;
                display: flex;
                justify-content: center;
                align-items: center;
            }
        }
    }

    .item-end {
        .icon {

            width: 24px;
            height: 24px;
            // display: block;
            margin: auto;

            // svg {
                height: 100%;
                display: flex;
                justify-content: center;
                align-items: center;
            // }
        }
    }
}
</style>