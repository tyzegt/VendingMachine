<template>
    <div>
        <div v-if="!loading">

            <b-container v-if="!isSigned" class="mt-5 w-25 mx-auto">
                <center><h4>Вход в административную часть</h4></center> <hr>
                <div class="input-group mb-3">
                    <div class="input-group-prepend">
                        <span class="input-group-text">Логин:</span>
                    </div>
                    <b-input v-model="login" @keydown.enter="signIn" type="text" class="form-control"></b-input>
                </div>
                <div class="input-group mb-3">
                    <div class="input-group-prepend">
                        <span class="input-group-text">Пароль:</span>
                    </div>
                    <b-input v-model="password" @keydown.enter="signIn" type="password" class="form-control"></b-input>
                </div>
                <b-button @click="signIn">Вход</b-button>
            </b-container>  

            <div v-else>
                <br>                
                <b-card no-body>
                    <b-card-header>
                        Панель управления торговым автоматом
                    </b-card-header>
                    <b-tabs card>
                        <b-tab lazy title="Товары" active>
                            <ProductsManager></ProductsManager>
                        </b-tab>
                        <b-tab lazy title="Категории">
                            <CategoriesManager></CategoriesManager>
                        </b-tab>
                        <b-tab lazy title="Монеты">
                            <CoinsManager></CoinsManager>
                        </b-tab>
                    </b-tabs>
                </b-card>
            </div>
        </div>
              
    </div>
</template>
<script src="./AdminPanel.ts">
</script>
<style>
.tabs {
    display:block;
    white-space: normal;
}
ul.pagination {
    border-bottom-width: 0px;
    border-bottom: 0px;
}
</style>