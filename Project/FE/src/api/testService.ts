import axios from "./axios";
import { Test } from "./types/Test";
import { log } from "console";

export function postTest(data: Test): Promise<Test> {
  return axios.post("Test", data).then((res) => res.data).catch((err) => console.error(err));
}