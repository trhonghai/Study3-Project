import "./App.css";
import { BrowserRouter, Routes, Route, useRoutes } from "react-router-dom";
import React from "react";
import routes from "./routes";
import { AuthProvider } from "./context/AuthContext";

const App: React.FC = () => {
  return (
    <AuthProvider>
      <BrowserRouter>
        <AppRoutes />
      </BrowserRouter>
    </AuthProvider>
  );
};
const AppRoutes: React.FC = () => {
  const routing = useRoutes(routes);
  return routing;
};

export default App;
