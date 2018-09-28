package com.mengyunzhi.carboncopies.repository;

import com.mengyunzhi.carboncopies.entity.Course;
import org.springframework.data.repository.PagingAndSortingRepository;

public interface CourseRepository extends PagingAndSortingRepository<Course, Long> {
}
