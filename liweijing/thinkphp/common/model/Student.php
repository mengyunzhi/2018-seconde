<?php
namespace app\common\model;
use think\Model;  //使用前进行声明
/**
 *
 * Student 学生表
 */
class Student extends Model
{
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
    public function Klass()
    {
        return $this->belongsTo('Klass');
    }
    protected $type = [
        'create_time' => 'datetime'
    ];
    protected $dateFormat = 'Y年m月d日';  // 日期格式
}