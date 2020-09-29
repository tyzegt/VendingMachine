<template>
    <div>
        <div v-if="categories.length == 0">
            <CarouselSkeleton v-for="i in 8" :key="i"></CarouselSkeleton>
        </div>
        <div v-else-if="categories.length > 0">
            <ProductsCarousel @purchased="purchased"
                v-for="category in categories" 
                :key="category.id" 
                :category="category">
            </ProductsCarousel>
        </div>

        

        
    </div>
</template>
<script src="./Showcase.ts"></script>