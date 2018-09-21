package com.mengyunzhi.SpringMvcStudy.service;

import com.mengyunzhi.SpringMvcStudy.repository.Teacher;
import com.mengyunzhi.SpringMvcStudy.repository.TeacherRespository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

/**
 * 教师
 * @author 某杰  on 2018/09/19
 */
@Service
public class TeacherServiceImpl implements TeacherService {
    @Autowired
    TeacherRespository teacherRespository; // 教师仓库
    /**
     * 更新实体
     * @param id 被更新的实体ID
     * @param newTeacher 要更新成的内容
     */
    @Override
    public void update(Long id, Teacher newTeacher) {
        //获取数据表中已保存的实体
        Teacher oldTeacher = teacherRespository.findOne(id);
        //依次更新各个字段
        oldTeacher.setName(newTeacher.getName());
        oldTeacher.setUsername(newTeacher.getUsername());
        oldTeacher.setEmail(newTeacher.getEmail());
        oldTeacher.setSex(newTeacher.isSex());
        //更新数据表
        teacherRespository.save(oldTeacher);
        return;
    }

    @Override
    public void delete(Long id) {
        teacherRespository.delete(id);
    }
}
