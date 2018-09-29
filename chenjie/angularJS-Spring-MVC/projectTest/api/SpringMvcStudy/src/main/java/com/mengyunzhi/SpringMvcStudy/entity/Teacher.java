package com.mengyunzhi.SpringMvcStudy.entity;

import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;

/**
 * @author 陈杰 on 2018/09/11
 * 教师表
 */
@Entity
public class Teacher {
    @Id//定义主键
    @GeneratedValue(strategy = GenerationType.IDENTITY)//主键自增
    private Long id;
    private String username;
    private String name;
    private boolean sex;
    private String email;

    //空构造函数
    public Teacher() {
    }

    public Long getId() {
        return id;
    }

    public void setId(Long id) {
        this.id = id;
    }

    public String getUsername() {
        return username;
    }

    public void setUsername(String username) {
        this.username = username;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public boolean isSex() {
        return sex;
    }

    public void setSex(boolean sex) {
        this.sex = sex;
    }

    public String getEmail() {
        return email;
    }

    public void setEmail(String email) {
        this.email = email;
    }
}
