<?php
namespace app\common\model;
use think\Model;
use think\Request;
/**
 *班级
 */
class Klass extends Model
{
    private $Teacher;
    /*
     * 获取对应的辅导员的信息
     * @return Teacher 教师
     */
    public function getTeacher()
    {
        if (is_null($this->Teacher)) {
            $teacherId = $this->getData('teacher_id');
            $this->Teacher = Teacher::get($teacherId);
        }
        return $this->Teacher;
    }   
}