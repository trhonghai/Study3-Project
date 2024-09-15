import React from "react";
import Header from "../components/Header";
import Footer from "../components/Footer/Footer";
import classNames from "classnames/bind";
import styles from "./HeaderOnly.module.scss";

const cx = classNames.bind(styles);

const HeaderOnly: React.FC<{ children: React.ReactNode }> = ({ children }) => {
  return (
    <div className={cx("wrapper")}>
      <Header />
      <div className={cx("container")}>
        <div className={cx("content")}>{children}</div>
      </div>
      <Footer />
    </div>
  );
};
export default HeaderOnly;
