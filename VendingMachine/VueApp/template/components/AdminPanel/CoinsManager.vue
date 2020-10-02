<template>
    <div>
        <b-modal @ok="saveCoin" id="editing-modal" title="Редактирование">
            <div class="input-group mb-3">
                <div class="input-group-prepend">
                    <span class="input-group-text">Номинал:</span>
                </div>
                <b-input v-model="editedCoin.value" type="number" class="form-control"></b-input>
            </div>
            <div class="input-group mb-3">
                <div class="input-group-prepend">
                    <span class="input-group-text">Количество:</span>
                </div>
                <b-input v-model="editedCoin.count" type="number" class="form-control"></b-input>
            </div>
            <b-form-checkbox v-model="editedCoin.isAvailable" switch>
                Активна
            </b-form-checkbox>
        </b-modal>

        <vue-good-table
            :columns="columns"
            :rows="coins">
            <template slot="table-row" slot-scope="props">  
                <span v-if="props.column.field == 'edit'">
                    <b-button v-b-modal.editing-modal variant="warning" @click="editCoin(props.row.id)">
                        <b-icon-pencil></b-icon-pencil>
                    </b-button>
                    <b-button variant="danger" @click="deleteCoin(props.row.id)"><b-icon-x></b-icon-x></b-button>
                </span>
                <span v-else-if="props.column.field == 'isAvailable'">
                    <span v-if="props.row.isAvailable">Активна</span>
                    <span v-else>Не активна</span>
                </span>   
            </template>
        </vue-good-table><br>
        <b-button variant="success"  v-b-modal.editing-modal @click="addCoin()">
            <b><b-icon-plus></b-icon-plus> Добавить монету</b>
        </b-button>
    </div>
</template>
<script src="./CoinsManager.ts">
</script>