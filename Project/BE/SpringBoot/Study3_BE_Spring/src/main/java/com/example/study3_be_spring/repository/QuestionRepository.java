package com.example.study3_be_spring.repository;


import com.example.study3_be_spring.model.Question;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

@Repository
public interface QuestionRepository extends AbstractRepository<Question, Long>{

}
