package com.mengyunzhi.SpringMvc.service;

import com.mengyunzhi.SpringMvc.entity.Teacher;
import com.mengyunzhi.SpringMvc.repository.TeacherRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

/**
 * 教师   更新数据
 */
@Service
public class TeacherServiceImpl implements TeacherService {

    @Autowired
    TeacherRepository teacherRepository;

    /**
     * 更新实体
     *
     * @param id         被更新的ID
     * @param newteacher 要更新的内容
     */
    @Override
    public void update(Long id, Teacher newteacher) {

        //获取数据表中保存的实体
        Teacher oldTeacher = teacherRepository.findOne(id);

        //更新各个字段
        oldTeacher.setUsername(newteacher.getUsername());
        oldTeacher.setName(newteacher.getName());
        oldTeacher.setEmail(newteacher.getEmail());
        oldTeacher.setSex(newteacher.isSex());

        //更新数据表
        teacherRepository.save(oldTeacher);
        return;

    }

    /**
     *删除
     * @param id
     */
    @Override
    public void delete(Long id) {
        teacherRepository.delete(id);
    }
}
