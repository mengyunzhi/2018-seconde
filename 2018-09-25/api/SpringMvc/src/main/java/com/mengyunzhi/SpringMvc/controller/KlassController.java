package com.mengyunzhi.SpringMvc.controller;

import com.mengyunzhi.SpringMvc.entity.Klass;
import com.mengyunzhi.SpringMvc.repository.KlassRepository;
import com.mengyunzhi.SpringMvc.service.KlassService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.data.domain.PageRequest;
import org.springframework.http.HttpStatus;
import org.springframework.web.bind.annotation.*;

/**
 * 班级
 */
@RestController
@RequestMapping("/Klass")
public class KlassController {

    @Autowired
    KlassRepository klassRepository;

    @Autowired
    KlassService klassService; //班级

    //获取所有班级
    @GetMapping("/")
    public Iterable<Klass> getAll() {
        Iterable klasses = klassRepository.findAll();
        return klasses;
    }

    //增加
    @PostMapping("/")
    @ResponseStatus(HttpStatus.CREATED)
    public Klass save(@RequestBody Klass klass){
       return klassService.save(klass);
    }

    //编辑更新数据
    @GetMapping("/{id}")
    public Klass getById(@PathVariable Long id){
        return klassService.getById(id);
    }

    @PutMapping("/{id}")
    public void update(@PathVariable Long id, @RequestBody Klass klass){
        klassService.updateByIdAndklass(id,klass);
    }

    //删除数据
    @DeleteMapping("/{id}")
    @ResponseStatus(HttpStatus.NO_CONTENT)
    public void delete(@PathVariable Long id){
        klassService.delete(id);
    }

    //分页
    //page?page=0&size=1
    @GetMapping("/page")
    public Iterable<Klass> page(@RequestParam int page ,@RequestParam int size){
        PageRequest pageRequest =new PageRequest(page,size);
        return klassService.page(pageRequest);
    }


}
