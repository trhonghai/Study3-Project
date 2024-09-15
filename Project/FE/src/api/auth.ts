import axios from "./axios";
import { TokenResponse } from "~/api/types/Auth";

interface AuthResponse {
  token: string;
}
interface RegisterRequest {
  firstName: string;
  lastName: string;
  email: string;
  password: string;
  rePassword: string;
  phoneNumber: string;
}

export const login = async (
  email: string,
  password: string
): Promise<TokenResponse> => {
  const response = await axios.post("User/login", {
    email,
    password,
  });
  return response.data as TokenResponse;
};

export const register = async (userData: RegisterRequest): Promise<string> => {
  console.log(userData);
  const response = await axios.post("User/register", userData, {
    headers: {
      "Content-Type": "application/json",
    },
  });
  return response.data;
};
