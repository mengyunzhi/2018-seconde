package com.mengyunzhi.carboncopies.repository;

import com.mengyunzhi.carboncopies.entity.Student;
import org.springframework.data.repository.PagingAndSortingRepository;
public interface StudentRepository extends PagingAndSortingRepository<Student, Long> {
}
