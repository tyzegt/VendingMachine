import Vue from "vue";
import { Component, Prop} from "vue-property-decorator";
import RefData from "@/template/util/RefData";
import Category from "@/template/models/Category";
import { BIconPencil, BIconX, BIconPlus } from 'bootstrap-vue';
import axios from "axios";
import Toaster from "@/template/util/Toaster";


@Component({
    components: {
        BIconPencil, BIconX, BIconPlus
    }
})
export default class CategoriesManager extends Vue {
    
    categories: Category[] = [];
    name: string = "";
    weight: number = 1000;
    editedCategory: Category = new Category();

    columns = [
        {
            label: 'Название категории',
            field: 'name',
        },
        {
            label: 'Вес (Для сортировки)',
            field: 'weight',
        },
        {
            label: '',
            field: 'edit',
            width: '10%',            
        },

    ];

    resetEditedCategory() {
        this.name = "";
        this.weight = 10;
        this.editedCategory.id = 0;
    }
    
    mounted() {       
        this.loadCategories();
    }

    async loadCategories() {
        this.categories = await RefData.getAllCategories();
    }

    addCategory() {
        this.resetEditedCategory();
    }

    editCategory(id: number) {
        this.editedCategory = this.categories.find(x => x.id == id) as Category;        
    }

    deleteCategory(id: number) {
        this.editedCategory = this.categories.find(x => x.id == id) as Category;   
        this.$bvModal.msgBoxConfirm("Вы уверены, что хотите безвозвратно удалить выбранную категорию?").then(modalResult => {
            if(modalResult) {
                axios.post("/Category/DeleteCategory", this.editedCategory).then(result => {
                    console.log(result.data);
                    if (result.data == "ok") {
                        Toaster.toast(this.$bvToast, "Монета удалена", "Успешно", "success");
                    } else if (result.data == "error") {
                        Toaster.toast(this.$bvToast, "Не удалось удалить категорию: к категории прикреплены товары", "Ошибка", "danger");
                    } else {
                        Toaster.toast(this.$bvToast, "Категория не найдена", "Ошибка", "danger");
                    }
                    this.loadCategories();
                    this.resetEditedCategory();
                }).catch(error => {
                    console.log(error);
                    Toaster.toast(this.$bvToast, "Что-то пошло не так", "Ошибка", "danger");
                });
            }
        });     
    }

    saveCategory() {
        var route = this.editedCategory.id == 0 ? "/Category/AddCategory" : "/Category/EditCategory";
        axios.post(route, this.editedCategory).then(result => {
            Toaster.toast(this.$bvToast, "Изменения сохранены", "Успешно", "success");
            this.loadCategories();
            this.resetEditedCategory();
        }).catch(error => {
            Toaster.toast(this.$bvToast, "Что-то пошло не так", "Ошибка", "danger");
        });
    }
    
}