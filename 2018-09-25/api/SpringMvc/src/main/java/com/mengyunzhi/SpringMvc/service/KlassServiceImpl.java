package com.mengyunzhi.SpringMvc.service;

import com.mengyunzhi.SpringMvc.entity.Klass;
import com.mengyunzhi.SpringMvc.repository.KlassRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.data.domain.Page;
import org.springframework.data.domain.Pageable;
import org.springframework.stereotype.Service;

@Service
public class KlassServiceImpl implements KlassService {
    @Autowired
     KlassRepository klassRepository; //班级

     /**
     * 获取班级信息
     *
     * @return
     */
    @Override
    public Iterable<Klass> getAll() {
        return klassRepository.findAll();
    }

    /**
     * 分页
     * @return
     */
    @Override
     public Page<Klass> page(Pageable pageable) {
        return klassRepository.findAll(pageable);
    }

    /**
     * 增加
     *
     * @param klass
     * @return
     */
    @Override
    public Klass save(Klass klass) {
        return klassRepository.save(klass);
    }

    /**
     * 编辑更新数据
     * @param id
     * @return
     */
    @Override
    public Klass getById(Long id) {
        return klassRepository.findOne(id);
    }

    @Override
    public void updateByIdAndklass(Long id, Klass newklass) {

        //获取传入的ID对应的实体
        Klass oldklass = klassRepository.findOne(id);

        //更新实体内容
        if (oldklass != null) {
            oldklass.setName(newklass.getName());
            oldklass.setTeacher(newklass.getTeacher());

            //保存到数据表
            klassRepository.save(oldklass);
        }
    }

    /**
     * 删除
     * @param id
     */
    @Override
    public void delete(Long id) {
        klassRepository.delete(id);
    }
}
