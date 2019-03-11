package com.mengyunzhi.SpringMvcStudy.service;

import com.mengyunzhi.SpringMvcStudy.entity.Teacher;

public interface TeacherService {
    // 更新实体
    void update(Long id, Teacher teacher);

    void delete(Long id);
}
