package com.example.study3_be_spring.repository;


import com.example.study3_be_spring.model.TestHistory;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

@Repository
public interface TestHistoryRepository extends JpaRepository<TestHistory, Long> {
}