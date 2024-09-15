import React, { lazy } from "react";
import { Navigate, RouteObject } from "react-router-dom";
// import Home from "~/pages/Home/Home";
import Login from "~/pages/Login/Login";
import Register from "~/pages/Register/Register";
import ProtectedRoute from "./ProtectedRoutes";
import HeaderOnly from "~/layouts/HeaderOnly/HeaderOnly";
import IeltsTest from "~/pages/IeltsTest/IeltsTest";
import TestsToeic from "~/pages/TestsToeic/TestsToeic";
import Dashboard from "~/pages/AdminPage/Dashboard/Dashboard";
import ManageTests from "~/pages/AdminPage/ManageTests/ManageTests";

import DefaultLayout from "~/layouts/DefaultLayout/DefaultLayout";

const Home = lazy(() => import("~/pages/Home/Home"));

const routes: RouteObject[] = [
  {
    path: "/",
    element: (
      <ProtectedRoute
        element={
          <HeaderOnly>
            <Home />
          </HeaderOnly>
        }
      />
    ),
  },
  {
    path: "/login",
    element: <Login />,
  },
  { path: "/register", element: <Register /> },
  {
    path: "/ielts-test",
    element: (
      <HeaderOnly>
        <IeltsTest />
      </HeaderOnly>
    ),
  },
  {
    path: "/list-tests",
    element: (
      <HeaderOnly>
        <TestsToeic />
      </HeaderOnly>
    ),
  },
  {
    path: "/dashboard",
    element: (
      <DefaultLayout>
        <Dashboard />
      </DefaultLayout>
    ),
  },
  {
    path: "/manage-tests",
    element: (
      <DefaultLayout>
        <ManageTests />
      </DefaultLayout>
    ),
  },
  // {
  //   path: "/dashboard",
  //   element: (
  //     <ProtectedRoute
  //       element={<Dashboard />}
  //       isAuthenticated={isAuthenticated}
  //     />
  //   ),
  // },
  // { path: "*", element: <Navigate to="/" /> }, // Xử lý các đường dẫn không xác định
];

export default routes;
