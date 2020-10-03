<template>
    <div>
        <b-modal @ok="saveCategory" id="category-editing-modal" title="Редактирование">
            <div class="input-group mb-3">
                <div class="input-group-prepend">
                    <span class="input-group-text">Название категории:</span>
                </div>
                <b-input v-model="editedCategory.name" class="form-control"></b-input>
            </div>
            <div class="input-group mb-3">
                <div class="input-group-prepend">
                    <span class="input-group-text">Вес (Для сортировки):</span>
                </div>
                <b-input v-model="editedCategory.weight" type="number" class="form-control"></b-input>
            </div>
        </b-modal>

        <vue-good-table
            :columns="columns"
            :rows="categories">
            <template slot="table-row" slot-scope="props">  
                <span v-if="props.column.field == 'edit'">
                    <b-button @click="editCategory(props.row.id)" v-b-modal.category-editing-modal variant="warning">
                        <b-icon-pencil></b-icon-pencil>
                    </b-button>
                    <b-button @click="deleteCategory(props.row.id)" variant="danger"><b-icon-x></b-icon-x></b-button>
                </span>
                <span v-else-if="props.column.field == 'isAvailable'">
                    <span v-if="props.row.isAvailable">Активна</span>
                    <span v-else>Не активна</span>
                </span>   
            </template>
        </vue-good-table><br>
        <b-button variant="success" v-b-modal.category-editing-modal>
            <b><b-icon-plus></b-icon-plus> Добавить категорию</b>
        </b-button>
    </div>
</template>
<script src="./CategoriesManager.ts">
</script>