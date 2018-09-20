package com.mengyunzhi.SpringMvc.repository;

import com.mengyunzhi.SpringMvc.entity.Klass;
import org.springframework.data.repository.PagingAndSortingRepository;

/**
 * 班级
 */

public interface KlassRepository extends PagingAndSortingRepository<Klass, Long> {

}
