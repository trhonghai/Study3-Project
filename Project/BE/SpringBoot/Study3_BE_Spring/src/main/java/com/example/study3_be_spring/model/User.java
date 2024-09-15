package com.example.study3_be_spring.model;



import jakarta.persistence.*;
import lombok.AllArgsConstructor;
import lombok.Builder;
import lombok.Data;
import lombok.NoArgsConstructor;

import java.util.Date;
import java.util.Set;

@Entity
@Table(name = "__user")
@Data
@Builder
@NoArgsConstructor
@AllArgsConstructor
public class User {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;

    @Column(nullable = false, length = 255)
    private String firstname;

    @Column(nullable = false, length = 255)
    private String lastname;

    @Column(nullable = false)
    @Temporal(TemporalType.DATE)
    private Date bod;

    @Column(nullable = false, length = 255, unique = true)
    private String email;

    @Column(length = 255)
    private String avatar;

    @Column
    private Boolean sex;

    @OneToMany(mappedBy = "user")
    private Set<TestHistory> testHistories;

    @OneToMany(mappedBy = "user")
    private Set<DoQuestion> doQuestions;


}
