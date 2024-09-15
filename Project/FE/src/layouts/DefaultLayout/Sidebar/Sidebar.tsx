import React, { useState } from "react";
import "./Sidebar.css";
import {
  MdOutlineSchool,
  MdOutlineAccountBalanceWallet,
  MdOutlineHome,
  MdOutlineMiscellaneousServices,
} from "react-icons/md";
import { FaRegNoteSticky } from "react-icons/fa6";
import { Link } from "react-router-dom";
const Sidebar = () => {
  return (
    <div className="admin-sidebar-container">
      <div className="admin-sb-header d-flex align-items-center justify-content-start gap-3 p-2 mb-4">
        <MdOutlineSchool className="icon-color" fontSize={25} />
        <span className="app-name fs-5">Study 3</span>
      </div>
      <div className="admin-sb-menu  mt-2">
        <ul className="admin-sb-menu-list">
          <li className="admin-sb-menu-item">
            <MdOutlineHome className="icon" />
            <a href="#" className="admin-sb-menu-link">
              Home
            </a>
          </li>
          <li className="admin-sb-menu-item">
            <MdOutlineAccountBalanceWallet className="icon" />
            <a href="#" className="admin-sb-menu-link">
              Balances
            </a>
          </li>
          <li className="admin-sb-menu-item">
            <MdOutlineMiscellaneousServices className="icon" />
            <a href="#" className="admin-sb-menu-link">
              Services
            </a>
          </li>
          <li className="admin-sb-menu-item">
            <FaRegNoteSticky className="icon" />
            <Link to={"/manage-tests"} className="admin-sb-menu-link">
              Test
            </Link>
          </li>
        </ul>
      </div>
    </div>
  );
};
export default Sidebar;
