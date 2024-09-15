import React, { useState } from "react";
import Modal from "react-modal";
import { AddType } from "~/api/typeService";
import Spinner from "~/shared/Spinner/Spinner";
const AddTypeModal = ({ modalIsOpen, closeModal, addNewType }) => {
  const [typeName, setTypeName] = useState("");
  const [isAdding, setIsAdding] = useState(false);
  const customStyles = {
    content: {
      top: "50%",
      left: "50%",
      right: "auto",
      bottom: "auto",
      marginRight: "-50%",
      transform: "translate(-50%, -50%)",
    },
  };
  Modal.setAppElement("#root");

  const onSubmitForm = async (e) => {
    e.preventDefault();
    console.log("Type Name:", typeName);
    setIsAdding(true);

    const response = await AddType(typeName);
    if (response.status === 201 || response.status === 200) {
      console.log("Type added successfully");
      addNewType({
        id: response.data.id,
        name: response.data.name,
      });
      setIsAdding(false);
      closeModal();
    } else {
      console.log("Error adding type");
      setIsAdding(false);
    }
  };
  return (
    <Modal
      isOpen={modalIsOpen}
      onRequestClose={closeModal}
      style={customStyles}
      contentLabel="Add Practice Type"
    >
      <h2>Add Practice Type </h2>
      <>
        {isAdding ? (
          <div className="d-flex align-items-center justify-content-center w-100 mt-4">
            <Spinner />
          </div>
        ) : (
          <>
            <form className="mt-2 mb-4">
              <label className="form-label" htmlFor="type-name">
                Type Name
              </label>
              <input
                id="type-name"
                name="type-name"
                className="form-control"
                onChange={(e) => setTypeName(e.target.value)}
              />
            </form>
            <div className="d-flex w-100 align-items-center justify-content-end gap-2">
              <button
                onClick={(e) => {
                  onSubmitForm(e);
                }}
              >
                Submit
              </button>
              <button onClick={closeModal}>close</button>
            </div>
          </>
        )}
      </>
    </Modal>
  );
};

export default AddTypeModal;
