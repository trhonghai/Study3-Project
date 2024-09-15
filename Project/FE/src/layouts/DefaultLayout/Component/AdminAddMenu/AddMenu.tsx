import React from "react";
import "./AddMenu.css";
import { useLocation, useNavigate } from "react-router-dom";
const AddMenu = () => {
  const location = useLocation();
  const navigate = useNavigate();
  const params = new URLSearchParams(location.search);
  function addTest() {
    console.log("Add Test");
    params.set("create", "test");

    navigate({
      pathname: location.pathname,
      search: params.toString(),
    });
  }
  return (
    <div className="add-menu-items-container">
      <div className="add-menu-item" onClick={() => addTest()}>
        Add Test
      </div>
      <div className="add-menu-item">Add Test Type</div>
      <div className="add-menu-item">Add Customer</div>
    </div>
  );
};

export default AddMenu;
