import React, { useEffect, useRef, useState } from "react";
import "./search.css";
import { HiOutlineSearch } from "react-icons/hi";
import { CgFormatSlash } from "react-icons/cg";

const Search = () => {
  const [search, setSearch] = useState("");
  const inputRef = useRef(null);
  useEffect(() => {
    const handleKeyDown = (event) => {
      if (event.key === "/") {
        event.preventDefault();
        inputRef.current.focus();
      }
    };
    window.addEventListener("keydown", handleKeyDown);
    return () => {
      window.removeEventListener("keydown", handleKeyDown);
    };
  }, []);
  return (
    <div className="search-container">
      <HiOutlineSearch className="search-icon" />
      <span className="search-shortcut">
        <CgFormatSlash size={16} />
      </span>
      <input
        ref={inputRef}
        className="search-input"
        type="text"
        placeholder="Search"
        value={search}
        onChange={(e) => setSearch(e.target.value)}
      />
    </div>
  );
};

export default Search;
