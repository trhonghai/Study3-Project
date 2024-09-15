import React from "react";
import "./AddContainer.css";
import AddTest from "./AddTest/AddTest";
const AddContainer = ({ closeAdd, open, createType }) => {
  const overrideClose = () => {
    closeAdd();
    const element = document.getElementById("add-test-container-id");
    // element.style.animation = "none";
    element.classList.toggle("add-test-out-animation");
  };
  return (
    <div
      className={`admin-add-test ${open ? "openComponent" : "closeComponent"}`}
      id="add-test-container-id"
    >
      <div className="add-content-container p-4">
        <div className="d-flex align-items-center justify-content-between border-bottom pb-2">
          <h1 className="fs-4" style={{ textTransform: "capitalize" }}>
            Add {createType}
          </h1>
          <button onClick={() => overrideClose()}>Close</button>
        </div>
        <div className="add-content-area">
          {createType === "test" && <AddTest />}
        </div>
      </div>
    </div>
  );
};

export default AddContainer;
