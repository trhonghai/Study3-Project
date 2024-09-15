import React from "react";
import styles from "./NewTests.module.scss";
import classNames from "classnames/bind";
const cx = classNames.bind(styles);

const testData = [
  {
    id: 1,
    title: "IELTS Simulation Listening test 1",
    time: "40 phút",
    participants: "511488",
    comments: "1647",
    sections: "4 phần thi | 40 câu hỏi",
    tags: ["#IELTS Academic", "#Listening"],
  },
  {
    id: 2,
    title: "IELTS Simulation Listening test 10",
    time: "40 phút",
    participants: "162291",
    comments: "445",
    sections: "4 phần thi | 40 câu hỏi",
    tags: ["#IELTS Academic", "#Listening"],
  },
  {
    id: 3,
    title: "IELTS Simulation Listening test 2",
    time: "40 phút",
    participants: "205500",
    comments: "447",
    sections: "4 phần thi | 40 câu hỏi",
    tags: ["#IELTS Academic", "#Listening"],
  },
  {
    id: 4,
    title: "IELTS Simulation Listening test 3",
    time: "40 phút",
    participants: "131895",
    comments: "251",
    sections: "4 phần thi | 40 câu hỏi",
    tags: ["#IELTS Academic", "#Listening"],
  },
  {
    id: 5,
    title: "IELTS Simulation Listening test 4",
    time: "40 phút",
    participants: "103821",
    comments: "247",
    sections: "4 phần thi | 40 câu hỏi",
    tags: ["#IELTS Academic", "#Listening"],
  },
  {
    id: 6,
    title: "IELTS Simulation Listening test 5",
    time: "40 phút",
    participants: "85650",
    comments: "175",
    sections: "4 phần thi | 40 câu hỏi",
    tags: ["#IELTS Academic", "#Listening"],
  },
  {
    id: 7,
    title: "IELTS Simulation Listening test 6",
    time: "40 phút",
    participants: "75798",
    comments: "144",
    sections: "4 phần thi | 40 câu hỏi",
    tags: ["#IELTS Academic", "#Listening"],
  },
  {
    id: 8,
    title: "IELTS Simulation Listening test 7",
    time: "40 phút",
    participants: "53955",
    comments: "104",
    sections: "4 phần thi | 40 câu hỏi",
    tags: ["#IELTS Academic", "#Listening"],
  },
];

const NewTests = () => {
  return (
    <div className={cx("container")}>
      <h1 className={cx("title")}>Đề thi mới nhất</h1>
      <div className={cx("card")}>
        {testData.map((test) => (
          <div className={cx("test")} key={test.id}>
            <div className={cx("test-info")}>
              <h3 className={cx("test-title")}>{test.title}</h3>
              <div className={cx("test-details")}>
                <p className={cx("test-time")}>{test.time}</p>
                <p className={cx("test-participants")}>{test.participants}</p>
                <p className={cx("test-comments")}>{test.comments}</p>
              </div>
              <p className={cx("test-sections")}>{test.sections}</p>
              <div className={cx("test-tags")}>
                {test.tags.map((tag) => (
                  <p key={tag} className={cx("tag")}>
                    {tag}
                  </p>
                ))}
              </div>
              <div>
                <a href="/ielts-test">
                  <button className={cx("btn")}>Làm bài</button>
                </a>
              </div>
            </div>
          </div>
        ))}
      </div>
    </div>
  );
};

export default NewTests;
