package com.example.study3_be_spring.dto.response;

import com.example.study3_be_spring.model.Question;
import jakarta.persistence.*;
import lombok.AllArgsConstructor;
import lombok.Builder;
import lombok.Data;
import lombok.NoArgsConstructor;

@Data
@NoArgsConstructor
@AllArgsConstructor
@Builder
public class AnswerResponse {
    private Long id;
    private String content;
    private Boolean isCorrect;
    private String explanation;
}
