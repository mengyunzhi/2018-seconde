package com.mengyunzhi.SpringMvcStudy.entity;

import javax.persistence.*;

/**
 *  @author 某杰
 *  班级表
 */
@Entity
public class Klass {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)//主键自增
    private Long id;
    private String name;

    @ManyToOne
    private Teacher teacher;
    public Klass() {

    }

    public Long getId() {
        return id;
    }

    public void setId(Long id) {
        this.id = id;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public Teacher getTeacher() {
        return teacher;
    }

    public void setTeacher(Teacher teacher) {
        this.teacher = teacher;
    }
}
