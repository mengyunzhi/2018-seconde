<?php
namespace app\common\model;
use think\Model;
/**
 * 班级
 */
class Course extends Model
{
    private $Course;

    /**
     * 获取对应的课程信息
     * @return Course 课程
     * @author <panjie@yunzhiclub.com> http://www.mengyunzhi.com
     */

    public function Course()
    {
        return $this->belongsTo('Course');
    }

    public function Klasses()
    {
        return $this->belongsToMany('Klass', config('database.prefix') . 'klass_course');
    }
}