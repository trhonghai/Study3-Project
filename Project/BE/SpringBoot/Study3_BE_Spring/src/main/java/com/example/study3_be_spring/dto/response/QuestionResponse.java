package com.example.study3_be_spring.dto.response;

import com.example.study3_be_spring.model.Answer;
import com.example.study3_be_spring.model.Audio;
import lombok.AllArgsConstructor;
import lombok.Builder;
import lombok.Data;
import lombok.NoArgsConstructor;


import java.util.List;

@Data
@AllArgsConstructor
@NoArgsConstructor
@Builder
public class QuestionResponse {
    // question, scriptId, audio, answer.

    private Long id;
    private String content;
    private Long script;
    private Long audio;
//    private AudioResponse audio;
    private List<AnswerResponse> answers;

}
