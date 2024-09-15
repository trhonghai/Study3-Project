package com.example.study3_be_spring.model;

import jakarta.persistence.*;
import lombok.AllArgsConstructor;
import lombok.Builder;
import lombok.Data;
import lombok.NoArgsConstructor;

import java.util.List;

@Entity
@Table(name = "audio")
@Data
@Builder
@AllArgsConstructor
@NoArgsConstructor
public class Audio {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;

    @Column(nullable = false, length = 255)
    private String url;

//    @OneToMany(mappedBy = "audio")
//    private List<Script> scripts;
//
//    @OneToMany(mappedBy = "audio")
//    private List<Question> questions;
}
