<?php
namespace app\common\model;
use think\Model;    // 使用前进行声明
/**
 * Student 学生表
 */
class Student extends Model
{
    protected $dateFormat = "Y年m月n日";       // 日期格式

    /**
     * 自定义字转换
     * @var array
     */
    protected $type = [
        'create_time' => 'datetime',
    ];

    /**
     * 输出性别的属性
     * @return string 0男，1女
     * @author 梦云智 http://www.mengyunzhi.com
     */
    public function getSexAttr($value)
    {
        $status = array('0'=>'男','1'=>'女');
        $sex = $status[$value];
        if (isset($sex))
        {
            return $sex;
        } else {
            return $status[0];
        }
    }

    public function getCreateTimeAttr($value)
    {
        return date('Y-m-d', $value);
    }

    /**
     * ThinkPhp使用一个叫做_get()的魔法函数来完成这个函数的自动调用
     * @author panjie
     */
    public function Klass()
    {
        return $this->belongsTo('Klass');
    }

    
}