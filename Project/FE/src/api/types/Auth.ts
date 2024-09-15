export interface TokenResponse {
  accessToken: {
    expiryTokenDate: string;
    token: string;
  };
  refreshToken: {
    token: string;
  };
}
