package com.mengyunzhi.SpringMvc.service;

import com.mengyunzhi.SpringMvc.entity.Klass;
import org.springframework.data.domain.Page;
import org.springframework.data.domain.Pageable;

/**
 * 班级
 */

public interface KlassService {

    /**
     * 获取班级信息
     *
     * @return
     */
    Iterable<Klass> getAll();

    /**
     * 分页
     * @return
     */
    Page<Klass> page(Pageable pageable);
    /**
     * 增加
     *
     * @param klass
     * @return
     */
    Klass save(Klass klass);


    /**
     *编辑更新数据
     * @param id
     * @return
     */
    Klass getById(Long id);

    void updateByIdAndklass(Long id, Klass klass);

    /**
     * 删除
     * @param id
     */
    void delete(Long id);

}
