package com.example.study3_be_spring.dto.request;

import com.example.study3_be_spring.dto.response.AnswerResponse;
import com.example.study3_be_spring.model.Script;
import lombok.AllArgsConstructor;
import lombok.Builder;
import lombok.Data;
import lombok.NoArgsConstructor;

import java.util.List;

@Data
@Builder
@AllArgsConstructor
@NoArgsConstructor
public class QuestionRequest {
    private String content;
    private Long scriptId;
    private Long audioId;
    private List<AnswerResponse> answers;

}
