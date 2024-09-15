//package com.example.study3_be_spring.service;
//
//import com.example.study3_be_spring.config.mapper_config.ModelMapperImpl;
//import com.example.study3_be_spring.repository.AbstractRepository;
//import lombok.RequiredArgsConstructor;
//import org.springframework.stereotype.Service;
//
//import java.lang.reflect.Field;
//import java.util.List;
//
//@Service
//@RequiredArgsConstructor
//public class AbstractService<T, PK> implements IAbstractService<T, PK>{
//
//    private final AbstractRepository<T, PK> repository;
////    private final ModelMapperImpl<T, T> modelMapper;
//
//    @Override
//    public T findById(PK id) {
//       return repository.findById(id).orElseThrow(()->new RuntimeException("Entity not found"));
//    }
//
//    @Override
//    public List<T> findAll() {
//        return repository.findAll();
//    }
//
//    @Override
//    public T save (T entity){
//        return repository.save(entity);
//    }
//
//    @Override
//    public void delete(PK id) {
//        T t = repository.findById(id).orElseThrow(()->new RuntimeException("Entity not found"));
//        repository.delete(t);
//    }
//
//    @Override
//    public void update(T entity, PK id) {
//        T existingEntity  = repository.findById(id).orElseThrow(()->new RuntimeException("Entity not found"));
////        updateFields(existingEntity, entity);
//        existingEntity = entity;
//        repository.save(existingEntity);
//    }
//
//
//    public void updateFields(T target, T source) {
//        try {
//            Field[] sourceFields = source.getClass().getDeclaredFields();
//            Field[] targetFields = target.getClass().getDeclaredFields();
//            for (Field sourceField : sourceFields) {
//                sourceField.setAccessible(true);
//                for (Field targetField : targetFields) {
//                    targetField.setAccessible(true);
//                    if (sourceField.getName().equals(targetField.getName())
//                            && targetField.getType().equals(sourceField.getType())) {
//                        targetField.set(target, sourceField.get(source));
//                    }
//                }
//            }
//        } catch (IllegalAccessException e) {
//            e.printStackTrace();
//        }
//    }
//
//}
