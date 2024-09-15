import classNames from "classnames/bind";
import PropTypes from "prop-types";
import styles from "./DefaultLayout.module.scss";
import Header from "~/layouts/components/Header";
import Sidebar from "./Sidebar/Sidebar";
import React from "react";
import AdminHeader from "./AdminHeader/AdminHeader";
const cx = classNames.bind(styles);
function DefaultLayout({ children }) {
  return (
    <div className="d-flex h-100">
      <Sidebar />
      <div className={cx("container")}>
        <AdminHeader />
        <div className={cx("content")}>{children}</div>
      </div>
    </div>
  );
}
DefaultLayout.propTypes = {
  children: PropTypes.node.isRequired,
};
export default DefaultLayout;
