package com.mengyunzhi.SpringMvcStudy.service;

import com.mengyunzhi.SpringMvcStudy.repository.Klass;
import com.mengyunzhi.SpringMvcStudy.repository.Teacher;

/**
 * 班级
 * @author 某杰
 */
public interface KlassService {
    Klass save(Klass klass);

    Iterable<Klass> getAll();

    /**
     * 更新
     * @param id 更新实体的iD
     * @param klass 更新的内容
     * @author 某杰
     */
    void updateByIdAndKlass(Long id, Klass klass);

    void delete(Long id);

    Klass getById(Long id);
}
