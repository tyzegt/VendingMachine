import Vue from "vue";
import axios from "axios";
import Coin from "../models/Coin";
import Product from "../models/Product";
import Category from "../models/Category";
import PagingOptions from "../models/PagingOptions";
import ProductsRequest from "../models/ProductsRequest";
import ProductsViewModel from "../models/ProductsViewModel";

export default class RefData extends Vue {
    
    public static async getCoins(): Promise<Coin[]> {
        return await (await axios.get("/Coins/GetCoins")).data;
    }

    public static async getAllCategories(): Promise<Category[]> {
        return await (await axios.get("/Category/GetAllCategories")).data;
    }

    public static async getFilledCategories(): Promise<Category[]> {
        return await (await axios.get("/Category/GetFilledCategories")).data;
    }

    public static async getProductsByCategory(categoryId: number): Promise<Product[]> {
        return await (await axios.get("/Product/GetByCategory?categoryId=" + categoryId)).data;
    }

    public static async getProducts(param: ProductsRequest): Promise<ProductsViewModel> {
        return await (await axios.post("/Product/GetProducts", param)).data;
    }
}