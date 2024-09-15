import React from "react";
import styles from "./Footer.module.scss";
import classNames from "classnames/bind";
const cx = classNames.bind(styles);

const Footer = () => {
  return (
    <div className={cx("footer")}>
      <div className={cx("footerContent")}>
        <div className={cx("footerSection")}>
          <h3>STUDY4</h3>
          <p>© 2024</p>
          <div>
            <a href="#">Facebook</a> | <a href="#">Instagram</a> |{" "}
            <a href="#">Twitter</a>
          </div>
        </div>
        <div className={cx("footerSection")}>
          <h3>Chương trình học</h3>
          <ul>
            <li>
              <a href="#">IELTS General Reading</a>
            </li>
            <li>
              <a href="#">IELTS General Writing</a>
            </li>
            <li>
              <a href="#">Complete TOEIC</a>
            </li>
            <li>
              <a href="#">IELTS Fundamentals</a>
            </li>
            <li>
              <a href="#">IELTS Intensive Listening</a>
            </li>
            <li>
              <a href="#">IELTS Intensive Reading</a>
            </li>
            <li>
              <a href="#">IELTS Intensive Speaking</a>
            </li>
            <li>
              <a href="#">IELTS Intensive Writing</a>
            </li>
          </ul>
        </div>
        <div className={cx("footerSection")}>
          <h3>Tài nguyên</h3>
          <ul>
            <li>
              <a href="#">Thư viện đề thi</a>
            </li>
            <li>
              <a href="#">Blog</a>
            </li>
            <li>
              <a href="#">Kho tài liệu</a>
            </li>
            <li>
              <a href="#">Nhóm học tập</a>
            </li>
          </ul>
        </div>
        <div className={cx("footerSection")}>
          <h3>Hỗ trợ</h3>
          <ul>
            <li>
              <a href="#">Hướng dẫn sử dụng</a>
            </li>
            <li>
              <a href="#">Hướng dẫn mua hàng</a>
            </li>
            <li>
              <a href="#">Chăm sóc khách hàng</a>
            </li>
            <li>
              <a href="#">Phản hồi khiếu nại</a>
            </li>
          </ul>
        </div>
      </div>
      <div className={cx("footerBottom")}>
        <h3>Thông tin doang nghiệp</h3>
        <p>
          Công ty TNHH Công Nghệ A Plus
          <br />
          Giấy chứng nhận Đăng ký doanh nghiệp số: 0109675459 do Sở Kế hoạch và
          Đầu tư thành phố Hà Nội cấp ngày 17/06/2021.
          <br />
          Điện thoại liên hệ/Hotline: 096 369 5525
          <br />
          Email: study4.team@gmail.com
          <br />
          Địa chỉ trụ sở: Số 15, Ngõ 208 Giải Phóng, Phương Liệt, Quận Thanh
          Xuân, Thành phố Hà Nội, Việt Nam
          <br />© 2021 - Bản quyền của Công ty TNHH Công Nghệ A Plus.
        </p>
      </div>
    </div>
  );
};

export default Footer;
