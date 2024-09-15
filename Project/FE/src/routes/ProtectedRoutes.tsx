import React, { useEffect, useState } from "react";
import { Navigate } from "react-router-dom";
import { useAuth } from "../context/AuthContext";

interface ProtectedRouteProps {
  element: JSX.Element;
}

const ProtectedRoute: React.FC<ProtectedRouteProps> = ({ element }) => {
  const { accessToken } = useAuth();
  const [isLoading, setIsLoading] = useState(true);

  useEffect(() => {
    if (accessToken !== undefined) {
      setIsLoading(false);
    }
  }, [accessToken]);

  if (isLoading) {
    return <div>Loading...</div>; // Replace with a proper loading spinner or component
  }

  return accessToken ? element : <Navigate to="/login" />;
};

export default ProtectedRoute;
