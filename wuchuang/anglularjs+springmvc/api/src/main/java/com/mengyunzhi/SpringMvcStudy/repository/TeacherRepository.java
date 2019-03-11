package com.mengyunzhi.SpringMvcStudy.repository;

import com.mengyunzhi.SpringMvcStudy.entity.Teacher;
import org.springframework.data.repository.CrudRepository;

/**
 * 建立一个访问teacher数据表的接口
 * 继承指出
 * 1. 要操作的为Teacher数据表
 * 2. 数据表主键类型 Long
 */
public interface TeacherRepository extends CrudRepository<Teacher, Long> {
}
