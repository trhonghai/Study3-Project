import axios from "./axios";

export function AddType(typeName: string) {
    return axios.post("/Test/add-type", { name: typeName });
}

export function getAllTypes() {
    return axios.get("/Test/get-types");
}