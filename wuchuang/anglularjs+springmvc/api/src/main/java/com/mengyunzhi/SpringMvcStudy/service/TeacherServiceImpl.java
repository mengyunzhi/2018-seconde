package com.mengyunzhi.SpringMvcStudy.service;

import com.mengyunzhi.SpringMvcStudy.entity.Teacher;
import com.mengyunzhi.SpringMvcStudy.repository.TeacherRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

@Service
public class TeacherServiceImpl implements TeacherService {
    @Autowired
    TeacherRepository teacherRepository;
    // 更新实体
    @Override
    public void update(Long id, Teacher teacher) {
        // 获取数据表中以保存的实体
        Teacher oldteacher = teacherRepository.findOne(id);

        // 更新各个字段
        oldteacher.setName(teacher.getName());
        oldteacher.setUsername(teacher.getUsername() );
        oldteacher.setSex(teacher.isSex());
        oldteacher.setEmail(teacher.getEmail());

        // 更新数据表
        teacherRepository.save(oldteacher);
        return;
    }

    @Override
    public void delete(Long id) {
        teacherRepository.delete(id);
    }
}
