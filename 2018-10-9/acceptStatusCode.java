package com.mengyunzhi.common.entity.nationalApi;

/**
 * 受理状态代码
 * @author: panjiaqi
 */

public enum acceptStatusCode {
    CHECK_NOT_ADMISSIBLE("未受理",(short)1),
    CHECK_INADMISSIBLE("不予受理", (short)2),
    CHECK_ADMISSIBLE("已受理",(short)3),
    CHECK_REDISTRIBUTION("自动分配后回绝",(short)4);

    private Short id;
    private Short code;     // 代码
    private String name;    // 名称

    acceptStatusCode(String name, Short code) {
        this.name = name;
        this.code = code;

    }

    public Short getId() {
        return id;
    }

    // 设置id的时候，将code同时设置上
    public void setId(Short id) {
        this.id = id;
        this.code = code;
    }

    public Short getCode() {
        return code;
    }

    // 设置code的时候，将id同时设置上
    public void setCode(Short code) {
        this.code = code;
        this.id = code;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }
}
