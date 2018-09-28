package www.mengyunzhi.pratice.controller;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;
import www.mengyunzhi.pratice.service.TeacherService;

/**
 * @author liyiheng
 * @date 2018/9/28 20:29
 */
@RestController
@RequestMapping("/Teacher")
public class TeacherController {

    @Autowired
    public TeacherController(TeacherService teacherService) {
    }


}
