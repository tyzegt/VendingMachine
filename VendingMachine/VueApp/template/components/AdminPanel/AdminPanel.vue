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
                        <span class="input-group-text">Порол:</span>
                    </div>
                    <b-input v-model="password" @keydown.enter="signIn" type="text" class="form-control"></b-input>
                </div>
                <b-button @click="signIn">Вход</b-button>
            </b-container>  
            <div v-else>
                <h4>Администрирование монет:</h4>
            </div>
        </div>
              
    </div>
</template>
<script src="./AdminPanel.ts">
</script>