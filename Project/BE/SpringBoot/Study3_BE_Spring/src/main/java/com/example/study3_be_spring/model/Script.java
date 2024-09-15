package com.example.study3_be_spring.model;

import jakarta.persistence.*;
import lombok.AllArgsConstructor;
import lombok.Builder;
import lombok.Data;
import lombok.NoArgsConstructor;

import java.util.List;

@Entity
@Table(name = "script")
@Data
@Builder
@AllArgsConstructor
@NoArgsConstructor
public class Script {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;

    @Column(nullable = false, columnDefinition = "TEXT")
    private String content;

    @ManyToOne
    @JoinColumn(name = "partId", nullable = false)
    private Part part;

    @ManyToOne
    @JoinColumn(name = "audioId")
    private Audio audio;

    @OneToMany(mappedBy = "script")
    private List<Question> questions;

    @OneToMany(mappedBy = "script")
    private List<Image> images;

}

