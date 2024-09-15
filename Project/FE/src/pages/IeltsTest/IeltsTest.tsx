import React, { useState } from "react";
import styles from "./IeltsTest.module.scss";
import classNames from "classnames/bind";

const cx = classNames.bind(styles);

const IeltsTest: React.FC = () => {
  const [selectedPart, setSelectedPart] = useState<string[]>([]);
  const [selectedTime, setSelectedTime] = useState<string>("");
  const [activeTab, setActiveTab] = useState<string>("practice");
  const handlePartChange = (part: string) => {
    setSelectedPart((prev) =>
      prev.includes(part) ? prev.filter((p) => p !== part) : [...prev, part]
    );
  };

  const recordings = [
    { id: 1, name: "Recording 1", tags: ["Note/Form Completion"] },
    {
      id: 2,
      name: "Recording 2",
      tags: ["Table Completion", "Multiple Choice"],
    },
    {
      id: 3,
      name: "Recording 3",
      tags: ["Note/Form Completion", "Table Completion"],
    },
    {
      id: 4,
      name: "Recording 4",
      tags: ["Summary/Flow chart Completion", "Matching"],
    },
  ];

  return (
    <div className={cx("ielts-test")}>
      <div className={cx("test-header")}>
        <h1>IELTS Simulation Listening Test 1</h1>
        <button className={cx("info-button")}>Thông tin đề thi</button>
        <p>
          ⏰ Thời gian làm bài: 40 phút | 4 phần thi | 40 câu hỏi | 1677 bình
          luận
        </p>
        <p>👥 519567 người đã luyện tập đề thi này</p>
        <p className={cx("note")}>
          Chú ý: đề được quy đổi sang scaled score...
        </p>
      </div>
      <div className={cx("test-tabs")}>
        <button
          className={activeTab === "practice" ? "active" : ""}
          onClick={() => setActiveTab("practice")}
        >
          Luyện tập
        </button>
        <button
          className={activeTab === "full-test" ? "active" : ""}
          onClick={() => setActiveTab("full-test")}
        >
          Làm full test
        </button>
      </div>
      <div className={cx("pro-tips")}>
        💡 Pro tips: Hình thức luyện tập từng phần và chọn mức thời gian phù hợp
        sẽ giúp bạn tập trung vào giải đúng các câu hỏi thay vì phải chịu áp lực
        hoàn thành bài thi.
      </div>
      <div className={cx("test-options")}>
        <p>Chọn phần thi bạn muốn làm</p>
        {recordings.map((recording) => (
          <div className={cx("test-recording")} key={recording.id}>
            <input
              className={cx("checkbox")}
              type="checkbox"
              id={recording.name}
              checked={selectedPart.includes(recording.name)}
              onChange={() => handlePartChange(recording.name)}
            />
            <label htmlFor={recording.name}>
              {recording.name} (10 câu hỏi)
            </label>
            <div className={cx("tags")}>
              {recording.tags.map((tag, index) => (
                <p key={index} className={cx("tag")}>
                  [Listening] {tag}
                </p>
              ))}
            </div>
          </div>
        ))}
        <div className={cx("timer-settings")}>
          <p>Giới hạn thời gian (Để trống để làm bài không giới hạn)</p>
          <select>
            <option>-- Chọn thời gian --</option>
            <option>10 phút</option>
            <option>20 phút</option>
            <option>30 phút</option>
            <option>40 phút</option>
          </select>
        </div>
        <button className={cx("practice-button")}>LUYỆN TẬP</button>
      </div>
    </div>
  );
};

export default IeltsTest;
