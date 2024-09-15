package com.example.study3_be_spring.repository;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.repository.NoRepositoryBean;
//import org.springframework.stereotype.Repository;

@NoRepositoryBean
public interface AbstractRepository<T, PK> extends JpaRepository<T, PK> {

}
