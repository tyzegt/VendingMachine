import Vue from "vue";
import axios from "axios";
import Coin from "../models/Coin";
import Product from "../models/Product";
import Category from "../models/Category";
import PagingOptions from "../models/PagingOptions";

export default class RefData extends Vue {
    
    public static async getCoins(): Promise<Coin[]> {
        return await (await axios.get("/Coins/GetCoins")).data;
    }

    public static async getCategories(): Promise<Category[]> {
        return await (await axios.get("/Category/GetCategories")).data;
    }

    public static async getProductsByCategory(categoryId: number): Promise<Product[]> {
        return await (await axios.get("/Product/GetByCategory?categoryId=" + categoryId)).data;
    }

    public static async getProductsAll(): Promise<Product[]> {
        return await (await axios.post("/Product/GetAll")).data;
    }
}