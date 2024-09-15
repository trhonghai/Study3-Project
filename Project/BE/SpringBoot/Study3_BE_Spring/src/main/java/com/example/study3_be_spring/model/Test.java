package com.example.study3_be_spring.model;

import jakarta.persistence.*;
import lombok.AllArgsConstructor;
import lombok.Builder;
import lombok.Data;
import lombok.NoArgsConstructor;

import java.util.List;

@Entity
@Table(name = "test")
@Data
@Builder
@AllArgsConstructor
@NoArgsConstructor
public class Test {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long     id;

    @Column(nullable = false, length = 255)
    private String title;

    @Column(nullable = false, length = 255)
    private String code;

    private Integer year;
    private Integer attempts;
    private Integer month;
    private Integer timeLimit;
    private Integer noCompleted;

    @ManyToOne
    @JoinColumn(name = "typeId", nullable = false)
    private Type type;

    @OneToMany(mappedBy = "test")
    private List<TestPart> testParts;

    @OneToMany(mappedBy = "test")
    private List<TestHistory> testHistories;
}
