<template>
    <div>
        <b-modal id="product-editing-modal" title="Редактирование" @ok="saveProduct" @cancel="cancel">
            <div class="input-group mb-3">
                <div class="input-group-prepend">
                    <span class="input-group-text">Наименование:</span>
                </div>
                <b-input v-model="editedProduct.name" class="form-control"></b-input>
            </div>
            <div class="input-group mb-3">
                <div class="input-group-prepend">
                    <span class="input-group-text">Описание:</span>
                </div>
                <b-textarea v-model="editedProduct.description" class="form-control"></b-textarea>
            </div>
            <div class="input-group mb-3">
                <div class="input-group-prepend">
                    <span class="input-group-text">Категория:</span>
                </div>
                <b-select 
                    :options="categories"
                    value-field="id"
                    text-field="name"
                    v-model="editedProduct.categoryId">
                </b-select>
            </div>      
            <div class="input-group mb-3">
                <div class="input-group-prepend">
                    <span class="input-group-text">Ссылка на фото:</span>
                </div>
                <b-input v-model="editedProduct.photoUrl" class="form-control"></b-input>
            </div>     
            <div class="input-group mb-3">
                <div class="input-group-prepend">
                    <span class="input-group-text">Цена:</span>
                </div>
                <b-input v-model="editedProduct.price" type="number" class="form-control"></b-input>
            </div>
            <div class="input-group mb-3">
                <div class="input-group-prepend">
                    <span class="input-group-text">Количество:</span>
                </div>
                <b-input v-model="editedProduct.count" type="number" class="form-control"></b-input>
            </div>
            <div class="input-group mb-3">
                <div class="input-group-prepend">
                    <span class="input-group-text">Вес (для сортировки):</span>
                </div>
                <b-input v-model="editedProduct.weight" type="number" class="form-control"></b-input>
            </div>
            <b-form-checkbox 
                v-model="editedProduct.isAvailable" switch>
                Активен
            </b-form-checkbox>
        </b-modal>

        <b-row>
            <b-col>
                <div class="input-group mb-3">
                    <div class="input-group-prepend">
                        <span class="input-group-text">Категория:</span>
                    </div>
                    <b-select 
                        @change="categoryChanged"
                        :options="categories"
                        value-field="id"
                        text-field="name"
                        v-model="categoryId">
                    </b-select>
                    <b-button @click="resetCategory" class="input-group-append">
                        Сброс
                    </b-button>
                </div>                
            </b-col>
            <b-col>
                <b-button @click="resetProduct" variant="success" v-b-modal.product-editing-modal>
                    <b><b-icon-plus></b-icon-plus>Новый товар</b>
                </b-button>
            </b-col>
            
        </b-row>

        
        
        <hr>
        <div v-for="product in products" :key="product.id">
            <h5>{{product.name}} ({{getCategory(product.categoryId)}})</h5>
            <b-row>
                <b-col cols="1"><b-img width="100px" :src="product.photoUrl"></b-img></b-col>
                <b-col cols="10">
                    <p>{{product.description}}</p>
                    <p><b>Цена:</b> {{product.price}} <b>Количество:</b> {{product.count}} </p>
                    <b-form-checkbox disabled
                        @change="onCheck($event, product.id)"
                        v-model="product.isAvailable" switch>
                        Активен
                    </b-form-checkbox>
                </b-col>
                <b-col cols="1">
                    <b-button @click="editProduct(product.id)" v-b-modal.product-editing-modal variant="warning">
                        <b-icon-pencil></b-icon-pencil>
                    </b-button>
                    <b-button variant="danger" @click="deleteProduct(product.id)"><b-icon-x></b-icon-x></b-button>
                </b-col>
            </b-row>

            <hr>
        </div>

        
        <b-row>
            <b-col>
                <b-pagination
                    @change="pageChanged"
                    v-model="pageNumber"
                    :total-rows="totalCount"
                    :per-page="perPage"
                    aria-controls="my-table"
                ></b-pagination>
            </b-col>
        </b-row>
        
    </div>
</template>
<script src="./ProductsManager.ts">
</script>