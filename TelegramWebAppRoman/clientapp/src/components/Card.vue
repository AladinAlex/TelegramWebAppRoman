<template>

<div class="card">
    <div class="card-inner">
        <div class="title">
            <span>{{ item.title }}</span>
        </div>
        <div class="subtitle">
            <span>{{ item.subtitle }}</span>
        </div>
        <div class="image">
            <img :src="item.image" alt="Картинка">
        </div>
        <div v-if="!store.checkItem(item)" class="price" @click="addToBasket(item)">
            <span>{{ (item.price).toLocaleString('ru') }}</span>
        </div>
        <div v-else class="price__in_basket" @click="removeFromBasket(item)">
            <!-- <span> -->
                <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" viewBox="0 0 16 16">
                    <path d="M16 8A8 8 0 1 1 0 8a8 8 0 0 1 16 0zM5.354 4.646a.5.5 0 1 0-.708.708L7.293 8l-2.647 2.646a.5.5 0 0 0 .708.708L8 8.707l2.646 2.647a.5.5 0 0 0 .708-.708L8.707 8l2.647-2.646a.5.5 0 0 0-.708-.708L8 7.293 5.354 4.646z"/>
                </svg>
            <!-- </span> -->
        </div>
    </div>
</div>

</template>

<script setup>
import { useBasketStore } from '../store/data.js'

const store = useBasketStore()

const props = defineProps({
    item: Object
})

const addToBasket = (item) => {
    store.addItem(item)
    configButton()
}

const removeFromBasket = (item) => {
    store.removeItem(item)
    configButton()
}


let tg = window.Telegram.WebApp
tg.MainButton.setParams({"color": "#007EF2"})
tg.MainButton.setParams({"textColor": "#FFFFFF"});

const configButton = () => {
    if(store.getBasket.length > 0)
    {
        tg.MainButton.setText("Корзина")
        tg.MainButton.show()
    }
    else {
        tg.MainButton.hide()
    }
}

</script>

<style lang="scss">
    .card {
        min-width: 175px;
        // width: 175px;

        .card-inner {
            display: block;
            // min-width: 119px;
            width: 119px;
            margin: 0px auto;

            .title {
                span {
                    color: #FFFFFF;
                    font-weight: 650;
                    font-size: 12px;
                }
            }

            .title {
                span {
                    color: #FFFFFF;
                    font-weight: 650;
                    font-size: 12px;
                }
            }

            .subtitle {
                span {
                    vertical-align: middle;
                    color: #AFAFAF;
                    font-weight: 410;
                    font-size: 8px;
                }
            }

            .image {
                display: inline-block;
                position: relative;
                // border: 1px dotted #262626;
                
                img {
                    display: block;
                    width: 119px;
                    height: 119px;
                    margin-top: 12px;

                    &::before {
                        content: '';
                        position: absolute;
                        border: 1px dotted #262626;
                        transform: rotate(8deg);
                        box-sizing: border-box;
                    }
                }
            }

            .price {
                margin-top: 16px;
                transform: rotate(-4deg);   
                
                span {
                    background-color: #FF5C00;
                    color: #FFFFFF;
                    font-weight: 410;
                    font-size: 16px;
                    margin: 0 auto;
                    border-radius: 40px;
                    padding: 2px 6px 2px 6px;

                    &::after {
                        content: " ₽";
                    }
                }
            }

            .price__in_basket {
                margin-top: 16px;
                transform: rotate(-4deg);
                svg {
                    background-color: #FFFFFF;
                    margin: 0 auto;
                    border-radius: 40px;
                    padding: 2px 6px 2px 6px;
                    text-align: center;
                    vertical-align: middle;
                }
            }
        }
    }
</style>