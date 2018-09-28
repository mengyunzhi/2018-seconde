package www.mengyunzhi.pratice.service;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import www.mengyunzhi.pratice.repositry.TeacherRepository;

/**
 * @author liyiheng
 * @date 2018/9/28 20:27
 */
@Service
public class TeacherServiceImpl implements TeacherService {
    private final TeacherRepository teacherRepository;

    @Autowired
    public TeacherServiceImpl(TeacherRepository teacherRepository) {
        this.teacherRepository = teacherRepository;
    }

    public TeacherRepository getTeacherRepository() {
        return teacherRepository;
    }

    @Override
    public void add() {

    }
}
