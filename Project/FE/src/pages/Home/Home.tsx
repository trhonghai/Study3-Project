import React from "react";
import Slideshow from "./SlideShow/SildeShow";

import classNames from "classnames/bind";
import styles from "./Home.module.scss";
import FeatureCourses from "./FeatureCourses/FeatureCourses";
import NewTests from "./NewTests/NewTests";

const cx = classNames.bind(styles);
const Home: React.FC = () => {
  return (
    <div className={cx("wrapper")}>
      <Slideshow />
      <FeatureCourses />
      <NewTests />
    </div>
  );
};
export default Home;
