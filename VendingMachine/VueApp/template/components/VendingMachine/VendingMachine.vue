<template>
    <div>
        <br>
        <MessageDisplay :message="message"></MessageDisplay>
        <hr>
        <b-row v-if="coins.length > 0" :cols="coins.length">            
            <b-col v-for="coin in coins" :key="coin.id">
                <b-button 
                    @click="addCoin(coin)"
                    :id="'coin-' + coin.id"
                    :variant="getCoinVariant(coin.isAvailable)" 
                    :disabled="!coin.isAvailable || loadingCoin"
                    block>                    
                    <span v-if="!coin.isAvailable">(Недоступно)</span>
                    <span v-else>Внести монету <b>{{coin.value}}р.</b></span>
                </b-button>
            </b-col>
        </b-row>
        <b-row v-else>
            <b-col v-for="i in 4" :key="i">
                <b-skeleton type="input"></b-skeleton>
            </b-col>
        </b-row>

        <br>
        <b-row>
            <b-col>
                <h4>Внесённая сумма: 
                    <b-spinner v-if="loadingSum" variant="secondary"></b-spinner>
                    <span v-else>{{totalSum}}</span>
                </h4>
            </b-col>
            <b-col>
                <b-button 
                    @click="returnChange"
                    :disabled="totalSum == 0" 
                    class="float-right" 
                    variant="warning">
                    Вернуть деньги
                </b-button>
            </b-col>
        </b-row>
        
        <hr>
        <Showcase></Showcase>

    </div>
</template>

<script src="./VendingMachine.ts">
</script>
