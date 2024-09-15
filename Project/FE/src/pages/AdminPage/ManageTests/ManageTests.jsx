import React, { useEffect } from "react";
import { Link, useLocation } from "react-router-dom";
import AllTests from "../../Component/AllTests/AllTests";
import ToeicList from "../../Component/Toeics/ToeicList";

import "./ManageTests.css";
const ManageTests = () => {
  const location = useLocation();

  const [select, setSelect] = React.useState("all");

  useEffect(() => {
    const query = new URLSearchParams(location.search);
    const selectParam = query.get("select");
    setSelect(selectParam || "all");
  }, [location.search]);

  // useEffect(() => {
  //   const query = new URLSearchParams(location.search);
  //   const createValue = query.get("create");

  //   if (createValue) {
  //     console.log(`Giá trị của 'create' là: ${createValue}`);
  //   } else {
  //     console.log("Không có giá trị 'create'");
  //   }
  // }, [location.search]);

  return (
    <div className="mgt-test-container">
      <h1 style={{ color: "var(--icon-color)" }}>Practice Tests</h1>
      <div className="list-type-container">
        <Link
          onClick={() => setSelect("all")}
          className={`type-link ${select === "all" ? "active" : ""}`}
          to={"?select=all"}
        >
          All
        </Link>
        <Link
          onClick={() => setSelect("toeic")}
          className={`type-link ${select === "toeic" ? "active" : ""}`}
          to={"?select=toeic"}
        >
          TOEIC
        </Link>
        <Link
          onClick={() => setSelect("ielts")}
          className={`type-link ${select === "ielts" ? "active" : ""}`}
          to={""}
        >
          IELTS Academic
        </Link>
      </div>

      <div className="test-list-container">
        {select === "all" && <AllTests />}
        {select === "toeic" && <ToeicList />}
        {select === "ielts" && <AllTests />}
      </div>
    </div>
  );
};

export default ManageTests;
