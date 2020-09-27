<template>
    <div>
        <h4><center>{{category.name}}</center></h4>
            <vueper-slides
                class="no-shadow"
                :visible-slides="3"
                :slide-ratio="1/3"
                :fixedHeight="'300px'"
                slide-multiple
                :gap="2"
                infinite>
                <vueper-slide v-for="product in products" :key="product.id">
                    <template v-slot:content>
                        <b-card :title="product.name + ' (' + product.count + ' Шт.)'">
                            <b-img class="product-image" :src="product.photoUrl" alt="Left image" />
                            <b-card-text class="product-desc">
                                {{product.description}}
                            </b-card-text>
                            <template v-slot:footer>
                                <b-button 
                                    @click="buy(product)"
                                    :variant="product.isAvailable ? 'success' : 'secondary'" 
                                    :disabled="!product.isAvailable" class="float-right" block>
                                    <b-icon-cart4></b-icon-cart4>
                                    Купить за <b>{{product.price}}р.</b>
                                </b-button>
                            </template>
                        </b-card>
                    </template>
                </vueper-slide>
            </vueper-slides>
        <hr>


        
    </div>
</template>
<script src="./ProductsCarousel.ts"></script>
<style>
img.product-image {
    height: 60px;
}
.product-desc {
    overflow-y: scroll;
    height: 100px;
}

</style>