package com.example.study3_be_spring.repository;


import com.example.study3_be_spring.model.TestPart;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

@Repository
public interface TestPartRepository extends JpaRepository<TestPart, Long> {
}
