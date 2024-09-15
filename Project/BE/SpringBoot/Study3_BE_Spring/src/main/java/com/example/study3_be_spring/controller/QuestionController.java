package com.example.study3_be_spring.controller;

import com.example.study3_be_spring.dto.request.QuestionRequest;
import com.example.study3_be_spring.dto.response.AnswerResponse;
import com.example.study3_be_spring.dto.response.QuestionResponse;
import com.example.study3_be_spring.model.Answer;
import com.example.study3_be_spring.model.Audio;
import com.example.study3_be_spring.model.Question;
import com.example.study3_be_spring.model.Script;
import com.example.study3_be_spring.repository.AnswerRepository;
import com.example.study3_be_spring.repository.QuestionRepository;
import lombok.RequiredArgsConstructor;
import org.modelmapper.ModelMapper;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;
import java.util.List;
import java.util.stream.Collectors;

@RestController
@RequestMapping("/question")
@RequiredArgsConstructor
public class QuestionController {

    private final QuestionRepository questionRepository;
    private final AnswerRepository  answerRepository;
    private final ModelMapper modelMapper;

    //with list answer, get list answerRequest from questionRequest and convert to list answer
    @PostMapping()
    public ResponseEntity<QuestionResponse> createQuestion(@RequestBody QuestionRequest questionRequest) {
        Script script = Script.builder().id(questionRequest.getScriptId()).build();
        Audio audio = Audio.builder().id(questionRequest.getAudioId()).build();

        List<Answer> answers = questionRequest.getAnswers().stream()
                .map(answerResponse -> modelMapper.map(answerResponse, Answer.class))
                .collect(Collectors.toList());

        Question question = Question.builder()
                .script(script)
                .audio(audio)
                .content(questionRequest.getContent())
                .answers(answers)
                .build();

        answers.forEach(answer -> answer.setQuestion(question));


        //save both question and answer because we use cascade = CascadeType.All in question for attribute answer
        //we can use CascadeType.PERSIST to save only both parent and children when parent saved
        Question savedQuestion = questionRepository.save(question);

        List<AnswerResponse> answerResponses = answers.stream()
                .map(answer -> modelMapper.map(answer, AnswerResponse.class)).collect(Collectors.toList());

        QuestionResponse questionResponse = QuestionResponse.builder()
                .id(savedQuestion.getId())
                .script(savedQuestion.getScript().getId())
                .content(savedQuestion.getContent())
                .answers(answerResponses)
                .audio(savedQuestion.getAudio().getId())
                .build();

        return ResponseEntity.ok(questionResponse);
    }


    @PutMapping()
    public ResponseEntity<Question> updateQuestion(@RequestBody Question question) {
        questionRepository.save(question);
        return ResponseEntity.ok(question);
    }

    @DeleteMapping("/{id}")
    public ResponseEntity<Long> deleteQuestion(@PathVariable long id) {
        var question = questionRepository.findById(id).orElseThrow(()-> new RuntimeException("Question not found"));
        questionRepository.delete(question);
        return ResponseEntity.ok(id);
    }

    @GetMapping("/{id}")
    public ResponseEntity<QuestionResponse> getQuestionById(@PathVariable long id) {
        var question = questionRepository.findById(id).orElseThrow(()-> new RuntimeException("Question not found"));

        List<AnswerResponse> listAnswerResponse = question.getAnswers()
                .stream().map(answer -> modelMapper.map(answer, AnswerResponse.class)).toList();

        QuestionResponse questionResponse = QuestionResponse.builder()
                .id(question.getId())
                .answers(listAnswerResponse)
                .audio(question.getAudio().getId())
                .script(question.getScript().getId())
                .content(question.getContent())
                .build();

        return ResponseEntity.ok(questionResponse);
    }

}
