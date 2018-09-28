package www.mengyunzhi.pratice.repositry;

import org.springframework.data.repository.PagingAndSortingRepository;
import www.mengyunzhi.pratice.entity.Teacher;

/**
 * @author liyiheng
 * @date 2018/9/28 20:25
 */
public interface TeacherRepository extends PagingAndSortingRepository<Teacher, Long> {
}
