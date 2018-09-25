package com.mengyunzhi.SpringMvc.repository;

import com.mengyunzhi.SpringMvc.entity.Teacher;
import org.springframework.data.repository.CrudRepository;

/**
 * 建立一个访问teacher数据表的借口
 * 指明：
 * 1.要操作的数据表 Teacher
 * 2.Teacher数据表中的主键类型 Long
 */
public interface TeacherRepository extends CrudRepository<Teacher, Long> {

}
