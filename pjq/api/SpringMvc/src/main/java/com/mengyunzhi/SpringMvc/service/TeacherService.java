package com.mengyunzhi.SpringMvc.service;

import com.mengyunzhi.SpringMvc.entity.Teacher;

/**
 * 教师 接口
 */
public interface TeacherService {
    /**
     * 更新实体
     * @param id
     * @param newteacher
     */

    void update(Long id, Teacher newteacher);

    /**
     * 删除
     * @param id
     */
    void delete(Long id);
}
