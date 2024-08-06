import React from "react";
import ReactDOM from "react-dom/client";
import { BrowserRouter, Route, Routes, Navigate } from "react-router-dom";

import "bootstrap/dist/css/bootstrap.css";
import "assets/scss/now-ui-dashboard.scss?v1.5.0";
import "assets/css/demo.css";

import AdminLayout from "layouts/Admin.js";
import Login from "layouts/Login";
import Cadastro from "layouts/Cadastro";

const root = ReactDOM.createRoot(document.getElementById("root"));

root.render(
  <BrowserRouter>
    <Routes>
      <Route path="/login" element={<Login />} />
      <Route path="/admin/*" element={<AdminLayout />} />
      <Route path="/cadastro" element={<Cadastro />} />
      <Route path="*" element={<Navigate to="/admin/dashboard" replace />} />
    </Routes>
  </BrowserRouter>
);
