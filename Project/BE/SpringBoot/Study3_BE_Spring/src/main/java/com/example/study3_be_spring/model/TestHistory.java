package com.example.study3_be_spring.model;


import jakarta.persistence.*;
import lombok.AllArgsConstructor;
import lombok.Builder;
import lombok.Data;
import lombok.NoArgsConstructor;

import java.util.Date;


@Entity
@Table(name = "TestHistory")
@Data
@Builder
@AllArgsConstructor
@NoArgsConstructor
public class TestHistory {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;

    @ManyToOne
    @JoinColumn(name = "testId", nullable = false)
    private Test test;

    @ManyToOne
    @JoinColumn(name = "userId", nullable = false)
    private User user;

    private Integer score;
    private Integer time;
    private Date date;
    private Boolean isCompleted;
    private Boolean isPassed;
    private Integer noCorrect;
    private Integer noSkip;
}
