import React from "react";
import { Slide } from "react-slideshow-image";
import "react-slideshow-image/dist/styles.css";
import classNames from "classnames/bind";
import styles from "./FeatureCourses.module.scss";

const cx = classNames.bind(styles);

// Example course data
const courses = [
  {
    title: "IELTS Intensive Listening",
    description:
      "Chiến lược làm bài - Chữa đề - Luyện nghe IELTS Listening theo phương pháp Dictation",
    rating: 4.5,
    reviews: 222,
    students: 30506,
    price: "699.000đ",
    originalPrice: "899.000đ",
    discount: "-22%",
    imageUrl: "https://via.placeholder.com/300x200",
  },
  {
    title: "IELTS Intensive Reading",
    description: "Chiến lược làm bài - Chữa đề - Từ vựng IELTS Reading",
    rating: 4.7,
    reviews: 136,
    students: 32536,
    price: "699.000đ",
    originalPrice: "899.000đ",
    discount: "-22%",
    imageUrl: "https://via.placeholder.com/300x200",
  },
  {
    title: "IELTS Intensive Speaking",
    description: "Thực hành luyện tập IELTS Speaking",
    rating: 4.6,
    reviews: 96,
    students: 17530,
    price: "699.000đ",
    originalPrice: "899.000đ",
    discount: "-22%",
    imageUrl: "https://via.placeholder.com/300x200",
  },
];

const FeatureCourses: React.FC = () => {
  const slides = [];
  for (let i = 0; i < courses.length; i += 3) {
    slides.push(courses.slice(i, i + 3));
  }

  return (
    <div className={cx("feature-courses-container")}>
      <h2 className={cx("title")}>Khoá học online nổi bật</h2>
      <Slide>
        {slides.map((slide, index) => (
          <div className={cx("each-slide")} key={index}>
            {slide.map((course) => (
              <div className={cx("course-card")} key={course.title}>
                <img
                  src={course.imageUrl}
                  alt={course.title}
                  className={cx("course-image")}
                />
                <div className={cx("course-info")}>
                  <h3 className={cx("course-title")}>{course.title}</h3>
                  <p className={cx("course-description")}>
                    {course.description}
                  </p>
                  <div className={cx("course-rating")}>
                    <p className={cx("star-rating")}>⭐</p>
                    <p>{course.rating}</p>
                    <p>({course.reviews})</p>
                  </div>

                  <div className={cx("course-price")}>
                    <p className={cx("current-price")}>{course.price}</p>
                    <p className={cx("original-price")}>
                      {course.originalPrice}
                    </p>
                    <p className={cx("discount")}>{course.discount}</p>
                  </div>
                </div>
              </div>
            ))}
          </div>
        ))}
      </Slide>
    </div>
  );
};

export default FeatureCourses;
