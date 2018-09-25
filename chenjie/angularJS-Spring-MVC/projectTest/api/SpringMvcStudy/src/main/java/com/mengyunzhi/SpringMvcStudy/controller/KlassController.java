package com.mengyunzhi.SpringMvcStudy.controller;

import com.mengyunzhi.SpringMvcStudy.repository.Klass;
import com.mengyunzhi.SpringMvcStudy.repository.KlassRepository;
import com.mengyunzhi.SpringMvcStudy.service.KlassService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.web.bind.annotation.*;

/**
 * @author 某杰
 */
@RestController
@RequestMapping("/Klass")
public class KlassController {
    @Autowired
    KlassRepository klassRepository;

    @Autowired
    KlassService klassService;

    @PostMapping("/")
    @ResponseStatus(HttpStatus.CREATED)
    public Klass save(@RequestBody Klass klass) {
        return klassService.save(klass);
    }

    //新增一个地址为：/Klass的GET方法对应的action
    @GetMapping("/")
    public Iterable<Klass> getAll() {
        return klassService.getAll();
    }

    //使用{id}说明，将/klass/xxx 中的xxx命名为id
    @GetMapping("/{id}")
    public Klass getById(@PathVariable Long id) {
        return klassService.getById(id);
    }

    //定义一个put路由来更新数据
    @PutMapping("/{id}")
    public void update(@PathVariable Long id, @RequestBody Klass klass) {
        klassService.updateByIdAndKlass(id, klass);
    }

    //定义一个delete路由来删除数据
    @DeleteMapping("/{id}")
    @ResponseStatus(HttpStatus.NO_CONTENT)
    public void delete(@PathVariable Long id) {
        klassService.delete(id);
    }

}
