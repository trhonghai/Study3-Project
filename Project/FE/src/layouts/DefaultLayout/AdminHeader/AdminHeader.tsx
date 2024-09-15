import React, { useEffect, useRef } from "react";
import Search from "~/shared/Search/Search";
import "./AdminHeader.css";
import { TbMessageCircleQuestion } from "react-icons/tb";
import { IoNotificationsOutline, IoSettingsOutline } from "react-icons/io5";
import { IoIosAddCircle } from "react-icons/io";
import AddMenu from "../Component/AdminAddMenu/AddMenu";
import { useLocation, useNavigate } from "react-router-dom";
import AddContainer from "~/layouts/components/AddminAddComponent/AddContainer";
import { log } from "console";

const AdminHeader = () => {
  const [openAddMenu, setOpenAddMenu] = React.useState(false);
  const [createType, setCreateType] = React.useState("");
  const [open, setOpen] = React.useState(false);

  const navigate = useNavigate();
  const location = useLocation();
  console.log(openAddMenu);
  const menuRef = useRef(null);
  const handleClickOutside = (event) => {
    // Check if the click is outside the menu or contains the button with specific id
    const buttonWithSpecificId = event.target.closest(".admin-hd-btn-add");

    // If the click is on the button with specific id, do nothing
    if (buttonWithSpecificId) return;

    if (menuRef.current && !menuRef.current.contains(event.target)) {
      setOpenAddMenu(false);
    }
  };

  useEffect(() => {
    if (openAddMenu) {
      document.addEventListener("mousedown", handleClickOutside);
    } else {
      document.removeEventListener("mousedown", handleClickOutside);
    }

    return () => {
      document.removeEventListener("mousedown", handleClickOutside);
    };
  }, [openAddMenu]);

  useEffect(() => {
    const query = new URLSearchParams(location.search);
    const createValue = query.get("create");

    if (createValue) {
      console.log(`Giá trị của 'create' là: ${createValue}`);
      setCreateType(createValue);
      setOpen(true);
    } else {
      console.log("Không có giá trị 'create'");
      setOpen(false);
    }
  }, [location.search]);

  const closeAddTest = () => {
    console.log("Đã đóng AddTest");
    const params = new URLSearchParams(location.search);
    params.delete("create");
    setOpen(false);
    navigate({
      pathname: location.pathname,
      search: params.toString(),
    });
  };

  return (
    <div className="admin-header-container">
      <Search />
      <a className="admin-hd-icon">
        <TbMessageCircleQuestion />
      </a>
      <a className="admin-hd-icon">
        <IoNotificationsOutline />
      </a>
      <a className="admin-hd-icon">
        <IoSettingsOutline />
      </a>
      <div className="admin-add-container">
        <button
          className="admin-hd-icon admin-hd-btn-add"
          style={{ color: "green", fontSize: "25px" }}
          onClick={() => {
            setOpenAddMenu(!openAddMenu);
          }}
        >
          <IoIosAddCircle />
        </button>
        {openAddMenu && (
          <div ref={menuRef}>
            <AddMenu />
          </div>
        )}
      </div>
      {
        <AddContainer
          closeAdd={closeAddTest}
          open={open}
          createType={createType}
        />
      }
    </div>
  );
};

export default AdminHeader;
