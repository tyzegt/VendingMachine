<template>
    <div>
        <h4><center><b-skeleton type="button"></b-skeleton></center></h4>
            <vueper-slides
                class="no-shadow"
                :visible-slides="3"
                :slide-ratio="1/3"
                slide-multiple
                :fixedHeight="'300px'"
                :gap="2"
                infinite>
                <vueper-slide v-for="i in 8" :key="i" :title="'' + i">
                    <template v-slot:content>
                        <b-skeleton-img></b-skeleton-img>
                    </template>
                </vueper-slide>
            </vueper-slides>
        <hr>


        
    </div>
</template>
<script src="./CarouselSkeleton.ts"></script>