import styles from "./Header.module.scss";
import classNames from "classnames/bind";
import React from "react";
const cx = classNames.bind(styles);
const Header: React.FC = () => {
  const menu = [
    {
      name: "Chương trình học",
      href: "/",
    },
    {
      name: "Đề thi online",
      href: "/list-tests",
    },
    {
      name: "Flashcards",
      href: "#flashcards",
    },
    {
      name: "Blog",
      href: "#blog",
    },
    {
      name: "Kích hoạt tài khoản",
      href: "#activate",
    },
    {
      name: "login",
      href: "#login",
    },
  ];
  return (
    <header className={cx("header")}>
      <div className={cx("container")}>
        <div className={cx("logo")}>STUDY 2</div>
        <nav className={cx("nav")}>
          {menu.map((item, index) => (
            <a key={index} className={cx("nav-item")} href={item.href}>
              {item.name}
            </a>
          ))}
        </nav>
      </div>
    </header>
  );
};

export default Header;
