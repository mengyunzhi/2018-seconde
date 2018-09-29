package com.mengyunzhi.SpringMvcStudy.service;

import com.mengyunzhi.SpringMvcStudy.entity.Teacher;

/**
 * 教师
 * @author 某杰
 */
public interface TeacherService {
    /**
     * 更新实体
     * @param id
     * @param teacher
     */
    void update(Long id, Teacher teacher);

    void delete(Long id);
}
