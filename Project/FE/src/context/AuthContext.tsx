import React, {
  createContext,
  useContext,
  useState,
  ReactNode,
  useEffect,
} from "react";
import Cookies from "js-cookie";

interface AuthContextType {
  accessToken: string | null;
  refreshToken: string | null;
  setTokens: (accessToken: string | null, refreshToken: string | null) => void;
}

const AuthContext = createContext<AuthContextType | undefined>(undefined);

export const useAuth = (): AuthContextType => {
  const context = useContext(AuthContext);
  if (!context) {
    throw new Error("useAuth must be used within an AuthProvider");
  }
  return context;
};

interface AuthProviderProps {
  children: ReactNode;
}

export const AuthProvider: React.FC<AuthProviderProps> = ({ children }) => {
  const [accessToken, setAccessToken] = useState<string | null>(null);
  const [refreshToken, setRefreshToken] = useState<string | null>(null);

  useEffect(() => {
    // Lấy token từ cookie khi component mount
    const savedAccessToken = Cookies.get("accessToken");
    const savedRefreshToken = Cookies.get("refreshToken");

    if (savedAccessToken) {
      setAccessToken(savedAccessToken);
    }

    if (savedRefreshToken) {
      setRefreshToken(savedRefreshToken);
    }
  }, []);

  useEffect(() => {
    if (accessToken) {
      Cookies.set("accessToken", accessToken);
    } else {
      Cookies.remove("accessToken");
    }
  }, [accessToken]);

  useEffect(() => {
    if (refreshToken) {
      Cookies.set("refreshToken", refreshToken);
    } else {
      Cookies.remove("refreshToken");
    }
  }, [refreshToken]);

  const setTokens = (
    newAccessToken: string | null,
    newRefreshToken: string | null
  ) => {
    setAccessToken(newAccessToken);
    setRefreshToken(newRefreshToken);
  };

  const value = {
    accessToken,
    refreshToken,
    setTokens,
  };

  return <AuthContext.Provider value={value}>{children}</AuthContext.Provider>;
};
