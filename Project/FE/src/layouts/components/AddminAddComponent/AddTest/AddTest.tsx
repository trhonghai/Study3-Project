import React, { useEffect, useState } from "react";
import "./AddTest.css";

import { FaClockRotateLeft } from "react-icons/fa6";
import { Test } from "~/api/types/Test";
import { postTest } from "~/api/testService";
import { MdAdd } from "react-icons/md";
import AddTypeModal from "../../Modals/AddTypeModal";
import { Type } from "~/api/types/Type";
import { getAllTypes } from "~/api/typeService";
import Spinner from "~/shared/Spinner/Spinner";
import { log } from "console";

const AddTest = () => {
  const [hours, setHours] = useState(0);
  const [minutes, setMinutes] = useState(0);
  const [isModalOpen, setIsModalOpen] = useState(false);
  const [types, setTypes] = useState<Type[]>([]);
  const [IsLoadingType, setIsLoadingType] = useState(false);
  const [isAddingTest, setIsAddingTest] = useState(false);
  const [testObject, setTestObject] = useState<Test>({
    title: "",
    code: "",
    year: 2019,
    month: 1,
    timeLimit: 60,
    typeId: 1,
    attempts: 0,
    noCompleted: 0,
  });

  const [addedTestTitle, setAddedTestTitle] = useState(null);

  const updateTestObject = (e) => {
    setTestObject({
      ...testObject,
      [e.target.name]: e.target.value,
    });
  };

  const openAddTypeModal = () => {
    setIsModalOpen(true);
  };

  const closeAddTypeModal = () => {
    setIsModalOpen(false);
  };

  const handleSubmit = (event) => {
    setIsAddingTest(true);

    event.preventDefault();
    console.log("Test Object:", testObject);

    const response = postTest(testObject);
    response
      .then((res) => {
        console.log(res);
        setIsAddingTest(false);
        setAddedTestTitle(res.title);
      })
      .catch((err) => {
        console.log(err);
        setIsAddingTest(false);
      });

    // const totalMinutes = parseInt(hours) * 60 + parseInt(minutes);
    // console.log("Total Time Limit (in minutes):", totalMinutes);
  };

  const addNewType = (newType) => {
    setTypes([...types, newType]);
  };

  useEffect(() => {
    const totalMinutes = hours * 60 + minutes;
    setTestObject({
      ...testObject,
      timeLimit: totalMinutes,
    });
  }, [hours, minutes]);

  const getAndSetTypes = async () => {
    setIsLoadingType(true);

    const response = await getAllTypes();
    if (response.status === 200) {
      console.log("Types:", response.data);
      setTypes(response.data);
      setIsLoadingType(false);
    } else {
      console.log("Error getting types");
      setIsLoadingType(false);
    }
  };

  useEffect(() => {
    getAndSetTypes();
  }, []);

  return (
    <>
      {addedTestTitle ? (
        <div className="addedTestTitle">{addedTestTitle}</div>
      ) : (
        <form
          action="
    "
        >
          <div className="add_test-container mt-4">
            <div className="input-container">
              <label className="form-label" htmlFor="test-name">
                Title
              </label>
              <input
                className="form-control form-control-sm"
                type="text"
                id="test-name"
                name="title"
                required
                onChange={(e) => updateTestObject(e)}
              />
            </div>

            <div className="d-flex gap-5">
              <div className="input-container" style={{ flex: "1" }}>
                <label className="form-label" htmlFor="code">
                  Code
                </label>
                <input
                  className="form-control form-control-sm"
                  type="text"
                  id="code"
                  name="code"
                  onChange={(e) => updateTestObject(e)}
                />
              </div>
              <div className="input-container" style={{ flex: "1" }}>
                <label className="form-label" htmlFor="year">
                  Year
                </label>
                <select
                  className="form-control form-select-sm"
                  id="year"
                  name="year"
                  onChange={(e) => updateTestObject(e)}
                >
                  <option>2019</option>
                  <option>2020</option>
                  <option>2021</option>
                  <option>2022</option>
                  <option>2023</option>
                  <option>2024</option>
                </select>
              </div>
              <div className="input-container" style={{ flex: "1" }}>
                <label className="form-label" htmlFor="month">
                  Month
                </label>
                <select
                  className="form-control form-select-sm"
                  id="month"
                  name="month"
                  onChange={(e) => updateTestObject(e)}
                >
                  <option>January</option>
                  <option>February</option>
                  <option>March</option>
                  <option>April</option>
                  <option>May</option>
                  <option>June</option>
                  <option>July</option>
                  <option>August</option>
                  <option>September</option>
                  <option>October</option>
                  <option>November</option>
                  <option>December</option>
                </select>
              </div>
            </div>
            <div className="input-container d-flex gap-4 align-items-end">
              <div style={{ width: "20%", maxWidth: "40%" }}>
                <label className="form-label">Hours:</label>
                <input
                  className="form-control form-control-sm"
                  type="number"
                  // value={hours}
                  onChange={(e) => setHours(parseInt(e.target.value) || 0)}
                  min="0"
                  required
                />
              </div>
              <div style={{ width: "20%", maxWidth: "40%" }}>
                <label className="form-label">Minutes:</label>
                <input
                  className="form-control form-control-sm"
                  type="number"
                  // value={minutes}
                  onChange={(e) => setMinutes(parseInt(e.target.value) || 0)}
                  min="0"
                  max="59"
                  required
                />
              </div>
              <button className="reset-time-btn" type="button">
                <FaClockRotateLeft />
                Reset
              </button>
            </div>

            <div
              className="input-container d-flex align-items-end gap-4 w-100"
              style={{ width: "20%" }}
            >
              <div style={{ maxWidth: "400px", minWidth: "100px" }}>
                <label className="form-label" htmlFor="type">
                  Type
                </label>
                {IsLoadingType ? (
                  <div className="d-flex align-items-center justify-content-center">
                    <Spinner />
                  </div>
                ) : (
                  <select
                    className="form-control form-select-sm"
                    id="type"
                    name="typeId"
                    onChange={(e) => updateTestObject(e)}
                  >
                    {types.map((type) => (
                      <option key={type.id} value={type.id}>
                        {type.name}
                      </option>
                    ))}
                  </select>
                )}
              </div>
              <button
                className="reset-time-btn add-type"
                type="button"
                onClick={() => openAddTypeModal()}
              >
                <MdAdd className="icon" />
                Add Type
              </button>
              <AddTypeModal
                modalIsOpen={isModalOpen}
                closeModal={closeAddTypeModal}
                addNewType={addNewType}
              />
            </div>
          </div>
          <button
            className="btn btn-success submit-form-btn d-flex align-items-center justify-content-between gap-2 text-white"
            type="submit"
            onClick={(e) => handleSubmit(e)}
            disabled={isAddingTest}
          >
            {isAddingTest && <Spinner />}
            Submit
          </button>
        </form>
      )}
    </>
  );
};

export default AddTest;
