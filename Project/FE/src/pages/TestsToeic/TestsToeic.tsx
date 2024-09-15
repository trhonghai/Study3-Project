import React, { useState } from "react";
import classNames from "classnames/bind";
import styles from "./TestsToeic.module.scss";
import Pagination from "~/layouts/components/Pagination/Pagination";
const cx = classNames.bind(styles);

interface Exam {
  id: number;
  title: string;
  duration: string;
  participants: number;
  questions: number;
  tags: string[];
}
const exams: Exam[] = [
  {
    id: 1,
    title: "IELTS Simulation Listening test 1",
    duration: "40 phút",
    participants: 526494,
    questions: 1700,
    tags: ["IELTS Academic", "Listening"],
  },
  {
    id: 1,
    title: "IELTS Simulation Listening test 1",
    duration: "40 phút",
    participants: 526494,
    questions: 1700,
    tags: ["IELTS Academic", "Listening"],
  },
  {
    id: 1,
    title: "IELTS Simulation Listening test 1",
    duration: "40 phút",
    participants: 526494,
    questions: 1700,
    tags: ["IELTS Academic", "Listening"],
  },
  {
    id: 1,
    title: "IELTS Simulation Listening test 1",
    duration: "40 phút",
    participants: 526494,
    questions: 1700,
    tags: ["IELTS Academic", "Listening"],
  },
  {
    id: 1,
    title: "IELTS Simulation Listening test 1",
    duration: "40 phút",
    participants: 526494,
    questions: 1700,
    tags: ["IELTS Academic", "Listening"],
  },
  {
    id: 1,
    title: "IELTS Simulation Listening test 1",
    duration: "40 phút",
    participants: 526494,
    questions: 1700,
    tags: ["IELTS Academic", "Listening"],
  },
  {
    id: 1,
    title: "IELTS Simulation Listening test 1",
    duration: "40 phút",
    participants: 526494,
    questions: 1700,
    tags: ["IELTS Academic", "Listening"],
  },
  {
    id: 1,
    title: "IELTS Simulation Listening test 1",
    duration: "40 phút",
    participants: 526494,
    questions: 1700,
    tags: ["IELTS Academic", "Listening"],
  },
  // Add more exams here
];
const ITEMS_PER_PAGE = 4;

const TestsToeic = () => {
  const [searchTerm, setSearchTerm] = useState("");

  const handleSearchChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    setSearchTerm(event.target.value);
  };

  const filteredExams = exams.filter((exam) =>
    exam.title.toLowerCase().includes(searchTerm.toLowerCase())
  );
  const [currentPage, setCurrentPage] = useState(1);

  const handlePageChange = (page: number) => {
    setCurrentPage(page);
  };

  const startIndex = (currentPage - 1) * ITEMS_PER_PAGE;
  const currentExams = exams.slice(startIndex, startIndex + ITEMS_PER_PAGE);
  const totalPages = Math.ceil(exams.length / ITEMS_PER_PAGE);

  return (
    <div className={cx("exam-library")}>
      <h1 className={cx("title")}>Thư viện đề thi</h1>
      <div className={cx("filters")}>
        <button className={cx("active")}>Tất cả</button>
        <button>IELTS Academic</button>
        <button>IELTS General</button>
      </div>
      <div className={cx("search-bar")}>
        <input
          type="text"
          placeholder="Nhập từ khoá bạn muốn tìm kiếm: tên sách, dạng câu hỏi ..."
          value={searchTerm}
          onChange={handleSearchChange}
        />
        <button>Tìm kiếm</button>
      </div>
      <div className={cx("exam-card-list")}>
        {exams.map((exam) => (
          <div key={exam.id} className={cx("exam-card")}>
            <h3>{exam.title}</h3>
            <p>
              ⏰ {exam.duration} | 👥 {exam.participants} | 💬 {exam.questions}
            </p>
            <p>4 phần thi | 40 câu hỏi</p>
            <div className={cx("tags")}>
              {exam.tags.map((tag) => (
                <p key={tag} className={cx("tag")}>
                  #{tag}
                </p>
              ))}
            </div>
            <button>Chi tiết</button>
          </div>
        ))}
      </div>
      <div className={cx("pagination-test")}>
        <Pagination
          currentPage={currentPage}
          totalPages={totalPages}
          onPageChange={handlePageChange}
        />
      </div>
    </div>
  );
};

export default TestsToeic;
