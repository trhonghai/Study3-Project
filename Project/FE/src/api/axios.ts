import axios from "axios";

const NET_BASE_URL = "http://localhost:5258/api";
const SPRINGBOOT_BASE_URL = "http://localhost:8081/api";

const instance = axios.create({
  baseURL: NET_BASE_URL,
  headers: {
    "Content-Type": "application/json",
  },
});

export default instance;
